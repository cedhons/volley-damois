IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200521142328_Init')
BEGIN
    CREATE TABLE [AspNetRoles] (
        [Id] nvarchar(450) NOT NULL,
        [Name] nvarchar(256) NULL,
        [NormalizedName] nvarchar(256) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoles] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200521142328_Init')
BEGIN
    CREATE TABLE [AspNetUsers] (
        [Id] nvarchar(450) NOT NULL,
        [UserName] nvarchar(256) NULL,
        [NormalizedUserName] nvarchar(256) NULL,
        [Email] nvarchar(256) NULL,
        [NormalizedEmail] nvarchar(256) NULL,
        [EmailConfirmed] bit NOT NULL,
        [PasswordHash] nvarchar(max) NULL,
        [SecurityStamp] nvarchar(max) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        [PhoneNumber] nvarchar(max) NULL,
        [PhoneNumberConfirmed] bit NOT NULL,
        [TwoFactorEnabled] bit NOT NULL,
        [LockoutEnd] datetimeoffset NULL,
        [LockoutEnabled] bit NOT NULL,
        [AccessFailedCount] int NOT NULL,
        CONSTRAINT [PK_AspNetUsers] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200521142328_Init')
BEGIN
    CREATE TABLE [Categories] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(20) NOT NULL,
        CONSTRAINT [PK_Categories] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200521142328_Init')
BEGIN
    CREATE TABLE [Pools] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NULL,
        CONSTRAINT [PK_Pools] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200521142328_Init')
BEGIN
    CREATE TABLE [AspNetRoleClaims] (
        [Id] int NOT NULL IDENTITY,
        [RoleId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200521142328_Init')
BEGIN
    CREATE TABLE [AspNetUserClaims] (
        [Id] int NOT NULL IDENTITY,
        [UserId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200521142328_Init')
BEGIN
    CREATE TABLE [AspNetUserLogins] (
        [LoginProvider] nvarchar(450) NOT NULL,
        [ProviderKey] nvarchar(450) NOT NULL,
        [ProviderDisplayName] nvarchar(max) NULL,
        [UserId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY ([LoginProvider], [ProviderKey]),
        CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200521142328_Init')
BEGIN
    CREATE TABLE [AspNetUserRoles] (
        [UserId] nvarchar(450) NOT NULL,
        [RoleId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY ([UserId], [RoleId]),
        CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200521142328_Init')
BEGIN
    CREATE TABLE [AspNetUserTokens] (
        [UserId] nvarchar(450) NOT NULL,
        [LoginProvider] nvarchar(450) NOT NULL,
        [Name] nvarchar(450) NOT NULL,
        [Value] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY ([UserId], [LoginProvider], [Name]),
        CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200521142328_Init')
BEGIN
    CREATE TABLE [Terrain] (
        [Number] int NOT NULL IDENTITY,
        [CategoryId] int NULL,
        CONSTRAINT [PK_Terrain] PRIMARY KEY ([Number]),
        CONSTRAINT [FK_Terrain_Categories_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [Categories] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200521142328_Init')
BEGIN
    CREATE TABLE [Teams] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(50) NOT NULL,
        [CategoryId] int NULL,
        [Camping] bit NOT NULL,
        [Confirmation] bit NOT NULL,
        [PoolId] int NULL,
        CONSTRAINT [PK_Teams] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Teams_Categories_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [Categories] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Teams_Pools_PoolId] FOREIGN KEY ([PoolId]) REFERENCES [Pools] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200521142328_Init')
BEGIN
    CREATE TABLE [Confrontations] (
        [Id] int NOT NULL IDENTITY,
        [TeamAId] int NULL,
        [TeamBId] int NULL,
        [TeamRefereeId] int NULL,
        [SetOneA] int NOT NULL,
        [SetOneB] int NOT NULL,
        [SetTwoA] int NOT NULL,
        [SetTwoB] int NOT NULL,
        [BeginTime] datetime2 NOT NULL DEFAULT (Getdate()),
        [TerrainNumber] int NULL,
        [Level] int NOT NULL,
        CONSTRAINT [PK_Confrontations] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Confrontations_Teams_TeamAId] FOREIGN KEY ([TeamAId]) REFERENCES [Teams] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Confrontations_Teams_TeamBId] FOREIGN KEY ([TeamBId]) REFERENCES [Teams] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Confrontations_Teams_TeamRefereeId] FOREIGN KEY ([TeamRefereeId]) REFERENCES [Teams] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Confrontations_Terrain_TerrainNumber] FOREIGN KEY ([TerrainNumber]) REFERENCES [Terrain] ([Number]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200521142328_Init')
BEGIN
    CREATE TABLE [Player] (
        [Id] int NOT NULL IDENTITY,
        [AffiliationNumber] nvarchar(50) NULL,
        [Lastname] nvarchar(50) NOT NULL,
        [Firstname] nvarchar(50) NOT NULL,
        [Gender] nvarchar(20) NOT NULL,
        [Capitain] bit NOT NULL,
        [Reservist] bit NOT NULL,
        [Adress] nvarchar(100) NOT NULL,
        [PhoneNumber] nvarchar(50) NULL,
        [Email] nvarchar(50) NULL,
        [TeamId] int NULL,
        CONSTRAINT [PK_Player] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Player_Teams_TeamId] FOREIGN KEY ([TeamId]) REFERENCES [Teams] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200521142328_Init')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[Categories]'))
        SET IDENTITY_INSERT [Categories] ON;
    INSERT INTO [Categories] ([Id], [Name])
    VALUES (1, N'Nationale');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[Categories]'))
        SET IDENTITY_INSERT [Categories] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200521142328_Init')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[Categories]'))
        SET IDENTITY_INSERT [Categories] ON;
    INSERT INTO [Categories] ([Id], [Name])
    VALUES (2, N'Provinciale');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[Categories]'))
        SET IDENTITY_INSERT [Categories] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200521142328_Init')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[Categories]'))
        SET IDENTITY_INSERT [Categories] ON;
    INSERT INTO [Categories] ([Id], [Name])
    VALUES (3, N'Loisir');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[Categories]'))
        SET IDENTITY_INSERT [Categories] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200521142328_Init')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Camping', N'CategoryId', N'Confirmation', N'Name', N'PoolId') AND [object_id] = OBJECT_ID(N'[Teams]'))
        SET IDENTITY_INSERT [Teams] ON;
    INSERT INTO [Teams] ([Id], [Camping], [CategoryId], [Confirmation], [Name], [PoolId])
    VALUES (1, CAST(0 AS bit), 1, CAST(0 AS bit), N'Equipe Nationale 1', NULL),
    (25, CAST(0 AS bit), 2, CAST(0 AS bit), N'Equipe Provinciale 25', NULL),
    (27, CAST(0 AS bit), 2, CAST(0 AS bit), N'Equipe Provinciale 27', NULL),
    (28, CAST(1 AS bit), 2, CAST(0 AS bit), N'Equipe Provinciale 28', NULL),
    (29, CAST(0 AS bit), 2, CAST(0 AS bit), N'Equipe Provinciale 29', NULL),
    (30, CAST(1 AS bit), 2, CAST(0 AS bit), N'Equipe Provinciale 30', NULL),
    (31, CAST(0 AS bit), 2, CAST(0 AS bit), N'Equipe Provinciale 31', NULL),
    (32, CAST(1 AS bit), 2, CAST(0 AS bit), N'Equipe Provinciale 32', NULL),
    (33, CAST(0 AS bit), 3, CAST(0 AS bit), N'Equipe Loisir 33', NULL),
    (34, CAST(1 AS bit), 3, CAST(0 AS bit), N'Equipe Loisir 34', NULL),
    (35, CAST(0 AS bit), 3, CAST(0 AS bit), N'Equipe Loisir 35', NULL),
    (36, CAST(1 AS bit), 3, CAST(0 AS bit), N'Equipe Loisir 36', NULL),
    (37, CAST(0 AS bit), 3, CAST(0 AS bit), N'Equipe Loisir 37', NULL),
    (38, CAST(1 AS bit), 3, CAST(0 AS bit), N'Equipe Loisir 38', NULL),
    (39, CAST(0 AS bit), 3, CAST(0 AS bit), N'Equipe Loisir 39', NULL),
    (40, CAST(1 AS bit), 3, CAST(0 AS bit), N'Equipe Loisir 40', NULL),
    (41, CAST(0 AS bit), 3, CAST(0 AS bit), N'Equipe Loisir 41', NULL),
    (42, CAST(1 AS bit), 3, CAST(0 AS bit), N'Equipe Loisir 42', NULL),
    (43, CAST(0 AS bit), 3, CAST(0 AS bit), N'Equipe Loisir 43', NULL),
    (44, CAST(1 AS bit), 3, CAST(0 AS bit), N'Equipe Loisir 44', NULL),
    (45, CAST(0 AS bit), 3, CAST(0 AS bit), N'Equipe Loisir 45', NULL),
    (46, CAST(1 AS bit), 3, CAST(0 AS bit), N'Equipe Loisir 46', NULL),
    (47, CAST(0 AS bit), 3, CAST(0 AS bit), N'Equipe Loisir 47', NULL),
    (48, CAST(1 AS bit), 3, CAST(0 AS bit), N'Equipe Loisir 48', NULL),
    (24, CAST(1 AS bit), 2, CAST(0 AS bit), N'Equipe Provinciale 24', NULL),
    (23, CAST(0 AS bit), 2, CAST(0 AS bit), N'Equipe Provinciale 23', NULL),
    (26, CAST(1 AS bit), 2, CAST(0 AS bit), N'Equipe Provinciale 26', NULL),
    (21, CAST(0 AS bit), 2, CAST(0 AS bit), N'Equipe Provinciale 21', NULL),
    (2, CAST(1 AS bit), 1, CAST(0 AS bit), N'Equipe Nationale 2', NULL),
    (3, CAST(0 AS bit), 1, CAST(0 AS bit), N'Equipe Nationale 3', NULL),
    (4, CAST(1 AS bit), 1, CAST(0 AS bit), N'Equipe Nationale 4', NULL),
    (5, CAST(0 AS bit), 1, CAST(0 AS bit), N'Equipe Nationale 5', NULL),
    (6, CAST(1 AS bit), 1, CAST(0 AS bit), N'Equipe Nationale 6', NULL),
    (7, CAST(0 AS bit), 1, CAST(0 AS bit), N'Equipe Nationale 7', NULL),
    (8, CAST(1 AS bit), 1, CAST(0 AS bit), N'Equipe Nationale 8', NULL),
    (9, CAST(0 AS bit), 1, CAST(0 AS bit), N'Equipe Nationale 9', NULL),
    (10, CAST(1 AS bit), 1, CAST(0 AS bit), N'Equipe Nationale 10', NULL),
    (11, CAST(0 AS bit), 1, CAST(0 AS bit), N'Equipe Nationale 11', NULL),
    (12, CAST(1 AS bit), 1, CAST(0 AS bit), N'Equipe Nationale 12', NULL),
    (13, CAST(0 AS bit), 1, CAST(0 AS bit), N'Equipe Nationale 13', NULL),
    (22, CAST(1 AS bit), 2, CAST(0 AS bit), N'Equipe Provinciale 22', NULL),
    (15, CAST(0 AS bit), 1, CAST(0 AS bit), N'Equipe Nationale 15', NULL),
    (14, CAST(1 AS bit), 1, CAST(0 AS bit), N'Equipe Nationale 14', NULL),
    (17, CAST(0 AS bit), 2, CAST(0 AS bit), N'Equipe Provinciale 17', NULL),
    (20, CAST(1 AS bit), 2, CAST(0 AS bit), N'Equipe Provinciale 20', NULL),
    (19, CAST(0 AS bit), 2, CAST(0 AS bit), N'Equipe Provinciale 19', NULL),
    (18, CAST(1 AS bit), 2, CAST(0 AS bit), N'Equipe Provinciale 18', NULL),
    (16, CAST(1 AS bit), 1, CAST(0 AS bit), N'Equipe Nationale 16', NULL);
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Camping', N'CategoryId', N'Confirmation', N'Name', N'PoolId') AND [object_id] = OBJECT_ID(N'[Teams]'))
        SET IDENTITY_INSERT [Teams] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200521142328_Init')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Number', N'CategoryId') AND [object_id] = OBJECT_ID(N'[Terrain]'))
        SET IDENTITY_INSERT [Terrain] ON;
    INSERT INTO [Terrain] ([Number], [CategoryId])
    VALUES (10, 3),
    (9, 3),
    (11, 3),
    (1, 1),
    (3, 1),
    (2, 1),
    (5, 2),
    (6, 2),
    (7, 2),
    (8, 2),
    (4, 1),
    (12, 3);
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Number', N'CategoryId') AND [object_id] = OBJECT_ID(N'[Terrain]'))
        SET IDENTITY_INSERT [Terrain] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200521142328_Init')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Adress', N'AffiliationNumber', N'Capitain', N'Email', N'Firstname', N'Gender', N'Lastname', N'PhoneNumber', N'Reservist', N'TeamId') AND [object_id] = OBJECT_ID(N'[Player]'))
        SET IDENTITY_INSERT [Player] ON;
    INSERT INTO [Player] ([Id], [Adress], [AffiliationNumber], [Capitain], [Email], [Firstname], [Gender], [Lastname], [PhoneNumber], [Reservist], [TeamId])
    VALUES (1, N'Liège 1', N'1', CAST(1 AS bit), N'mail1@mail.com', N'Prénom N:1', N'Male', N'Nom N:1', N'1', CAST(0 AS bit), 1),
    (195, N'Liège 195', N'195', CAST(0 AS bit), N'mail195@mail.com', N'Prénom L:195', N'Male', N'Nom L:195', N'195', CAST(1 AS bit), 33),
    (196, N'Liège 196', N'196', CAST(0 AS bit), N'mail196@mail.com', N'Prénom L:196', N'Female', N'Nom L:196', N'196', CAST(1 AS bit), 33),
    (197, N'Liège 197', N'197', CAST(0 AS bit), N'mail197@mail.com', N'Prénom L:197', N'Male', N'Nom L:197', N'197', CAST(1 AS bit), 33),
    (198, N'Liège 198', N'198', CAST(0 AS bit), N'mail198@mail.com', N'Prénom L:198', N'Female', N'Nom L:198', N'198', CAST(1 AS bit), 33),
    (199, N'Liège 199', N'199', CAST(0 AS bit), N'mail199@mail.com', N'Prénom L:199', N'Male', N'Nom L:199', N'199', CAST(0 AS bit), 34),
    (200, N'Liège 200', N'200', CAST(0 AS bit), N'mail200@mail.com', N'Prénom L:200', N'Female', N'Nom L:200', N'200', CAST(0 AS bit), 34),
    (201, N'Liège 201', N'201', CAST(0 AS bit), N'mail201@mail.com', N'Prénom L:201', N'Male', N'Nom L:201', N'201', CAST(0 AS bit), 34),
    (202, N'Liège 202', N'202', CAST(0 AS bit), N'mail202@mail.com', N'Prénom L:202', N'Female', N'Nom L:202', N'202', CAST(0 AS bit), 34),
    (203, N'Liège 203', N'203', CAST(0 AS bit), N'mail203@mail.com', N'Prénom L:203', N'Male', N'Nom L:203', N'203', CAST(0 AS bit), 34),
    (204, N'Liège 204', N'204', CAST(0 AS bit), N'mail204@mail.com', N'Prénom L:204', N'Female', N'Nom L:204', N'204', CAST(0 AS bit), 34),
    (205, N'Liège 205', N'205', CAST(0 AS bit), N'mail205@mail.com', N'Prénom L:205', N'Male', N'Nom L:205', N'205', CAST(0 AS bit), 35),
    (206, N'Liège 206', N'206', CAST(0 AS bit), N'mail206@mail.com', N'Prénom L:206', N'Female', N'Nom L:206', N'206', CAST(0 AS bit), 35),
    (207, N'Liège 207', N'207', CAST(0 AS bit), N'mail207@mail.com', N'Prénom L:207', N'Male', N'Nom L:207', N'207', CAST(0 AS bit), 35),
    (194, N'Liège 194', N'194', CAST(0 AS bit), N'mail194@mail.com', N'Prénom L:194', N'Female', N'Nom L:194', N'194', CAST(1 AS bit), 33),
    (208, N'Liège 208', N'208', CAST(0 AS bit), N'mail208@mail.com', N'Prénom L:208', N'Female', N'Nom L:208', N'208', CAST(0 AS bit), 35),
    (210, N'Liège 210', N'210', CAST(0 AS bit), N'mail210@mail.com', N'Prénom L:210', N'Female', N'Nom L:210', N'210', CAST(0 AS bit), 35),
    (211, N'Liège 211', N'211', CAST(0 AS bit), N'mail211@mail.com', N'Prénom L:211', N'Male', N'Nom L:211', N'211', CAST(1 AS bit), 36),
    (212, N'Liège 212', N'212', CAST(0 AS bit), N'mail212@mail.com', N'Prénom L:212', N'Female', N'Nom L:212', N'212', CAST(1 AS bit), 36),
    (213, N'Liège 213', N'213', CAST(0 AS bit), N'mail213@mail.com', N'Prénom L:213', N'Male', N'Nom L:213', N'213', CAST(1 AS bit), 36),
    (214, N'Liège 214', N'214', CAST(0 AS bit), N'mail214@mail.com', N'Prénom L:214', N'Female', N'Nom L:214', N'214', CAST(1 AS bit), 36),
    (215, N'Liège 215', N'215', CAST(0 AS bit), N'mail215@mail.com', N'Prénom L:215', N'Male', N'Nom L:215', N'215', CAST(1 AS bit), 36),
    (216, N'Liège 216', N'216', CAST(0 AS bit), N'mail216@mail.com', N'Prénom L:216', N'Female', N'Nom L:216', N'216', CAST(1 AS bit), 36),
    (217, N'Liège 217', N'217', CAST(0 AS bit), N'mail217@mail.com', N'Prénom L:217', N'Male', N'Nom L:217', N'217', CAST(0 AS bit), 37),
    (218, N'Liège 218', N'218', CAST(0 AS bit), N'mail218@mail.com', N'Prénom L:218', N'Female', N'Nom L:218', N'218', CAST(0 AS bit), 37),
    (219, N'Liège 219', N'219', CAST(0 AS bit), N'mail219@mail.com', N'Prénom L:219', N'Male', N'Nom L:219', N'219', CAST(0 AS bit), 37),
    (220, N'Liège 220', N'220', CAST(0 AS bit), N'mail220@mail.com', N'Prénom L:220', N'Female', N'Nom L:220', N'220', CAST(0 AS bit), 37),
    (221, N'Liège 221', N'221', CAST(0 AS bit), N'mail221@mail.com', N'Prénom L:221', N'Male', N'Nom L:221', N'221', CAST(0 AS bit), 37),
    (222, N'Liège 222', N'222', CAST(0 AS bit), N'mail222@mail.com', N'Prénom L:222', N'Female', N'Nom L:222', N'222', CAST(0 AS bit), 37),
    (209, N'Liège 209', N'209', CAST(0 AS bit), N'mail209@mail.com', N'Prénom L:209', N'Male', N'Nom L:209', N'209', CAST(0 AS bit), 35),
    (223, N'Liège 223', N'223', CAST(0 AS bit), N'mail223@mail.com', N'Prénom L:223', N'Male', N'Nom L:223', N'223', CAST(0 AS bit), 38),
    (193, N'Liège 193', N'193', CAST(0 AS bit), N'mail193@mail.com', N'Prénom L:193', N'Male', N'Nom L:193', N'193', CAST(1 AS bit), 33),
    (191, N'Liège 191', N'191', CAST(0 AS bit), N'mail191@mail.com', N'Prénom P:191', N'Male', N'Nom P:191', N'191', CAST(0 AS bit), 32),
    (163, N'Liège 163', N'163', CAST(0 AS bit), N'mail163@mail.com', N'Prénom P:163', N'Male', N'Nom P:163', N'163', CAST(0 AS bit), 28),
    (164, N'Liège 164', N'164', CAST(0 AS bit), N'mail164@mail.com', N'Prénom P:164', N'Female', N'Nom P:164', N'164', CAST(0 AS bit), 28),
    (165, N'Liège 165', N'165', CAST(0 AS bit), N'mail165@mail.com', N'Prénom P:165', N'Male', N'Nom P:165', N'165', CAST(0 AS bit), 28),
    (166, N'Liège 166', N'166', CAST(0 AS bit), N'mail166@mail.com', N'Prénom P:166', N'Female', N'Nom P:166', N'166', CAST(0 AS bit), 28),
    (167, N'Liège 167', N'167', CAST(0 AS bit), N'mail167@mail.com', N'Prénom P:167', N'Male', N'Nom P:167', N'167', CAST(0 AS bit), 28),
    (168, N'Liège 168', N'168', CAST(0 AS bit), N'mail168@mail.com', N'Prénom P:168', N'Female', N'Nom P:168', N'168', CAST(0 AS bit), 28),
    (169, N'Liège 169', N'169', CAST(0 AS bit), N'mail169@mail.com', N'Prénom P:169', N'Male', N'Nom P:169', N'169', CAST(0 AS bit), 29),
    (170, N'Liège 170', N'170', CAST(0 AS bit), N'mail170@mail.com', N'Prénom P:170', N'Female', N'Nom P:170', N'170', CAST(0 AS bit), 29),
    (171, N'Liège 171', N'171', CAST(0 AS bit), N'mail171@mail.com', N'Prénom P:171', N'Male', N'Nom P:171', N'171', CAST(0 AS bit), 29),
    (172, N'Liège 172', N'172', CAST(0 AS bit), N'mail172@mail.com', N'Prénom P:172', N'Female', N'Nom P:172', N'172', CAST(0 AS bit), 29),
    (173, N'Liège 173', N'173', CAST(0 AS bit), N'mail173@mail.com', N'Prénom P:173', N'Male', N'Nom P:173', N'173', CAST(0 AS bit), 29),
    (174, N'Liège 174', N'174', CAST(0 AS bit), N'mail174@mail.com', N'Prénom P:174', N'Female', N'Nom P:174', N'174', CAST(0 AS bit), 29),
    (175, N'Liège 175', N'175', CAST(0 AS bit), N'mail175@mail.com', N'Prénom P:175', N'Male', N'Nom P:175', N'175', CAST(1 AS bit), 30),
    (192, N'Liège 192', N'192', CAST(0 AS bit), N'mail192@mail.com', N'Prénom P:192', N'Female', N'Nom P:192', N'192', CAST(0 AS bit), 32),
    (176, N'Liège 176', N'176', CAST(0 AS bit), N'mail176@mail.com', N'Prénom P:176', N'Female', N'Nom P:176', N'176', CAST(1 AS bit), 30),
    (178, N'Liège 178', N'178', CAST(0 AS bit), N'mail178@mail.com', N'Prénom P:178', N'Female', N'Nom P:178', N'178', CAST(1 AS bit), 30),
    (179, N'Liège 179', N'179', CAST(0 AS bit), N'mail179@mail.com', N'Prénom P:179', N'Male', N'Nom P:179', N'179', CAST(1 AS bit), 30),
    (180, N'Liège 180', N'180', CAST(0 AS bit), N'mail180@mail.com', N'Prénom P:180', N'Female', N'Nom P:180', N'180', CAST(1 AS bit), 30),
    (181, N'Liège 181', N'181', CAST(0 AS bit), N'mail181@mail.com', N'Prénom P:181', N'Male', N'Nom P:181', N'181', CAST(0 AS bit), 31),
    (182, N'Liège 182', N'182', CAST(0 AS bit), N'mail182@mail.com', N'Prénom P:182', N'Female', N'Nom P:182', N'182', CAST(0 AS bit), 31),
    (183, N'Liège 183', N'183', CAST(0 AS bit), N'mail183@mail.com', N'Prénom P:183', N'Male', N'Nom P:183', N'183', CAST(0 AS bit), 31),
    (184, N'Liège 184', N'184', CAST(0 AS bit), N'mail184@mail.com', N'Prénom P:184', N'Female', N'Nom P:184', N'184', CAST(0 AS bit), 31),
    (185, N'Liège 185', N'185', CAST(0 AS bit), N'mail185@mail.com', N'Prénom P:185', N'Male', N'Nom P:185', N'185', CAST(0 AS bit), 31),
    (186, N'Liège 186', N'186', CAST(0 AS bit), N'mail186@mail.com', N'Prénom P:186', N'Female', N'Nom P:186', N'186', CAST(0 AS bit), 31),
    (187, N'Liège 187', N'187', CAST(0 AS bit), N'mail187@mail.com', N'Prénom P:187', N'Male', N'Nom P:187', N'187', CAST(0 AS bit), 32),
    (188, N'Liège 188', N'188', CAST(0 AS bit), N'mail188@mail.com', N'Prénom P:188', N'Female', N'Nom P:188', N'188', CAST(0 AS bit), 32),
    (189, N'Liège 189', N'189', CAST(0 AS bit), N'mail189@mail.com', N'Prénom P:189', N'Male', N'Nom P:189', N'189', CAST(0 AS bit), 32),
    (190, N'Liège 190', N'190', CAST(0 AS bit), N'mail190@mail.com', N'Prénom P:190', N'Female', N'Nom P:190', N'190', CAST(0 AS bit), 32),
    (177, N'Liège 177', N'177', CAST(0 AS bit), N'mail177@mail.com', N'Prénom P:177', N'Male', N'Nom P:177', N'177', CAST(1 AS bit), 30),
    (162, N'Liège 162', N'162', CAST(0 AS bit), N'mail162@mail.com', N'Prénom P:162', N'Female', N'Nom P:162', N'162', CAST(1 AS bit), 27),
    (224, N'Liège 224', N'224', CAST(0 AS bit), N'mail224@mail.com', N'Prénom L:224', N'Female', N'Nom L:224', N'224', CAST(0 AS bit), 38),
    (226, N'Liège 226', N'226', CAST(0 AS bit), N'mail226@mail.com', N'Prénom L:226', N'Female', N'Nom L:226', N'226', CAST(0 AS bit), 38),
    (259, N'Liège 259', N'259', CAST(0 AS bit), N'mail259@mail.com', N'Prénom L:259', N'Male', N'Nom L:259', N'259', CAST(0 AS bit), 44),
    (260, N'Liège 260', N'260', CAST(0 AS bit), N'mail260@mail.com', N'Prénom L:260', N'Female', N'Nom L:260', N'260', CAST(0 AS bit), 44),
    (261, N'Liège 261', N'261', CAST(0 AS bit), N'mail261@mail.com', N'Prénom L:261', N'Male', N'Nom L:261', N'261', CAST(0 AS bit), 44),
    (262, N'Liège 262', N'262', CAST(0 AS bit), N'mail262@mail.com', N'Prénom L:262', N'Female', N'Nom L:262', N'262', CAST(0 AS bit), 44),
    (263, N'Liège 263', N'263', CAST(0 AS bit), N'mail263@mail.com', N'Prénom L:263', N'Male', N'Nom L:263', N'263', CAST(0 AS bit), 44),
    (264, N'Liège 264', N'264', CAST(0 AS bit), N'mail264@mail.com', N'Prénom L:264', N'Female', N'Nom L:264', N'264', CAST(0 AS bit), 44),
    (265, N'Liège 265', N'265', CAST(0 AS bit), N'mail265@mail.com', N'Prénom L:265', N'Male', N'Nom L:265', N'265', CAST(1 AS bit), 45),
    (266, N'Liège 266', N'266', CAST(0 AS bit), N'mail266@mail.com', N'Prénom L:266', N'Female', N'Nom L:266', N'266', CAST(1 AS bit), 45),
    (267, N'Liège 267', N'267', CAST(0 AS bit), N'mail267@mail.com', N'Prénom L:267', N'Male', N'Nom L:267', N'267', CAST(1 AS bit), 45),
    (268, N'Liège 268', N'268', CAST(0 AS bit), N'mail268@mail.com', N'Prénom L:268', N'Female', N'Nom L:268', N'268', CAST(1 AS bit), 45),
    (269, N'Liège 269', N'269', CAST(0 AS bit), N'mail269@mail.com', N'Prénom L:269', N'Male', N'Nom L:269', N'269', CAST(1 AS bit), 45),
    (270, N'Liège 270', N'270', CAST(0 AS bit), N'mail270@mail.com', N'Prénom L:270', N'Female', N'Nom L:270', N'270', CAST(1 AS bit), 45),
    (271, N'Liège 271', N'271', CAST(0 AS bit), N'mail271@mail.com', N'Prénom L:271', N'Male', N'Nom L:271', N'271', CAST(0 AS bit), 46),
    (258, N'Liège 258', N'258', CAST(0 AS bit), N'mail258@mail.com', N'Prénom L:258', N'Female', N'Nom L:258', N'258', CAST(0 AS bit), 43),
    (272, N'Liège 272', N'272', CAST(0 AS bit), N'mail272@mail.com', N'Prénom L:272', N'Female', N'Nom L:272', N'272', CAST(0 AS bit), 46),
    (274, N'Liège 274', N'274', CAST(0 AS bit), N'mail274@mail.com', N'Prénom L:274', N'Female', N'Nom L:274', N'274', CAST(0 AS bit), 46),
    (275, N'Liège 275', N'275', CAST(0 AS bit), N'mail275@mail.com', N'Prénom L:275', N'Male', N'Nom L:275', N'275', CAST(0 AS bit), 46),
    (276, N'Liège 276', N'276', CAST(0 AS bit), N'mail276@mail.com', N'Prénom L:276', N'Female', N'Nom L:276', N'276', CAST(0 AS bit), 46),
    (277, N'Liège 277', N'277', CAST(0 AS bit), N'mail277@mail.com', N'Prénom L:277', N'Male', N'Nom L:277', N'277', CAST(0 AS bit), 47),
    (278, N'Liège 278', N'278', CAST(0 AS bit), N'mail278@mail.com', N'Prénom L:278', N'Female', N'Nom L:278', N'278', CAST(0 AS bit), 47),
    (279, N'Liège 279', N'279', CAST(0 AS bit), N'mail279@mail.com', N'Prénom L:279', N'Male', N'Nom L:279', N'279', CAST(0 AS bit), 47),
    (280, N'Liège 280', N'280', CAST(0 AS bit), N'mail280@mail.com', N'Prénom L:280', N'Female', N'Nom L:280', N'280', CAST(0 AS bit), 47),
    (281, N'Liège 281', N'281', CAST(0 AS bit), N'mail281@mail.com', N'Prénom L:281', N'Male', N'Nom L:281', N'281', CAST(0 AS bit), 47),
    (282, N'Liège 282', N'282', CAST(0 AS bit), N'mail282@mail.com', N'Prénom L:282', N'Female', N'Nom L:282', N'282', CAST(0 AS bit), 47),
    (283, N'Liège 283', N'283', CAST(0 AS bit), N'mail283@mail.com', N'Prénom L:283', N'Male', N'Nom L:283', N'283', CAST(1 AS bit), 48),
    (284, N'Liège 284', N'284', CAST(0 AS bit), N'mail284@mail.com', N'Prénom L:284', N'Female', N'Nom L:284', N'284', CAST(1 AS bit), 48),
    (285, N'Liège 285', N'285', CAST(0 AS bit), N'mail285@mail.com', N'Prénom L:285', N'Male', N'Nom L:285', N'285', CAST(1 AS bit), 48),
    (286, N'Liège 286', N'286', CAST(0 AS bit), N'mail286@mail.com', N'Prénom L:286', N'Female', N'Nom L:286', N'286', CAST(1 AS bit), 48),
    (273, N'Liège 273', N'273', CAST(0 AS bit), N'mail273@mail.com', N'Prénom L:273', N'Male', N'Nom L:273', N'273', CAST(0 AS bit), 46),
    (225, N'Liège 225', N'225', CAST(0 AS bit), N'mail225@mail.com', N'Prénom L:225', N'Male', N'Nom L:225', N'225', CAST(0 AS bit), 38),
    (257, N'Liège 257', N'257', CAST(0 AS bit), N'mail257@mail.com', N'Prénom L:257', N'Male', N'Nom L:257', N'257', CAST(0 AS bit), 43),
    (255, N'Liège 255', N'255', CAST(0 AS bit), N'mail255@mail.com', N'Prénom L:255', N'Male', N'Nom L:255', N'255', CAST(0 AS bit), 43),
    (227, N'Liège 227', N'227', CAST(0 AS bit), N'mail227@mail.com', N'Prénom L:227', N'Male', N'Nom L:227', N'227', CAST(0 AS bit), 38),
    (228, N'Liège 228', N'228', CAST(0 AS bit), N'mail228@mail.com', N'Prénom L:228', N'Female', N'Nom L:228', N'228', CAST(0 AS bit), 38),
    (229, N'Liège 229', N'229', CAST(0 AS bit), N'mail229@mail.com', N'Prénom L:229', N'Male', N'Nom L:229', N'229', CAST(1 AS bit), 39),
    (230, N'Liège 230', N'230', CAST(0 AS bit), N'mail230@mail.com', N'Prénom L:230', N'Female', N'Nom L:230', N'230', CAST(1 AS bit), 39),
    (231, N'Liège 231', N'231', CAST(0 AS bit), N'mail231@mail.com', N'Prénom L:231', N'Male', N'Nom L:231', N'231', CAST(1 AS bit), 39),
    (232, N'Liège 232', N'232', CAST(0 AS bit), N'mail232@mail.com', N'Prénom L:232', N'Female', N'Nom L:232', N'232', CAST(1 AS bit), 39),
    (233, N'Liège 233', N'233', CAST(0 AS bit), N'mail233@mail.com', N'Prénom L:233', N'Male', N'Nom L:233', N'233', CAST(1 AS bit), 39),
    (234, N'Liège 234', N'234', CAST(0 AS bit), N'mail234@mail.com', N'Prénom L:234', N'Female', N'Nom L:234', N'234', CAST(1 AS bit), 39),
    (235, N'Liège 235', N'235', CAST(0 AS bit), N'mail235@mail.com', N'Prénom L:235', N'Male', N'Nom L:235', N'235', CAST(0 AS bit), 40),
    (236, N'Liège 236', N'236', CAST(0 AS bit), N'mail236@mail.com', N'Prénom L:236', N'Female', N'Nom L:236', N'236', CAST(0 AS bit), 40),
    (237, N'Liège 237', N'237', CAST(0 AS bit), N'mail237@mail.com', N'Prénom L:237', N'Male', N'Nom L:237', N'237', CAST(0 AS bit), 40),
    (238, N'Liège 238', N'238', CAST(0 AS bit), N'mail238@mail.com', N'Prénom L:238', N'Female', N'Nom L:238', N'238', CAST(0 AS bit), 40),
    (239, N'Liège 239', N'239', CAST(0 AS bit), N'mail239@mail.com', N'Prénom L:239', N'Male', N'Nom L:239', N'239', CAST(0 AS bit), 40),
    (256, N'Liège 256', N'256', CAST(0 AS bit), N'mail256@mail.com', N'Prénom L:256', N'Female', N'Nom L:256', N'256', CAST(0 AS bit), 43),
    (240, N'Liège 240', N'240', CAST(0 AS bit), N'mail240@mail.com', N'Prénom L:240', N'Female', N'Nom L:240', N'240', CAST(0 AS bit), 40),
    (242, N'Liège 242', N'242', CAST(0 AS bit), N'mail242@mail.com', N'Prénom L:242', N'Female', N'Nom L:242', N'242', CAST(0 AS bit), 41),
    (243, N'Liège 243', N'243', CAST(0 AS bit), N'mail243@mail.com', N'Prénom L:243', N'Male', N'Nom L:243', N'243', CAST(0 AS bit), 41),
    (244, N'Liège 244', N'244', CAST(0 AS bit), N'mail244@mail.com', N'Prénom L:244', N'Female', N'Nom L:244', N'244', CAST(0 AS bit), 41),
    (245, N'Liège 245', N'245', CAST(0 AS bit), N'mail245@mail.com', N'Prénom L:245', N'Male', N'Nom L:245', N'245', CAST(0 AS bit), 41),
    (246, N'Liège 246', N'246', CAST(0 AS bit), N'mail246@mail.com', N'Prénom L:246', N'Female', N'Nom L:246', N'246', CAST(0 AS bit), 41),
    (247, N'Liège 247', N'247', CAST(0 AS bit), N'mail247@mail.com', N'Prénom L:247', N'Male', N'Nom L:247', N'247', CAST(1 AS bit), 42),
    (248, N'Liège 248', N'248', CAST(0 AS bit), N'mail248@mail.com', N'Prénom L:248', N'Female', N'Nom L:248', N'248', CAST(1 AS bit), 42),
    (249, N'Liège 249', N'249', CAST(0 AS bit), N'mail249@mail.com', N'Prénom L:249', N'Male', N'Nom L:249', N'249', CAST(1 AS bit), 42),
    (250, N'Liège 250', N'250', CAST(0 AS bit), N'mail250@mail.com', N'Prénom L:250', N'Female', N'Nom L:250', N'250', CAST(1 AS bit), 42),
    (251, N'Liège 251', N'251', CAST(0 AS bit), N'mail251@mail.com', N'Prénom L:251', N'Male', N'Nom L:251', N'251', CAST(1 AS bit), 42),
    (252, N'Liège 252', N'252', CAST(0 AS bit), N'mail252@mail.com', N'Prénom L:252', N'Female', N'Nom L:252', N'252', CAST(1 AS bit), 42),
    (253, N'Liège 253', N'253', CAST(0 AS bit), N'mail253@mail.com', N'Prénom L:253', N'Male', N'Nom L:253', N'253', CAST(0 AS bit), 43),
    (254, N'Liège 254', N'254', CAST(0 AS bit), N'mail254@mail.com', N'Prénom L:254', N'Female', N'Nom L:254', N'254', CAST(0 AS bit), 43),
    (241, N'Liège 241', N'241', CAST(0 AS bit), N'mail241@mail.com', N'Prénom L:241', N'Male', N'Nom L:241', N'241', CAST(0 AS bit), 41),
    (161, N'Liège 161', N'161', CAST(0 AS bit), N'mail161@mail.com', N'Prénom P:161', N'Male', N'Nom P:161', N'161', CAST(1 AS bit), 27),
    (160, N'Liège 160', N'160', CAST(0 AS bit), N'mail160@mail.com', N'Prénom P:160', N'Female', N'Nom P:160', N'160', CAST(1 AS bit), 27),
    (159, N'Liège 159', N'159', CAST(0 AS bit), N'mail159@mail.com', N'Prénom P:159', N'Male', N'Nom P:159', N'159', CAST(1 AS bit), 27),
    (34, N'Liège 34', N'34', CAST(0 AS bit), N'mail34@mail.com', N'Prénom N:34', N'Female', N'Nom N:34', N'34', CAST(1 AS bit), 9),
    (35, N'Liège 35', N'35', CAST(0 AS bit), N'mail35@mail.com', N'Prénom N:35', N'Male', N'Nom N:35', N'35', CAST(1 AS bit), 9),
    (36, N'Liège 36', N'36', CAST(0 AS bit), N'mail36@mail.com', N'Prénom N:36', N'Female', N'Nom N:36', N'36', CAST(1 AS bit), 9),
    (37, N'Liège 37', N'37', CAST(0 AS bit), N'mail37@mail.com', N'Prénom N:37', N'Male', N'Nom N:37', N'37', CAST(0 AS bit), 10),
    (38, N'Liège 38', N'38', CAST(0 AS bit), N'mail38@mail.com', N'Prénom N:38', N'Female', N'Nom N:38', N'38', CAST(0 AS bit), 10),
    (39, N'Liège 39', N'39', CAST(0 AS bit), N'mail39@mail.com', N'Prénom N:39', N'Male', N'Nom N:39', N'39', CAST(0 AS bit), 10),
    (40, N'Liège 40', N'40', CAST(0 AS bit), N'mail40@mail.com', N'Prénom N:40', N'Female', N'Nom N:40', N'40', CAST(0 AS bit), 10),
    (41, N'Liège 41', N'41', CAST(0 AS bit), N'mail41@mail.com', N'Prénom N:41', N'Male', N'Nom N:41', N'41', CAST(0 AS bit), 11),
    (42, N'Liège 42', N'42', CAST(0 AS bit), N'mail42@mail.com', N'Prénom N:42', N'Female', N'Nom N:42', N'42', CAST(0 AS bit), 11),
    (43, N'Liège 43', N'43', CAST(0 AS bit), N'mail43@mail.com', N'Prénom N:43', N'Male', N'Nom N:43', N'43', CAST(0 AS bit), 11),
    (44, N'Liège 44', N'44', CAST(0 AS bit), N'mail44@mail.com', N'Prénom N:44', N'Female', N'Nom N:44', N'44', CAST(0 AS bit), 11),
    (45, N'Liège 45', N'45', CAST(0 AS bit), N'mail45@mail.com', N'Prénom N:45', N'Male', N'Nom N:45', N'45', CAST(1 AS bit), 12),
    (46, N'Liège 46', N'46', CAST(0 AS bit), N'mail46@mail.com', N'Prénom N:46', N'Female', N'Nom N:46', N'46', CAST(1 AS bit), 12),
    (33, N'Liège 33', N'33', CAST(0 AS bit), N'mail33@mail.com', N'Prénom N:33', N'Male', N'Nom N:33', N'33', CAST(1 AS bit), 9),
    (47, N'Liège 47', N'47', CAST(0 AS bit), N'mail47@mail.com', N'Prénom N:47', N'Male', N'Nom N:47', N'47', CAST(1 AS bit), 12),
    (49, N'Liège 49', N'49', CAST(0 AS bit), N'mail49@mail.com', N'Prénom N:49', N'Male', N'Nom N:49', N'49', CAST(0 AS bit), 13),
    (50, N'Liège 50', N'50', CAST(0 AS bit), N'mail50@mail.com', N'Prénom N:50', N'Female', N'Nom N:50', N'50', CAST(0 AS bit), 13),
    (51, N'Liège 51', N'51', CAST(0 AS bit), N'mail51@mail.com', N'Prénom N:51', N'Male', N'Nom N:51', N'51', CAST(0 AS bit), 13),
    (52, N'Liège 52', N'52', CAST(0 AS bit), N'mail52@mail.com', N'Prénom N:52', N'Female', N'Nom N:52', N'52', CAST(0 AS bit), 13),
    (53, N'Liège 53', N'53', CAST(0 AS bit), N'mail53@mail.com', N'Prénom N:53', N'Male', N'Nom N:53', N'53', CAST(0 AS bit), 14),
    (54, N'Liège 54', N'54', CAST(0 AS bit), N'mail54@mail.com', N'Prénom N:54', N'Female', N'Nom N:54', N'54', CAST(0 AS bit), 14),
    (55, N'Liège 55', N'55', CAST(0 AS bit), N'mail55@mail.com', N'Prénom N:55', N'Male', N'Nom N:55', N'55', CAST(0 AS bit), 14),
    (56, N'Liège 56', N'56', CAST(0 AS bit), N'mail56@mail.com', N'Prénom N:56', N'Female', N'Nom N:56', N'56', CAST(0 AS bit), 14),
    (57, N'Liège 57', N'57', CAST(0 AS bit), N'mail57@mail.com', N'Prénom N:57', N'Male', N'Nom N:57', N'57', CAST(1 AS bit), 15),
    (58, N'Liège 58', N'58', CAST(0 AS bit), N'mail58@mail.com', N'Prénom N:58', N'Female', N'Nom N:58', N'58', CAST(1 AS bit), 15),
    (59, N'Liège 59', N'59', CAST(0 AS bit), N'mail59@mail.com', N'Prénom N:59', N'Male', N'Nom N:59', N'59', CAST(1 AS bit), 15),
    (60, N'Liège 60', N'60', CAST(0 AS bit), N'mail60@mail.com', N'Prénom N:60', N'Female', N'Nom N:60', N'60', CAST(1 AS bit), 15),
    (61, N'Liège 61', N'61', CAST(0 AS bit), N'mail61@mail.com', N'Prénom N:61', N'Male', N'Nom N:61', N'61', CAST(0 AS bit), 16),
    (48, N'Liège 48', N'48', CAST(0 AS bit), N'mail48@mail.com', N'Prénom N:48', N'Female', N'Nom N:48', N'48', CAST(1 AS bit), 12),
    (62, N'Liège 62', N'62', CAST(0 AS bit), N'mail62@mail.com', N'Prénom N:62', N'Female', N'Nom N:62', N'62', CAST(0 AS bit), 16),
    (32, N'Liège 32', N'32', CAST(0 AS bit), N'mail32@mail.com', N'Prénom N:32', N'Female', N'Nom N:32', N'32', CAST(0 AS bit), 8),
    (30, N'Liège 30', N'30', CAST(0 AS bit), N'mail30@mail.com', N'Prénom N:30', N'Female', N'Nom N:30', N'30', CAST(0 AS bit), 8),
    (2, N'Liège 2', N'2', CAST(1 AS bit), N'mail2@mail.com', N'Prénom N:2', N'Female', N'Nom N:2', N'2', CAST(0 AS bit), 1),
    (3, N'Liège 3', N'3', CAST(1 AS bit), N'mail3@mail.com', N'Prénom N:3', N'Male', N'Nom N:3', N'3', CAST(0 AS bit), 1),
    (4, N'Liège 4', N'4', CAST(1 AS bit), N'mail4@mail.com', N'Prénom N:4', N'Female', N'Nom N:4', N'4', CAST(0 AS bit), 1),
    (5, N'Liège 5', N'5', CAST(0 AS bit), N'mail5@mail.com', N'Prénom N:5', N'Male', N'Nom N:5', N'5', CAST(0 AS bit), 2),
    (6, N'Liège 6', N'6', CAST(0 AS bit), N'mail6@mail.com', N'Prénom N:6', N'Female', N'Nom N:6', N'6', CAST(0 AS bit), 2),
    (7, N'Liège 7', N'7', CAST(0 AS bit), N'mail7@mail.com', N'Prénom N:7', N'Male', N'Nom N:7', N'7', CAST(0 AS bit), 2),
    (8, N'Liège 8', N'8', CAST(0 AS bit), N'mail8@mail.com', N'Prénom N:8', N'Female', N'Nom N:8', N'8', CAST(0 AS bit), 2),
    (9, N'Liège 9', N'9', CAST(0 AS bit), N'mail9@mail.com', N'Prénom N:9', N'Male', N'Nom N:9', N'9', CAST(1 AS bit), 3),
    (10, N'Liège 10', N'10', CAST(0 AS bit), N'mail10@mail.com', N'Prénom N:10', N'Female', N'Nom N:10', N'10', CAST(1 AS bit), 3),
    (11, N'Liège 11', N'11', CAST(0 AS bit), N'mail11@mail.com', N'Prénom N:11', N'Male', N'Nom N:11', N'11', CAST(1 AS bit), 3),
    (12, N'Liège 12', N'12', CAST(0 AS bit), N'mail12@mail.com', N'Prénom N:12', N'Female', N'Nom N:12', N'12', CAST(1 AS bit), 3),
    (13, N'Liège 13', N'13', CAST(0 AS bit), N'mail13@mail.com', N'Prénom N:13', N'Male', N'Nom N:13', N'13', CAST(0 AS bit), 4),
    (14, N'Liège 14', N'14', CAST(0 AS bit), N'mail14@mail.com', N'Prénom N:14', N'Female', N'Nom N:14', N'14', CAST(0 AS bit), 4),
    (31, N'Liège 31', N'31', CAST(0 AS bit), N'mail31@mail.com', N'Prénom N:31', N'Male', N'Nom N:31', N'31', CAST(0 AS bit), 8),
    (15, N'Liège 15', N'15', CAST(0 AS bit), N'mail15@mail.com', N'Prénom N:15', N'Male', N'Nom N:15', N'15', CAST(0 AS bit), 4),
    (17, N'Liège 17', N'17', CAST(0 AS bit), N'mail17@mail.com', N'Prénom N:17', N'Male', N'Nom N:17', N'17', CAST(0 AS bit), 5),
    (18, N'Liège 18', N'18', CAST(0 AS bit), N'mail18@mail.com', N'Prénom N:18', N'Female', N'Nom N:18', N'18', CAST(0 AS bit), 5),
    (19, N'Liège 19', N'19', CAST(0 AS bit), N'mail19@mail.com', N'Prénom N:19', N'Male', N'Nom N:19', N'19', CAST(0 AS bit), 5),
    (20, N'Liège 20', N'20', CAST(0 AS bit), N'mail20@mail.com', N'Prénom N:20', N'Female', N'Nom N:20', N'20', CAST(0 AS bit), 5),
    (21, N'Liège 21', N'21', CAST(0 AS bit), N'mail21@mail.com', N'Prénom N:21', N'Male', N'Nom N:21', N'21', CAST(1 AS bit), 6),
    (22, N'Liège 22', N'22', CAST(0 AS bit), N'mail22@mail.com', N'Prénom N:22', N'Female', N'Nom N:22', N'22', CAST(1 AS bit), 6),
    (23, N'Liège 23', N'23', CAST(0 AS bit), N'mail23@mail.com', N'Prénom N:23', N'Male', N'Nom N:23', N'23', CAST(1 AS bit), 6),
    (24, N'Liège 24', N'24', CAST(0 AS bit), N'mail24@mail.com', N'Prénom N:24', N'Female', N'Nom N:24', N'24', CAST(1 AS bit), 6),
    (25, N'Liège 25', N'25', CAST(0 AS bit), N'mail25@mail.com', N'Prénom N:25', N'Male', N'Nom N:25', N'25', CAST(0 AS bit), 7),
    (26, N'Liège 26', N'26', CAST(0 AS bit), N'mail26@mail.com', N'Prénom N:26', N'Female', N'Nom N:26', N'26', CAST(0 AS bit), 7),
    (27, N'Liège 27', N'27', CAST(0 AS bit), N'mail27@mail.com', N'Prénom N:27', N'Male', N'Nom N:27', N'27', CAST(0 AS bit), 7),
    (28, N'Liège 28', N'28', CAST(0 AS bit), N'mail28@mail.com', N'Prénom N:28', N'Female', N'Nom N:28', N'28', CAST(0 AS bit), 7),
    (29, N'Liège 29', N'29', CAST(0 AS bit), N'mail29@mail.com', N'Prénom N:29', N'Male', N'Nom N:29', N'29', CAST(0 AS bit), 8),
    (16, N'Liège 16', N'16', CAST(0 AS bit), N'mail16@mail.com', N'Prénom N:16', N'Female', N'Nom N:16', N'16', CAST(0 AS bit), 4);
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Adress', N'AffiliationNumber', N'Capitain', N'Email', N'Firstname', N'Gender', N'Lastname', N'PhoneNumber', N'Reservist', N'TeamId') AND [object_id] = OBJECT_ID(N'[Player]'))
        SET IDENTITY_INSERT [Player] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200521142328_Init')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Adress', N'AffiliationNumber', N'Capitain', N'Email', N'Firstname', N'Gender', N'Lastname', N'PhoneNumber', N'Reservist', N'TeamId') AND [object_id] = OBJECT_ID(N'[Player]'))
        SET IDENTITY_INSERT [Player] ON;
    INSERT INTO [Player] ([Id], [Adress], [AffiliationNumber], [Capitain], [Email], [Firstname], [Gender], [Lastname], [PhoneNumber], [Reservist], [TeamId])
    VALUES (63, N'Liège 63', N'63', CAST(0 AS bit), N'mail63@mail.com', N'Prénom N:63', N'Male', N'Nom N:63', N'63', CAST(0 AS bit), 16),
    (64, N'Liège 64', N'64', CAST(0 AS bit), N'mail64@mail.com', N'Prénom N:64', N'Female', N'Nom N:64', N'64', CAST(0 AS bit), 16),
    (97, N'Liège 97', N'97', CAST(0 AS bit), N'mail97@mail.com', N'Prénom P:97', N'Male', N'Nom P:97', N'97', CAST(0 AS bit), 17),
    (131, N'Liège 131', N'131', CAST(0 AS bit), N'mail131@mail.com', N'Prénom P:131', N'Male', N'Nom P:131', N'131', CAST(0 AS bit), 22),
    (132, N'Liège 132', N'132', CAST(0 AS bit), N'mail132@mail.com', N'Prénom P:132', N'Female', N'Nom P:132', N'132', CAST(0 AS bit), 22),
    (133, N'Liège 133', N'133', CAST(0 AS bit), N'mail133@mail.com', N'Prénom P:133', N'Male', N'Nom P:133', N'133', CAST(0 AS bit), 23),
    (134, N'Liège 134', N'134', CAST(0 AS bit), N'mail134@mail.com', N'Prénom P:134', N'Female', N'Nom P:134', N'134', CAST(0 AS bit), 23),
    (135, N'Liège 135', N'135', CAST(0 AS bit), N'mail135@mail.com', N'Prénom P:135', N'Male', N'Nom P:135', N'135', CAST(0 AS bit), 23),
    (136, N'Liège 136', N'136', CAST(0 AS bit), N'mail136@mail.com', N'Prénom P:136', N'Female', N'Nom P:136', N'136', CAST(0 AS bit), 23),
    (137, N'Liège 137', N'137', CAST(0 AS bit), N'mail137@mail.com', N'Prénom P:137', N'Male', N'Nom P:137', N'137', CAST(0 AS bit), 23),
    (138, N'Liège 138', N'138', CAST(0 AS bit), N'mail138@mail.com', N'Prénom P:138', N'Female', N'Nom P:138', N'138', CAST(0 AS bit), 23),
    (139, N'Liège 139', N'139', CAST(0 AS bit), N'mail139@mail.com', N'Prénom P:139', N'Male', N'Nom P:139', N'139', CAST(1 AS bit), 24),
    (140, N'Liège 140', N'140', CAST(0 AS bit), N'mail140@mail.com', N'Prénom P:140', N'Female', N'Nom P:140', N'140', CAST(1 AS bit), 24),
    (141, N'Liège 141', N'141', CAST(0 AS bit), N'mail141@mail.com', N'Prénom P:141', N'Male', N'Nom P:141', N'141', CAST(1 AS bit), 24),
    (142, N'Liège 142', N'142', CAST(0 AS bit), N'mail142@mail.com', N'Prénom P:142', N'Female', N'Nom P:142', N'142', CAST(1 AS bit), 24),
    (143, N'Liège 143', N'143', CAST(0 AS bit), N'mail143@mail.com', N'Prénom P:143', N'Male', N'Nom P:143', N'143', CAST(1 AS bit), 24),
    (130, N'Liège 130', N'130', CAST(0 AS bit), N'mail130@mail.com', N'Prénom P:130', N'Female', N'Nom P:130', N'130', CAST(0 AS bit), 22),
    (144, N'Liège 144', N'144', CAST(0 AS bit), N'mail144@mail.com', N'Prénom P:144', N'Female', N'Nom P:144', N'144', CAST(1 AS bit), 24),
    (146, N'Liège 146', N'146', CAST(0 AS bit), N'mail146@mail.com', N'Prénom P:146', N'Female', N'Nom P:146', N'146', CAST(0 AS bit), 25),
    (147, N'Liège 147', N'147', CAST(0 AS bit), N'mail147@mail.com', N'Prénom P:147', N'Male', N'Nom P:147', N'147', CAST(0 AS bit), 25),
    (148, N'Liège 148', N'148', CAST(0 AS bit), N'mail148@mail.com', N'Prénom P:148', N'Female', N'Nom P:148', N'148', CAST(0 AS bit), 25),
    (149, N'Liège 149', N'149', CAST(0 AS bit), N'mail149@mail.com', N'Prénom P:149', N'Male', N'Nom P:149', N'149', CAST(0 AS bit), 25),
    (150, N'Liège 150', N'150', CAST(0 AS bit), N'mail150@mail.com', N'Prénom P:150', N'Female', N'Nom P:150', N'150', CAST(0 AS bit), 25),
    (151, N'Liège 151', N'151', CAST(0 AS bit), N'mail151@mail.com', N'Prénom P:151', N'Male', N'Nom P:151', N'151', CAST(0 AS bit), 26),
    (152, N'Liège 152', N'152', CAST(0 AS bit), N'mail152@mail.com', N'Prénom P:152', N'Female', N'Nom P:152', N'152', CAST(0 AS bit), 26),
    (153, N'Liège 153', N'153', CAST(0 AS bit), N'mail153@mail.com', N'Prénom P:153', N'Male', N'Nom P:153', N'153', CAST(0 AS bit), 26),
    (154, N'Liège 154', N'154', CAST(0 AS bit), N'mail154@mail.com', N'Prénom P:154', N'Female', N'Nom P:154', N'154', CAST(0 AS bit), 26),
    (155, N'Liège 155', N'155', CAST(0 AS bit), N'mail155@mail.com', N'Prénom P:155', N'Male', N'Nom P:155', N'155', CAST(0 AS bit), 26),
    (156, N'Liège 156', N'156', CAST(0 AS bit), N'mail156@mail.com', N'Prénom P:156', N'Female', N'Nom P:156', N'156', CAST(0 AS bit), 26),
    (157, N'Liège 157', N'157', CAST(0 AS bit), N'mail157@mail.com', N'Prénom P:157', N'Male', N'Nom P:157', N'157', CAST(1 AS bit), 27),
    (158, N'Liège 158', N'158', CAST(0 AS bit), N'mail158@mail.com', N'Prénom P:158', N'Female', N'Nom P:158', N'158', CAST(1 AS bit), 27),
    (145, N'Liège 145', N'145', CAST(0 AS bit), N'mail145@mail.com', N'Prénom P:145', N'Male', N'Nom P:145', N'145', CAST(0 AS bit), 25),
    (129, N'Liège 129', N'129', CAST(0 AS bit), N'mail129@mail.com', N'Prénom P:129', N'Male', N'Nom P:129', N'129', CAST(0 AS bit), 22),
    (128, N'Liège 128', N'128', CAST(0 AS bit), N'mail128@mail.com', N'Prénom P:128', N'Female', N'Nom P:128', N'128', CAST(0 AS bit), 22),
    (127, N'Liège 127', N'127', CAST(0 AS bit), N'mail127@mail.com', N'Prénom P:127', N'Male', N'Nom P:127', N'127', CAST(0 AS bit), 22),
    (98, N'Liège 98', N'98', CAST(0 AS bit), N'mail98@mail.com', N'Prénom P:98', N'Female', N'Nom P:98', N'98', CAST(0 AS bit), 17),
    (99, N'Liège 99', N'99', CAST(0 AS bit), N'mail99@mail.com', N'Prénom P:99', N'Male', N'Nom P:99', N'99', CAST(0 AS bit), 17),
    (100, N'Liège 100', N'100', CAST(0 AS bit), N'mail100@mail.com', N'Prénom P:100', N'Female', N'Nom P:100', N'100', CAST(0 AS bit), 17),
    (101, N'Liège 101', N'101', CAST(0 AS bit), N'mail101@mail.com', N'Prénom P:101', N'Male', N'Nom P:101', N'101', CAST(0 AS bit), 17),
    (102, N'Liège 102', N'102', CAST(0 AS bit), N'mail102@mail.com', N'Prénom P:102', N'Female', N'Nom P:102', N'102', CAST(0 AS bit), 17),
    (103, N'Liège 103', N'103', CAST(0 AS bit), N'mail103@mail.com', N'Prénom P:103', N'Male', N'Nom P:103', N'103', CAST(1 AS bit), 18),
    (104, N'Liège 104', N'104', CAST(0 AS bit), N'mail104@mail.com', N'Prénom P:104', N'Female', N'Nom P:104', N'104', CAST(1 AS bit), 18),
    (105, N'Liège 105', N'105', CAST(0 AS bit), N'mail105@mail.com', N'Prénom P:105', N'Male', N'Nom P:105', N'105', CAST(1 AS bit), 18),
    (106, N'Liège 106', N'106', CAST(0 AS bit), N'mail106@mail.com', N'Prénom P:106', N'Female', N'Nom P:106', N'106', CAST(1 AS bit), 18),
    (107, N'Liège 107', N'107', CAST(0 AS bit), N'mail107@mail.com', N'Prénom P:107', N'Male', N'Nom P:107', N'107', CAST(1 AS bit), 18),
    (108, N'Liège 108', N'108', CAST(0 AS bit), N'mail108@mail.com', N'Prénom P:108', N'Female', N'Nom P:108', N'108', CAST(1 AS bit), 18),
    (109, N'Liège 109', N'109', CAST(0 AS bit), N'mail109@mail.com', N'Prénom P:109', N'Male', N'Nom P:109', N'109', CAST(0 AS bit), 19),
    (110, N'Liège 110', N'110', CAST(0 AS bit), N'mail110@mail.com', N'Prénom P:110', N'Female', N'Nom P:110', N'110', CAST(0 AS bit), 19),
    (111, N'Liège 111', N'111', CAST(0 AS bit), N'mail111@mail.com', N'Prénom P:111', N'Male', N'Nom P:111', N'111', CAST(0 AS bit), 19),
    (112, N'Liège 112', N'112', CAST(0 AS bit), N'mail112@mail.com', N'Prénom P:112', N'Female', N'Nom P:112', N'112', CAST(0 AS bit), 19),
    (113, N'Liège 113', N'113', CAST(0 AS bit), N'mail113@mail.com', N'Prénom P:113', N'Male', N'Nom P:113', N'113', CAST(0 AS bit), 19),
    (114, N'Liège 114', N'114', CAST(0 AS bit), N'mail114@mail.com', N'Prénom P:114', N'Female', N'Nom P:114', N'114', CAST(0 AS bit), 19),
    (115, N'Liège 115', N'115', CAST(0 AS bit), N'mail115@mail.com', N'Prénom P:115', N'Male', N'Nom P:115', N'115', CAST(0 AS bit), 20),
    (116, N'Liège 116', N'116', CAST(0 AS bit), N'mail116@mail.com', N'Prénom P:116', N'Female', N'Nom P:116', N'116', CAST(0 AS bit), 20),
    (117, N'Liège 117', N'117', CAST(0 AS bit), N'mail117@mail.com', N'Prénom P:117', N'Male', N'Nom P:117', N'117', CAST(0 AS bit), 20),
    (118, N'Liège 118', N'118', CAST(0 AS bit), N'mail118@mail.com', N'Prénom P:118', N'Female', N'Nom P:118', N'118', CAST(0 AS bit), 20),
    (119, N'Liège 119', N'119', CAST(0 AS bit), N'mail119@mail.com', N'Prénom P:119', N'Male', N'Nom P:119', N'119', CAST(0 AS bit), 20),
    (120, N'Liège 120', N'120', CAST(0 AS bit), N'mail120@mail.com', N'Prénom P:120', N'Female', N'Nom P:120', N'120', CAST(0 AS bit), 20),
    (121, N'Liège 121', N'121', CAST(0 AS bit), N'mail121@mail.com', N'Prénom P:121', N'Male', N'Nom P:121', N'121', CAST(1 AS bit), 21),
    (122, N'Liège 122', N'122', CAST(0 AS bit), N'mail122@mail.com', N'Prénom P:122', N'Female', N'Nom P:122', N'122', CAST(1 AS bit), 21),
    (123, N'Liège 123', N'123', CAST(0 AS bit), N'mail123@mail.com', N'Prénom P:123', N'Male', N'Nom P:123', N'123', CAST(1 AS bit), 21),
    (124, N'Liège 124', N'124', CAST(0 AS bit), N'mail124@mail.com', N'Prénom P:124', N'Female', N'Nom P:124', N'124', CAST(1 AS bit), 21),
    (125, N'Liège 125', N'125', CAST(0 AS bit), N'mail125@mail.com', N'Prénom P:125', N'Male', N'Nom P:125', N'125', CAST(1 AS bit), 21),
    (126, N'Liège 126', N'126', CAST(0 AS bit), N'mail126@mail.com', N'Prénom P:126', N'Female', N'Nom P:126', N'126', CAST(1 AS bit), 21),
    (287, N'Liège 287', N'287', CAST(0 AS bit), N'mail287@mail.com', N'Prénom L:287', N'Male', N'Nom L:287', N'287', CAST(1 AS bit), 48),
    (288, N'Liège 288', N'288', CAST(0 AS bit), N'mail288@mail.com', N'Prénom L:288', N'Female', N'Nom L:288', N'288', CAST(1 AS bit), 48);
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Adress', N'AffiliationNumber', N'Capitain', N'Email', N'Firstname', N'Gender', N'Lastname', N'PhoneNumber', N'Reservist', N'TeamId') AND [object_id] = OBJECT_ID(N'[Player]'))
        SET IDENTITY_INSERT [Player] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200521142328_Init')
