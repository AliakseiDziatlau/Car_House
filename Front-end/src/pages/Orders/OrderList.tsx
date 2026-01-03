import { useEffect, useState } from 'react';
import { Link } from 'react-router-dom';
import { useTranslation } from 'react-i18next';
import api from '../../services/api';
import Pagination from '../../components/Pagination';
import { useAuth } from '../../context/AuthContext';
import type { Order, PagedResult } from '../../types';

const statusColors: Record<string, string> = {
  Pending: 'bg-yellow-100 text-yellow-800',
  Approved: 'bg-blue-100 text-blue-800',
  Completed: 'bg-green-100 text-green-800',
  Cancelled: 'bg-red-100 text-red-800',
};

export default function OrderList() {
  const { t } = useTranslation();
  const { hasRole } = useAuth();
  const isManager = hasRole('Manager', 'Admin');
  const [orders, setOrders] = useState<Order[]>([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);
  const [page, setPage] = useState(1);
  const [totalPages, setTotalPages] = useState(1);

  useEffect(() => {
    fetchOrders();
  }, [page]);

  const fetchOrders = async () => {
    try {
      setLoading(true);
      const response = await api.get<PagedResult<Order>>('/orders', {
        params: { page, pageSize: 10 },
      });
      setOrders(response.data.items);
      setTotalPages(response.data.totalPages);
    } catch {
      setError(t('orders.loadError'));
    } finally {
      setLoading(false);
    }
  };

  const handleDelete = async (id: string) => {
    if (!confirm(t('orders.deleteConfirm'))) return;
    try {
      await api.delete(`/orders/${id}`);
      fetchOrders();
    } catch {
      setError(t('orders.deleteError'));
    }
  };

  const formatDate = (dateString: string) => {
    return new Date(dateString).toLocaleDateString('en-US', {
      year: 'numeric',
      month: 'short',
      day: 'numeric',
      hour: '2-digit',
      minute: '2-digit',
    });
  };

  const getStatusLabel = (status: string) => {
    const key = status.toLowerCase() as 'pending' | 'approved' | 'completed' | 'cancelled';
    return t(`orders.status.${key}`);
  };

  if (loading && orders.length === 0) return <div className="text-center py-8 text-gray-400">{t('common.loading')}</div>;
  if (error) return <div className="text-center py-8 text-red-400">{error}</div>;

  return (
    <div>
      <div className="flex justify-between items-center mb-6">
        <h1 className="text-2xl font-bold text-white">{t('orders.title')}</h1>
        <Link
          to="/orders/new"
          className="inline-flex items-center justify-center h-9 px-4 bg-orange-500 text-white text-sm font-medium rounded-md shadow-sm transition-all duration-150 outline-none hover:bg-orange-600 focus-visible:ring-2 focus-visible:ring-orange-500/50"
        >
          {t('orders.placeOrder')}
        </Link>
      </div>

      {orders.length === 0 ? (
        <p className="text-center py-8 text-gray-400">{t('orders.noOrders')}</p>
      ) : (
        <div className="overflow-x-auto bg-gray-800 rounded-lg shadow">
          <table className="min-w-full divide-y divide-gray-700">
            <thead className="bg-gray-900">
              <tr>
                <th className="px-6 py-3 text-left text-xs font-medium text-gray-400 uppercase tracking-wider">
                  {t('orders.orderDate')}
                </th>
                <th className="px-6 py-3 text-left text-xs font-medium text-gray-400 uppercase tracking-wider">
                  {t('orders.car')}
                </th>
                <th className="px-6 py-3 text-left text-xs font-medium text-gray-400 uppercase tracking-wider">
                  {t('common.status')}
                </th>
                <th className="px-6 py-3 text-left text-xs font-medium text-gray-400 uppercase tracking-wider">
                  {t('common.price')}
                </th>
                {isManager && (
                  <th className="px-6 py-3 text-left text-xs font-medium text-gray-400 uppercase tracking-wider">
                    {t('orders.customer')}
                  </th>
                )}
                <th className="px-6 py-3 text-left text-xs font-medium text-gray-400 uppercase tracking-wider">
                  {t('common.actions')}
                </th>
              </tr>
            </thead>
            <tbody className="bg-gray-800 divide-y divide-gray-700">
              {orders.map((order) => (
                <tr key={order.id} className="hover:bg-gray-700">
                  <td className="px-6 py-4 whitespace-nowrap text-sm text-gray-300">
                    {formatDate(order.orderDate)}
                  </td>
                  <td className="px-6 py-4 whitespace-nowrap text-sm text-white">
                    {order.carModel}
                  </td>
                  <td className="px-6 py-4 whitespace-nowrap">
                    <span
                      className={`px-2 py-1 rounded text-xs font-medium ${
                        statusColors[order.status] || 'bg-gray-100 text-gray-800'
                      }`}
                    >
                      {getStatusLabel(order.status)}
                    </span>
                  </td>
                  <td className="px-6 py-4 whitespace-nowrap text-sm text-orange-500 font-medium">
                    ${order.totalPrice.toLocaleString()}
                  </td>
                  {isManager && (
                    <td className="px-6 py-4 whitespace-nowrap text-sm text-gray-400">
                      {order.userEmail}
                    </td>
                  )}
                  <td className="px-6 py-4 whitespace-nowrap text-sm space-x-2">
                    <Link
                      to={`/orders/${order.id}`}
                      className="inline-flex items-center justify-center h-8 px-3 text-sm font-medium text-orange-500 rounded-md transition-all duration-150 outline-none hover:bg-orange-500/10 focus-visible:ring-2 focus-visible:ring-orange-500/50"
                    >
                      {t('common.view')}
                    </Link>
                    <button
                      onClick={() => handleDelete(order.id)}
                      className="inline-flex items-center justify-center h-8 px-3 text-sm font-medium text-red-400 rounded-md transition-all duration-150 outline-none hover:bg-red-500/10 focus-visible:ring-2 focus-visible:ring-red-500/50"
                    >
                      {t('common.delete')}
                    </button>
                  </td>
                </tr>
              ))}
            </tbody>
          </table>
        </div>
      )}

      <Pagination currentPage={page} totalPages={totalPages} onPageChange={setPage} />
    </div>
  );
}
