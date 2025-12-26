import { Link } from 'react-router-dom';

export default function Home() {
  return (
    <div className="text-center">
      <h1 className="text-4xl font-bold text-gray-800 mb-4">
        Welcome to Car House
      </h1>
      <p className="text-xl text-gray-600 mb-8">
        Find your perfect car from our premium collection
      </p>
      <div className="flex justify-center gap-4">
        <Link
          to="/cars"
          className="bg-blue-600 text-white px-6 py-3 rounded-lg hover:bg-blue-700 transition"
        >
          Browse Cars
        </Link>
        <Link
          to="/brands"
          className="bg-gray-200 text-gray-800 px-6 py-3 rounded-lg hover:bg-gray-300 transition"
        >
          View Brands
        </Link>
      </div>
    </div>
  );
}
