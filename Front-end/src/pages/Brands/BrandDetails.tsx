import { useEffect, useState } from 'react';
import { useParams, Link } from 'react-router-dom';
import api from '../../services/api';
import type { BrandDetail } from '../../types';

export default function BrandDetails() {
  const { id } = useParams<{ id: string }>();
  const [brand, setBrand] = useState<BrandDetail | null>(null);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    const fetchBrand = async () => {
      try {
        const response = await api.get<BrandDetail>(`/brands/${id}`);
        setBrand(response.data);
      } catch {
        setError('Failed to load brand details');
      } finally {
        setLoading(false);
      }
    };
    fetchBrand();
  }, [id]);

  if (loading) return <div className="text-center py-8">Loading...</div>;
  if (error) return <div className="text-center py-8 text-red-600">{error}</div>;
  if (!brand) return <div className="text-center py-8">Brand not found</div>;

  return (
    <div>
      <div className="flex justify-between items-center mb-6">
        <h1 className="text-2xl font-bold">{brand.name}</h1>
        <div className="space-x-2">
          <Link
            to={`/brands/${id}/edit`}
            className="bg-blue-600 text-white px-4 py-2 rounded hover:bg-blue-700"
          >
            Edit
          </Link>
          <Link
            to="/brands"
            className="bg-gray-200 text-gray-800 px-4 py-2 rounded hover:bg-gray-300"
          >
            Back to List
          </Link>
        </div>
      </div>

      <div className="bg-white rounded-lg shadow p-6 mb-6">
        <div className="flex items-start gap-6">
          {brand.logoUrl ? (
            <img
              src={brand.logoUrl}
              alt={brand.name}
              className="h-24 w-24 object-contain"
            />
          ) : (
            <div className="h-24 w-24 bg-gray-200 rounded flex items-center justify-center">
              <span className="text-gray-500">No Logo</span>
            </div>
          )}
          <div>
            <h2 className="text-xl font-semibold mb-2">{brand.name}</h2>
            <p className="text-gray-600">Country: {brand.country}</p>
          </div>
        </div>
      </div>

      <h2 className="text-xl font-semibold mb-4">Cars from {brand.name}</h2>
      {brand.cars.length === 0 ? (
        <p className="text-gray-500">No cars available from this brand.</p>
      ) : (
        <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-4">
          {brand.cars.map((car) => (
            <Link
              key={car.id}
              to={`/cars/${car.id}`}
              className="bg-white rounded-lg shadow p-4 hover:shadow-md transition"
            >
              {car.imageUrl ? (
                <img
                  src={car.imageUrl}
                  alt={car.model}
                  className="h-40 w-full object-cover rounded mb-3"
                />
              ) : (
                <div className="h-40 bg-gray-200 rounded mb-3 flex items-center justify-center">
                  <span className="text-gray-500">No Image</span>
                </div>
              )}
              <h3 className="font-semibold">{car.model}</h3>
              <p className="text-gray-600">{car.year}</p>
              <p className="text-blue-600 font-bold">${car.price.toLocaleString()}</p>
              <span
                className={`inline-block mt-2 px-2 py-1 rounded text-xs ${
                  car.isAvailable
                    ? 'bg-green-100 text-green-800'
                    : 'bg-red-100 text-red-800'
                }`}
              >
                {car.isAvailable ? 'Available' : 'Sold'}
              </span>
            </Link>
          ))}
        </div>
      )}
    </div>
  );
}
