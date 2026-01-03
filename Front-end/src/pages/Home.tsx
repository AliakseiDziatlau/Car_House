import { Link } from 'react-router-dom';
import { useTranslation } from 'react-i18next';
import { useAuth } from '../context/AuthContext';
import { Car, Tag, ShoppingCart, ClipboardList, LogIn, UserPlus, Mail, Shield, Calendar } from 'lucide-react';

export default function Home() {
  const { t } = useTranslation();
  const { user, isAuthenticated } = useAuth();

  const formatDate = (dateString: string) => {
    return new Date(dateString).toLocaleDateString(undefined, {
      year: 'numeric',
      month: 'short',
    });
  };

  return (
    <div className="max-w-4xl mx-auto">
      <div className="text-center mb-10">
        <h1 className="text-4xl font-bold text-white mb-4">
          {t('home.welcome')}
        </h1>
        <p className="text-xl text-gray-400">
          {t('home.subtitle')}
        </p>
      </div>

      <div className="grid grid-cols-1 md:grid-cols-2 gap-6 mb-10">
        <div className="bg-gray-800 rounded-lg p-6 border border-gray-700">
          {isAuthenticated && user ? (
            <>
              <h2 className="text-2xl font-semibold text-white mb-4">
                {t('home.helloUser', { name: user.firstName })}
              </h2>
              <div className="border-t border-gray-700 pt-4">
                <h3 className="text-sm font-medium text-gray-400 uppercase tracking-wider mb-3">
                  {t('home.yourProfile')}
                </h3>
                <div className="space-y-3">
                  <div className="flex items-center gap-3 text-gray-300">
                    <Mail className="w-4 h-4 text-gray-500" />
                    <span>{user.email}</span>
                  </div>
                  <div className="flex items-center gap-3 text-gray-300">
                    <Shield className="w-4 h-4 text-gray-500" />
                    <span>{user.roleName}</span>
                  </div>
                  <div className="flex items-center gap-3 text-gray-300">
                    <Calendar className="w-4 h-4 text-gray-500" />
                    <span>{t('home.memberSince')} {formatDate(user.createdAt)}</span>
                  </div>
                </div>
              </div>
            </>
          ) : (
            <>
              <h2 className="text-2xl font-semibold text-white mb-4">
                {t('home.helloGuest')}
              </h2>
              <div className="border-t border-gray-700 pt-4">
                <p className="text-gray-400 mb-4">{t('home.guestBenefits')}</p>
                <ul className="space-y-2 mb-6">
                  <li className="flex items-center gap-2 text-gray-300">
                    <ShoppingCart className="w-4 h-4 text-orange-500" />
                    <span>{t('home.guestBenefit1')}</span>
                  </li>
                  <li className="flex items-center gap-2 text-gray-300">
                    <ClipboardList className="w-4 h-4 text-orange-500" />
                    <span>{t('home.guestBenefit2')}</span>
                  </li>
                </ul>
                <div className="flex gap-3">
                  <Link
                    to="/login"
                    className="flex-1 inline-flex items-center justify-center gap-2 h-10 px-4 border border-gray-600 bg-gray-700/50 text-white text-sm font-medium rounded-lg transition-all duration-150 hover:bg-gray-700 hover:border-gray-500"
                  >
                    <LogIn className="w-4 h-4" />
                    {t('nav.login')}
                  </Link>
                  <Link
                    to="/register"
                    className="flex-1 inline-flex items-center justify-center gap-2 h-10 px-4 bg-orange-500 text-white text-sm font-medium rounded-lg transition-all duration-150 hover:bg-orange-600"
                  >
                    <UserPlus className="w-4 h-4" />
                    {t('nav.register')}
                  </Link>
                </div>
              </div>
            </>
          )}
        </div>

        <div className="bg-gray-800 rounded-lg p-6 border border-gray-700">
          <h2 className="text-2xl font-semibold text-white mb-4">
            {t('home.whatWeOffer')}
          </h2>
          <div className="border-t border-gray-700 pt-4">
            <ul className="space-y-4">
              <li className="flex items-start gap-3">
                <Car className="w-5 h-5 text-orange-500 mt-0.5 shrink-0" />
                <span className="text-gray-300">{t('home.feature1')}</span>
              </li>
              <li className="flex items-start gap-3">
                <Tag className="w-5 h-5 text-orange-500 mt-0.5 shrink-0" />
                <span className="text-gray-300">{t('home.feature2')}</span>
              </li>
              <li className="flex items-start gap-3">
                <ShoppingCart className="w-5 h-5 text-orange-500 mt-0.5 shrink-0" />
                <span className="text-gray-300">{t('home.feature3')}</span>
              </li>
              <li className="flex items-start gap-3">
                <ClipboardList className="w-5 h-5 text-orange-500 mt-0.5 shrink-0" />
                <span className="text-gray-300">{t('home.feature4')}</span>
              </li>
            </ul>
          </div>
        </div>
      </div>

      <div className="flex justify-center gap-4">
        <Link
          to="/cars"
          className="inline-flex items-center justify-center gap-2 h-12 px-8 bg-orange-500 text-white font-medium rounded-lg shadow-sm transition-all duration-150 outline-none hover:bg-orange-600 focus-visible:ring-2 focus-visible:ring-orange-500/50"
        >
          <Car className="w-5 h-5" />
          {t('home.browseCars')}
        </Link>
        <Link
          to="/brands"
          className="inline-flex items-center justify-center gap-2 h-12 px-8 border border-gray-600 bg-gray-800/50 text-white font-medium rounded-lg shadow-sm transition-all duration-150 outline-none hover:bg-gray-700 hover:border-gray-500 focus-visible:ring-2 focus-visible:ring-orange-500/50"
        >
          <Tag className="w-5 h-5" />
          {t('home.viewBrands')}
        </Link>
      </div>
    </div>
  );
}
