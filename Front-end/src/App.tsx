import { Routes, Route } from 'react-router-dom';
import Layout from './components/Layout';
import Home from './pages/Home';
import { BrandList, BrandDetails, BrandForm } from './pages/Brands';
import { FeatureList, FeatureDetails, FeatureForm } from './pages/Features';
import { CarList, CarDetails, CarForm } from './pages/Cars';

export default function App() {
  return (
    <Routes>
      <Route path="/" element={<Layout />}>
        <Route index element={<Home />} />
        <Route path="brands" element={<BrandList />} />
        <Route path="brands/new" element={<BrandForm />} />
        <Route path="brands/:id" element={<BrandDetails />} />
        <Route path="brands/:id/edit" element={<BrandForm />} />
        <Route path="features" element={<FeatureList />} />
        <Route path="features/new" element={<FeatureForm />} />
        <Route path="features/:id" element={<FeatureDetails />} />
        <Route path="features/:id/edit" element={<FeatureForm />} />
        <Route path="cars" element={<CarList />} />
        <Route path="cars/new" element={<CarForm />} />
        <Route path="cars/:id" element={<CarDetails />} />
        <Route path="cars/:id/edit" element={<CarForm />} />
      </Route>
    </Routes>
  );
}
