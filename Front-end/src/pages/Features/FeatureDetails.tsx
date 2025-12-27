import { useEffect, useState } from 'react';
import { useParams, Link } from 'react-router-dom';
import api from '../../services/api';
import type { Feature } from '../../types';

export default function FeatureDetails() {
  const { id } = useParams<{ id: string }>();
  const [feature, setFeature] = useState<Feature | null>(null);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    const fetchFeature = async () => {
      try {
        const response = await api.get<Feature>(`/features/${id}`);
        setFeature(response.data);
      } catch {
        setError('Failed to load feature details');
      } finally {
        setLoading(false);
      }
    };
    fetchFeature();
  }, [id]);

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
  if (!feature) return <div className="text-center py-8">Feature not found</div>;

  return (
    <div>
      <div className="flex justify-between items-center mb-6">
        <h1 className="text-2xl font-bold">{feature.name}</h1>
        <div className="space-x-2">
          <Link
            to={`/features/${id}/edit`}
            className="bg-blue-600 text-white px-4 py-2 rounded hover:bg-blue-700"
          >
            Edit
          </Link>
          <Link
            to="/features"
            className="bg-gray-200 text-gray-800 px-4 py-2 rounded hover:bg-gray-300"
          >
            Back to List
          </Link>
        </div>
      </div>

      <div className="bg-white rounded-lg shadow p-6">
        <div className="grid grid-cols-1 md:grid-cols-2 gap-6">
          <div>
            <h3 className="text-sm font-medium text-gray-500 mb-1">Name</h3>
            <p className="text-lg">{feature.name}</p>
          </div>
          <div>
            <h3 className="text-sm font-medium text-gray-500 mb-1">Category</h3>
            <span className={`px-3 py-1 rounded text-sm font-medium ${getCategoryColor(feature.category)}`}>
              {feature.category}
            </span>
          </div>
          <div className="md:col-span-2">
            <h3 className="text-sm font-medium text-gray-500 mb-1">Description</h3>
            <p className="text-gray-700">{feature.description || 'No description provided'}</p>
          </div>
        </div>
      </div>
    </div>
  );
}
