ALTER TABLE Events
ADD ShortDescription NVARCHAR(256)
GO

UPDATE Events SET ShortDescription = SUBSTRING([Description],0,100)