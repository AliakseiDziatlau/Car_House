import { useEffect, useState } from 'react';
import { useParams, Link } from 'react-router-dom';
import { useTranslation } from 'react-i18next';
import api from '../../services/api';
import { useAuth } from '../../context/AuthContext';
import type { Feature } from '../../types';

export default function FeatureDetails() {
  const { t } = useTranslation();
  const { id } = useParams<{ id: string }>();
  const { hasRole } = useAuth();
  const canManage = hasRole('Manager', 'Admin');
  const [feature, setFeature] = useState<Feature | null>(null);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    const fetchFeature = async () => {
      try {
        const response = await api.get<Feature>(`/features/${id}`);
        setFeature(response.data);
      } catch {
        setError(t('features.loadDetailError'));
      } finally {
        setLoading(false);
      }
    };
    fetchFeature();
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
  if (!feature) return <div className="text-center py-8 text-gray-400">{t('features.notFound')}</div>;

  return (
    <div>
      <div className="flex justify-between items-center mb-6">
        <h1 className="text-2xl font-bold text-white">{feature.name}</h1>
        <div className="flex gap-2">
          {canManage && (
            <Link
              to={`/features/${id}/edit`}
              className="inline-flex items-center justify-center h-9 px-4 bg-orange-500 text-white text-sm font-medium rounded-md shadow-sm transition-all duration-150 outline-none hover:bg-orange-600 focus-visible:ring-2 focus-visible:ring-orange-500/50"
            >
              {t('common.edit')}
            </Link>
          )}
          <Link
            to="/features"
            className="inline-flex items-center justify-center h-9 px-4 border border-gray-600 bg-gray-800/50 text-white text-sm font-medium rounded-md shadow-sm transition-all duration-150 outline-none hover:bg-gray-700 hover:border-gray-500 focus-visible:ring-2 focus-visible:ring-orange-500/50"
          >
            {t('features.backToList')}
          </Link>
        </div>
      </div>

      <div className="bg-gray-800 rounded-lg shadow p-6">
        <div className="grid grid-cols-1 md:grid-cols-2 gap-6">
          <div>
            <h3 className="text-sm font-medium text-gray-400 mb-1">{t('common.name')}</h3>
            <p className="text-lg text-white">{feature.name}</p>
          </div>
          <div>
            <h3 className="text-sm font-medium text-gray-400 mb-1">{t('common.category')}</h3>
            <span className={`px-3 py-1 rounded text-sm font-medium ${getCategoryColor(feature.category)}`}>
              {getCategoryLabel(feature.category)}
            </span>
          </div>
          <div className="md:col-span-2">
            <h3 className="text-sm font-medium text-gray-400 mb-1">{t('common.description')}</h3>
            <p className="text-gray-300">{feature.description || t('features.noDescription')}</p>
          </div>
        </div>
      </div>
    </div>
  );
}
