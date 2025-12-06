# MyAmigurumi Monorepo

Monorepo for the MyAmigurumi marketplace: .NET 10 backend microservices and React 19 (TypeScript 5.9) frontends, wired for Docker-first workflows.

## Stack
- Backend: ASP.NET Core 10 controllers, MediatR CQRS, EF Core 10 + PostgreSQL, MassTransit + RabbitMQ, JWT bearer auth, Swagger, ProblemDetails, health checks.
- Frontend: React 19 + Vite, TypeScript strict, Storybook, Jest, ESLint/Prettier, shared UI/API/Config packages.
- Tooling: npm workspaces, Husky hooks, Style Dictionary tokens, GitHub Actions CI.

## Structure
- `backend/Services/Catalog` – Listings/catalog API (own Postgres DB).
- `backend/Services/Identity` – JWT issuance & users (own Postgres DB).
- `frontend/apps/storefront` – customer-facing web.\n- `frontend/apps/admin` – seller dashboard.\n- `frontend/packages/*` – shared UI, API client, config/tokens.
- `docker-compose.yml` – orchestrates DBs, RabbitMQ, APIs, and UIs with opt-in profiles.

## Running with Docker (default)
```bash
docker compose --profile catalog --profile identity --profile storefront --profile admin up --build
```
Services:
- Catalog API: `http://localhost:5101` (health `/health`)
- Identity API: `http://localhost:5100` (health `/health`)
- Storefront: `http://localhost:5173`
- Admin: `http://localhost:5174`

Stop a subset (e.g., work locally on storefront only):
```bash
docker compose --profile storefront up --build
```
Then point Vite env vars to local/remote APIs via `VITE_CATALOG_API` / `VITE_IDENTITY_API`.

## Local backend (without containers)
```bash
dotnet restore backend/Services/Catalog/Api/Catalog.Api.csproj
dotnet run --project backend/Services/Catalog/Api/Catalog.Api.csproj
# or Identity
dotnet run --project backend/Services/Identity/Api/Identity.Api.csproj
```
Environment:
- `ConnectionStrings__Catalog` / `ConnectionStrings__Identity`
- `Jwt__Issuer`, `Jwt__Audience`, `Jwt__Key`
- `RabbitMq__Host`, `RabbitMq__Username`, `RabbitMq__Password`

## Local frontend (without containers)
```bash
npm install
npm run dev -w frontend/apps/storefront
npm run dev -w frontend/apps/admin
```
Env: set `VITE_CATALOG_API` and `VITE_IDENTITY_API` for the UIs.

## Seeding & auth
- Seeded admin user: `admin@myamigurumi.com` / password `changeit` (Identity service).
- Use `POST /api/auth/token` (Identity) to obtain JWT and hit authorized endpoints (e.g., `POST /api/listings` in Catalog).
- Default JWT config uses `Jwt__Key=super_secret_local` in compose; override in production.

## Testing & linting
```bash
npm run lint   # workspace-wide ESLint
npm run test   # Jest (js/ts)
npm run build  # builds all frontends/packages
```
Storybook: `npm run storybook -w frontend/apps/storefront`.

## CI
GitHub Actions workflow runs lint/test/build and smoke health checks on API containers.

## Notes on React 19
Uses React 19 RC ranges in package.json to align with requested React 19.2+; pin to the latest stable 19.x when available.

## Checklist
- [x] Monorepo layout with backend/, frontend/, packages/ and Docker-first setup.
- [x] .NET 10 APIs with controllers, MediatR CQRS, EF Core 10, MassTransit, Swagger, ProblemDetails, health checks.
- [x] JWT bearer auth wired; sample secured endpoint for listings creation.
- [x] Vite React 19 apps (storefront/admin) with shared UI/API/config packages and Storybook.
- [x] TypeScript 5.9 strict config, ESLint/Prettier, Jest, Style Dictionary, Husky hooks.
- [x] Dockerfiles per service and compose with optional profiles for isolated dev.
- [x] README instructions (Docker/local), seeded user, and CI workflow.
