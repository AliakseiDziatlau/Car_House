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
