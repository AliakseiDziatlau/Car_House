import { useState } from 'react';
import { useTranslation } from 'react-i18next';
import { ChevronDown, ChevronRight, Filter, X } from 'lucide-react';

interface CategoryOption {
  value: string;
  label: string;
}

interface FeatureFiltersProps {
  categories: CategoryOption[];
  selectedCategories: string[];
  onCategoriesChange: (categories: string[]) => void;
  onClearFilters: () => void;
}

export default function FeatureFilters({
  categories,
  selectedCategories,
  onCategoriesChange,
  onClearFilters,
}: FeatureFiltersProps) {
  const { t } = useTranslation();
  const [expandedSections, setExpandedSections] = useState<Record<string, boolean>>({
    categories: true,
  });

  const toggleSection = (section: string) => {
    setExpandedSections((prev) => ({ ...prev, [section]: !prev[section] }));
  };

  const handleCategoryToggle = (category: string) => {
    const newSelected = selectedCategories.includes(category)
      ? selectedCategories.filter((c) => c !== category)
      : [...selectedCategories, category];
    onCategoriesChange(newSelected);
  };

  const hasActiveFilters = selectedCategories.length > 0;
  const activeFilterCount = selectedCategories.length;

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
            onClick={() => toggleSection('categories')}
            className="flex items-center gap-2 text-sm font-medium text-gray-300 mb-2 hover:text-white w-full"
          >
            {expandedSections.categories ? (
              <ChevronDown className="w-4 h-4" />
            ) : (
              <ChevronRight className="w-4 h-4" />
            )}
            {t('filters.categories')}
          </button>
          {expandedSections.categories && (
            <div className="pl-6 space-y-2">
              {categories.map((category) => (
                <label key={category.value} className="flex items-center gap-2 cursor-pointer">
                  <input
                    type="checkbox"
                    checked={selectedCategories.includes(category.value)}
                    onChange={() => handleCategoryToggle(category.value)}
                    className="h-4 w-4 text-orange-500 focus:ring-orange-500 border-gray-600 rounded bg-gray-700"
                  />
                  <span className="text-sm text-gray-300">{category.label}</span>
                </label>
              ))}
            </div>
          )}
        </div>
      </div>
    </div>
  );
}
