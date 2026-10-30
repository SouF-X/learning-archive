# Code Context

## Files Retrieved
1. `src/MechanicShop.Api/MechanicShop.Api.csproj` (lines 1-35) - Web SDK targeting .NET 9; project references Application, Contracts, Infrastructure.
2. `src/MechanicShop.Api/Program.cs` (lines 1-68) - composition root; runs EF migrations and first-manager bootstrap at startup; maps controllers, static frontend, SignalR hub, Prometheus endpoint.
3. `src/MechanicShop.Api/MiddlewareExtensions.cs` (lines 8-35) - serves default/static files and HTTPS/HSTS, authentication and authorization.
4. `src/MechanicShop.Infrastructure/DependencyInjection.cs` (lines 25-139) - SQL Server EF Core, JWT, Identity, hybrid cache, hosted cleanup service and notifications.
5. `src/MechanicShop.Api/appsettings.json` (lines 1-67) - connection string, demo manager credentials, JWT settings, CORS and Seq defaults.
6. `Dockerfile` (lines 1-23) - multi-stage .NET 9 container publish; listens on port 8080.
7. `docker-compose.yml` (lines 1-68) - API plus SQL Server, Seq, Prometheus and Grafana; runtime environment overrides.
8. `.github/workflows/dotnet-ci.yml` (lines 1-25) - GitHub Actions restore/build only; no deployment.
9. `README.md` (lines 40-160) - documented stack, local build/run commands and Docker usage.
10. `global.json` (lines 1-6) - SDK pinned to 9.0.315.

## Key Code
- Build/run: `dotnet restore MechanicShop.sln`; `dotnet build MechanicShop.sln`; `dotnet run --project src/MechanicShop.Api`; container build executes `dotnet publish src/MechanicShop.Api/MechanicShop.Api.csproj -c Release -o /app/publish`.
- `Program.cs` creates scope and calls `dbContext.Database.MigrateAsync()` before serving requests, so deployment needs a reachable writable SQL Server and migration permissions.
- `DependencyInjection.cs` obtains `ConnectionStrings:DefaultConnection` and calls `options.UseSqlServer(connectionString)`; Identity stores are EF-backed. JWT authentication and role authorization are required. A background overdue-booking hosted service runs in-process.
- `MiddlewareExtensions.cs` calls `UseDefaultFiles()` and `UseStaticFiles()`: frontend is bundled under `src/MechanicShop.Api/wwwroot`, but it is not a static-only site because controllers, database, JWT, SignalR, PDF generation and background work are server-side.
- Compose overrides `ConnectionStrings__DefaultConnection` to SQL Server service `mechanicshop-db`; exposes API as host port 5001 -> container 8080.

## Architecture
ASP.NET Core 9 full-stack monolith: vanilla HTML/CSS/JS static assets are served by the API, while API controllers and SignalR share the process. Clean Architecture layers are Domain -> Application -> Infrastructure -> Api. Persistent dependency is SQL Server via EF Core/Identity. Optional operational dependencies in Compose are Seq, Prometheus and Grafana; hybrid cache is configured but no separate cache service is declared.

