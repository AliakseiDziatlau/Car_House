import { Link } from 'react-router-dom';
import { useTranslation } from 'react-i18next';
import { useAuth } from '../context/AuthContext';
import LanguageSwitcher from './LanguageSwitcher';

export default function Navbar() {
  const { t } = useTranslation();
  const { user, isAuthenticated, logout, hasRole } = useAuth();

  return (
    <nav className="bg-gray-800 text-white shadow-lg">
      <div className="max-w-7xl mx-auto px-4">
        <div className="flex justify-between h-16">
          <div className="flex items-center">
            <Link to="/" className="text-xl font-bold">
              {t('nav.home')}
            </Link>
            <div className="ml-10 flex space-x-4">
              <Link to="/cars" className="hover:bg-gray-700 px-3 py-2 rounded-md">
                {t('nav.cars')}
              </Link>
              <Link to="/brands" className="hover:bg-gray-700 px-3 py-2 rounded-md">
                {t('nav.brands')}
              </Link>
              <Link to="/features" className="hover:bg-gray-700 px-3 py-2 rounded-md">
                {t('nav.features')}
              </Link>
              {isAuthenticated && (
                <Link to="/orders" className="hover:bg-gray-700 px-3 py-2 rounded-md">
                  {t('nav.orders')}
                </Link>
              )}
              {hasRole('Admin') && (
                <Link to="/users" className="hover:bg-gray-700 px-3 py-2 rounded-md">
                  {t('nav.users')}
                </Link>
              )}
            </div>
          </div>
          <div className="flex items-center space-x-4">
            <LanguageSwitcher />
            {isAuthenticated ? (
              <>
                <span className="text-gray-300">
                  {user?.firstName} {user?.lastName}
                </span>
                <button
                  onClick={logout}
                  className="hover:bg-gray-700 px-3 py-2 rounded-md"
                >
                  {t('nav.logout')}
                </button>
              </>
            ) : (
              <>
                <Link to="/login" className="hover:bg-gray-700 px-3 py-2 rounded-md">
                  {t('nav.login')}
                </Link>
                <Link
                  to="/register"
                  className="bg-blue-600 hover:bg-blue-700 px-4 py-2 rounded-md"
                >
                  {t('nav.register')}
                </Link>
              </>
            )}
          </div>
        </div>
      </div>
    </nav>
  );
}
