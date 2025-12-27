import { Link } from 'react-router-dom';
import { useAuth } from '../context/AuthContext';

export default function Navbar() {
  const { user, isAuthenticated, logout, hasRole } = useAuth();

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
              {isAuthenticated && (
                <Link to="/orders" className="hover:bg-gray-700 px-3 py-2 rounded-md">
                  Orders
                </Link>
              )}
              {hasRole('Admin') && (
                <Link to="/users" className="hover:bg-gray-700 px-3 py-2 rounded-md">
                  Users
                </Link>
              )}
            </div>
          </div>
          <div className="flex items-center space-x-4">
            {isAuthenticated ? (
              <>
                <span className="text-gray-300">
                  {user?.firstName} {user?.lastName}
                </span>
                <button
                  onClick={logout}
                  className="hover:bg-gray-700 px-3 py-2 rounded-md"
                >
                  Logout
                </button>
              </>
            ) : (
              <>
                <Link to="/login" className="hover:bg-gray-700 px-3 py-2 rounded-md">
                  Login
                </Link>
                <Link
                  to="/register"
                  className="bg-blue-600 hover:bg-blue-700 px-4 py-2 rounded-md"
                >
                  Register
                </Link>
              </>
            )}
          </div>
        </div>
      </div>
    </nav>
  );
}
