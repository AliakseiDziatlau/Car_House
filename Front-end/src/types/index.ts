export interface PagedResult<T> {
  items: T[];
  totalCount: number;
  page: number;
  pageSize: number;
  totalPages: number;
}

export interface Brand {
  id: string;
  name: string;
  country: string;
  logoUrl?: string;
}

export interface BrandDetail extends Brand {
  cars: CarListItem[];
}

export interface CreateBrand {
  name: string;
  country: string;
  logoUrl?: string;
}

export interface UpdateBrand {
  name: string;
  country: string;
  logoUrl?: string;
}

export interface CarListItem {
  id: string;
  brandName: string;
  model: string;
  year: number;
  price: number;
  imageUrl?: string;
  isAvailable: boolean;
}

export interface Feature {
  id: string;
  name: string;
  description?: string;
  category: string;
}

export interface CreateFeature {
  name: string;
  description?: string;
  category: string;
}

export interface UpdateFeature {
  name: string;
  description?: string;
  category: string;
}

export interface CarDetail {
  id: string;
  brandId: string;
  model: string;
  year: number;
  price: number;
  mileage: number;
  description?: string;
  imageUrl?: string;
  isAvailable: boolean;
  createdAt: string;
  brand: Brand;
  features: CarFeature[];
}

export interface CarFeature {
  featureId: string;
  featureName: string;
  category: string;
  isStandard: boolean;
  additionalPrice: number;
}

export interface CreateCar {
  brandId: string;
  model: string;
  year: number;
  price: number;
  mileage: number;
  description?: string;
  imageUrl?: string;
  isAvailable: boolean;
  features: CreateCarFeature[];
}

export interface CreateCarFeature {
  featureId: string;
  isStandard: boolean;
  additionalPrice: number;
}

export interface UpdateCar {
  brandId: string;
  model: string;
  year: number;
  price: number;
  mileage: number;
  description?: string;
  imageUrl?: string;
  isAvailable: boolean;
  features: CreateCarFeature[];
}

export interface User {
  id: string;
  email: string;
  firstName: string;
  lastName: string;
  roleName: string;
  createdAt: string;
}

export interface AuthResponse {
  token: string;
  user: User;
}

export interface LoginRequest {
  email: string;
  password: string;
}

export interface RegisterRequest {
  email: string;
  password: string;
  firstName: string;
  lastName: string;
}

export interface Order {
  id: string;
  orderDate: string;
  status: string;
  totalPrice: number;
  carModel: string;
  userEmail: string;
}

export interface OrderDetail {
  id: string;
  userId: string;
  carId: string;
  orderDate: string;
  status: string;
  totalPrice: number;
  notes?: string;
  user: User;
  car: CarListItem;
}

export interface CreateOrder {
  carId: string;
  notes?: string;
}

export interface UpdateOrderStatus {
  status: string;
}

export interface Role {
  id: string;
  name: string;
}

export interface UpdateUserRole {
  roleId: string;
}

export interface CreateUser {
  email: string;
  password: string;
  firstName: string;
  lastName: string;
  roleId: string;
}
