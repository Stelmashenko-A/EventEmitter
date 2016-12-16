CREATE PROCEDURE CreateOrUpdateSetting @Id UNIQUEIDENTIFIER, @Name NVARCHAR(255), @Value NVARCHAR(255)
AS
	IF EXISTS (SELECT * FROM Settings WHERE SettingId = @Id AND Name != @Name)
		THROW 50001, 'Identifier is used', 1;

	IF EXISTS (SELECT * FROM Settings WHERE Name = @Name AND (Value != @Value OR SettingId != @Id ))
	BEGIN
		UPDATE Settings SET SettingId = @Id, Value = @Value WHERE SettingId = @Id;
		RETURN
	END;

	IF NOT EXISTS (SELECT * FROM Settings WHERE Name = @Name)
	BEGIN
		INSERT INTO Settings VALUES (@Id, @Name, @Value)
		RETURN
	END;
GO
