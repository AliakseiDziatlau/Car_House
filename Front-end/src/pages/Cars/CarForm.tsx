import { useEffect, useState } from 'react';
import { useNavigate, useParams } from 'react-router-dom';
import { useForm } from 'react-hook-form';
import { zodResolver } from '@hookform/resolvers/zod';
import { z } from 'zod';
import api from '../../services/api';
import type { Brand, Feature, CarDetail, PagedResult, CreateCarFeature } from '../../types';

const carSchema = z.object({
  brandId: z.string().min(1, 'Brand is required'),
  model: z.string().min(1, 'Model is required').max(100, 'Model cannot exceed 100 characters'),
  year: z.number().min(1900, 'Year must be at least 1900').max(new Date().getFullYear() + 1, 'Invalid year'),
  price: z.number().min(0, 'Price must be positive'),
  mileage: z.number().min(0, 'Mileage must be positive'),
  description: z.string().max(2000, 'Description cannot exceed 2000 characters').optional().or(z.literal('')),
  imageUrl: z.string().url('Must be a valid URL').optional().or(z.literal('')),
  isAvailable: z.boolean(),
});

type CarFormData = z.infer<typeof carSchema>;

interface SelectedFeature extends CreateCarFeature {
  name: string;
  category: string;
}

export default function CarForm() {
  const { id } = useParams<{ id: string }>();
  const navigate = useNavigate();
  const isEdit = Boolean(id);

  const [brands, setBrands] = useState<Brand[]>([]);
  const [features, setFeatures] = useState<Feature[]>([]);
  const [selectedFeatures, setSelectedFeatures] = useState<SelectedFeature[]>([]);
  const [loading, setLoading] = useState(true);

  const {
    register,
    handleSubmit,
    reset,
    formState: { errors, isSubmitting },
  } = useForm<CarFormData>({
    resolver: zodResolver(carSchema),
    defaultValues: {
      brandId: '',
      model: '',
      year: new Date().getFullYear(),
      price: 0,
      mileage: 0,
      description: '',
      imageUrl: '',
      isAvailable: true,
    },
  });

  useEffect(() => {
    const loadData = async () => {
      try {
        const [brandsRes, featuresRes] = await Promise.all([
          api.get<PagedResult<Brand>>('/brands', { params: { pageSize: 100 } }),
          api.get<PagedResult<Feature>>('/features', { params: { pageSize: 100 } }),
        ]);
        setBrands(brandsRes.data.items);
        setFeatures(featuresRes.data.items);

        if (isEdit) {
          const carRes = await api.get<CarDetail>(`/cars/${id}`);
          const car = carRes.data;
          reset({
            brandId: car.brandId,
            model: car.model,
            year: car.year,
            price: car.price,
            mileage: car.mileage,
            description: car.description || '',
            imageUrl: car.imageUrl || '',
            isAvailable: car.isAvailable,
          });
          setSelectedFeatures(
            car.features.map((f) => ({
              featureId: f.featureId,
              name: f.featureName,
              category: f.category,
              isStandard: f.isStandard,
              additionalPrice: f.additionalPrice,
            }))
          );
        }
      } catch (err) {
        console.error('Failed to load data', err);
      } finally {
        setLoading(false);
      }
    };
    loadData();
  }, [id, isEdit, reset]);

  const toggleFeature = (feature: Feature) => {
    const existing = selectedFeatures.find((f) => f.featureId === feature.id);
    if (existing) {
      setSelectedFeatures(selectedFeatures.filter((f) => f.featureId !== feature.id));
    } else {
      setSelectedFeatures([
        ...selectedFeatures,
        {
          featureId: feature.id,
          name: feature.name,
          category: feature.category,
          isStandard: true,
          additionalPrice: 0,
        },
      ]);
    }
  };

  const updateFeature = (featureId: string, updates: Partial<SelectedFeature>) => {
    setSelectedFeatures(
      selectedFeatures.map((f) =>
        f.featureId === featureId ? { ...f, ...updates } : f
      )
    );
  };

  const onSubmit = async (data: CarFormData) => {
    try {
      const payload = {
        ...data,
        description: data.description || null,
        imageUrl: data.imageUrl || null,
        features: selectedFeatures.map((f) => ({
          featureId: f.featureId,
          isStandard: f.isStandard,
          additionalPrice: f.additionalPrice,
        })),
      };

      if (isEdit) {
        await api.put(`/cars/${id}`, payload);
      } else {
        await api.post('/cars', payload);
      }
      navigate('/cars');
    } catch {
      alert('Failed to save car');
    }
  };

  const getCategoryColor = (category: string) => {
    const colors: Record<string, string> = {
      Safety: 'bg-red-100 text-red-800 border-red-200',
      Comfort: 'bg-blue-100 text-blue-800 border-blue-200',
      Technology: 'bg-purple-100 text-purple-800 border-purple-200',
      Performance: 'bg-orange-100 text-orange-800 border-orange-200',
    };
    return colors[category] || 'bg-gray-100 text-gray-800 border-gray-200';
  };

  if (loading) return <div className="text-center py-8">Loading...</div>;

  const groupedFeatures = features.reduce((acc, feature) => {
    if (!acc[feature.category]) {
      acc[feature.category] = [];
    }
    acc[feature.category].push(feature);
    return acc;
  }, {} as Record<string, Feature[]>);

  return (
    <div className="max-w-4xl mx-auto">
      <h1 className="text-2xl font-bold mb-6">{isEdit ? 'Edit Car' : 'Add Car'}</h1>

      <form onSubmit={handleSubmit(onSubmit)} className="space-y-6">
        <div className="bg-white rounded-lg shadow p-6">
          <h2 className="text-lg font-semibold mb-4">Basic Information</h2>

          <div className="grid grid-cols-1 md:grid-cols-2 gap-4">
            <div>
              <label htmlFor="brandId" className="block text-sm font-medium text-gray-700 mb-1">
                Brand
              </label>
              <select
                id="brandId"
                {...register('brandId')}
                className="w-full px-3 py-2 border border-gray-300 rounded-md focus:outline-none focus:ring-2 focus:ring-blue-500"
              >
                <option value="">Select a brand</option>
                {brands.map((brand) => (
                  <option key={brand.id} value={brand.id}>
                    {brand.name}
                  </option>
                ))}
              </select>
              {errors.brandId && (
                <p className="mt-1 text-sm text-red-600">{errors.brandId.message}</p>
              )}
            </div>

            <div>
              <label htmlFor="model" className="block text-sm font-medium text-gray-700 mb-1">
                Model
              </label>
              <input
                type="text"
                id="model"
                {...register('model')}
                className="w-full px-3 py-2 border border-gray-300 rounded-md focus:outline-none focus:ring-2 focus:ring-blue-500"
              />
              {errors.model && (
                <p className="mt-1 text-sm text-red-600">{errors.model.message}</p>
              )}
            </div>

            <div>
              <label htmlFor="year" className="block text-sm font-medium text-gray-700 mb-1">
                Year
              </label>
              <input
                type="number"
                id="year"
                {...register('year', { valueAsNumber: true })}
                className="w-full px-3 py-2 border border-gray-300 rounded-md focus:outline-none focus:ring-2 focus:ring-blue-500"
              />
              {errors.year && (
                <p className="mt-1 text-sm text-red-600">{errors.year.message}</p>
              )}
            </div>

            <div>
              <label htmlFor="mileage" className="block text-sm font-medium text-gray-700 mb-1">
                Mileage (km)
              </label>
              <input
                type="number"
                id="mileage"
                {...register('mileage', { valueAsNumber: true })}
                className="w-full px-3 py-2 border border-gray-300 rounded-md focus:outline-none focus:ring-2 focus:ring-blue-500"
              />
              {errors.mileage && (
                <p className="mt-1 text-sm text-red-600">{errors.mileage.message}</p>
              )}
            </div>

            <div>
              <label htmlFor="price" className="block text-sm font-medium text-gray-700 mb-1">
                Price ($)
              </label>
              <input
                type="number"
                id="price"
                {...register('price', { valueAsNumber: true })}
                className="w-full px-3 py-2 border border-gray-300 rounded-md focus:outline-none focus:ring-2 focus:ring-blue-500"
              />
              {errors.price && (
                <p className="mt-1 text-sm text-red-600">{errors.price.message}</p>
              )}
            </div>

            <div>
              <label htmlFor="imageUrl" className="block text-sm font-medium text-gray-700 mb-1">
                Image URL (optional)
              </label>
              <input
                type="text"
                id="imageUrl"
                {...register('imageUrl')}
                className="w-full px-3 py-2 border border-gray-300 rounded-md focus:outline-none focus:ring-2 focus:ring-blue-500"
              />
              {errors.imageUrl && (
                <p className="mt-1 text-sm text-red-600">{errors.imageUrl.message}</p>
              )}
            </div>

            <div className="md:col-span-2">
              <label htmlFor="description" className="block text-sm font-medium text-gray-700 mb-1">
                Description (optional)
              </label>
              <textarea
                id="description"
                rows={3}
                {...register('description')}
                className="w-full px-3 py-2 border border-gray-300 rounded-md focus:outline-none focus:ring-2 focus:ring-blue-500"
              />
              {errors.description && (
                <p className="mt-1 text-sm text-red-600">{errors.description.message}</p>
              )}
            </div>

            <div className="flex items-center">
              <input
                type="checkbox"
                id="isAvailable"
                {...register('isAvailable')}
                className="h-4 w-4 text-blue-600 focus:ring-blue-500 border-gray-300 rounded"
              />
              <label htmlFor="isAvailable" className="ml-2 text-sm text-gray-700">
                Available for sale
              </label>
            </div>
          </div>
        </div>

        <div className="bg-white rounded-lg shadow p-6">
          <h2 className="text-lg font-semibold mb-4">Features</h2>

          {Object.entries(groupedFeatures).map(([category, categoryFeatures]) => (
            <div key={category} className="mb-6 last:mb-0">
              <h3 className={`inline-block px-2 py-1 rounded text-sm font-medium mb-3 ${getCategoryColor(category)}`}>
                {category}
              </h3>
              <div className="grid grid-cols-1 md:grid-cols-2 gap-3">
                {categoryFeatures.map((feature) => {
                  const selected = selectedFeatures.find((f) => f.featureId === feature.id);
                  return (
                    <div
                      key={feature.id}
                      className={`border rounded-lg p-3 cursor-pointer transition ${
                        selected ? 'border-blue-500 bg-blue-50' : 'border-gray-200 hover:border-gray-300'
                      }`}
                      onClick={() => toggleFeature(feature)}
                    >
                      <div className="flex items-center justify-between">
                        <div className="flex items-center">
                          <input
                            type="checkbox"
                            checked={!!selected}
                            onChange={() => toggleFeature(feature)}
                            onClick={(e) => e.stopPropagation()}
                            className="h-4 w-4 text-blue-600 focus:ring-blue-500 border-gray-300 rounded"
                          />
                          <span className="ml-2 font-medium">{feature.name}</span>
                        </div>
                      </div>
                      {selected && (
                        <div className="mt-3 pl-6 space-y-2" onClick={(e) => e.stopPropagation()}>
                          <label className="flex items-center">
                            <input
                              type="checkbox"
                              checked={selected.isStandard}
                              onChange={(e) => updateFeature(feature.id, {
                                isStandard: e.target.checked,
                                additionalPrice: e.target.checked ? 0 : selected.additionalPrice
                              })}
                              className="h-4 w-4 text-blue-600 focus:ring-blue-500 border-gray-300 rounded"
                            />
                            <span className="ml-2 text-sm">Standard (included)</span>
                          </label>
                          {!selected.isStandard && (
                            <div className="flex items-center gap-2">
                              <label className="text-sm text-gray-600">Additional price: $</label>
                              <input
                                type="number"
                                value={selected.additionalPrice}
                                onChange={(e) => updateFeature(feature.id, { additionalPrice: Number(e.target.value) })}
                                className="w-24 px-2 py-1 border border-gray-300 rounded text-sm"
                                min="0"
                              />
                            </div>
                          )}
                        </div>
                      )}
                    </div>
                  );
                })}
              </div>
            </div>
          ))}
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
            onClick={() => navigate('/cars')}
            className="flex-1 bg-gray-200 text-gray-800 py-2 px-4 rounded-md hover:bg-gray-300"
          >
            Cancel
          </button>
        </div>
      </form>
    </div>
  );
}
