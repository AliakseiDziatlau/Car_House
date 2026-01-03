import { useEffect } from 'react';
import { useNavigate, useParams } from 'react-router-dom';
import { useForm } from 'react-hook-form';
import { zodResolver } from '@hookform/resolvers/zod';
import { z } from 'zod';
import { useTranslation } from 'react-i18next';
import api from '../../services/api';
import type { Brand } from '../../types';

const brandSchema = z.object({
  name: z.string().min(1, 'Name is required').max(100, 'Name cannot exceed 100 characters'),
  country: z.string().min(1, 'Country is required').max(100, 'Country cannot exceed 100 characters'),
  logoUrl: z.string().url('Must be a valid URL').optional().or(z.literal('')),
});

type BrandFormData = z.infer<typeof brandSchema>;

export default function BrandForm() {
  const { t } = useTranslation();
  const { id } = useParams<{ id: string }>();
  const navigate = useNavigate();
  const isEdit = Boolean(id);

  const {
    register,
    handleSubmit,
    reset,
    formState: { errors, isSubmitting },
  } = useForm<BrandFormData>({
    resolver: zodResolver(brandSchema),
    defaultValues: {
      name: '',
      country: '',
      logoUrl: '',
    },
  });

  useEffect(() => {
    if (isEdit) {
      api.get<Brand>(`/brands/${id}`).then((response) => {
        reset({
          name: response.data.name,
          country: response.data.country,
          logoUrl: response.data.logoUrl || '',
        });
      });
    }
  }, [id, isEdit, reset]);

  const onSubmit = async (data: BrandFormData) => {
    try {
      const payload = {
        ...data,
        logoUrl: data.logoUrl || null,
      };

      if (isEdit) {
        await api.put(`/brands/${id}`, payload);
      } else {
        await api.post('/brands', payload);
      }
      navigate('/brands');
    } catch {
      alert(t('brands.saveError'));
    }
  };

  return (
    <div className="max-w-lg mx-auto">
      <h1 className="text-2xl font-bold mb-6 text-white">
        {isEdit ? t('brands.editBrand') : t('brands.addBrand')}
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
          <label htmlFor="country" className="block text-sm font-medium text-gray-300 mb-1">
            {t('brands.country')}
          </label>
          <input
            type="text"
            id="country"
            {...register('country')}
            className="w-full h-10 px-3 py-2 border border-gray-600 bg-gray-700/50 text-white rounded-md shadow-sm transition-all duration-150 outline-none focus:border-orange-500 focus:ring-2 focus:ring-orange-500/30 placeholder:text-gray-500"
          />
          {errors.country && (
            <p className="mt-1 text-sm text-red-400">{errors.country.message}</p>
          )}
        </div>

        <div className="mb-6">
          <label htmlFor="logoUrl" className="block text-sm font-medium text-gray-300 mb-1">
            {t('brands.logoUrl')}
          </label>
          <input
            type="text"
            id="logoUrl"
            {...register('logoUrl')}
            className="w-full h-10 px-3 py-2 border border-gray-600 bg-gray-700/50 text-white rounded-md shadow-sm transition-all duration-150 outline-none focus:border-orange-500 focus:ring-2 focus:ring-orange-500/30 placeholder:text-gray-500"
          />
          {errors.logoUrl && (
            <p className="mt-1 text-sm text-red-400">{errors.logoUrl.message}</p>
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
            onClick={() => navigate('/brands')}
            className="flex-1 h-10 border border-gray-600 bg-gray-800/50 text-white font-medium rounded-md shadow-sm transition-all duration-150 outline-none hover:bg-gray-700 hover:border-gray-500 focus-visible:ring-2 focus-visible:ring-orange-500/50"
          >
            {t('common.cancel')}
          </button>
        </div>
      </form>
    </div>
  );
}
