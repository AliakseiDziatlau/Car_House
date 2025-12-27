import { useEffect, useState } from 'react';
import { Link, useSearchParams } from 'react-router-dom';
import api from '../../services/api';
import Pagination from '../../components/Pagination';
import type { CarListItem, Brand, PagedResult } from '../../types';

export default function CarList() {
  const [searchParams, setSearchParams] = useSearchParams();
  const [cars, setCars] = useState<CarListItem[]>([]);
  const [brands, setBrands] = useState<Brand[]>([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);
  const [page, setPage] = useState(1);
  const [totalPages, setTotalPages] = useState(1);
  const [selectedBrand, setSelectedBrand] = useState<string>(searchParams.get('brandId') || '');

  useEffect(() => {
    fetchBrands();
  }, []);

  useEffect(() => {
    fetchCars();
  }, [page, selectedBrand]);

  const fetchBrands = async () => {
    try {
      const response = await api.get<PagedResult<Brand>>('/brands', {
        params: { pageSize: 100 },
      });
      setBrands(response.data.items);
    } catch {
      console.error('Failed to load brands');
    }
  };

  const fetchCars = async () => {
    try {
      setLoading(true);
      const params: Record<string, string | number> = { page, pageSize: 9 };
      if (selectedBrand) {
        params.brandId = selectedBrand;
      }
      const response = await api.get<PagedResult<CarListItem>>('/cars', { params });
      setCars(response.data.items);
      setTotalPages(response.data.totalPages);
    } catch {
      setError('Failed to load cars');
    } finally {
      setLoading(false);
    }
  };

  const handleBrandFilter = (brandId: string) => {
    setSelectedBrand(brandId);
    setPage(1);
    if (brandId) {
      setSearchParams({ brandId });
    } else {
      setSearchParams({});
    }
  };

  const handleDelete = async (id: string) => {
    if (!confirm('Are you sure you want to delete this car?')) return;
    try {
      await api.delete(`/cars/${id}`);
      fetchCars();
    } catch {
      setError('Failed to delete car');
    }
  };

  if (loading && cars.length === 0) return <div className="text-center py-8">Loading...</div>;
  if (error) return <div className="text-center py-8 text-red-600">{error}</div>;

  return (
    <div>
      <div className="flex justify-between items-center mb-6">
        <h1 className="text-2xl font-bold">Cars</h1>
        <Link
          to="/cars/new"
          className="bg-blue-600 text-white px-4 py-2 rounded hover:bg-blue-700"
        >
          Add Car
        </Link>
      </div>

      <div className="mb-6">
        <label htmlFor="brandFilter" className="block text-sm font-medium text-gray-700 mb-1">
          Filter by Brand
        </label>
        <select
          id="brandFilter"
          value={selectedBrand}
          onChange={(e) => handleBrandFilter(e.target.value)}
          className="w-full md:w-64 px-3 py-2 border border-gray-300 rounded-md focus:outline-none focus:ring-2 focus:ring-blue-500"
        >
          <option value="">All Brands</option>
          {brands.map((brand) => (
            <option key={brand.id} value={brand.id}>
              {brand.name}
            </option>
          ))}
        </select>
      </div>

      {cars.length === 0 ? (
        <p className="text-center py-8 text-gray-500">No cars found.</p>
      ) : (
        <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-6">
          {cars.map((car) => (
            <div key={car.id} className="bg-white rounded-lg shadow overflow-hidden">
              {car.imageUrl ? (
                <img
                  src={car.imageUrl}
                  alt={car.model}
                  className="h-48 w-full object-cover"
                />
              ) : (
                <div className="h-48 bg-gray-200 flex items-center justify-center">
                  <span className="text-gray-500">No Image</span>
                </div>
              )}
              <div className="p-4">
                <div className="flex justify-between items-start mb-2">
                  <div>
                    <h3 className="font-semibold text-lg">{car.model}</h3>
                    <p className="text-gray-600">{car.brandName} • {car.year}</p>
                  </div>
                  <span
                    className={`px-2 py-1 rounded text-xs font-medium ${
                      car.isAvailable
                        ? 'bg-green-100 text-green-800'
                        : 'bg-red-100 text-red-800'
                    }`}
                  >
                    {car.isAvailable ? 'Available' : 'Sold'}
                  </span>
                </div>
                <p className="text-blue-600 font-bold text-xl mb-4">
                  ${car.price.toLocaleString()}
                </p>
                <div className="flex gap-2">
                  <Link
                    to={`/cars/${car.id}`}
                    className="flex-1 text-center bg-blue-600 text-white py-2 rounded hover:bg-blue-700"
                  >
                    View
                  </Link>
                  <Link
                    to={`/cars/${car.id}/edit`}
                    className="flex-1 text-center bg-gray-200 text-gray-800 py-2 rounded hover:bg-gray-300"
                  >
                    Edit
                  </Link>
                  <button
                    onClick={() => handleDelete(car.id)}
                    className="px-4 py-2 bg-red-100 text-red-600 rounded hover:bg-red-200"
                  >
                    Delete
                  </button>
                </div>
              </div>
            </div>
          ))}
        </div>
      )}

      <Pagination currentPage={page} totalPages={totalPages} onPageChange={setPage} />
    </div>
  );
}
