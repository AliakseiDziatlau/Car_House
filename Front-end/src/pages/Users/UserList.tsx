import { useEffect, useState } from 'react';
import { Link } from 'react-router-dom';
import { useTranslation } from 'react-i18next';
import api from '../../services/api';
import Pagination from '../../components/Pagination';
import type { User, Role, PagedResult } from '../../types';

export default function UserList() {
  const { t } = useTranslation();
  const [users, setUsers] = useState<User[]>([]);
  const [roles, setRoles] = useState<Role[]>([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);
  const [page, setPage] = useState(1);
  const [totalPages, setTotalPages] = useState(1);
  const [updatingUserId, setUpdatingUserId] = useState<string | null>(null);

  useEffect(() => {
    fetchRoles();
  }, []);

  useEffect(() => {
    fetchUsers();
  }, [page]);

  const fetchRoles = async () => {
    try {
      const response = await api.get<Role[]>('/roles');
      setRoles(response.data);
    } catch {
      console.error('Failed to load roles');
    }
  };

  const fetchUsers = async () => {
    try {
      setLoading(true);
      const response = await api.get<PagedResult<User>>('/users', {
        params: { page, pageSize: 10 },
      });
      setUsers(response.data.items);
      setTotalPages(response.data.totalPages);
    } catch {
      setError(t('users.loadError'));
    } finally {
      setLoading(false);
    }
  };

  const handleRoleChange = async (userId: string, newRoleId: string, currentRoleName: string) => {
    const newRole = roles.find((r) => r.id === newRoleId);
    if (!newRole || newRole.name === currentRoleName) return;

    if (!confirm(t('users.changeRoleConfirm', { role: newRole.name }))) {
      return;
    }

    try {
      setUpdatingUserId(userId);
      await api.put(`/users/${userId}/role`, { roleId: newRoleId });
      setUsers((prev) =>
        prev.map((user) =>
          user.id === userId ? { ...user, roleName: newRole.name } : user
        )
      );
    } catch {
      setError(t('users.updateRoleError'));
    } finally {
      setUpdatingUserId(null);
    }
  };

  const formatDate = (dateString: string) => {
    return new Date(dateString).toLocaleDateString('en-US', {
      year: 'numeric',
      month: 'short',
      day: 'numeric',
    });
  };

  if (loading && users.length === 0) return <div className="text-center py-8 text-gray-400">{t('common.loading')}</div>;
  if (error) return <div className="text-center py-8 text-red-400">{error}</div>;

  return (
    <div>
      <div className="flex justify-between items-center mb-6">
        <h1 className="text-2xl font-bold text-white">{t('users.title')}</h1>
        <Link
          to="/users/new"
          className="px-4 py-2 bg-orange-500 text-white rounded-md hover:bg-orange-600 transition-colors"
        >
          {t('users.addUser')}
        </Link>
      </div>

      {users.length === 0 ? (
        <p className="text-center py-8 text-gray-400">{t('users.noUsers')}</p>
      ) : (
        <div className="overflow-x-auto bg-gray-800 rounded-lg shadow">
          <table className="min-w-full divide-y divide-gray-700">
            <thead className="bg-gray-900">
              <tr>
                <th className="px-6 py-3 text-left text-xs font-medium text-gray-400 uppercase tracking-wider">
                  {t('common.name')}
                </th>
                <th className="px-6 py-3 text-left text-xs font-medium text-gray-400 uppercase tracking-wider">
                  {t('common.email')}
                </th>
                <th className="px-6 py-3 text-left text-xs font-medium text-gray-400 uppercase tracking-wider">
                  {t('users.role')}
                </th>
                <th className="px-6 py-3 text-left text-xs font-medium text-gray-400 uppercase tracking-wider">
                  {t('users.created')}
                </th>
              </tr>
            </thead>
            <tbody className="bg-gray-800 divide-y divide-gray-700">
              {users.map((user) => (
                <tr key={user.id} className="hover:bg-gray-700">
                  <td className="px-6 py-4 whitespace-nowrap">
                    <div className="text-sm font-medium text-white">
                      {user.firstName} {user.lastName}
                    </div>
                  </td>
                  <td className="px-6 py-4 whitespace-nowrap text-sm text-gray-400">
                    {user.email}
                  </td>
                  <td className="px-6 py-4 whitespace-nowrap">
                    <select
                      value={roles.find((r) => r.name === user.roleName)?.id || ''}
                      onChange={(e) => handleRoleChange(user.id, e.target.value, user.roleName)}
                      disabled={updatingUserId === user.id}
                      className="px-2 py-1 border border-gray-600 bg-gray-700 text-white rounded-md text-sm focus:outline-none focus:ring-2 focus:ring-orange-500 disabled:opacity-50"
                    >
                      {roles.map((role) => (
                        <option key={role.id} value={role.id}>
                          {role.name}
                        </option>
                      ))}
                    </select>
                    {updatingUserId === user.id && (
                      <span className="ml-2 text-sm text-gray-400">{t('common.updating')}</span>
                    )}
                  </td>
                  <td className="px-6 py-4 whitespace-nowrap text-sm text-gray-400">
                    {formatDate(user.createdAt)}
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
