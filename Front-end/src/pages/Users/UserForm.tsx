import { useEffect, useState } from 'react';
import { useNavigate, Link } from 'react-router-dom';
import { useForm } from 'react-hook-form';
import { zodResolver } from '@hookform/resolvers/zod';
import { z } from 'zod';
import { useTranslation } from 'react-i18next';
import api from '../../services/api';
import type { Role } from '../../types';

const userSchema = z.object({
  email: z.string().min(1, 'Email is required').email('Invalid email format').max(256, 'Email cannot exceed 256 characters'),
  password: z
    .string()
    .min(6, 'Password must be at least 6 characters')
    .regex(/[A-Z]/, 'Password must contain at least one uppercase letter')
    .regex(/[a-z]/, 'Password must contain at least one lowercase letter')
    .regex(/[0-9]/, 'Password must contain at least one digit'),
  firstName: z.string().min(1, 'First name is required').max(100, 'First name cannot exceed 100 characters'),
  lastName: z.string().min(1, 'Last name is required').max(100, 'Last name cannot exceed 100 characters'),
  roleId: z.string().min(1, 'Role is required'),
});

type UserFormData = z.infer<typeof userSchema>;

export default function UserForm() {
  const { t } = useTranslation();
  const navigate = useNavigate();
  const [roles, setRoles] = useState<Role[]>([]);
  const [serverError, setServerError] = useState<string | null>(null);

  const {
    register,
    handleSubmit,
    formState: { errors, isSubmitting },
  } = useForm<UserFormData>({
    resolver: zodResolver(userSchema),
    defaultValues: {
      email: '',
      password: '',
      firstName: '',
      lastName: '',
      roleId: '',
    },
  });

  useEffect(() => {
    api.get<Role[]>('/roles').then((response) => {
      setRoles(response.data);
    });
  }, []);

  const onSubmit = async (data: UserFormData) => {
    try {
      setServerError(null);
      await api.post('/users', data);
      navigate('/users');
    } catch (error: unknown) {
      const err = error as { response?: { status?: number } };
      if (err.response?.status === 409) {
        setServerError(t('users.emailExists'));
      } else {
        setServerError(t('users.saveError'));
      }
    }
  };

  return (
    <div className="max-w-lg mx-auto">
      <div className="mb-6">
        <Link to="/users" className="text-orange-500 hover:text-orange-400 text-sm">
          &larr; {t('users.backToList')}
        </Link>
      </div>

      <h1 className="text-2xl font-bold mb-6 text-white">{t('users.createUser')}</h1>

      {serverError && (
        <div className="mb-4 p-3 bg-red-900/50 border border-red-700 rounded-md text-red-400 text-sm">
          {serverError}
        </div>
      )}

      <form onSubmit={handleSubmit(onSubmit)} className="bg-gray-800 rounded-lg shadow p-6">
        <div className="mb-4">
          <label htmlFor="email" className="block text-sm font-medium text-gray-300 mb-1">
            {t('auth.email')}
          </label>
          <input
            type="email"
            id="email"
            {...register('email')}
            className="w-full h-10 px-3 py-2 border border-gray-600 bg-gray-700/50 text-white rounded-md shadow-sm transition-all duration-150 outline-none focus:border-orange-500 focus:ring-2 focus:ring-orange-500/30 placeholder:text-gray-500"
          />
          {errors.email && <p className="mt-1 text-sm text-red-400">{errors.email.message}</p>}
        </div>

        <div className="mb-4">
          <label htmlFor="password" className="block text-sm font-medium text-gray-300 mb-1">
            {t('auth.password')}
          </label>
          <input
            type="password"
            id="password"
            {...register('password')}
            className="w-full h-10 px-3 py-2 border border-gray-600 bg-gray-700/50 text-white rounded-md shadow-sm transition-all duration-150 outline-none focus:border-orange-500 focus:ring-2 focus:ring-orange-500/30 placeholder:text-gray-500"
          />
          {errors.password && <p className="mt-1 text-sm text-red-400">{errors.password.message}</p>}
        </div>

        <div className="mb-4">
          <label htmlFor="firstName" className="block text-sm font-medium text-gray-300 mb-1">
            {t('auth.firstName')}
          </label>
          <input
            type="text"
            id="firstName"
            {...register('firstName')}
            className="w-full h-10 px-3 py-2 border border-gray-600 bg-gray-700/50 text-white rounded-md shadow-sm transition-all duration-150 outline-none focus:border-orange-500 focus:ring-2 focus:ring-orange-500/30 placeholder:text-gray-500"
          />
          {errors.firstName && <p className="mt-1 text-sm text-red-400">{errors.firstName.message}</p>}
        </div>

        <div className="mb-4">
          <label htmlFor="lastName" className="block text-sm font-medium text-gray-300 mb-1">
            {t('auth.lastName')}
          </label>
          <input
            type="text"
            id="lastName"
            {...register('lastName')}
            className="w-full h-10 px-3 py-2 border border-gray-600 bg-gray-700/50 text-white rounded-md shadow-sm transition-all duration-150 outline-none focus:border-orange-500 focus:ring-2 focus:ring-orange-500/30 placeholder:text-gray-500"
          />
          {errors.lastName && <p className="mt-1 text-sm text-red-400">{errors.lastName.message}</p>}
        </div>

        <div className="mb-6">
          <label htmlFor="roleId" className="block text-sm font-medium text-gray-300 mb-1">
            {t('users.role')}
          </label>
          <select
            id="roleId"
            {...register('roleId')}
            className="w-full h-10 px-3 py-2 border border-gray-600 bg-gray-700/50 text-white rounded-md shadow-sm transition-all duration-150 outline-none focus:border-orange-500 focus:ring-2 focus:ring-orange-500/30"
          >
            <option value="">{t('users.selectRole')}</option>
            {roles.map((role) => (
              <option key={role.id} value={role.id}>
                {role.name}
              </option>
            ))}
          </select>
          {errors.roleId && <p className="mt-1 text-sm text-red-400">{errors.roleId.message}</p>}
        </div>

        <div className="flex gap-3">
          <button
            type="submit"
            disabled={isSubmitting}
            className="flex-1 h-10 bg-orange-500 text-white font-medium rounded-md shadow-sm transition-all duration-150 outline-none hover:bg-orange-600 focus-visible:ring-2 focus-visible:ring-orange-500/50 disabled:opacity-50 disabled:pointer-events-none"
          >
            {isSubmitting ? t('users.creating') : t('users.createUser')}
          </button>
          <button
            type="button"
            onClick={() => navigate('/users')}
            className="flex-1 h-10 border border-gray-600 bg-gray-800/50 text-white font-medium rounded-md shadow-sm transition-all duration-150 outline-none hover:bg-gray-700 hover:border-gray-500 focus-visible:ring-2 focus-visible:ring-orange-500/50"
          >
            {t('common.cancel')}
          </button>
        </div>
      </form>
    </div>
  );
}
