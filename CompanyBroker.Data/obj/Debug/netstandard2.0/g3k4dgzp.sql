DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Accounts]') AND [c].[name] = N'Email');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Accounts] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Accounts] DROP COLUMN [Email];

GO

DELETE FROM [__EFMigrationsHistory]
WHERE [MigrationId] = N'20200509115501_AddEmailToAccount';

GO