BEGIN
    CREATE INDEX [IX_AspNetRoleClaims_RoleId] ON [AspNetRoleClaims] ([RoleId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200521142328_Init')
BEGIN
    CREATE UNIQUE INDEX [RoleNameIndex] ON [AspNetRoles] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200521142328_Init')
BEGIN
    CREATE INDEX [IX_AspNetUserClaims_UserId] ON [AspNetUserClaims] ([UserId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200521142328_Init')
BEGIN
    CREATE INDEX [IX_AspNetUserLogins_UserId] ON [AspNetUserLogins] ([UserId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200521142328_Init')
BEGIN
    CREATE INDEX [IX_AspNetUserRoles_RoleId] ON [AspNetUserRoles] ([RoleId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200521142328_Init')
BEGIN
    CREATE INDEX [EmailIndex] ON [AspNetUsers] ([NormalizedEmail]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200521142328_Init')
BEGIN
    CREATE UNIQUE INDEX [UserNameIndex] ON [AspNetUsers] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200521142328_Init')
BEGIN
    CREATE INDEX [IX_Confrontations_TeamAId] ON [Confrontations] ([TeamAId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200521142328_Init')
BEGIN
    CREATE INDEX [IX_Confrontations_TeamBId] ON [Confrontations] ([TeamBId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200521142328_Init')
BEGIN
    CREATE INDEX [IX_Confrontations_TeamRefereeId] ON [Confrontations] ([TeamRefereeId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200521142328_Init')
BEGIN
    CREATE INDEX [IX_Confrontations_TerrainNumber] ON [Confrontations] ([TerrainNumber]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200521142328_Init')
BEGIN
    CREATE INDEX [IX_Player_TeamId] ON [Player] ([TeamId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200521142328_Init')
BEGIN
    CREATE INDEX [IX_Teams_CategoryId] ON [Teams] ([CategoryId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200521142328_Init')
BEGIN
    CREATE INDEX [IX_Teams_PoolId] ON [Teams] ([PoolId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200521142328_Init')
BEGIN
    CREATE INDEX [IX_Terrain_CategoryId] ON [Terrain] ([CategoryId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200521142328_Init')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200521142328_Init', N'3.1.3');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200527184703_AddLevelTable')
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Confrontations]') AND [c].[name] = N'Level');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Confrontations] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [Confrontations] DROP COLUMN [Level];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200527184703_AddLevelTable')
BEGIN
    ALTER TABLE [Confrontations] ADD [LevelId] int NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200527184703_AddLevelTable')
BEGIN
    CREATE TABLE [Level] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NULL,
        [Order] int NOT NULL,
        CONSTRAINT [PK_Level] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200527184703_AddLevelTable')
BEGIN
    CREATE INDEX [IX_Confrontations_LevelId] ON [Confrontations] ([LevelId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200527184703_AddLevelTable')
BEGIN
    ALTER TABLE [Confrontations] ADD CONSTRAINT [FK_Confrontations_Level_LevelId] FOREIGN KEY ([LevelId]) REFERENCES [Level] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200527184703_AddLevelTable')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200527184703_AddLevelTable', N'3.1.3');
END;

GO

