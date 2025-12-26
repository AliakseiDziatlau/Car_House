import { useEffect } from 'react';
import { useNavigate, useParams } from 'react-router-dom';
import { useForm } from 'react-hook-form';
import { zodResolver } from '@hookform/resolvers/zod';
import { z } from 'zod';
import api from '../../services/api';
import type { Brand } from '../../types';

const brandSchema = z.object({
  name: z.string().min(1, 'Name is required').max(100, 'Name cannot exceed 100 characters'),
  country: z.string().min(1, 'Country is required').max(100, 'Country cannot exceed 100 characters'),
  logoUrl: z.string().url('Must be a valid URL').optional().or(z.literal('')),
});

type BrandFormData = z.infer<typeof brandSchema>;

export default function BrandForm() {
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
      alert('Failed to save brand');
    }
  };

  return (
    <div className="max-w-lg mx-auto">
      <h1 className="text-2xl font-bold mb-6">{isEdit ? 'Edit Brand' : 'Add Brand'}</h1>

      <form onSubmit={handleSubmit(onSubmit)} className="bg-white rounded-lg shadow p-6">
        <div className="mb-4">
          <label htmlFor="name" className="block text-sm font-medium text-gray-700 mb-1">
            Name
          </label>
          <input
            type="text"
            id="name"
            {...register('name')}
            className="w-full px-3 py-2 border border-gray-300 rounded-md focus:outline-none focus:ring-2 focus:ring-blue-500"
          />
          {errors.name && (
            <p className="mt-1 text-sm text-red-600">{errors.name.message}</p>
          )}
        </div>

        <div className="mb-4">
          <label htmlFor="country" className="block text-sm font-medium text-gray-700 mb-1">
            Country
          </label>
          <input
            type="text"
            id="country"
            {...register('country')}
            className="w-full px-3 py-2 border border-gray-300 rounded-md focus:outline-none focus:ring-2 focus:ring-blue-500"
          />
          {errors.country && (
            <p className="mt-1 text-sm text-red-600">{errors.country.message}</p>
          )}
        </div>

        <div className="mb-6">
          <label htmlFor="logoUrl" className="block text-sm font-medium text-gray-700 mb-1">
            Logo URL (optional)
          </label>
          <input
            type="text"
            id="logoUrl"
            {...register('logoUrl')}
            className="w-full px-3 py-2 border border-gray-300 rounded-md focus:outline-none focus:ring-2 focus:ring-blue-500"
          />
          {errors.logoUrl && (
            <p className="mt-1 text-sm text-red-600">{errors.logoUrl.message}</p>
          )}
        </div>

        <div className="flex gap-4">
          <button
            type="submit"
            disabled={isSubmitting}
            className="flex-1 bg-blue-600 text-white py-2 px-4 rounded-md hover:bg-blue-700 disabled:opacity-50"
          >
            {isSubmitting ? 'Saving...' : 'Save'}
          </button>
          <button
            type="button"
            onClick={() => navigate('/brands')}
            className="flex-1 bg-gray-200 text-gray-800 py-2 px-4 rounded-md hover:bg-gray-300"
          >
            Cancel
          </button>
        </div>
      </form>
    </div>
  );
}
