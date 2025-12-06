import axios from 'axios';
import { apiConfig } from '@config/index';

export type Listing = {
  id: string;
  title: string;
  description: string;
  price: number;
  stock: number;
  tags: string[];
  mediaUrls: string[];
  category: string;
  storeName: string;
  isCustomizable: boolean;
};

export const fetchListings = async (params?: { category?: string; search?: string; customizable?: boolean }) => {
  const response = await axios.get(`${apiConfig.catalogBaseUrl}/api/listings`, { params });
  return response.data as Listing[];
};

export const authenticate = async (email: string, password: string) => {
  const response = await axios.post(`${apiConfig.identityBaseUrl}/api/auth/token`, { email, password });
  return response.data as string;
};
