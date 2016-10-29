CREATE DATABASE EventEmitter;
GO

CREATE TABLE EventEmitter.dbo.[UserTypes]
(
	UserTypeId UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID() PRIMARY KEY,
	Name NVARCHAR(255) NOT NULL
); 

CREATE TABLE EventEmitter.dbo.UserAccounts
(
	UserAccountId UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID() PRIMARY KEY,
	Name NVARCHAR(255) NOT NULL,
	LoginProvider NVARCHAR(255),
	LoginProviderKey NVARCHAR(255),
	Base64Secret NVARCHAR(255) NOT NULL,
	UserTypeId UNIQUEIDENTIFIER NOT NULL,
	CONSTRAINT fk_UserAccountUserType FOREIGN KEY (UserTypeId)
	REFERENCES EventEmitter.dbo.[UserTypes](UserTypeId)
); 


CREATE TABLE EventEmitter.dbo.[Claims]
(
	ClaimId UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID() PRIMARY KEY,
	Name NVARCHAR(255) NOT NULL,
	[Description] NVARCHAR(255) NOT NULL
); 

CREATE TABLE EventEmitter.dbo.[UserTypeClaim]
(
	UserTypeClaimId UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID() PRIMARY KEY,

	ClaimId UNIQUEIDENTIFIER NOT NULL,
	CONSTRAINT fk_ClaimUserType FOREIGN KEY (ClaimId)
	REFERENCES EventEmitter.dbo.[Claims](ClaimId),

	UserTypeId UNIQUEIDENTIFIER NOT NULL,
	CONSTRAINT fk_UserTypeClaimUserType FOREIGN KEY (UserTypeId)
	REFERENCES EventEmitter.dbo.[UserTypes](UserTypeId)
); 

CREATE TABLE EventEmitter.dbo.[Phones]
(
	PhoneId UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID() PRIMARY KEY,
	Value NVARCHAR(20) NOT NULL,

	UserAccountId UNIQUEIDENTIFIER NOT NULL,
	CONSTRAINT fk_PhoneUserAccount FOREIGN KEY (UserAccountId)
	REFERENCES EventEmitter.dbo.[UserAccounts](UserAccountId),
); 

CREATE TABLE EventEmitter.dbo.[Contacts]
(
	ContactId UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID() PRIMARY KEY,
	
	SenderUserId UNIQUEIDENTIFIER NOT NULL,
	CONSTRAINT fk_ContactSenderUserAccount FOREIGN KEY (SenderUserId)
	REFERENCES EventEmitter.dbo.[UserAccounts](UserAccountId),

	GetterUserId UNIQUEIDENTIFIER NOT NULL,
	CONSTRAINT fk_ContactGetterUserAccount FOREIGN KEY (GetterUserId)
	REFERENCES EventEmitter.dbo.[UserAccounts](UserAccountId)
); 

CREATE TABLE EventEmitter.dbo.[EventTypes]
(
	EventTypeId UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID() PRIMARY KEY,
	Name NVARCHAR(255) NOT NULL,
	[Description] NVARCHAR(255) NOT NULL
); 

CREATE TABLE EventEmitter.dbo.[Events]
(
	EventId UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID() PRIMARY KEY,
	Start DATETIME NOT NULL,
	Duration INT,
	Slots INT,
	Price FLOAT,
	
	EventTypeId UNIQUEIDENTIFIER NOT NULL,
	CONSTRAINT fk_EventEventTypes FOREIGN KEY (EventTypeId)
	REFERENCES EventEmitter.dbo.[EventTypes](EventTypeId),
);

CREATE TABLE EventEmitter.dbo.[RegistrationTypes]
(
	RegistrationTypeId UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID() PRIMARY KEY,
	Name NVARCHAR(255) NOT NULL,
	[Description] NVARCHAR(255) NOT NULL
); 

