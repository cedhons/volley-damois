IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Number', N'CategoryId') AND [object_id] = OBJECT_ID(N'[Terrain]'))
    SET IDENTITY_INSERT [Terrain] ON;
INSERT INTO [Terrain] ([Number], [CategoryId])
VALUES (1, 1),
(2, 1),
(3, 1),
(4, 1),
(5, 2),
(6, 2),
(7, 2),
(8, 2),
(9, 3),
(10, 3),
(11, 3),
(12, 3);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Number', N'CategoryId') AND [object_id] = OBJECT_ID(N'[Terrain]'))
    SET IDENTITY_INSERT [Terrain] OFF;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200518130334_AddTerrains', N'3.1.3');

GO

DROP TABLE [Set];

GO

ALTER TABLE [Confrontations] ADD [SetOneA] int NOT NULL DEFAULT 0;

GO

ALTER TABLE [Confrontations] ADD [SetOneB] int NOT NULL DEFAULT 0;

GO

ALTER TABLE [Confrontations] ADD [SetTwoA] int NOT NULL DEFAULT 0;

GO

ALTER TABLE [Confrontations] ADD [SetTwoB] int NOT NULL DEFAULT 0;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200518155941_RemoveSetTable', N'3.1.3');

GO

ALTER TABLE [Confrontations] ADD [Level] int NOT NULL DEFAULT 0;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200520230225_Level', N'3.1.3');

GO

