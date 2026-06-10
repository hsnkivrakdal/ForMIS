# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Build & run

- `dotnet build ForMIS.sln` — build the full solution.
- `dotnet build ForMIS.<Project>/ForMIS.<Project>.csproj` — build one project for faster feedback while iterating on a single API.
- `dotnet run --project ForMIS.UserManagementApi` (or `ForMIS.UniversityManagementApi`, `ForMIS.FormManagementApi`) — run one API locally. `launchSettings.json` is disabled (`<NoDefaultLaunchSettingsFile>True</NoDefaultLaunchSettingsFile>`), so `dotnet run` uses default Kestrel bindings.
- `docker compose up --build` — full stack: 3 APIs + SQL Server (`azure-sql-edge`) on the `formis-network` bridge.
- Swagger is enabled on every API at `/swagger`.
- **No test suite exists in this repo.**

External → container port map (see `docker-compose.yml`):

| Port | Service |
|---|---|
| `8080` | UniversityManagementApi |
| `8081` | FormManagementApi |
| `8082` | UserManagementApi |
| `1433` | SQL Server (`formisdatabase`, DB `ForMISDb`) |

## Connection string caveat

All `appsettings.json` files use `Server=sqlserver;…` — the docker-compose service hostname. Running an API outside docker against a local SQL Server requires changing this to `localhost` (or aliasing `sqlserver` in `/etc/hosts`).

## Architecture (the non-obvious parts)

- **Three Web API microservices share one Clean Architecture core.** `ForMIS.Domain`, `ForMIS.Application`, and `ForMIS.Infrastructure` are project-referenced by all three Api hosts. Each host registers **only the slice** of services and repositories it needs in its own `Extensions/ServiceRegistration.cs`. The same entity / DTO / service / repository code can be active in multiple APIs — splitting is at the DI/controller layer, not the assembly layer.
- **Single shared DB and DbContext.** `ForMIS.Infrastructure/Persistance/AppDbContext.cs` declares every `DbSet`. All three APIs point at the same `ForMISDb` database.
- **Domain split** (which controllers live where):
  - `UserManagementApi` (8082): Student, User, DepartmentMember, Standing
  - `UniversityManagementApi` (8080): University, Faculty, Department, Semester
  - `FormManagementApi` (8081): Form, FormType, FormContent, FormContentPrecursor, FormReview, FormStatus

## Misleadingly-named base classes — read this first

Two types in this codebase break the C# convention that `I…` means "interface". **Both are concrete generic base classes**:

- `ForMIS.Infrastructure.Interfaces.IDatabaseBusinessRepository<TEntity>` — concrete CRUD base. Concrete repositories (`StudentRepository`, `FormRepository`, …) **inherit** from it.
- `ForMIS.Application.Interfaces.IDatabaseServiceImplementation<TDto, TEntity>` — concrete DTO-mapped service base. Concrete services **inherit** from it; Mapster handles DTO ↔ entity adaptation.

The **real** interface contracts are:

- `ForMIS.Domain.Interfaces.IDatabaseRepository<T>`
- `ForMIS.Application.Interfaces.IDatabaseService<TDto, TEntity>`

Do not rename either base class; many files inherit from these names.

## Recipe: add a CRUD-only entity

1. Entity in `ForMIS.Domain/Entities/Foo.cs`.
2. DTO in `ForMIS.Application/DTOs/FooDto.cs`.
3. `DbSet<Foo>` in `AppDbContext`.
4. `FooRepository : IDatabaseBusinessRepository<Foo>` (no extra interface needed).
5. `FooService : IDatabaseServiceImplementation<FooDto, Foo>`.
6. Controller in the relevant API project, injecting `IDatabaseService<FooDto, Foo>`.
7. Register in that API's `Extensions/ServiceRegistration.cs`:
   ```csharp
   services.AddScoped<IDatabaseService<FooDto, Foo>, FooService>();
   services.AddScoped<IDatabaseRepository<Foo>, FooRepository>();
   ```
8. **Add the column(s) to SQL Server manually** — there are no EF migrations (see below).

## Recipe: add a custom (non-CRUD) operation

When you need anything beyond generic CRUD — e.g. a join projection — follow the `Student` / `Form` pattern already in the codebase:

1. Add a projection entity `FooDetail` in `Domain/Entities` and `FooDetailsDto` in `Application/DTOs`.
2. Define `IFooRepository : IDatabaseRepository<Foo>` in `Domain/Interfaces` with the new method signature.
3. `FooRepository : IDatabaseBusinessRepository<Foo>, IFooRepository` — implement the join query. See `FormRepository.BuildFormDetailQuery()` for a reusable shared-query helper pattern when one query backs multiple endpoints.
4. `FooService : IDatabaseServiceImplementation<FooDto, Foo>` — inject `IFooRepository`, expose the new method, return DTO(s).
5. **Controller injects the concrete `FooService`**, not `IDatabaseService<FooDto, Foo>` — otherwise the custom methods aren't visible.
6. Register in `ServiceRegistration.cs`:
   ```csharp
   services.AddScoped<FooService>();              // concrete, not interface
   services.AddScoped<IFooRepository, FooRepository>();
   ```

Existing examples:

- `StudentRepository.GetStudentDetailsByIdentityNumber` — single-result join, uses `FirstOrDefaultAsync` so SQL Server emits `TOP 1`.
- `FormRepository.GetFormDetailsByStudentNumber` / `GetFormDetailsById` — list + single-result variants sharing one `BuildFormDetailQuery()` helper.

## No EF migrations

There is no `Migrations/` folder anywhere. DB schema is managed **manually** in SQL Server. Adding a property to an entity does **not** automatically add the column — run the corresponding `ALTER TABLE` against the DB, or LINQ queries that touch the new column will throw at runtime.

## REST response conventions in use

- Single-resource endpoints (`GET /api/X/{id}`, `GET /api/X/by-uniqueKey/{val}`, `DELETE /api/X/{id}`) return `404 NotFound` when the resource is absent.
- Collection endpoints (`GET /api/X`, `GET /api/X/by-Y/{val}` returning a list) return `200 OK` + `[]` for an empty result — **do not** add an `Any()`-then-`NotFound` guard.
- Controllers wrap action bodies in `try { … } catch (Exception e) { return BadRequest(e.Message); }` — match this style for new endpoints.

## Frontend lives elsewhere

The Next.js frontend is at `~/Desktop/formis-frontend`, a separate repo with its own `CLAUDE.md`. Do **not** add UI code to this repo. Cross-cutting changes (new endpoint + new screen) require edits in both repos.