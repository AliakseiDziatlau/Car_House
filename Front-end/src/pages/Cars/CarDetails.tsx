import { useEffect, useState } from 'react';
import { useParams, Link } from 'react-router-dom';
import { useTranslation } from 'react-i18next';
import api from '../../services/api';
import { useAuth } from '../../context/AuthContext';
import type { CarDetail } from '../../types';

export default function CarDetails() {
  const { t } = useTranslation();
  const { id } = useParams<{ id: string }>();
  const { hasRole } = useAuth();
  const canManage = hasRole('Manager', 'Admin');
  const [car, setCar] = useState<CarDetail | null>(null);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    const fetchCar = async () => {
      try {
        const response = await api.get<CarDetail>(`/cars/${id}`);
        setCar(response.data);
      } catch {
        setError(t('cars.loadDetailError'));
      } finally {
        setLoading(false);
      }
    };
    fetchCar();
  }, [id, t]);

  const getCategoryColor = (category: string) => {
    const colors: Record<string, string> = {
      Safety: 'bg-red-100 text-red-800',
      Comfort: 'bg-blue-100 text-blue-800',
      Technology: 'bg-purple-100 text-purple-800',
      Performance: 'bg-amber-100 text-amber-800',
    };
    return colors[category] || 'bg-gray-100 text-gray-800';
  };

  const getCategoryLabel = (category: string) => {
    const key = category.toLowerCase() as 'safety' | 'comfort' | 'technology' | 'performance';
    return t(`features.categories.${key}`);
  };

  if (loading) return <div className="text-center py-8 text-gray-400">{t('common.loading')}</div>;
  if (error) return <div className="text-center py-8 text-red-400">{error}</div>;
  if (!car) return <div className="text-center py-8 text-gray-400">{t('cars.notFound')}</div>;

  const totalFeaturePrice = car.features
    .filter((f) => !f.isStandard)
    .reduce((sum, f) => sum + f.additionalPrice, 0);

  return (
    <div>
      <div className="flex justify-between items-center mb-6">
        <h1 className="text-2xl font-bold text-white">{car.brand.name} {car.model}</h1>
        <div className="flex gap-2">
          {canManage && (
            <Link
              to={`/cars/${id}/edit`}
              className="inline-flex items-center justify-center h-9 px-4 bg-orange-500 text-white text-sm font-medium rounded-md shadow-sm transition-all duration-150 outline-none hover:bg-orange-600 focus-visible:ring-2 focus-visible:ring-orange-500/50"
            >
              {t('common.edit')}
            </Link>
          )}
          <Link
            to="/cars"
            className="inline-flex items-center justify-center h-9 px-4 border border-gray-600 bg-gray-800/50 text-white text-sm font-medium rounded-md shadow-sm transition-all duration-150 outline-none hover:bg-gray-700 hover:border-gray-500 focus-visible:ring-2 focus-visible:ring-orange-500/50"
          >
            {t('cars.backToList')}
          </Link>
        </div>
      </div>

      <div className="grid grid-cols-1 lg:grid-cols-2 gap-6">
        <div>
          {car.imageUrl ? (
            <img
              src={car.imageUrl}
              alt={car.model}
              className="w-full h-80 object-cover rounded-lg shadow"
            />
          ) : (
            <div className="w-full h-80 bg-gray-700 rounded-lg shadow flex items-center justify-center">
              <span className="text-gray-500 text-lg">{t('cars.noImageAvailable')}</span>
            </div>
          )}
        </div>

        <div className="bg-gray-800 rounded-lg shadow p-6">
          <div className="flex justify-between items-start mb-4">
            <div>
              <h2 className="text-2xl font-bold text-white">{car.model}</h2>
              <Link to={`/brands/${car.brandId}`} className="text-orange-500 hover:underline">
                {car.brand.name}
              </Link>
            </div>
            <span
              className={`px-3 py-1 rounded text-sm font-medium ${
                car.isAvailable
                  ? 'bg-green-100 text-green-800'
                  : 'bg-red-100 text-red-800'
              }`}
            >
              {car.isAvailable ? t('common.available') : t('common.sold')}
            </span>
          </div>

          <div className="grid grid-cols-2 gap-4 mb-6">
            <div>
              <p className="text-sm text-gray-400">{t('common.year')}</p>
              <p className="font-medium text-white">{car.year}</p>
            </div>
            <div>
              <p className="text-sm text-gray-400">{t('cars.mileage')}</p>
              <p className="font-medium text-white">{car.mileage.toLocaleString()} {t('cars.km')}</p>
            </div>
            <div>
              <p className="text-sm text-gray-400">{t('cars.basePrice')}</p>
              <p className="font-medium text-white">${car.price.toLocaleString()}</p>
            </div>
            <div>
              <p className="text-sm text-gray-400">{t('cars.totalPrice')}</p>
              <p className="font-bold text-orange-500 text-lg">
                ${(car.price + totalFeaturePrice).toLocaleString()}
              </p>
            </div>
          </div>

          {car.description && (
            <div className="mb-6">
              <p className="text-sm text-gray-400 mb-1">{t('common.description')}</p>
              <p className="text-gray-300">{car.description}</p>
            </div>
          )}
        </div>
      </div>

      <div className="mt-6 bg-gray-800 rounded-lg shadow p-6">
        <h3 className="text-xl font-semibold mb-4 text-white">{t('cars.featuresTitle')}</h3>
        {car.features.length === 0 ? (
          <p className="text-gray-400">{t('cars.noFeatures')}</p>
        ) : (
          <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-4">
            {car.features.map((feature) => (
              <div
                key={feature.featureId}
                className="border border-gray-700 rounded-lg p-4 flex justify-between items-start bg-gray-900"
              >
                <div>
                  <p className="font-medium text-white">{feature.featureName}</p>
                  <span className={`inline-block mt-1 px-2 py-0.5 rounded text-xs ${getCategoryColor(feature.category)}`}>
                    {getCategoryLabel(feature.category)}
                  </span>
                </div>
                <div className="text-right">
                  {feature.isStandard ? (
                    <span className="text-green-400 text-sm font-medium">{t('cars.included')}</span>
                  ) : (
                    <span className="text-orange-500 font-medium">
                      +${feature.additionalPrice.toLocaleString()}
                    </span>
                  )}
                </div>
              </div>
            ))}
          </div>
        )}
      </div>
    </div>
  );
}
