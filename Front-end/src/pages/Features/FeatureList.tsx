import { useEffect, useState, useMemo } from 'react';
import { Link } from 'react-router-dom';
import { useTranslation } from 'react-i18next';
import { ChevronLeft, ChevronRight } from 'lucide-react';
import api from '../../services/api';
import { useAuth } from '../../context/AuthContext';
import Pagination from '../../components/Pagination';
import FeatureFilters from '../../components/FeatureFilters';
import type { Feature, PagedResult } from '../../types';

const CATEGORIES = ['Safety', 'Comfort', 'Technology', 'Performance'];
const FILTERS_COLLAPSED_KEY = 'feature-filters-collapsed';
const FILTERS_CATEGORIES_KEY = 'feature-filters-categories';

export default function FeatureList() {
  const { t } = useTranslation();
  const { hasRole } = useAuth();
  const canManage = hasRole('Manager', 'Admin');
  const [features, setFeatures] = useState<Feature[]>([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);
  const [page, setPage] = useState(1);
  const [totalPages, setTotalPages] = useState(1);
  const [selectedCategories, setSelectedCategories] = useState<string[]>(() => {
    const saved = localStorage.getItem(FILTERS_CATEGORIES_KEY);
    return saved ? JSON.parse(saved) : [];
  });
  const [filtersCollapsed, setFiltersCollapsed] = useState(() => {
    return localStorage.getItem(FILTERS_COLLAPSED_KEY) === 'true';
  });

  useEffect(() => {
    fetchFeatures();
  }, [page, selectedCategories]);

  useEffect(() => {
    localStorage.setItem(FILTERS_COLLAPSED_KEY, filtersCollapsed ? 'true' : '');
  }, [filtersCollapsed]);

  useEffect(() => {
    localStorage.setItem(FILTERS_CATEGORIES_KEY, JSON.stringify(selectedCategories));
  }, [selectedCategories]);

  const fetchFeatures = async () => {
    try {
      setLoading(true);
      const params: Record<string, string | number | string[]> = { page, pageSize: 10 };
      if (selectedCategories.length > 0) {
        params.categories = selectedCategories;
      }
      const response = await api.get<PagedResult<Feature>>('/features', { params });
      setFeatures(response.data.items);
      setTotalPages(response.data.totalPages);
    } catch {
      setError(t('features.loadError'));
    } finally {
      setLoading(false);
    }
  };

  const categoryOptions = useMemo(() => {
    return CATEGORIES.map((category) => ({
      value: category,
      label: t(`features.categories.${category.toLowerCase()}`),
    }));
  }, [t]);

  const handleCategoriesChange = (categories: string[]) => {
    setSelectedCategories(categories);
    setPage(1);
  };

  const handleClearFilters = () => {
    setSelectedCategories([]);
    setPage(1);
    localStorage.removeItem(FILTERS_CATEGORIES_KEY);
  };

  const handleDelete = async (id: string) => {
    if (!confirm(t('features.deleteConfirm'))) return;
    try {
      await api.delete(`/features/${id}`);
      fetchFeatures();
    } catch {
      setError(t('features.deleteError'));
    }
  };

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

  if (loading && features.length === 0) return <div className="text-center py-8 text-gray-400">{t('common.loading')}</div>;
  if (error) return <div className="text-center py-8 text-red-400">{error}</div>;

  return (
    <div>
      <div className="flex justify-between items-center mb-6">
        <h1 className="text-2xl font-bold text-white">{t('features.title')}</h1>
        {canManage && (
          <Link
            to="/features/new"
            className="inline-flex items-center justify-center h-9 px-4 bg-orange-500 text-white text-sm font-medium rounded-md shadow-sm transition-all duration-150 outline-none hover:bg-orange-600 focus-visible:ring-2 focus-visible:ring-orange-500/50"
          >
            {t('features.addFeature')}
          </Link>
        )}
      </div>

      <div className="flex gap-6">
        <div
          className={`transition-[width] duration-200 ease-linear overflow-hidden shrink-0 ${
            filtersCollapsed ? 'w-0' : 'w-64'
          }`}
        >
          <div className="min-w-[256px]">
            <FeatureFilters
              categories={categoryOptions}
              selectedCategories={selectedCategories}
              onCategoriesChange={handleCategoriesChange}
              onClearFilters={handleClearFilters}
            />
          </div>
        </div>

        <div className="relative flex-1 min-w-0">
          <button
            onClick={() => setFiltersCollapsed(!filtersCollapsed)}
            className="absolute -left-3 top-0 z-10 h-6 w-6 rounded-full border border-gray-600 bg-gray-800 shadow-sm hover:bg-gray-700 flex items-center justify-center transition-colors"
            aria-label={filtersCollapsed ? t('filters.show') : t('filters.hide')}
            title={filtersCollapsed ? t('filters.show') : t('filters.hide')}
          >
            {filtersCollapsed ? (
              <ChevronRight className="h-3 w-3 text-gray-400" />
            ) : (
              <ChevronLeft className="h-3 w-3 text-gray-400" />
            )}
          </button>

          <div className="bg-gray-800 rounded-lg shadow overflow-hidden">
            <table className="min-w-full divide-y divide-gray-700">
              <thead className="bg-gray-900">
                <tr>
                  <th className="px-6 py-3 text-left text-xs font-medium text-gray-400 uppercase tracking-wider">
                    {t('common.name')}
                  </th>
                  <th className="px-6 py-3 text-left text-xs font-medium text-gray-400 uppercase tracking-wider">
                    {t('common.category')}
                  </th>
                  <th className="px-6 py-3 text-left text-xs font-medium text-gray-400 uppercase tracking-wider">
                    {t('common.description')}
                  </th>
                  {canManage && (
                    <th className="px-6 py-3 text-right text-xs font-medium text-gray-400 uppercase tracking-wider">
                      {t('common.actions')}
                    </th>
                  )}
                </tr>
              </thead>
              <tbody className="bg-gray-800 divide-y divide-gray-700">
                {features.map((feature) => (
                  <tr key={feature.id} className="hover:bg-gray-700">
                    <td className="px-6 py-4 whitespace-nowrap">
                      <Link
                        to={`/features/${feature.id}`}
                        className="text-orange-500 hover:underline font-medium"
                      >
                        {feature.name}
                      </Link>
                    </td>
                    <td className="px-6 py-4 whitespace-nowrap">
                      <span className={`px-2 py-1 rounded text-xs font-medium ${getCategoryColor(feature.category)}`}>
                        {getCategoryLabel(feature.category)}
                      </span>
                    </td>
                    <td className="px-6 py-4 text-gray-400 max-w-xs truncate">
                      {feature.description || '-'}
                    </td>
                    {canManage && (
                      <td className="px-6 py-4 whitespace-nowrap text-right space-x-2">
                        <Link
                          to={`/features/${feature.id}/edit`}
                          className="inline-flex items-center justify-center h-8 px-3 text-sm font-medium text-orange-500 rounded-md transition-all duration-150 outline-none hover:bg-orange-500/10 focus-visible:ring-2 focus-visible:ring-orange-500/50"
                        >
                          {t('common.edit')}
                        </Link>
                        <button
                          onClick={() => handleDelete(feature.id)}
                          className="inline-flex items-center justify-center h-8 px-3 text-sm font-medium text-red-400 rounded-md transition-all duration-150 outline-none hover:bg-red-500/10 focus-visible:ring-2 focus-visible:ring-red-500/50"
                        >
                          {t('common.delete')}
                        </button>
                      </td>
                    )}
                  </tr>
                ))}
              </tbody>
            </table>
          </div>

          <Pagination currentPage={page} totalPages={totalPages} onPageChange={setPage} />
        </div>
      </div>
    </div>
  );
}
