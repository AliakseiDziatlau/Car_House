import { useEffect, useState } from 'react';
import { Link } from 'react-router-dom';
import api from '../../services/api';
import Pagination from '../../components/Pagination';
import type { Feature, PagedResult } from '../../types';

export default function FeatureList() {
  const [features, setFeatures] = useState<Feature[]>([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);
  const [page, setPage] = useState(1);
  const [totalPages, setTotalPages] = useState(1);

  useEffect(() => {
    fetchFeatures();
  }, [page]);

  const fetchFeatures = async () => {
    try {
      setLoading(true);
      const response = await api.get<PagedResult<Feature>>('/features', {
        params: { page, pageSize: 10 },
      });
      setFeatures(response.data.items);
      setTotalPages(response.data.totalPages);
    } catch {
      setError('Failed to load features');
    } finally {
      setLoading(false);
    }
  };

  const handleDelete = async (id: string) => {
    if (!confirm('Are you sure you want to delete this feature?')) return;
    try {
      await api.delete(`/features/${id}`);
      fetchFeatures();
    } catch {
      setError('Failed to delete feature');
    }
  };

  const getCategoryColor = (category: string) => {
    const colors: Record<string, string> = {
      Safety: 'bg-red-100 text-red-800',
      Comfort: 'bg-blue-100 text-blue-800',
      Technology: 'bg-purple-100 text-purple-800',
      Performance: 'bg-orange-100 text-orange-800',
    };
    return colors[category] || 'bg-gray-100 text-gray-800';
  };

  if (loading) return <div className="text-center py-8">Loading...</div>;
  if (error) return <div className="text-center py-8 text-red-600">{error}</div>;

  return (
    <div>
      <div className="flex justify-between items-center mb-6">
        <h1 className="text-2xl font-bold">Features</h1>
        <Link
          to="/features/new"
          className="bg-blue-600 text-white px-4 py-2 rounded hover:bg-blue-700"
        >
          Add Feature
        </Link>
      </div>

      <div className="bg-white rounded-lg shadow overflow-hidden">
        <table className="min-w-full divide-y divide-gray-200">
          <thead className="bg-gray-50">
            <tr>
              <th className="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">
                Name
              </th>
              <th className="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">
                Category
              </th>
              <th className="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">
                Description
              </th>
              <th className="px-6 py-3 text-right text-xs font-medium text-gray-500 uppercase tracking-wider">
                Actions
              </th>
            </tr>
          </thead>
          <tbody className="bg-white divide-y divide-gray-200">
            {features.map((feature) => (
              <tr key={feature.id} className="hover:bg-gray-50">
                <td className="px-6 py-4 whitespace-nowrap">
                  <Link
                    to={`/features/${feature.id}`}
                    className="text-blue-600 hover:underline font-medium"
                  >
                    {feature.name}
                  </Link>
                </td>
                <td className="px-6 py-4 whitespace-nowrap">
                  <span className={`px-2 py-1 rounded text-xs font-medium ${getCategoryColor(feature.category)}`}>
                    {feature.category}
                  </span>
                </td>
                <td className="px-6 py-4 text-gray-500 max-w-xs truncate">
                  {feature.description || '-'}
                </td>
                <td className="px-6 py-4 whitespace-nowrap text-right">
                  <Link
                    to={`/features/${feature.id}/edit`}
                    className="text-blue-600 hover:underline mr-4"
                  >
                    Edit
                  </Link>
                  <button
                    onClick={() => handleDelete(feature.id)}
                    className="text-red-600 hover:underline"
                  >
                    Delete
                  </button>
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>

      <Pagination currentPage={page} totalPages={totalPages} onPageChange={setPage} />
    </div>
  );
}
