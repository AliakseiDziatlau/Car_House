import { useEffect } from 'react';
import { useNavigate, useParams } from 'react-router-dom';
import { useForm } from 'react-hook-form';
import { zodResolver } from '@hookform/resolvers/zod';
import { z } from 'zod';
import { useTranslation } from 'react-i18next';
import api from '../../services/api';
import type { Feature } from '../../types';

const featureSchema = z.object({
  name: z.string().min(1, 'Name is required').max(100, 'Name cannot exceed 100 characters'),
  category: z.string().min(1, 'Category is required'),
  description: z.string().max(500, 'Description cannot exceed 500 characters').optional().or(z.literal('')),
});

type FeatureFormData = z.infer<typeof featureSchema>;

const categories = ['Safety', 'Comfort', 'Technology', 'Performance'];

export default function FeatureForm() {
  const { t } = useTranslation();
  const { id } = useParams<{ id: string }>();
  const navigate = useNavigate();
  const isEdit = Boolean(id);

  const {
    register,
    handleSubmit,
    reset,
    formState: { errors, isSubmitting },
  } = useForm<FeatureFormData>({
    resolver: zodResolver(featureSchema),
    defaultValues: {
      name: '',
      category: '',
      description: '',
    },
  });

  useEffect(() => {
    if (isEdit) {
      api.get<Feature>(`/features/${id}`).then((response) => {
        reset({
          name: response.data.name,
          category: response.data.category,
          description: response.data.description || '',
        });
      });
    }
  }, [id, isEdit, reset]);

  const onSubmit = async (data: FeatureFormData) => {
    try {
      const payload = {
        ...data,
        description: data.description || null,
      };

      if (isEdit) {
        await api.put(`/features/${id}`, payload);
      } else {
        await api.post('/features', payload);
      }
      navigate('/features');
    } catch {
      alert(t('features.saveError'));
    }
  };

  const getCategoryLabel = (category: string) => {
    const key = category.toLowerCase() as 'safety' | 'comfort' | 'technology' | 'performance';
    return t(`features.categories.${key}`);
  };

  return (
    <div className="max-w-lg mx-auto">
      <h1 className="text-2xl font-bold mb-6 text-white">
        {isEdit ? t('features.editFeature') : t('features.addFeature')}
      </h1>

      <form onSubmit={handleSubmit(onSubmit)} className="bg-gray-800 rounded-lg shadow p-6">
        <div className="mb-4">
          <label htmlFor="name" className="block text-sm font-medium text-gray-300 mb-1">
            {t('common.name')}
          </label>
          <input
            type="text"
            id="name"
            {...register('name')}
            className="w-full h-10 px-3 py-2 border border-gray-600 bg-gray-700/50 text-white rounded-md shadow-sm transition-all duration-150 outline-none focus:border-orange-500 focus:ring-2 focus:ring-orange-500/30 placeholder:text-gray-500"
          />
          {errors.name && (
            <p className="mt-1 text-sm text-red-400">{errors.name.message}</p>
          )}
        </div>

        <div className="mb-4">
          <label htmlFor="category" className="block text-sm font-medium text-gray-300 mb-1">
            {t('common.category')}
          </label>
          <select
            id="category"
            {...register('category')}
            className="w-full h-10 px-3 py-2 border border-gray-600 bg-gray-700/50 text-white rounded-md shadow-sm transition-all duration-150 outline-none focus:border-orange-500 focus:ring-2 focus:ring-orange-500/30"
          >
            <option value="">{t('features.selectCategory')}</option>
            {categories.map((cat) => (
              <option key={cat} value={cat}>
                {getCategoryLabel(cat)}
              </option>
            ))}
          </select>
          {errors.category && (
            <p className="mt-1 text-sm text-red-400">{errors.category.message}</p>
          )}
        </div>

        <div className="mb-6">
          <label htmlFor="description" className="block text-sm font-medium text-gray-300 mb-1">
            {t('features.descriptionOptional')}
          </label>
          <textarea
            id="description"
            rows={3}
            {...register('description')}
            className="w-full px-3 py-2 border border-gray-600 bg-gray-700/50 text-white rounded-md shadow-sm transition-all duration-150 outline-none focus:border-orange-500 focus:ring-2 focus:ring-orange-500/30 placeholder:text-gray-500"
          />
          {errors.description && (
            <p className="mt-1 text-sm text-red-400">{errors.description.message}</p>
          )}
        </div>

        <div className="flex gap-3">
          <button
            type="submit"
            disabled={isSubmitting}
            className="flex-1 h-10 bg-orange-500 text-white font-medium rounded-md shadow-sm transition-all duration-150 outline-none hover:bg-orange-600 focus-visible:ring-2 focus-visible:ring-orange-500/50 disabled:opacity-50 disabled:pointer-events-none"
          >
            {isSubmitting ? t('common.saving') : t('common.save')}
          </button>
          <button
            type="button"
            onClick={() => navigate('/features')}
            className="flex-1 h-10 border border-gray-600 bg-gray-800/50 text-white font-medium rounded-md shadow-sm transition-all duration-150 outline-none hover:bg-gray-700 hover:border-gray-500 focus-visible:ring-2 focus-visible:ring-orange-500/50"
          >
            {t('common.cancel')}
          </button>
        </div>
      </form>
    </div>
  );
}