CREATE TABLE EventEmitter.dbo.[Registrations]
(
	RegistrationId UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID() PRIMARY KEY,
	
	RegistrationTypeId UNIQUEIDENTIFIER NOT NULL,
	CONSTRAINT fk_RegistrationRegistrationTypes FOREIGN KEY (RegistrationTypeId)
	REFERENCES EventEmitter.dbo.[RegistrationTypes](RegistrationTypeId),

	UserAccountId UNIQUEIDENTIFIER NOT NULL,
	CONSTRAINT fk_RegistrationUserAccount FOREIGN KEY (UserAccountId)
	REFERENCES EventEmitter.dbo.[UserAccounts](UserAccountId),

	EventId UNIQUEIDENTIFIER NOT NULL,
	CONSTRAINT fk_RegistrationEvent FOREIGN KEY (EventId)
	REFERENCES EventEmitter.dbo.[Events](EventId),
); 

CREATE TABLE EventEmitter.dbo.[Messages]
(
	MessageId UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID() PRIMARY KEY,
	[Text] NVARCHAR(1000) NOT NULL,
	[Time] DATETIME NOT NULL,

	UserAccountId UNIQUEIDENTIFIER NOT NULL,
	CONSTRAINT fk_MessageUserAccount FOREIGN KEY (UserAccountId)
	REFERENCES EventEmitter.dbo.[UserAccounts](UserAccountId),

	EventId UNIQUEIDENTIFIER NOT NULL,
	CONSTRAINT fk_MessageEvent FOREIGN KEY (EventId)
	REFERENCES EventEmitter.dbo.[Events](EventId),
); 

CREATE TABLE EventEmitter.dbo.[BenefitTypes]
(
	BenefitTypeId UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID() PRIMARY KEY,
	Name NVARCHAR(255) NOT NULL,
	[Description] NVARCHAR(255) NOT NULL
); 

CREATE TABLE EventEmitter.dbo.[Benefit]
(
	BenefitId UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID() PRIMARY KEY,
	
	BenefitTypeId UNIQUEIDENTIFIER NOT NULL,
	CONSTRAINT fk_BenefitTypes FOREIGN KEY (BenefitTypeId)
	REFERENCES EventEmitter.dbo.[BenefitTypes](BenefitTypeId),

	UserAccountId UNIQUEIDENTIFIER NOT NULL,
	CONSTRAINT fk_BenefitUserAccount FOREIGN KEY (UserAccountId)
	REFERENCES EventEmitter.dbo.[UserAccounts](UserAccountId),

	EventId UNIQUEIDENTIFIER NOT NULL,
	CONSTRAINT fk_BenefitEvent FOREIGN KEY (EventId)
	REFERENCES EventEmitter.dbo.[Events](EventId),
);


CREATE TABLE EventEmitter.dbo.[StopListRecords]
(
	StopListRecordId UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID() PRIMARY KEY,

	UserAccountId UNIQUEIDENTIFIER NOT NULL,
	CONSTRAINT fk_StopListRecordUserAccount FOREIGN KEY (UserAccountId)
	REFERENCES EventEmitter.dbo.[UserAccounts](UserAccountId),

	EventId UNIQUEIDENTIFIER NOT NULL,
	CONSTRAINT fk_StopListRecordEvent FOREIGN KEY (EventId)
	REFERENCES EventEmitter.dbo.[Events](EventId),
);


CREATE TABLE EventEmitter.dbo.[WhiteListRecords]
(
	WhiteListRecordId UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID() PRIMARY KEY,

	UserAccountId UNIQUEIDENTIFIER NOT NULL,
	CONSTRAINT fk_WhiteListRecordUserAccount FOREIGN KEY (UserAccountId)
	REFERENCES EventEmitter.dbo.[UserAccounts](UserAccountId),

	EventId UNIQUEIDENTIFIER NOT NULL,
	CONSTRAINT fk_WhiteListRecordEvent FOREIGN KEY (EventId)
	REFERENCES EventEmitter.dbo.[Events](EventId),
);

