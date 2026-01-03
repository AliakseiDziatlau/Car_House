import { useEffect, useState, useMemo } from 'react';
import { Link } from 'react-router-dom';
import { useTranslation } from 'react-i18next';
import { ChevronLeft, ChevronRight } from 'lucide-react';
import api from '../../services/api';
import { useAuth } from '../../context/AuthContext';
import Pagination from '../../components/Pagination';
import BrandFilters from '../../components/BrandFilters';
import type { Brand, PagedResult } from '../../types';

const FILTERS_COLLAPSED_KEY = 'brand-filters-collapsed';
const FILTERS_COUNTRIES_KEY = 'brand-filters-countries';

export default function BrandList() {
  const { t } = useTranslation();
  const { hasRole } = useAuth();
  const canManage = hasRole('Manager', 'Admin');
  const [brands, setBrands] = useState<Brand[]>([]);
  const [allBrands, setAllBrands] = useState<Brand[]>([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);
  const [page, setPage] = useState(1);
  const [totalPages, setTotalPages] = useState(1);
  const [selectedCountries, setSelectedCountries] = useState<string[]>(() => {
    const saved = localStorage.getItem(FILTERS_COUNTRIES_KEY);
    return saved ? JSON.parse(saved) : [];
  });
  const [filtersCollapsed, setFiltersCollapsed] = useState(() => {
    return localStorage.getItem(FILTERS_COLLAPSED_KEY) === 'true';
  });

  useEffect(() => {
    fetchAllBrands();
  }, []);

  useEffect(() => {
    fetchBrands();
  }, [page, selectedCountries]);

  useEffect(() => {
    localStorage.setItem(FILTERS_COLLAPSED_KEY, filtersCollapsed ? 'true' : '');
  }, [filtersCollapsed]);

  useEffect(() => {
    localStorage.setItem(FILTERS_COUNTRIES_KEY, JSON.stringify(selectedCountries));
  }, [selectedCountries]);

  const fetchAllBrands = async () => {
    try {
      const response = await api.get<PagedResult<Brand>>('/brands', {
        params: { pageSize: 100 },
      });
      setAllBrands(response.data.items);
    } catch {
      console.error('Failed to load all brands');
    }
  };

  const fetchBrands = async () => {
    try {
      setLoading(true);
      const params: Record<string, string | number | string[]> = { page, pageSize: 10 };
      if (selectedCountries.length > 0) {
        params.countries = selectedCountries;
      }
      const response = await api.get<PagedResult<Brand>>('/brands', { params });
      setBrands(response.data.items);
      setTotalPages(response.data.totalPages);
    } catch {
      setError(t('brands.loadError'));
    } finally {
      setLoading(false);
    }
  };

  const countries = useMemo(() => {
    const uniqueCountries = [...new Set(allBrands.map((b) => b.country))];
    return uniqueCountries.sort();
  }, [allBrands]);

  const handleCountriesChange = (newCountries: string[]) => {
    setSelectedCountries(newCountries);
    setPage(1);
  };

  const handleClearFilters = () => {
    setSelectedCountries([]);
    setPage(1);
    localStorage.removeItem(FILTERS_COUNTRIES_KEY);
  };

  const handleDelete = async (id: string) => {
    if (!confirm(t('brands.deleteConfirm'))) return;
    try {
      await api.delete(`/brands/${id}`);
      fetchBrands();
    } catch {
      setError(t('brands.deleteError'));
    }
  };

  if (loading && brands.length === 0) return <div className="text-center py-8 text-gray-400">{t('common.loading')}</div>;
  if (error) return <div className="text-center py-8 text-red-400">{error}</div>;

  return (
    <div>
      <div className="flex justify-between items-center mb-6">
        <h1 className="text-2xl font-bold text-white">{t('brands.title')}</h1>
        {canManage && (
          <Link
            to="/brands/new"
            className="inline-flex items-center justify-center h-9 px-4 bg-orange-500 text-white text-sm font-medium rounded-md shadow-sm transition-all duration-150 outline-none hover:bg-orange-600 focus-visible:ring-2 focus-visible:ring-orange-500/50"
          >
            {t('brands.addBrand')}
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
            <BrandFilters
              countries={countries}
              selectedCountries={selectedCountries}
              onCountriesChange={handleCountriesChange}
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
                    {t('brands.logo')}
                  </th>
                  <th className="px-6 py-3 text-left text-xs font-medium text-gray-400 uppercase tracking-wider">
                    {t('common.name')}
                  </th>
                  <th className="px-6 py-3 text-left text-xs font-medium text-gray-400 uppercase tracking-wider">
                    {t('brands.country')}
                  </th>
                  {canManage && (
                    <th className="px-6 py-3 text-right text-xs font-medium text-gray-400 uppercase tracking-wider">
                      {t('common.actions')}
                    </th>
                  )}
                </tr>
              </thead>
              <tbody className="bg-gray-800 divide-y divide-gray-700">
                {brands.map((brand) => (
                  <tr key={brand.id} className="hover:bg-gray-700">
                    <td className="px-6 py-4 whitespace-nowrap">
                      {brand.logoUrl ? (
                        <img
                          src={brand.logoUrl}
                          alt={brand.name}
                          className="h-10 w-10 object-contain"
                        />
                      ) : (
                        <div className="h-10 w-10 bg-gray-700 rounded flex items-center justify-center">
                          <span className="text-gray-500 text-xs">{t('brands.noLogo')}</span>
                        </div>
                      )}
                    </td>
                    <td className="px-6 py-4 whitespace-nowrap">
                      <Link
                        to={`/brands/${brand.id}`}
                        className="text-orange-500 hover:underline font-medium"
                      >
                        {brand.name}
                      </Link>
                    </td>
                    <td className="px-6 py-4 whitespace-nowrap text-gray-400">
                      {brand.country}
                    </td>
                    {canManage && (
                      <td className="px-6 py-4 whitespace-nowrap text-right space-x-2">
                        <Link
                          to={`/brands/${brand.id}/edit`}
                          className="inline-flex items-center justify-center h-8 px-3 text-sm font-medium text-orange-500 rounded-md transition-all duration-150 outline-none hover:bg-orange-500/10 focus-visible:ring-2 focus-visible:ring-orange-500/50"
                        >
                          {t('common.edit')}
                        </Link>
                        <button
                          onClick={() => handleDelete(brand.id)}
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