## Deployment/config findings
- Existing deployment support: `Dockerfile`, `docker-compose.yml`, and CI build workflow only. No `azure-pipelines.yml`, ARM/Bicep/Terraform, App Service config, Web App for Containers config, or deployment workflow found.
- Environment variables currently evidenced: `ASPNETCORE_URLS` (Dockerfile); `ASPNETCORE_ENVIRONMENT`, `ConnectionStrings__DefaultConnection`, `OTEL_EXPORTER_OTLP_ENDPOINT`, `OTEL_EXPORTER_OTLP_PROTOCOL`, and `Serilog__WriteTo__1__Args__serverUrl` (Compose); `ASPNETCORE_ENVIRONMENT` in launch settings. All JSON configuration keys can be supplied via standard ASP.NET configuration environment overrides, especially `JwtSettings__Secret`, `JwtSettings__Issuer`, `JwtSettings__Audience`, `FirstManager__*`, and `AppSettings__AllowedOrigins`.
- **High severity:** `src/MechanicShop.Api/appsettings.json:3` contains a machine-local SQL Server connection and `:5-9` contains a demo password; `:52` contains a development JWT secret. These must be replaced/rotated through host secrets before public deployment.
- **High severity:** `docker-compose.yml:21` and `:39` commit SQL SA and Grafana passwords. Do not reuse in production; use platform secret settings.
- **Medium severity:** startup auto-migrations (`Program.cs:20-26`) require production DB DDL rights and can cause concurrent deployment/startup races.
- **Medium severity:** `UseHttpsRedirection()` is enabled; configure forwarded headers/TLS correctly on a reverse proxy. CORS currently only lists localhost origins (`appsettings.json:24-28`), so hosted frontend origin must be supplied.
- **Medium severity:** `FirstManager` bootstrap runs on every startup; production initialization should be deliberate and credentials secret-managed.

## Git state/recent commits
`git status --short --branch`: `## main...origin/main` plus untracked `.pi-subagents/` (artifact directory created by tooling; no tracked source changes). No diff summary was available because the worktree has no tracked modifications. Recent commits: `c752350 Fix demo authentication and hosted frontend routing`; `c25a25c Harden labor auth and refresh sessions`; `8bf9d56 Add project README`; `0b18bdd Initial MechanicShop portfolio project`.

## Best free hosting category
Use a **free-tier container-capable web app/PaaS (or small free VM) with a separately provisioned managed SQL database**, not static hosting. Static hosts cannot run the API, EF/Identity SQL Server, JWT auth, SignalR, PDF generation, or hosted cleanup service. A free container tier can run the Dockerfile, but the SQL Server requirement is the limiting cost/availability factor; the practical free demo may need a compatible free PostgreSQL migration (not currently supported) or an external/free SQL Server instance. Azure-specific config is absent, so Azure App Service for Containers plus Azure SQL would require adding resources/secrets and may exceed perpetual free limits.

## Start Here
Open `src/MechanicShop.Api/Program.cs` first: it shows the production-critical startup migration/bootstrap and all server endpoints, then inspect `src/MechanicShop.Infrastructure/DependencyInjection.cs` for database/auth/runtime dependencies.

```acceptance-report
{
  "criteriaSatisfied": [
    {
      "id": "criterion-1",
      "status": "satisfied",
      "evidence": "Concrete deployment findings, exact file paths/line ranges, severity-tagged risks, framework/build commands, dependencies, config, environment variables, and git state are documented above."
    }
  ],
  "changedFiles": [],
  "testsAddedOrUpdated": [],
  "commandsRun": [
    {"command": "git status --short --branch", "result": "passed", "summary": "main tracks origin/main; only untracked .pi-subagents artifact directory"},
    {"command": "git log -5 --oneline --decorate", "result": "passed", "summary": "Captured five most recent commits"}
  ],
  "validationOutput": ["Read-only inspection completed; no project files modified."],
  "residualRisks": ["SQL Server hosting/free-tier availability and cost must be confirmed", "rotate committed demo/JWT/SQL/Grafana secrets", "configure hosted CORS and reverse-proxy HTTPS", "startup migrations need controlled production strategy"],
  "noStagedFiles": true,
  "diffSummary": "No source diff; only pre-existing/tooling untracked .pi-subagents artifacts observed.",
  "reviewFindings": ["high: src/MechanicShop.Api/appsettings.json:3-9,52 - development database credentials, manager password, and JWT secret are deployment-inappropriate", "high: docker-compose.yml:21,39 - plaintext SQL SA and Grafana passwords", "medium: Program.cs:20-26 - automatic startup migrations require DDL access and race control", "medium: appsettings.json:24-28 - CORS only permits localhost origins", "no blockers in code inspection for containerized deployment category"],
  "manualNotes": "No Azure/deployment manifests or deployment CI found; Dockerfile is the clearest deployment entry point."
}
```