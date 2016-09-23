CREATE DATABASE AuthorizationServer;
GO

CREATE TABLE AuthorizationServer.dbo.[Application]
(
	ApplicationId UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID() PRIMARY KEY,
	Name nvarchar(255) NOT NULL,
	ApplicationBase64Secret nvarchar(255) NOT NULL
); 

CREATE TABLE AuthorizationServer.dbo.UserAccount
(
	UserAccountId UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID() PRIMARY KEY,
	Name NVARCHAR(255) NOT NULL,
	LoginProvider NVARCHAR(255),
	Base64Secret NVARCHAR(255) NOT NULL,
	ApplicationId UNIQUEIDENTIFIER NOT NULL,
	CONSTRAINT fk_UserAccountApplication FOREIGN KEY (ApplicationId)
	REFERENCES AuthorizationServer.dbo.[Application](ApplicationId)
); 