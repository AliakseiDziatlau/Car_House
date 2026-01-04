# Car House

## Tech Stack

- **Backend**: ASP.NET Core 8 Web API (C#)
- **Frontend**: React 18 + TypeScript + Vite + Tailwind CSS
- **Database**: SQLite with Entity Framework Core
- **Authentication**: JWT tokens with BCrypt password hashing
- **Validation**: FluentValidation (server), Zod + React Hook Form (client)
- **Internationalization**: i18next (English + Polish)

## Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Node.js 18+](https://nodejs.org/)
- npm (comes with Node.js)

## Quick Start

### Backend Setup

```bash
cd Back-end
dotnet restore

# Configure user secrets (first time only)
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Data Source=carhouse.db"
dotnet user-secrets set "Jwt:Key" "YourSuperSecretKeyThatIsAtLeast32CharactersLong!"
dotnet user-secrets set "Jwt:Issuer" "CarHouseAPI"
dotnet user-secrets set "Jwt:Audience" "CarHouseApp"

dotnet ef database update
dotnet run
```

The API will be available at `http://localhost:5019`

### Frontend Setup

```bash
cd Front-end
npm install
npm run dev
```

The app will be available at `http://localhost:5173`

## Database Configuration

### User Secrets (Development)

Configuration is stored using .NET User Secrets (not in source control).

To change the database path:
```bash
cd Back-end
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Data Source=/path/to/your/database.db"
```

### Using SQL Scripts (Alternative Method)

If you prefer to create the database manually instead of using EF Core migrations:

```bash
cd scripts
sqlite3 ../Back-end/carhouse.db < create-database.sql
sqlite3 ../Back-end/carhouse.db < seed-data.sql
```

## Default Credentials

| Role    | Email               | Password   |
|---------|---------------------|------------|
| Admin   | admin@carhouse.com  | Admin123!  |

New users can register through the app and will receive the "User" role by default.

## User Roles

| Role    | Permissions                                           |
|---------|-------------------------------------------------------|
| Guest   | View cars, brands, features                           |
| User    | + Place orders, view own orders                       |
| Manager | + Manage cars/brands/features, view all orders        |
| Admin   | + Manage users and roles                              |

## Project Structure

```
Car-House/
├── Back-end/
│   ├── Domain/              # Entities, Repository interfaces
│   ├── Application/         # DTOs, Services, Service interfaces
│   ├── Infrastructure/      # DbContext, Repositories, Migrations
│   ├── Presentation/        # Controllers, Validators
│   ├── Program.cs
│   └── appsettings.json     # Configuration (connection string here)
├── Front-end/
│   ├── src/
│   │   ├── components/      # Reusable UI components
│   │   ├── pages/           # Page components
│   │   ├── services/        # API client
│   │   ├── context/         # Auth context
│   │   ├── locales/         # i18n translations (en.json, pl.json)
│   │   └── App.tsx          # Routes
│   └── package.json
├── scripts/
│   ├── create-database.sql  # Database schema
│   └── seed-data.sql        # Sample data
└── README.md
```

## API Endpoints

### Authentication
- `POST /api/auth/register` - Register new user
- `POST /api/auth/login` - Login and get JWT token

### Brands
- `GET /api/brands` - List all brands (paginated)
- `GET /api/brands/{id}` - Get brand details with cars
- `POST /api/brands` - Create brand (Manager+)
- `PUT /api/brands/{id}` - Update brand (Manager+)
- `DELETE /api/brands/{id}` - Delete brand (Manager+)

### Cars
- `GET /api/cars` - List all cars (paginated, filterable)
- `GET /api/cars/{id}` - Get car details with features
- `POST /api/cars` - Create car (Manager+)
- `PUT /api/cars/{id}` - Update car (Manager+)
- `DELETE /api/cars/{id}` - Delete car (Manager+)

### Features
- `GET /api/features` - List all features (paginated)
- `GET /api/features/{id}` - Get feature details
- `POST /api/features` - Create feature (Manager+)
- `PUT /api/features/{id}` - Update feature (Manager+)
- `DELETE /api/features/{id}` - Delete feature (Manager+)

### Orders
- `GET /api/orders` - List orders (own for User, all for Manager+)
- `GET /api/orders/{id}` - Get order details
- `POST /api/orders` - Create order (authenticated)
- `PUT /api/orders/{id}/status` - Update status (Manager+)
- `DELETE /api/orders/{id}` - Delete order (owner or Admin)

### Users (Admin only)
- `GET /api/users` - List all users
- `GET /api/users/{id}` - Get user details
- `PUT /api/users/{id}/role` - Update user role
