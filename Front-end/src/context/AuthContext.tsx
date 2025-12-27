import { createContext, useContext, useState, useEffect, type ReactNode } from 'react';
import api from '../services/api';
import type { User, AuthResponse, LoginRequest, RegisterRequest } from '../types';

interface AuthContextType {
  user: User | null;
  isLoading: boolean;
  isAuthenticated: boolean;
  login: (data: LoginRequest) => Promise<void>;
  register: (data: RegisterRequest) => Promise<void>;
  logout: () => void;
  hasRole: (...roles: string[]) => boolean;
}

const AuthContext = createContext<AuthContextType | null>(null);

export function AuthProvider({ children }: { children: ReactNode }) {
  const [user, setUser] = useState<User | null>(null);
  const [isLoading, setIsLoading] = useState(true);

  useEffect(() => {
    const token = localStorage.getItem('token');
    const storedUser = localStorage.getItem('user');
    if (token && storedUser) {
      setUser(JSON.parse(storedUser));
    }
    setIsLoading(false);
  }, []);

  const login = async (data: LoginRequest) => {
    const response = await api.post<AuthResponse>('/auth/login', data);
    localStorage.setItem('token', response.data.token);
    localStorage.setItem('user', JSON.stringify(response.data.user));
    setUser(response.data.user);
  };

  const register = async (data: RegisterRequest) => {
    const response = await api.post<AuthResponse>('/auth/register', data);
    localStorage.setItem('token', response.data.token);
    localStorage.setItem('user', JSON.stringify(response.data.user));
    setUser(response.data.user);
  };

  const logout = () => {
    localStorage.removeItem('token');
    localStorage.removeItem('user');
    setUser(null);
  };

  const isAuthenticated = user !== null;

  const hasRole = (...roles: string[]) => {
    if (!user) return false;
    return roles.includes(user.roleName);
  };

  return (
    <AuthContext.Provider
      value={{ user, isLoading, isAuthenticated, login, register, logout, hasRole }}
    >
      {children}
    </AuthContext.Provider>
  );
}

export function useAuth() {
  const context = useContext(AuthContext);
  if (!context) {
    throw new Error('useAuth must be used within an AuthProvider');
  }
  return context;
}
