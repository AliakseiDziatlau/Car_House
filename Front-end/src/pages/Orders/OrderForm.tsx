import { useEffect, useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { useForm } from 'react-hook-form';
import { zodResolver } from '@hookform/resolvers/zod';
import { z } from 'zod';
import { useTranslation } from 'react-i18next';
import api from '../../services/api';
import type { CarListItem, PagedResult } from '../../types';

const orderSchema = z.object({
  carId: z.string().min(1, 'Please select a car'),
  notes: z.string().max(1000, 'Notes cannot exceed 1000 characters').optional(),
});

type OrderFormData = z.infer<typeof orderSchema>;

export default function OrderForm() {
  const { t } = useTranslation();
  const navigate = useNavigate();
  const [cars, setCars] = useState<CarListItem[]>([]);
  const [selectedCar, setSelectedCar] = useState<CarListItem | null>(null);
  const [loadingCars, setLoadingCars] = useState(true);

  const {
    register,
    handleSubmit,
    watch,
    formState: { errors, isSubmitting },
  } = useForm<OrderFormData>({
    resolver: zodResolver(orderSchema),
    defaultValues: {
      carId: '',
      notes: '',
    },
  });

  const watchedCarId = watch('carId');

  useEffect(() => {
    const fetchCars = async () => {
      try {
        const response = await api.get<PagedResult<CarListItem>>('/cars', {
          params: { pageSize: 100 },
        });
        const availableCars = response.data.items.filter((car) => car.isAvailable);
        setCars(availableCars);
      } catch {
        console.error('Failed to load cars');
      } finally {
        setLoadingCars(false);
      }
    };
    fetchCars();
  }, []);

  useEffect(() => {
    if (watchedCarId) {
      const car = cars.find((c) => c.id === watchedCarId);
      setSelectedCar(car || null);
    } else {
      setSelectedCar(null);
    }
  }, [watchedCarId, cars]);

  const onSubmit = async (data: OrderFormData) => {
    try {
      const payload = {
        carId: data.carId,
        notes: data.notes || null,
      };
      await api.post('/orders', payload);
      navigate('/orders');
    } catch {
      alert(t('orders.placeError'));
    }
  };

  return (
    <div className="max-w-lg mx-auto">
      <h1 className="text-2xl font-bold mb-6 text-white">{t('orders.placeOrder')}</h1>

      <form onSubmit={handleSubmit(onSubmit)} className="bg-gray-800 rounded-lg shadow p-6">
        <div className="mb-4">
          <label htmlFor="carId" className="block text-sm font-medium text-gray-300 mb-1">
            {t('orders.selectCar')}
          </label>
          {loadingCars ? (
            <p className="text-gray-400">{t('orders.loadingCars')}</p>
          ) : cars.length === 0 ? (
            <p className="text-gray-400">{t('orders.noCarsAvailable')}</p>
          ) : (
            <select
              id="carId"
              {...register('carId')}
              className="w-full h-10 px-3 py-2 border border-gray-600 bg-gray-700/50 text-white rounded-md shadow-sm transition-all duration-150 outline-none focus:border-orange-500 focus:ring-2 focus:ring-orange-500/30"
            >
              <option value="">{t('orders.selectCarPlaceholder')}</option>
              {cars.map((car) => (
                <option key={car.id} value={car.id}>
                  {car.brandName} {car.model} ({car.year}) - ${car.price.toLocaleString()}
                </option>
              ))}
            </select>
          )}
          {errors.carId && (
            <p className="mt-1 text-sm text-red-400">{errors.carId.message}</p>
          )}
        </div>

        {selectedCar && (
          <div className="mb-4 p-4 bg-gray-900 rounded-lg">
            <h3 className="font-medium mb-2 text-white">{t('orders.selectedCar')}</h3>
            <div className="flex gap-4">
              {selectedCar.imageUrl ? (
                <img
                  src={selectedCar.imageUrl}
                  alt={selectedCar.model}
                  className="w-24 h-18 object-cover rounded"
                />
              ) : (
                <div className="w-24 h-18 bg-gray-700 rounded flex items-center justify-center">
                  <span className="text-gray-500 text-xs">{t('common.noImage')}</span>
                </div>
              )}
              <div>
                <p className="font-semibold text-white">{selectedCar.brandName} {selectedCar.model}</p>
                <p className="text-gray-400">{t('common.year')}: {selectedCar.year}</p>
                <p className="text-orange-500 font-bold">${selectedCar.price.toLocaleString()}</p>
              </div>
            </div>
          </div>
        )}

        <div className="mb-6">
          <label htmlFor="notes" className="block text-sm font-medium text-gray-300 mb-1">
            {t('orders.notesOptional')}
          </label>
          <textarea
            id="notes"
            rows={4}
            {...register('notes')}
            placeholder={t('orders.notesPlaceholder')}
            className="w-full px-3 py-2 border border-gray-600 bg-gray-700/50 text-white rounded-md shadow-sm transition-all duration-150 outline-none focus:border-orange-500 focus:ring-2 focus:ring-orange-500/30 placeholder:text-gray-500"
          />
          {errors.notes && (
            <p className="mt-1 text-sm text-red-400">{errors.notes.message}</p>
          )}
        </div>

        <div className="flex gap-3">
          <button
            type="submit"
            disabled={isSubmitting || cars.length === 0}
            className="flex-1 h-10 bg-orange-500 text-white font-medium rounded-md shadow-sm transition-all duration-150 outline-none hover:bg-orange-600 focus-visible:ring-2 focus-visible:ring-orange-500/50 disabled:opacity-50 disabled:pointer-events-none"
          >
            {isSubmitting ? t('orders.placingOrder') : t('orders.placeOrder')}
          </button>
          <button
            type="button"
            onClick={() => navigate('/orders')}
            className="flex-1 h-10 border border-gray-600 bg-gray-800/50 text-white font-medium rounded-md shadow-sm transition-all duration-150 outline-none hover:bg-gray-700 hover:border-gray-500 focus-visible:ring-2 focus-visible:ring-orange-500/50"
          >
            {t('common.cancel')}
          </button>
        </div>
      </form>
    </div>
  );
}
