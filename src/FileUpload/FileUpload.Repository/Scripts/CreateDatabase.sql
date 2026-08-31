-- Run this once against your SQL Server instance before starting the API.
-- Matches the connection string in FileUpload.API/appsettings.json (ConnectionStrings:FileUploadDb).

IF DB_ID('FileUploadDb') IS NULL
BEGIN
    CREATE DATABASE FileUploadDb;
END
GO

USE FileUploadDb;
GO

IF OBJECT_ID('dbo.Photos', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.Photos
    (
        Id            BIGINT IDENTITY(1,1) PRIMARY KEY,
        EmployeeId    BIGINT NOT NULL,
        FileName      NVARCHAR(260) NOT NULL,
        ContentType   NVARCHAR(100) NOT NULL,
        SizeBytes     BIGINT NOT NULL,
        Content       VARBINARY(MAX) NOT NULL,
        UploadedAtUtc DATETIME2 NOT NULL
    );
END
GO

IF OBJECT_ID('dbo.Signatures', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.Signatures
    (
        Id            BIGINT IDENTITY(1,1) PRIMARY KEY,
        EmployeeId    BIGINT NOT NULL,
        FileName      NVARCHAR(260) NOT NULL,
        ContentType   NVARCHAR(100) NOT NULL,
        SizeBytes     BIGINT NOT NULL,
        Content       VARBINARY(MAX) NOT NULL,
        UploadedAtUtc DATETIME2 NOT NULL
    );
END
GO

IF OBJECT_ID('dbo.Certificates', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.Certificates
    (
        Id            BIGINT IDENTITY(1,1) PRIMARY KEY,
        EmployeeId    BIGINT NOT NULL,
        Title         NVARCHAR(200) NOT NULL,
        IssuedBy      NVARCHAR(200) NULL,
        IssuedOn      DATETIME2 NULL,
        ExpiresOn     DATETIME2 NULL,
        FileName      NVARCHAR(260) NOT NULL,
        ContentType   NVARCHAR(100) NOT NULL,
        SizeBytes     BIGINT NOT NULL,
        Content       VARBINARY(MAX) NOT NULL,
        UploadedAtUtc DATETIME2 NOT NULL
    );
END
GO
