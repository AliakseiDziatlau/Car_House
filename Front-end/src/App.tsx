import { Routes, Route } from 'react-router-dom';
import Layout from './components/Layout';
import ProtectedRoute from './components/ProtectedRoute';
import Home from './pages/Home';
import { BrandList, BrandDetails, BrandForm } from './pages/Brands';
import { FeatureList, FeatureDetails, FeatureForm } from './pages/Features';
import { CarList, CarDetails, CarForm } from './pages/Cars';
import { OrderList, OrderDetails, OrderForm } from './pages/Orders';
import { UserList, UserForm } from './pages/Users';
import { Login, Register } from './pages/Auth';

export default function App() {
  return (
    <Routes>
      <Route path="/" element={<Layout />}>
        <Route index element={<Home />} />
        <Route path="login" element={<Login />} />
        <Route path="register" element={<Register />} />
        <Route path="brands" element={<BrandList />} />
        <Route
          path="brands/new"
          element={
            <ProtectedRoute roles={['Manager', 'Admin']}>
              <BrandForm />
            </ProtectedRoute>
          }
        />
        <Route path="brands/:id" element={<BrandDetails />} />
        <Route
          path="brands/:id/edit"
          element={
            <ProtectedRoute roles={['Manager', 'Admin']}>
              <BrandForm />
            </ProtectedRoute>
          }
        />
        <Route path="features" element={<FeatureList />} />
        <Route
          path="features/new"
          element={
            <ProtectedRoute roles={['Manager', 'Admin']}>
              <FeatureForm />
            </ProtectedRoute>
          }
        />
        <Route path="features/:id" element={<FeatureDetails />} />
        <Route
          path="features/:id/edit"
          element={
            <ProtectedRoute roles={['Manager', 'Admin']}>
              <FeatureForm />
            </ProtectedRoute>
          }
        />
        <Route path="cars" element={<CarList />} />
        <Route
          path="cars/new"
          element={
            <ProtectedRoute roles={['Manager', 'Admin']}>
              <CarForm />
            </ProtectedRoute>
          }
        />
        <Route path="cars/:id" element={<CarDetails />} />
        <Route
          path="cars/:id/edit"
          element={
            <ProtectedRoute roles={['Manager', 'Admin']}>
              <CarForm />
            </ProtectedRoute>
          }
        />
        <Route
          path="orders"
          element={
            <ProtectedRoute>
              <OrderList />
            </ProtectedRoute>
          }
        />
        <Route
          path="orders/new"
          element={
            <ProtectedRoute>
              <OrderForm />
            </ProtectedRoute>
          }
        />
        <Route
          path="orders/:id"
          element={
            <ProtectedRoute>
              <OrderDetails />
            </ProtectedRoute>
          }
        />
        <Route
          path="users"
          element={
            <ProtectedRoute roles={['Admin']}>
              <UserList />
            </ProtectedRoute>
          }
        />
        <Route
          path="users/new"
          element={
            <ProtectedRoute roles={['Admin']}>
              <UserForm />
            </ProtectedRoute>
          }
        />
      </Route>
    </Routes>
  );
}
