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
