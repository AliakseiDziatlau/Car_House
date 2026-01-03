import { useTranslation } from 'react-i18next';
import { ChevronLeft, ChevronRight } from 'lucide-react';

interface PaginationProps {
  currentPage: number;
  totalPages: number;
  onPageChange: (page: number) => void;
}

export default function Pagination({ currentPage, totalPages, onPageChange }: PaginationProps) {
  const { t } = useTranslation();

  if (totalPages <= 1) return null;

  const pages = [];
  for (let i = 1; i <= totalPages; i++) {
    pages.push(i);
  }

  return (
    <div className="flex justify-center items-center gap-1 mt-6">
      <button
        onClick={() => onPageChange(currentPage - 1)}
        disabled={currentPage === 1}
        className="inline-flex items-center justify-center gap-1.5 h-9 px-3 border border-gray-700 bg-gray-800/50 text-gray-300 text-sm font-medium rounded-md shadow-sm transition-all duration-150 outline-none hover:bg-gray-700 hover:text-white hover:border-gray-600 focus-visible:ring-2 focus-visible:ring-orange-500/50 disabled:opacity-50 disabled:pointer-events-none"
      >
        <ChevronLeft className="w-4 h-4" />
        {t('common.previous')}
      </button>

      <div className="flex items-center gap-1 mx-2">
        {pages.map((page) => (
          <button
            key={page}
            onClick={() => onPageChange(page)}
            className={`inline-flex items-center justify-center min-w-[36px] h-9 px-3 text-sm font-medium rounded-md transition-all duration-150 outline-none focus-visible:ring-2 focus-visible:ring-orange-500/50 ${
              page === currentPage
                ? 'bg-orange-500 text-white shadow-sm'
                : 'border border-gray-700 bg-gray-800/50 text-gray-300 hover:bg-gray-700 hover:text-white hover:border-gray-600'
            }`}
          >
            {page}
          </button>
        ))}
      </div>

      <button
        onClick={() => onPageChange(currentPage + 1)}
        disabled={currentPage === totalPages}
        className="inline-flex items-center justify-center gap-1.5 h-9 px-3 border border-gray-700 bg-gray-800/50 text-gray-300 text-sm font-medium rounded-md shadow-sm transition-all duration-150 outline-none hover:bg-gray-700 hover:text-white hover:border-gray-600 focus-visible:ring-2 focus-visible:ring-orange-500/50 disabled:opacity-50 disabled:pointer-events-none"
      >
        {t('common.next')}
        <ChevronRight className="w-4 h-4" />
      </button>
    </div>
  );
}
