ALTER TABLE Events
ADD [Name] NVARCHAR(64)
GO

ALTER TABLE Events
ADD [Description] NVARCHAR(MAX)
GO

ALTER TABLE Events
ADD [Image] NVARCHAR(MAX)
GO