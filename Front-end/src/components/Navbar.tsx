import { Link } from 'react-router-dom';

export default function Navbar() {
  return (
    <nav className="bg-gray-800 text-white shadow-lg">
      <div className="max-w-7xl mx-auto px-4">
        <div className="flex justify-between h-16">
          <div className="flex items-center">
            <Link to="/" className="text-xl font-bold">
              Car House
            </Link>
            <div className="ml-10 flex space-x-4">
              <Link to="/cars" className="hover:bg-gray-700 px-3 py-2 rounded-md">
                Cars
              </Link>
              <Link to="/brands" className="hover:bg-gray-700 px-3 py-2 rounded-md">
                Brands
              </Link>
              <Link to="/features" className="hover:bg-gray-700 px-3 py-2 rounded-md">
                Features
              </Link>
            </div>
          </div>
          <div className="flex items-center space-x-4">
            <Link to="/login" className="hover:bg-gray-700 px-3 py-2 rounded-md">
              Login
            </Link>
            <Link
              to="/register"
              className="bg-blue-600 hover:bg-blue-700 px-4 py-2 rounded-md"
            >
              Register
            </Link>
          </div>
        </div>
      </div>
    </nav>
  );
}
