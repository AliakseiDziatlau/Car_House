import { useTranslation } from 'react-i18next';

const languages = [
  { code: 'en', label: 'EN' },
  { code: 'pl', label: 'PL' },
];

interface LanguageSwitcherProps {
  collapsed?: boolean;
}

export default function LanguageSwitcher({ collapsed = false }: LanguageSwitcherProps) {
  const { i18n } = useTranslation();

  if (collapsed) {
    return (
      <div className="text-sm font-medium text-gray-400">
        {i18n.language.toUpperCase()}
      </div>
    );
  }

  return (
    <div className="inline-flex rounded-lg border border-gray-700 p-0.5 bg-gray-800/50">
      {languages.map((lang) => (
        <button
          key={lang.code}
          onClick={() => i18n.changeLanguage(lang.code)}
          className={`
            relative px-3 py-1.5 text-sm font-medium rounded-md
            transition-all duration-150 outline-none
            focus-visible:ring-2 focus-visible:ring-orange-500/50
            ${
              i18n.language === lang.code
                ? 'bg-orange-500 text-white shadow-sm'
                : 'text-gray-400 hover:text-white hover:bg-gray-700/50'
            }
          `}
        >
          {lang.label}
        </button>
      ))}
    </div>
  );
}
