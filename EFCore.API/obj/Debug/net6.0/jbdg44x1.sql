IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Departments] (
    [Id] int NOT NULL IDENTITY,
    [Nome] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Departments] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Users] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [Email] nvarchar(max) NOT NULL,
    [Gender] nvarchar(max) NULL,
    [RegistrationDate] datetimeoffset NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Contacts] (
    [Id] int NOT NULL IDENTITY,
    [UserId] int NOT NULL,
    [Phone] nvarchar(max) NULL,
    CONSTRAINT [PK_Contacts] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Contacts_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [DeliveryAddresses] (
    [Id] int NOT NULL IDENTITY,
    [UserId] int NOT NULL,
    [Name] nvarchar(max) NOT NULL,
    [City] nvarchar(max) NOT NULL,
    [Country] nvarchar(max) NOT NULL,
    [Address] nvarchar(max) NOT NULL,
    [Number] nvarchar(max) NULL,
    CONSTRAINT [PK_DeliveryAddresses] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_DeliveryAddresses_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [DepartmentUser] (
    [DepartmentsId] int NOT NULL,
    [UsersId] int NOT NULL,
    CONSTRAINT [PK_DepartmentUser] PRIMARY KEY ([DepartmentsId], [UsersId]),
    CONSTRAINT [FK_DepartmentUser_Departments_DepartmentsId] FOREIGN KEY ([DepartmentsId]) REFERENCES [Departments] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_DepartmentUser_Users_UsersId] FOREIGN KEY ([UsersId]) REFERENCES [Users] ([Id]) ON DELETE CASCADE
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Nome') AND [object_id] = OBJECT_ID(N'[Departments]'))
    SET IDENTITY_INSERT [Departments] ON;
INSERT INTO [Departments] ([Id], [Nome])
VALUES (1, N'IT');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Nome') AND [object_id] = OBJECT_ID(N'[Departments]'))
    SET IDENTITY_INSERT [Departments] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Nome') AND [object_id] = OBJECT_ID(N'[Departments]'))
    SET IDENTITY_INSERT [Departments] ON;
INSERT INTO [Departments] ([Id], [Nome])
VALUES (2, N'Human Resources');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Nome') AND [object_id] = OBJECT_ID(N'[Departments]'))
    SET IDENTITY_INSERT [Departments] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Nome') AND [object_id] = OBJECT_ID(N'[Departments]'))
    SET IDENTITY_INSERT [Departments] ON;
INSERT INTO [Departments] ([Id], [Nome])
VALUES (3, N'Economics ');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Nome') AND [object_id] = OBJECT_ID(N'[Departments]'))
    SET IDENTITY_INSERT [Departments] OFF;
GO

CREATE UNIQUE INDEX [IX_Contacts_UserId] ON [Contacts] ([UserId]);
GO

CREATE INDEX [IX_DeliveryAddresses_UserId] ON [DeliveryAddresses] ([UserId]);
GO

CREATE INDEX [IX_DepartmentUser_UsersId] ON [DepartmentUser] ([UsersId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231018192300_InitialCreate', N'6.0.23');
GO

COMMIT;
GO

