import { useEffect, useState } from 'react';
import { useParams, Link } from 'react-router-dom';
import { useTranslation } from 'react-i18next';
import api from '../../services/api';
import { useAuth } from '../../context/AuthContext';
import type { OrderDetail } from '../../types';

const statusColors: Record<string, string> = {
  Pending: 'bg-yellow-100 text-yellow-800',
  Approved: 'bg-blue-100 text-blue-800',
  Completed: 'bg-green-100 text-green-800',
  Cancelled: 'bg-red-100 text-red-800',
};

const statusOptions = ['Pending', 'Approved', 'Completed', 'Cancelled'];

export default function OrderDetails() {
  const { t } = useTranslation();
  const { id } = useParams<{ id: string }>();
  const { hasRole } = useAuth();
  const isManager = hasRole('Manager', 'Admin');
  const [order, setOrder] = useState<OrderDetail | null>(null);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);
  const [updating, setUpdating] = useState(false);

  useEffect(() => {
    const fetchOrder = async () => {
      try {
        const response = await api.get<OrderDetail>(`/orders/${id}`);
        setOrder(response.data);
      } catch {
        setError(t('orders.loadDetailError'));
      } finally {
        setLoading(false);
      }
    };
    fetchOrder();
  }, [id]);

  const handleStatusChange = async (newStatus: string) => {
    if (!order || newStatus === order.status) return;
    try {
      setUpdating(true);
      const response = await api.put<OrderDetail>(`/orders/${id}/status`, {
        status: newStatus,
      });
      setOrder(response.data);
    } catch {
      setError(t('orders.updateStatusError'));
    } finally {
      setUpdating(false);
    }
  };

  const formatDate = (dateString: string) => {
    return new Date(dateString).toLocaleDateString('en-US', {
      year: 'numeric',
      month: 'long',
      day: 'numeric',
      hour: '2-digit',
      minute: '2-digit',
    });
  };

  const getStatusLabel = (status: string) => {
    const key = status.toLowerCase() as 'pending' | 'approved' | 'completed' | 'cancelled';
    return t(`orders.status.${key}`);
  };

  if (loading) return <div className="text-center py-8 text-gray-400">{t('common.loading')}</div>;
  if (error) return <div className="text-center py-8 text-red-400">{error}</div>;
  if (!order) return <div className="text-center py-8 text-gray-400">{t('orders.notFound')}</div>;

  return (
    <div>
      <div className="flex justify-between items-center mb-6">
        <h1 className="text-2xl font-bold text-white">{t('orders.orderDetails')}</h1>
        <Link
          to="/orders"
          className="inline-flex items-center justify-center h-9 px-4 border border-gray-600 bg-gray-800/50 text-white text-sm font-medium rounded-md shadow-sm transition-all duration-150 outline-none hover:bg-gray-700 hover:border-gray-500 focus-visible:ring-2 focus-visible:ring-orange-500/50"
        >
          {t('orders.backToList')}
        </Link>
      </div>

      <div className="grid grid-cols-1 lg:grid-cols-2 gap-6">
        <div className="bg-gray-800 rounded-lg shadow p-6">
          <h2 className="text-xl font-semibold mb-4 text-white">{t('orders.orderInfo')}</h2>

          <div className="space-y-4">
            <div>
              <p className="text-sm text-gray-400">{t('orders.orderDate')}</p>
              <p className="font-medium text-white">{formatDate(order.orderDate)}</p>
            </div>

            <div>
              <p className="text-sm text-gray-400">{t('common.status')}</p>
              {isManager ? (
                <div className="flex items-center gap-2 mt-1">
                  <select
                    value={order.status}
                    onChange={(e) => handleStatusChange(e.target.value)}
                    disabled={updating}
                    className="px-3 py-2 border border-gray-600 bg-gray-700 text-white rounded-md focus:outline-none focus:ring-2 focus:ring-orange-500 disabled:opacity-50"
                  >
                    {statusOptions.map((status) => (
                      <option key={status} value={status}>
                        {getStatusLabel(status)}
                      </option>
                    ))}
                  </select>
                  {updating && <span className="text-sm text-gray-400">{t('common.updating')}</span>}
                </div>
              ) : (
                <span
                  className={`inline-block mt-1 px-3 py-1 rounded text-sm font-medium ${
                    statusColors[order.status] || 'bg-gray-100 text-gray-800'
                  }`}
                >
                  {getStatusLabel(order.status)}
                </span>
              )}
            </div>

            <div>
              <p className="text-sm text-gray-400">{t('common.price')}</p>
              <p className="font-bold text-orange-500 text-xl">
                ${order.totalPrice.toLocaleString()}
              </p>
            </div>

            {order.notes && (
              <div>
                <p className="text-sm text-gray-400">{t('orders.notes')}</p>
                <p className="text-gray-300">{order.notes}</p>
              </div>
            )}
          </div>
        </div>

        <div className="bg-gray-800 rounded-lg shadow p-6">
          <h2 className="text-xl font-semibold mb-4 text-white">{t('orders.carInfo')}</h2>

          <div className="flex gap-4">
            {order.car.imageUrl ? (
              <img
                src={order.car.imageUrl}
                alt={order.car.model}
                className="w-32 h-24 object-cover rounded"
              />
            ) : (
              <div className="w-32 h-24 bg-gray-700 rounded flex items-center justify-center">
                <span className="text-gray-500 text-xs">{t('common.noImage')}</span>
              </div>
            )}

            <div className="flex-1">
              <Link
                to={`/cars/${order.carId}`}
                className="text-lg font-semibold text-orange-500 hover:underline"
              >
                {order.car.brandName} {order.car.model}
              </Link>
              <p className="text-gray-400">{order.car.year}</p>
              <p className="font-medium text-white">${order.car.price.toLocaleString()}</p>
              <span
                className={`inline-block mt-1 px-2 py-0.5 rounded text-xs font-medium ${
                  order.car.isAvailable
                    ? 'bg-green-100 text-green-800'
                    : 'bg-red-100 text-red-800'
                }`}
              >
                {order.car.isAvailable ? t('common.available') : t('common.sold')}
              </span>
            </div>
          </div>
        </div>

        {isManager && (
          <div className="bg-gray-800 rounded-lg shadow p-6">
            <h2 className="text-xl font-semibold mb-4 text-white">{t('orders.customerInfo')}</h2>

            <div className="space-y-3">
              <div>
                <p className="text-sm text-gray-400">{t('common.email')}</p>
                <p className="font-medium text-white">{order.user.email}</p>
              </div>
              <div>
                <p className="text-sm text-gray-400">{t('common.name')}</p>
                <p className="font-medium text-white">
                  {order.user.firstName} {order.user.lastName}
                </p>
              </div>
              <div>
                <p className="text-sm text-gray-400">{t('users.role')}</p>
                <p className="font-medium text-white">{order.user.roleName}</p>
              </div>
              <div>
                <p className="text-sm text-gray-400">{t('users.memberSince')}</p>
                <p className="font-medium text-white">
                  {new Date(order.user.createdAt).toLocaleDateString()}
                </p>
              </div>
            </div>
          </div>
        )}
      </div>
    </div>
  );
}
