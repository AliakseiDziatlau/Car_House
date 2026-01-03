import { useEffect, useState } from 'react';
import { useParams, Link } from 'react-router-dom';
import { useTranslation } from 'react-i18next';
import api from '../../services/api';
import { useAuth } from '../../context/AuthContext';
import type { BrandDetail } from '../../types';

export default function BrandDetails() {
  const { t } = useTranslation();
  const { id } = useParams<{ id: string }>();
  const { hasRole } = useAuth();
  const canManage = hasRole('Manager', 'Admin');
  const [brand, setBrand] = useState<BrandDetail | null>(null);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    const fetchBrand = async () => {
      try {
        const response = await api.get<BrandDetail>(`/brands/${id}`);
        setBrand(response.data);
      } catch {
        setError(t('brands.loadDetailError'));
      } finally {
        setLoading(false);
      }
    };
    fetchBrand();
  }, [id, t]);

  if (loading) return <div className="text-center py-8 text-gray-400">{t('common.loading')}</div>;
  if (error) return <div className="text-center py-8 text-red-400">{error}</div>;
  if (!brand) return <div className="text-center py-8 text-gray-400">{t('brands.notFound')}</div>;

  return (
    <div>
      <div className="flex justify-between items-center mb-6">
        <h1 className="text-2xl font-bold text-white">{brand.name}</h1>
        <div className="flex gap-2">
          {canManage && (
            <Link
              to={`/brands/${id}/edit`}
              className="inline-flex items-center justify-center h-9 px-4 bg-orange-500 text-white text-sm font-medium rounded-md shadow-sm transition-all duration-150 outline-none hover:bg-orange-600 focus-visible:ring-2 focus-visible:ring-orange-500/50"
            >
              {t('common.edit')}
            </Link>
          )}
          <Link
            to="/brands"
            className="inline-flex items-center justify-center h-9 px-4 border border-gray-600 bg-gray-800/50 text-white text-sm font-medium rounded-md shadow-sm transition-all duration-150 outline-none hover:bg-gray-700 hover:border-gray-500 focus-visible:ring-2 focus-visible:ring-orange-500/50"
          >
            {t('brands.backToList')}
          </Link>
        </div>
      </div>

      <div className="bg-gray-800 rounded-lg shadow p-6 mb-6">
        <div className="flex items-start gap-6">
          {brand.logoUrl ? (
            <img
              src={brand.logoUrl}
              alt={brand.name}
              className="h-24 w-24 object-contain"
            />
          ) : (
            <div className="h-24 w-24 bg-gray-700 rounded flex items-center justify-center">
              <span className="text-gray-500">{t('brands.noLogo')}</span>
            </div>
          )}
          <div>
            <h2 className="text-xl font-semibold mb-2 text-white">{brand.name}</h2>
            <p className="text-gray-400">{t('brands.country')}: {brand.country}</p>
          </div>
        </div>
      </div>

      <h2 className="text-xl font-semibold mb-4 text-white">{t('brands.carsFrom', { name: brand.name })}</h2>
      {brand.cars.length === 0 ? (
        <p className="text-gray-400">{t('brands.noCars')}</p>
      ) : (
        <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-4">
          {brand.cars.map((car) => (
            <Link
              key={car.id}
              to={`/cars/${car.id}`}
              className="bg-gray-800 rounded-lg shadow p-4 hover:bg-gray-700 transition"
            >
              {car.imageUrl ? (
                <img
                  src={car.imageUrl}
                  alt={car.model}
                  className="h-40 w-full object-cover rounded mb-3"
                />
              ) : (
                <div className="h-40 bg-gray-700 rounded mb-3 flex items-center justify-center">
                  <span className="text-gray-500">{t('common.noImage')}</span>
                </div>
              )}
              <h3 className="font-semibold text-white">{car.model}</h3>
              <p className="text-gray-400">{car.year}</p>
              <p className="text-orange-500 font-bold">${car.price.toLocaleString()}</p>
              <span
                className={`inline-block mt-2 px-2 py-1 rounded text-xs ${
                  car.isAvailable
                    ? 'bg-green-100 text-green-800'
                    : 'bg-red-100 text-red-800'
                }`}
              >
                {car.isAvailable ? t('common.available') : t('common.sold')}
              </span>
            </Link>
          ))}
        </div>
      )}
    </div>
  );
}
