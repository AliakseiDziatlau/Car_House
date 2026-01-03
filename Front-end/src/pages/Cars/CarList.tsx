import { useEffect, useState } from 'react';
import { Link, useSearchParams } from 'react-router-dom';
import { useTranslation } from 'react-i18next';
import { ChevronLeft, ChevronRight } from 'lucide-react';
import api from '../../services/api';
import { useAuth } from '../../context/AuthContext';
import Pagination from '../../components/Pagination';
import CarFilters from '../../components/CarFilters';
import type { CarListItem, Brand, Feature, PagedResult } from '../../types';

const FILTERS_COLLAPSED_KEY = 'car-filters-collapsed';
const FILTERS_COUNTRIES_KEY = 'car-filters-countries';
const FILTERS_BRANDS_KEY = 'car-filters-brands';
const FILTERS_FEATURES_KEY = 'car-filters-features';

export default function CarList() {
  const { t } = useTranslation();
  const { hasRole } = useAuth();
  const canManage = hasRole('Manager', 'Admin');
  const [searchParams, setSearchParams] = useSearchParams();
  const [cars, setCars] = useState<CarListItem[]>([]);
  const [brands, setBrands] = useState<Brand[]>([]);
  const [features, setFeatures] = useState<Feature[]>([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);
  const [page, setPage] = useState(1);
  const [totalPages, setTotalPages] = useState(1);
  const [selectedCountries, setSelectedCountries] = useState<string[]>(() => {
    const saved = localStorage.getItem(FILTERS_COUNTRIES_KEY);
    return saved ? JSON.parse(saved) : [];
  });
  const [selectedBrandIds, setSelectedBrandIds] = useState<string[]>(() => {
    const brandId = searchParams.get('brandId');
    if (brandId) return [brandId];
    const saved = localStorage.getItem(FILTERS_BRANDS_KEY);
    return saved ? JSON.parse(saved) : [];
  });
  const [selectedFeatureIds, setSelectedFeatureIds] = useState<string[]>(() => {
    const saved = localStorage.getItem(FILTERS_FEATURES_KEY);
    return saved ? JSON.parse(saved) : [];
  });
  const [filtersCollapsed, setFiltersCollapsed] = useState(() => {
    return localStorage.getItem(FILTERS_COLLAPSED_KEY) === 'true';
  });

  useEffect(() => {
    fetchBrands();
    fetchFeatures();
  }, []);

  useEffect(() => {
    fetchCars();
  }, [page, selectedCountries, selectedBrandIds, selectedFeatureIds, canManage]);

  useEffect(() => {
    localStorage.setItem(FILTERS_COLLAPSED_KEY, filtersCollapsed ? 'true' : '');
  }, [filtersCollapsed]);

  useEffect(() => {
    localStorage.setItem(FILTERS_COUNTRIES_KEY, JSON.stringify(selectedCountries));
  }, [selectedCountries]);

  useEffect(() => {
    localStorage.setItem(FILTERS_BRANDS_KEY, JSON.stringify(selectedBrandIds));
  }, [selectedBrandIds]);

  useEffect(() => {
    localStorage.setItem(FILTERS_FEATURES_KEY, JSON.stringify(selectedFeatureIds));
  }, [selectedFeatureIds]);

  const fetchBrands = async () => {
    try {
      const response = await api.get<PagedResult<Brand>>('/brands', {
        params: { pageSize: 100 },
      });
      setBrands(response.data.items);
    } catch {
      console.error('Failed to load brands');
    }
  };

  const fetchFeatures = async () => {
    try {
      const response = await api.get<PagedResult<Feature>>('/features', {
        params: { pageSize: 100 },
      });
      setFeatures(response.data.items);
    } catch {
      console.error('Failed to load features');
    }
  };

  const fetchCars = async () => {
    try {
      setLoading(true);
      const params: Record<string, string | number | string[] | boolean> = { page, pageSize: 9 };

      if (!canManage) {
        params.isAvailable = true;
      }

      if (selectedCountries.length > 0) {
        params.countries = selectedCountries;
      }

      if (selectedBrandIds.length > 0) {
        params.brandIds = selectedBrandIds;
      }

      if (selectedFeatureIds.length > 0) {
        params.featureIds = selectedFeatureIds;
      }

      const response = await api.get<PagedResult<CarListItem>>('/cars', { params });
      setCars(response.data.items);
      setTotalPages(response.data.totalPages);
    } catch {
      setError(t('cars.loadError'));
    } finally {
      setLoading(false);
    }
  };

  const handleCountriesChange = (countries: string[]) => {
    setSelectedCountries(countries);
    setPage(1);
  };

  const handleBrandsChange = (brandIds: string[]) => {
    setSelectedBrandIds(brandIds);
    setPage(1);
    if (brandIds.length === 1) {
      setSearchParams({ brandId: brandIds[0] });
    } else {
      setSearchParams({});
    }
  };

  const handleFeaturesChange = (featureIds: string[]) => {
    setSelectedFeatureIds(featureIds);
    setPage(1);
  };

  const handleClearFilters = () => {
    setSelectedCountries([]);
    setSelectedBrandIds([]);
    setSelectedFeatureIds([]);
    setPage(1);
    setSearchParams({});
    localStorage.removeItem(FILTERS_COUNTRIES_KEY);
    localStorage.removeItem(FILTERS_BRANDS_KEY);
    localStorage.removeItem(FILTERS_FEATURES_KEY);
  };

  const handleDelete = async (id: string) => {
    if (!confirm(t('cars.deleteConfirm'))) return;
    try {
      await api.delete(`/cars/${id}`);
      fetchCars();
    } catch {
      setError(t('cars.deleteError'));
    }
  };

  if (loading && cars.length === 0) return <div className="text-center py-8 text-gray-400">{t('common.loading')}</div>;
  if (error) return <div className="text-center py-8 text-red-400">{error}</div>;

  return (
    <div>
      <div className="flex justify-between items-center mb-6">
        <h1 className="text-2xl font-bold text-white">{t('cars.title')}</h1>
        {canManage && (
          <Link
            to="/cars/new"
            className="inline-flex items-center justify-center h-9 px-4 bg-orange-500 text-white text-sm font-medium rounded-md shadow-sm transition-all duration-150 outline-none hover:bg-orange-600 focus-visible:ring-2 focus-visible:ring-orange-500/50"
          >
            {t('cars.addCar')}
          </Link>
        )}
      </div>

      <div className="flex gap-6">
        <div
          className={`transition-[width] duration-200 ease-linear overflow-hidden shrink-0 ${
            filtersCollapsed ? 'w-0' : 'w-72'
          }`}
        >
          <div className="min-w-[288px]">
            <CarFilters
              brands={brands}
              features={features}
              selectedCountries={selectedCountries}
              selectedBrandIds={selectedBrandIds}
              selectedFeatureIds={selectedFeatureIds}
              onCountriesChange={handleCountriesChange}
              onBrandsChange={handleBrandsChange}
              onFeaturesChange={handleFeaturesChange}
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

          {cars.length === 0 ? (
            <p className="text-center py-8 text-gray-400">{t('cars.noCars')}</p>
          ) : (
            <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-6">
              {cars.map((car) => (
                <div key={car.id} className="bg-gray-800 rounded-lg shadow overflow-hidden">
                  {car.imageUrl ? (
                    <img
                      src={car.imageUrl}
                      alt={car.model}
                      className="h-48 w-full object-cover"
                    />
                  ) : (
                    <div className="h-48 bg-gray-700 flex items-center justify-center">
                      <span className="text-gray-500">{t('common.noImage')}</span>
                    </div>
                  )}
                  <div className="p-4">
                    <div className="flex justify-between items-start mb-2">
                      <div>
                        <h3 className="font-semibold text-lg text-white">{car.model}</h3>
                        <p className="text-gray-400">{car.brandName} • {car.year}</p>
                      </div>
                      <span
                        className={`px-2 py-1 rounded text-xs font-medium ${
                          car.isAvailable
                            ? 'bg-green-100 text-green-800'
                            : 'bg-red-100 text-red-800'
                        }`}
                      >
                        {car.isAvailable ? t('common.available') : t('common.sold')}
                      </span>
                    </div>
                    <p className="text-orange-500 font-bold text-xl mb-4">
                      ${car.price.toLocaleString()}
                    </p>
                    <div className="flex gap-2">
                      <Link
                        to={`/cars/${car.id}`}
                        className="flex-1 inline-flex items-center justify-center h-9 bg-orange-500 text-white text-sm font-medium rounded-md shadow-sm transition-all duration-150 outline-none hover:bg-orange-600 focus-visible:ring-2 focus-visible:ring-orange-500/50"
                      >
                        {t('common.view')}
                      </Link>
                      {canManage && (
                        <>
                          <Link
                            to={`/cars/${car.id}/edit`}
                            className="flex-1 inline-flex items-center justify-center h-9 border border-gray-600 bg-gray-800/50 text-white text-sm font-medium rounded-md shadow-sm transition-all duration-150 outline-none hover:bg-gray-700 hover:border-gray-500 focus-visible:ring-2 focus-visible:ring-orange-500/50"
                          >
                            {t('common.edit')}
                          </Link>
                          <button
                            onClick={() => handleDelete(car.id)}
                            className="inline-flex items-center justify-center h-9 px-3 text-sm font-medium text-red-400 rounded-md transition-all duration-150 outline-none hover:bg-red-500/10 focus-visible:ring-2 focus-visible:ring-red-500/50"
                          >
                            {t('common.delete')}
                          </button>
                        </>
                      )}
                    </div>
                  </div>
                </div>
              ))}
            </div>
          )}

          <Pagination currentPage={page} totalPages={totalPages} onPageChange={setPage} />
        </div>
      </div>
    </div>
  );
}
