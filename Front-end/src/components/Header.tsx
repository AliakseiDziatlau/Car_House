import { Link } from 'react-router-dom';
import { useTranslation } from 'react-i18next';
import { useAuth } from '../context/AuthContext';
import LanguageSwitcher from './LanguageSwitcher';
import { LogIn, LogOut, UserPlus, User } from 'lucide-react';

export default function Header() {
  const { t } = useTranslation();
  const { user, isAuthenticated, logout } = useAuth();

  return (
    <header className="h-14 bg-gray-900 border-b border-gray-800 px-4 flex items-center justify-between shrink-0">
      <div className="flex items-center gap-3">
        <Link to="/" className="flex items-center gap-2">
          <span className="text-orange-500 font-bold text-2xl">CH</span>
          <span className="text-lg font-semibold text-white hidden sm:inline">Car House</span>
        </Link>
      </div>

      <div className="flex items-center gap-3">
        <LanguageSwitcher />

        {isAuthenticated ? (
          <div className="flex items-center gap-3">
            <div className="flex items-center gap-2 px-3 py-1.5 rounded-lg bg-gray-800/50 border border-gray-700">
              <User className="w-4 h-4 text-gray-400" />
              <span className="text-sm text-gray-300 hidden sm:inline">
                {user?.firstName} {user?.lastName}
              </span>
            </div>
            <button
              onClick={logout}
              className="flex items-center gap-2 px-3 py-1.5 rounded-lg border border-gray-700 bg-gray-800/50 text-gray-300 hover:bg-gray-700 hover:text-white hover:border-gray-600 transition-colors"
            >
              <LogOut className="w-4 h-4" />
              <span className="text-sm font-medium hidden sm:inline">{t('nav.logout')}</span>
            </button>
          </div>
        ) : (
          <div className="flex items-center gap-2">
            <Link
              to="/login"
              className="flex items-center gap-2 px-3 py-1.5 rounded-lg border border-gray-700 bg-gray-800/50 text-gray-300 hover:bg-gray-700 hover:text-white hover:border-gray-600 transition-colors"
            >
              <LogIn className="w-4 h-4" />
              <span className="text-sm font-medium hidden sm:inline">{t('nav.login')}</span>
            </Link>
            <Link
              to="/register"
              className="flex items-center gap-2 px-3 py-1.5 rounded-lg bg-orange-500 text-white hover:bg-orange-600 transition-colors"
            >
              <UserPlus className="w-4 h-4" />
              <span className="text-sm font-medium hidden sm:inline">{t('nav.register')}</span>
            </Link>
          </div>
        )}
      </div>
    </header>
  );
}
