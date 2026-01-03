import { useState, useMemo } from 'react';
import { useTranslation } from 'react-i18next';
import { ChevronDown, ChevronRight, Filter, X } from 'lucide-react';
import type { Brand, Feature } from '../types';

interface CarFiltersProps {
  brands: Brand[];
  features: Feature[];
  selectedCountries: string[];
  selectedBrandIds: string[];
  selectedFeatureIds: string[];
  onCountriesChange: (countries: string[]) => void;
  onBrandsChange: (brandIds: string[]) => void;
  onFeaturesChange: (featureIds: string[]) => void;
  onClearFilters: () => void;
}

export default function CarFilters({
  brands,
  features,
  selectedCountries,
  selectedBrandIds,
  selectedFeatureIds,
  onCountriesChange,
  onBrandsChange,
  onFeaturesChange,
  onClearFilters,
}: CarFiltersProps) {
  const { t } = useTranslation();
  const [expandedSections, setExpandedSections] = useState<Record<string, boolean>>({
    countries: true,
    brands: true,
    features: true,
  });
  const [expandedCountries, setExpandedCountries] = useState<Record<string, boolean>>({});
  const [expandedCategories, setExpandedCategories] = useState<Record<string, boolean>>({});

  const countries = useMemo(() => {
    const uniqueCountries = [...new Set(brands.map((b) => b.country))];
    return uniqueCountries.sort();
  }, [brands]);

  const brandsByCountry = useMemo(() => {
    return brands.reduce((acc, brand) => {
      if (!acc[brand.country]) {
        acc[brand.country] = [];
      }
      acc[brand.country].push(brand);
      return acc;
    }, {} as Record<string, Brand[]>);
  }, [brands]);

  const featuresByCategory = useMemo(() => {
    return features.reduce((acc, feature) => {
      if (!acc[feature.category]) {
        acc[feature.category] = [];
      }
      acc[feature.category].push(feature);
      return acc;
    }, {} as Record<string, Feature[]>);
  }, [features]);

  const toggleSection = (section: string) => {
    setExpandedSections((prev) => ({ ...prev, [section]: !prev[section] }));
  };

  const toggleCountryExpand = (country: string) => {
    setExpandedCountries((prev) => ({ ...prev, [country]: !prev[country] }));
  };

  const toggleCategoryExpand = (category: string) => {
    setExpandedCategories((prev) => ({ ...prev, [category]: !prev[category] }));
  };

  const handleCountryToggle = (country: string) => {
    const newSelected = selectedCountries.includes(country)
      ? selectedCountries.filter((c) => c !== country)
      : [...selectedCountries, country];
    onCountriesChange(newSelected);
  };

  const handleBrandToggle = (brandId: string) => {
    const newSelected = selectedBrandIds.includes(brandId)
      ? selectedBrandIds.filter((id) => id !== brandId)
      : [...selectedBrandIds, brandId];
    onBrandsChange(newSelected);
  };

  const handleFeatureToggle = (featureId: string) => {
    const newSelected = selectedFeatureIds.includes(featureId)
      ? selectedFeatureIds.filter((id) => id !== featureId)
      : [...selectedFeatureIds, featureId];
    onFeaturesChange(newSelected);
  };

  const hasActiveFilters =
    selectedCountries.length > 0 || selectedBrandIds.length > 0 || selectedFeatureIds.length > 0;

  const activeFilterCount =
    selectedCountries.length + selectedBrandIds.length + selectedFeatureIds.length;

  const getCategoryLabel = (category: string) => {
    const key = category.toLowerCase() as 'safety' | 'comfort' | 'technology' | 'performance';
    return t(`features.categories.${key}`);
  };

  return (
    <div className="bg-gray-800 rounded-lg shadow h-fit">
      <div className="flex items-center justify-between p-4 border-b border-gray-700">
        <div className="flex items-center gap-2">
          <Filter className="w-5 h-5 text-orange-500" />
          <span className="font-medium text-white">{t('filters.title')}</span>
          {activeFilterCount > 0 && (
            <span className="bg-orange-500 text-white text-xs px-2 py-0.5 rounded-full">
              {activeFilterCount}
            </span>
          )}
        </div>
        {hasActiveFilters && (
          <button
            onClick={onClearFilters}
            className="text-sm text-gray-400 hover:text-white flex items-center gap-1"
          >
            <X className="w-4 h-4" />
            {t('filters.clear')}
          </button>
        )}
      </div>

      <div className="p-4 space-y-4 max-h-[calc(100vh-250px)] overflow-y-auto">
        <div>
          <button
            onClick={() => toggleSection('countries')}
            className="flex items-center gap-2 text-sm font-medium text-gray-300 mb-2 hover:text-white w-full"
          >
            {expandedSections.countries ? (
              <ChevronDown className="w-4 h-4" />
            ) : (
              <ChevronRight className="w-4 h-4" />
            )}
            {t('filters.countries')}
          </button>
          {expandedSections.countries && (
            <div className="pl-6 space-y-2">
              {countries.map((country) => (
                <label key={country} className="flex items-center gap-2 cursor-pointer">
                  <input
                    type="checkbox"
                    checked={selectedCountries.includes(country)}
                    onChange={() => handleCountryToggle(country)}
                    className="h-4 w-4 text-orange-500 focus:ring-orange-500 border-gray-600 rounded bg-gray-700"
                  />
                  <span className="text-sm text-gray-300">{country}</span>
                </label>
              ))}
            </div>
          )}
        </div>

        <div className="border-t border-gray-700 pt-4">
          <button
            onClick={() => toggleSection('brands')}
            className="flex items-center gap-2 text-sm font-medium text-gray-300 mb-2 hover:text-white w-full"
          >
            {expandedSections.brands ? (
              <ChevronDown className="w-4 h-4" />
            ) : (
              <ChevronRight className="w-4 h-4" />
            )}
            {t('filters.brandsByCountry')}
          </button>
          {expandedSections.brands && (
            <div className="pl-4 space-y-2">
              {Object.entries(brandsByCountry).map(([country, countryBrands]) => (
                <div key={country}>
                  <button
                    onClick={() => toggleCountryExpand(country)}
                    className="flex items-center gap-2 text-sm text-gray-400 hover:text-white py-1"
                  >
                    {expandedCountries[country] ? (
                      <ChevronDown className="w-3 h-3" />
                    ) : (
                      <ChevronRight className="w-3 h-3" />
                    )}
                    {country}
                    <span className="text-xs text-gray-500">({countryBrands.length})</span>
                  </button>
                  {expandedCountries[country] && (
                    <div className="pl-5 space-y-1 mt-1">
                      {countryBrands.map((brand) => (
                        <label
                          key={brand.id}
                          className="flex items-center gap-2 cursor-pointer"
                        >
                          <input
                            type="checkbox"
                            checked={selectedBrandIds.includes(brand.id)}
                            onChange={() => handleBrandToggle(brand.id)}
                            className="h-4 w-4 text-orange-500 focus:ring-orange-500 border-gray-600 rounded bg-gray-700"
                          />
                          <span className="text-sm text-gray-300">{brand.name}</span>
                        </label>
                      ))}
                    </div>
                  )}
                </div>
              ))}
            </div>
          )}
        </div>

        <div className="border-t border-gray-700 pt-4">
          <button
            onClick={() => toggleSection('features')}
            className="flex items-center gap-2 text-sm font-medium text-gray-300 mb-2 hover:text-white w-full"
          >
            {expandedSections.features ? (
              <ChevronDown className="w-4 h-4" />
            ) : (
              <ChevronRight className="w-4 h-4" />
            )}
            {t('filters.featuresByCategory')}
          </button>
          {expandedSections.features && (
            <div className="pl-4 space-y-2">
              {Object.entries(featuresByCategory).map(([category, categoryFeatures]) => (
                <div key={category}>
                  <button
                    onClick={() => toggleCategoryExpand(category)}
                    className="flex items-center gap-2 text-sm text-gray-400 hover:text-white py-1"
                  >
                    {expandedCategories[category] ? (
                      <ChevronDown className="w-3 h-3" />
                    ) : (
                      <ChevronRight className="w-3 h-3" />
                    )}
                    {getCategoryLabel(category)}
                    <span className="text-xs text-gray-500">({categoryFeatures.length})</span>
                  </button>
                  {expandedCategories[category] && (
                    <div className="pl-5 space-y-1 mt-1">
                      {categoryFeatures.map((feature) => (
                        <label
                          key={feature.id}
                          className="flex items-center gap-2 cursor-pointer"
                        >
                          <input
                            type="checkbox"
                            checked={selectedFeatureIds.includes(feature.id)}
                            onChange={() => handleFeatureToggle(feature.id)}
                            className="h-4 w-4 text-orange-500 focus:ring-orange-500 border-gray-600 rounded bg-gray-700"
                          />
                          <span className="text-sm text-gray-300">{feature.name}</span>
                        </label>
                      ))}
                    </div>
                  )}
                </div>
              ))}
            </div>
          )}
        </div>
      </div>
    </div>
  );
}
