import { Routes, Route } from 'react-router-dom';
import Layout from './components/Layout';
import Home from './pages/Home';
import { BrandList, BrandDetails, BrandForm } from './pages/Brands';

export default function App() {
  return (
    <Routes>
      <Route path="/" element={<Layout />}>
        <Route index element={<Home />} />
        <Route path="brands" element={<BrandList />} />
        <Route path="brands/new" element={<BrandForm />} />
        <Route path="brands/:id" element={<BrandDetails />} />
        <Route path="brands/:id/edit" element={<BrandForm />} />
      </Route>
    </Routes>
  );
}
