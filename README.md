# FileUpload

A sample .NET 10 Web API that uploads Photos, Certificates, and Signatures to SQL Server (via Dapper) and retrieves them back by id.

## Architecture

CQRS-lite layering:

- `FileUpload.API` — controllers (`UploadPhotoController`, `UploadCertificateController`, `UploadSignatureController`)
- `FileUpload.DTO` — commands / queries / results
- `FileUpload.Handler` — command/query handlers (business logic)
- `FileUpload.Repository` — Dapper repositories + SQL Server access
- `ERS.Shared` — shared abstractions (`ICommand`, `ICommandHandler`, `IQuery`, `IQueryHandler`, `Event`)

## Setup

1. Make sure SQL Server (or LocalDB) is reachable, then create the schema:

```bash
sqlcmd -S "(localdb)\MSSQLLocalDB" -i src/FileUpload/FileUpload.Repository/Scripts/CreateDatabase.sql
```

2. Point `ConnectionStrings:FileUploadDb` in `src/FileUpload/FileUpload.API/appsettings.json` (or `appsettings.Development.json`) at your server. It defaults to LocalDB:

```json
"ConnectionStrings": {
  "FileUploadDb": "Server=(localdb)\\MSSQLLocalDB;Database=FileUploadDb;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

3. Run the API:

```bash
dotnet run --project src/FileUpload/FileUpload.API
```

4. Open `https://localhost:7131/swagger` (Development environment) to try it, or use `src/FileUpload/FileUpload.API/FileUpload.API.http`.

## Endpoints (same shape for Photo / Certificate / Signature)

- `POST /api/UploadPhoto/Upload/Photo?employeeId=1` (multipart `file`) → `{ "id": 1 }`
- `GET /api/UploadPhoto/Photo/{id}` → the file bytes
- `DELETE /api/UploadPhoto/Photo/{id}` → 204

Certificate upload also accepts `title`, `issuedBy`, `issuedOn`, `expiresOn` query parameters.
