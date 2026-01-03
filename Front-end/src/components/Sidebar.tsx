import { Link, useLocation } from 'react-router-dom';
import { useTranslation } from 'react-i18next';
import { useAuth } from '../context/AuthContext';
import { useSidebarState } from '../hooks/useSidebarState';
import { useState, useEffect } from 'react';
import {
  Home,
  Car,
  Tag,
  Sparkles,
  ShoppingCart,
  Users,
  ChevronLeft,
  ChevronRight,
  Menu,
  X,
} from 'lucide-react';

interface NavItem {
  to: string;
  label: string;
  icon: React.ReactNode;
  requiresAuth?: boolean;
  roles?: string[];
}

export default function Sidebar() {
  const { t } = useTranslation();
  const { isAuthenticated, hasRole } = useAuth();
  const { isCollapsed, toggle } = useSidebarState();
  const location = useLocation();
  const [isMobileOpen, setIsMobileOpen] = useState(false);
  const [isMobile, setIsMobile] = useState(false);

  useEffect(() => {
    const checkMobile = () => setIsMobile(window.innerWidth < 768);
    checkMobile();
    window.addEventListener('resize', checkMobile);
    return () => window.removeEventListener('resize', checkMobile);
  }, []);

  useEffect(() => {
    setIsMobileOpen(false);
  }, [location.pathname]);

  const navigationItems: NavItem[] = [
    { to: '/', label: t('nav.home'), icon: <Home className="w-5 h-5" /> },
    { to: '/cars', label: t('nav.cars'), icon: <Car className="w-5 h-5" /> },
    { to: '/brands', label: t('nav.brands'), icon: <Tag className="w-5 h-5" /> },
    { to: '/features', label: t('nav.features'), icon: <Sparkles className="w-5 h-5" /> },
  ];

  const accountItems: NavItem[] = [
    { to: '/orders', label: t('nav.orders'), icon: <ShoppingCart className="w-5 h-5" />, requiresAuth: true },
    { to: '/users', label: t('nav.users'), icon: <Users className="w-5 h-5" />, roles: ['Admin'] },
  ];

  const isActive = (path: string) => {
    if (path === '/') return location.pathname === '/';
    return location.pathname.startsWith(path);
  };

  const filterItems = (items: NavItem[]) =>
    items.filter((item) => {
      if (item.roles && !item.roles.some((role) => hasRole(role))) return false;
      if (item.requiresAuth && !isAuthenticated) return false;
      return true;
    });

  const filteredNavigationItems = filterItems(navigationItems);
  const filteredAccountItems = filterItems(accountItems);

  const NavLink = ({ item }: { item: NavItem }) => {
    const active = isActive(item.to);
    const collapsed = isCollapsed && !isMobile;

    return (
      <Link
        to={item.to}
        title={collapsed ? item.label : undefined}
        className={`
          flex items-center gap-3 rounded-lg transition-colors duration-150
          ${collapsed ? 'justify-center px-2 py-2.5' : 'px-3 py-2.5'}
          ${
            active
              ? 'bg-orange-500/10 text-orange-500 font-medium border-l-2 border-orange-500'
              : 'text-gray-300 hover:bg-gray-800 hover:text-white border-l-2 border-transparent'
          }
        `}
      >
        <span className="flex-shrink-0">{item.icon}</span>
        {!collapsed && <span className="text-sm">{item.label}</span>}
      </Link>
    );
  };

  const GroupLabel = ({ label }: { label: string }) => {
    if (isCollapsed && !isMobile) return null;
    return (
      <div className="px-3 py-2 text-xs font-semibold uppercase tracking-wider text-gray-500">
        {label}
      </div>
    );
  };

  const sidebarContent = (
    <nav className="flex-1 py-4 overflow-y-auto">
      <div className="mb-6">
        <GroupLabel label={t('nav.navigation')} />
        <div className="space-y-1 px-2">
          {filteredNavigationItems.map((item) => (
            <NavLink key={item.to} item={item} />
          ))}
        </div>
      </div>

      {filteredAccountItems.length > 0 && (
        <div className="mb-6">
          <GroupLabel label={t('nav.account')} />
          <div className="space-y-1 px-2">
            {filteredAccountItems.map((item) => (
              <NavLink key={item.to} item={item} />
            ))}
          </div>
        </div>
      )}
    </nav>
  );

  if (isMobile) {
    return (
      <>
        <button
          onClick={() => setIsMobileOpen(true)}
          className="fixed top-[4.25rem] left-4 z-40 p-2 bg-gray-900 text-white rounded-lg shadow-lg md:hidden"
          aria-label={t('nav.openMenu')}
        >
          <Menu className="w-6 h-6" />
        </button>

        {isMobileOpen && (
          <div
            className="fixed inset-0 bg-black/50 z-40 md:hidden"
            onClick={() => setIsMobileOpen(false)}
          />
        )}

        <aside
          className={`fixed top-14 bottom-0 left-0 z-50 w-64 bg-gray-900 text-white flex flex-col transform transition-transform duration-300 ease-in-out md:hidden ${
            isMobileOpen ? 'translate-x-0' : '-translate-x-full'
          }`}
        >
          <button
            onClick={() => setIsMobileOpen(false)}
            className="absolute top-4 right-4 p-1 text-gray-400 hover:text-white"
            aria-label={t('nav.closeMenu')}
          >
            <X className="w-6 h-6" />
          </button>
          {sidebarContent}
        </aside>
      </>
    );
  }

  return (
    <div className="relative shrink-0 h-full">
      <aside
        className={`h-full bg-gray-900 text-white flex flex-col transition-all duration-300 ease-in-out ${
          isCollapsed ? 'w-16' : 'w-64'
        }`}
      >
        {sidebarContent}
      </aside>
      <button
        onClick={toggle}
        className="absolute -right-3 top-4 z-10 h-6 w-6 rounded-full border border-gray-600 bg-gray-800 shadow-sm hover:bg-gray-700 flex items-center justify-center transition-colors"
        aria-label={isCollapsed ? t('nav.expandSidebar') : t('nav.collapseSidebar')}
        title={isCollapsed ? t('nav.expandSidebar') : t('nav.collapseSidebar')}
      >
        {isCollapsed ? (
          <ChevronRight className="h-3 w-3 text-gray-400" />
        ) : (
          <ChevronLeft className="h-3 w-3 text-gray-400" />
        )}
      </button>
    </div>
  );
}
