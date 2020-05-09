ALTER TABLE [Accounts] ADD [Email] nvarchar(250) NULL;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200509115501_AddEmailToAccount', N'3.1.3');

GO

