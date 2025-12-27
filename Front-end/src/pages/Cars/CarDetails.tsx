import { useEffect, useState } from 'react';
import { useParams, Link } from 'react-router-dom';
import api from '../../services/api';
import type { CarDetail } from '../../types';

export default function CarDetails() {
  const { id } = useParams<{ id: string }>();
  const [car, setCar] = useState<CarDetail | null>(null);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    const fetchCar = async () => {
      try {
        const response = await api.get<CarDetail>(`/cars/${id}`);
        setCar(response.data);
      } catch {
        setError('Failed to load car details');
      } finally {
        setLoading(false);
      }
    };
    fetchCar();
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
  if (!car) return <div className="text-center py-8">Car not found</div>;

  const totalFeaturePrice = car.features
    .filter((f) => !f.isStandard)
    .reduce((sum, f) => sum + f.additionalPrice, 0);

  return (
    <div>
      <div className="flex justify-between items-center mb-6">
        <h1 className="text-2xl font-bold">{car.brand.name} {car.model}</h1>
        <div className="space-x-2">
          <Link
            to={`/cars/${id}/edit`}
            className="bg-blue-600 text-white px-4 py-2 rounded hover:bg-blue-700"
          >
            Edit
          </Link>
          <Link
            to="/cars"
            className="bg-gray-200 text-gray-800 px-4 py-2 rounded hover:bg-gray-300"
          >
            Back to List
          </Link>
        </div>
      </div>

      <div className="grid grid-cols-1 lg:grid-cols-2 gap-6">
        <div>
          {car.imageUrl ? (
            <img
              src={car.imageUrl}
              alt={car.model}
              className="w-full h-80 object-cover rounded-lg shadow"
            />
          ) : (
            <div className="w-full h-80 bg-gray-200 rounded-lg shadow flex items-center justify-center">
              <span className="text-gray-500 text-lg">No Image Available</span>
            </div>
          )}
        </div>

        <div className="bg-white rounded-lg shadow p-6">
          <div className="flex justify-between items-start mb-4">
            <div>
              <h2 className="text-2xl font-bold">{car.model}</h2>
              <Link to={`/brands/${car.brandId}`} className="text-blue-600 hover:underline">
                {car.brand.name}
              </Link>
            </div>
            <span
              className={`px-3 py-1 rounded text-sm font-medium ${
                car.isAvailable
                  ? 'bg-green-100 text-green-800'
                  : 'bg-red-100 text-red-800'
              }`}
            >
              {car.isAvailable ? 'Available' : 'Sold'}
            </span>
          </div>

          <div className="grid grid-cols-2 gap-4 mb-6">
            <div>
              <p className="text-sm text-gray-500">Year</p>
              <p className="font-medium">{car.year}</p>
            </div>
            <div>
              <p className="text-sm text-gray-500">Mileage</p>
              <p className="font-medium">{car.mileage.toLocaleString()} km</p>
            </div>
            <div>
              <p className="text-sm text-gray-500">Base Price</p>
              <p className="font-medium">${car.price.toLocaleString()}</p>
            </div>
            <div>
              <p className="text-sm text-gray-500">Total Price</p>
              <p className="font-bold text-blue-600 text-lg">
                ${(car.price + totalFeaturePrice).toLocaleString()}
              </p>
            </div>
          </div>

          {car.description && (
            <div className="mb-6">
              <p className="text-sm text-gray-500 mb-1">Description</p>
              <p className="text-gray-700">{car.description}</p>
            </div>
          )}
        </div>
      </div>

      <div className="mt-6 bg-white rounded-lg shadow p-6">
        <h3 className="text-xl font-semibold mb-4">Features</h3>
        {car.features.length === 0 ? (
          <p className="text-gray-500">No features listed for this car.</p>
        ) : (
          <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-4">
            {car.features.map((feature) => (
              <div
                key={feature.featureId}
                className="border rounded-lg p-4 flex justify-between items-start"
              >
                <div>
                  <p className="font-medium">{feature.featureName}</p>
                  <span className={`inline-block mt-1 px-2 py-0.5 rounded text-xs ${getCategoryColor(feature.category)}`}>
                    {feature.category}
                  </span>
                </div>
                <div className="text-right">
                  {feature.isStandard ? (
                    <span className="text-green-600 text-sm font-medium">Included</span>
                  ) : (
                    <span className="text-blue-600 font-medium">
                      +${feature.additionalPrice.toLocaleString()}
                    </span>
                  )}
                </div>
              </div>
            ))}
          </div>
        )}
      </div>
    </div>
  );
}
