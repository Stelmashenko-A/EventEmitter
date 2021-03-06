USE [master]
GO
/****** Object:  Database [EventEmitter]    Script Date: 07.12.2016 21:29:49 ******/
CREATE DATABASE [EventEmitter]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'EventEmitter', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\EventEmitter.mdf' , SIZE = 11456KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'EventEmitter_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\EventEmitter_log.ldf' , SIZE = 7744KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [EventEmitter] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EventEmitter].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [EventEmitter] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [EventEmitter] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [EventEmitter] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [EventEmitter] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [EventEmitter] SET ARITHABORT OFF 
GO
ALTER DATABASE [EventEmitter] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [EventEmitter] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [EventEmitter] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [EventEmitter] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [EventEmitter] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [EventEmitter] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [EventEmitter] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [EventEmitter] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [EventEmitter] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [EventEmitter] SET  ENABLE_BROKER 
GO
ALTER DATABASE [EventEmitter] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [EventEmitter] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [EventEmitter] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [EventEmitter] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [EventEmitter] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [EventEmitter] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [EventEmitter] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [EventEmitter] SET RECOVERY FULL 
GO
ALTER DATABASE [EventEmitter] SET  MULTI_USER 
GO
ALTER DATABASE [EventEmitter] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [EventEmitter] SET DB_CHAINING OFF 
GO
ALTER DATABASE [EventEmitter] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [EventEmitter] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [EventEmitter] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'EventEmitter', N'ON'
GO
USE [EventEmitter]
GO
/****** Object:  Table [dbo].[Benefit]    Script Date: 07.12.2016 21:29:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Benefit](
	[BenefitId] [uniqueidentifier] NOT NULL,
	[BenefitTypeId] [uniqueidentifier] NOT NULL,
	[UserAccountId] [uniqueidentifier] NOT NULL,
	[EventId] [uniqueidentifier] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[BenefitId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BenefitTypes]    Script Date: 07.12.2016 21:29:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BenefitTypes](
	[BenefitTypeId] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Description] [nvarchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[BenefitTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Claims]    Script Date: 07.12.2016 21:29:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Claims](
	[ClaimId] [uniqueidentifier] NOT NULL DEFAULT (newid()),
	[Name] [nvarchar](255) NOT NULL,
	[Description] [nvarchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ClaimId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Contacts]    Script Date: 07.12.2016 21:29:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contacts](
	[ContactId] [uniqueidentifier] NOT NULL,
	[SenderUserId] [uniqueidentifier] NOT NULL,
	[GetterUserId] [uniqueidentifier] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ContactId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Events]    Script Date: 07.12.2016 21:29:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Events](
	[EventId] [uniqueidentifier] NOT NULL DEFAULT (newid()),
	[Start] [datetime] NOT NULL,
	[Duration] [int] NULL,
	[Slots] [int] NULL,
	[Price] [float] NULL,
	[EventTypeId] [uniqueidentifier] NOT NULL,
	[TimeStamp] [float] NULL,
	[EventCreatorId] [uniqueidentifier] NULL,
	[Name] [nvarchar](64) NULL,
	[Description] [nvarchar](max) NULL,
	[Image] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[EventId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EventTypes]    Script Date: 07.12.2016 21:29:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EventTypes](
	[EventTypeId] [uniqueidentifier] NOT NULL DEFAULT (newid()),
	[Name] [nvarchar](255) NOT NULL,
	[Description] [nvarchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[EventTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Messages]    Script Date: 07.12.2016 21:29:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Messages](
	[MessageId] [uniqueidentifier] NOT NULL DEFAULT (newid()),
	[Text] [nvarchar](1000) NOT NULL,
	[Time] [datetime] NOT NULL,
	[UserAccountId] [uniqueidentifier] NOT NULL,
	[EventId] [uniqueidentifier] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MessageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Phones]    Script Date: 07.12.2016 21:29:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Phones](
	[PhoneId] [uniqueidentifier] NOT NULL,
	[Value] [nvarchar](20) NOT NULL,
	[UserAccountId] [uniqueidentifier] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[PhoneId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Registrations]    Script Date: 07.12.2016 21:29:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Registrations](
	[RegistrationId] [uniqueidentifier] NOT NULL,
	[RegistrationTypeId] [uniqueidentifier] NOT NULL,
	[UserAccountId] [uniqueidentifier] NOT NULL,
	[EventId] [uniqueidentifier] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[RegistrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RegistrationTypes]    Script Date: 07.12.2016 21:29:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RegistrationTypes](
	[RegistrationTypeId] [uniqueidentifier] NOT NULL DEFAULT (newid()),
	[Name] [nvarchar](255) NOT NULL,
	[Description] [nvarchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[RegistrationTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Settings]    Script Date: 07.12.2016 21:29:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Settings](
	[SettingId] [uniqueidentifier] NOT NULL DEFAULT (newid()),
	[Name] [nvarchar](255) NULL,
	[Value] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[SettingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[StopListRecords]    Script Date: 07.12.2016 21:29:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StopListRecords](
	[StopListRecordId] [uniqueidentifier] NOT NULL,
	[UserAccountId] [uniqueidentifier] NOT NULL,
	[EventId] [uniqueidentifier] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[StopListRecordId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserAccounts]    Script Date: 07.12.2016 21:29:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserAccounts](
	[UserAccountId] [uniqueidentifier] NOT NULL DEFAULT (newid()),
	[Name] [nvarchar](255) NOT NULL,
	[LoginProvider] [nvarchar](255) NULL,
	[LoginProviderKey] [nvarchar](255) NULL,
	[Base64Secret] [nvarchar](255) NOT NULL,
	[UserTypeId] [uniqueidentifier] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserAccountId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserTypeClaim]    Script Date: 07.12.2016 21:29:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserTypeClaim](
	[UserTypeClaimId] [uniqueidentifier] NOT NULL DEFAULT (newid()),
	[ClaimId] [uniqueidentifier] NOT NULL,
	[UserTypeId] [uniqueidentifier] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserTypeClaimId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [ucPair] UNIQUE NONCLUSTERED 
(
	[ClaimId] ASC,
	[UserTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserTypes]    Script Date: 07.12.2016 21:29:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserTypes](
	[UserTypeId] [uniqueidentifier] NOT NULL DEFAULT (newid()),
	[Name] [nvarchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[WhiteListRecords]    Script Date: 07.12.2016 21:29:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WhiteListRecords](
	[WhiteListRecordId] [uniqueidentifier] NOT NULL,
	[UserAccountId] [uniqueidentifier] NOT NULL,
	[EventId] [uniqueidentifier] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[WhiteListRecordId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Benefit] ADD  DEFAULT (newid()) FOR [BenefitId]
GO
ALTER TABLE [dbo].[BenefitTypes] ADD  DEFAULT (newid()) FOR [BenefitTypeId]
GO
ALTER TABLE [dbo].[Contacts] ADD  DEFAULT (newid()) FOR [ContactId]
GO
ALTER TABLE [dbo].[Phones] ADD  DEFAULT (newid()) FOR [PhoneId]
GO
ALTER TABLE [dbo].[Registrations] ADD  DEFAULT (newid()) FOR [RegistrationId]
GO
ALTER TABLE [dbo].[StopListRecords] ADD  DEFAULT (newid()) FOR [StopListRecordId]
GO
ALTER TABLE [dbo].[WhiteListRecords] ADD  DEFAULT (newid()) FOR [WhiteListRecordId]
GO
ALTER TABLE [dbo].[Benefit]  WITH CHECK ADD  CONSTRAINT [fk_BenefitEvent] FOREIGN KEY([EventId])
REFERENCES [dbo].[Events] ([EventId])
GO
ALTER TABLE [dbo].[Benefit] CHECK CONSTRAINT [fk_BenefitEvent]
GO
ALTER TABLE [dbo].[Benefit]  WITH CHECK ADD  CONSTRAINT [fk_BenefitTypes] FOREIGN KEY([BenefitTypeId])
REFERENCES [dbo].[BenefitTypes] ([BenefitTypeId])
GO
ALTER TABLE [dbo].[Benefit] CHECK CONSTRAINT [fk_BenefitTypes]
GO
ALTER TABLE [dbo].[Benefit]  WITH CHECK ADD  CONSTRAINT [fk_BenefitUserAccount] FOREIGN KEY([UserAccountId])
REFERENCES [dbo].[UserAccounts] ([UserAccountId])
GO
ALTER TABLE [dbo].[Benefit] CHECK CONSTRAINT [fk_BenefitUserAccount]
GO
ALTER TABLE [dbo].[Contacts]  WITH CHECK ADD  CONSTRAINT [fk_ContactGetterUserAccount] FOREIGN KEY([GetterUserId])
REFERENCES [dbo].[UserAccounts] ([UserAccountId])
GO
ALTER TABLE [dbo].[Contacts] CHECK CONSTRAINT [fk_ContactGetterUserAccount]
GO
ALTER TABLE [dbo].[Contacts]  WITH CHECK ADD  CONSTRAINT [fk_ContactSenderUserAccount] FOREIGN KEY([SenderUserId])
REFERENCES [dbo].[UserAccounts] ([UserAccountId])
GO
ALTER TABLE [dbo].[Contacts] CHECK CONSTRAINT [fk_ContactSenderUserAccount]
GO
ALTER TABLE [dbo].[Events]  WITH CHECK ADD  CONSTRAINT [fk_EventEventTypes] FOREIGN KEY([EventTypeId])
REFERENCES [dbo].[EventTypes] ([EventTypeId])
GO
ALTER TABLE [dbo].[Events] CHECK CONSTRAINT [fk_EventEventTypes]
GO
ALTER TABLE [dbo].[Events]  WITH CHECK ADD  CONSTRAINT [fk_EventUserAccount] FOREIGN KEY([EventCreatorId])
REFERENCES [dbo].[UserAccounts] ([UserAccountId])
GO
ALTER TABLE [dbo].[Events] CHECK CONSTRAINT [fk_EventUserAccount]
GO
ALTER TABLE [dbo].[Messages]  WITH CHECK ADD  CONSTRAINT [fk_MessageEvent] FOREIGN KEY([EventId])
REFERENCES [dbo].[Events] ([EventId])
GO
ALTER TABLE [dbo].[Messages] CHECK CONSTRAINT [fk_MessageEvent]
GO
ALTER TABLE [dbo].[Messages]  WITH CHECK ADD  CONSTRAINT [fk_MessageUserAccount] FOREIGN KEY([UserAccountId])
REFERENCES [dbo].[UserAccounts] ([UserAccountId])
GO
ALTER TABLE [dbo].[Messages] CHECK CONSTRAINT [fk_MessageUserAccount]
GO
ALTER TABLE [dbo].[Phones]  WITH CHECK ADD  CONSTRAINT [fk_PhoneUserAccount] FOREIGN KEY([UserAccountId])
REFERENCES [dbo].[UserAccounts] ([UserAccountId])
GO
ALTER TABLE [dbo].[Phones] CHECK CONSTRAINT [fk_PhoneUserAccount]
GO
ALTER TABLE [dbo].[Registrations]  WITH CHECK ADD  CONSTRAINT [fk_RegistrationEvent] FOREIGN KEY([EventId])
REFERENCES [dbo].[Events] ([EventId])
GO
ALTER TABLE [dbo].[Registrations] CHECK CONSTRAINT [fk_RegistrationEvent]
GO
ALTER TABLE [dbo].[Registrations]  WITH CHECK ADD  CONSTRAINT [fk_RegistrationRegistrationTypes] FOREIGN KEY([RegistrationTypeId])
REFERENCES [dbo].[RegistrationTypes] ([RegistrationTypeId])
GO
ALTER TABLE [dbo].[Registrations] CHECK CONSTRAINT [fk_RegistrationRegistrationTypes]
GO
ALTER TABLE [dbo].[Registrations]  WITH CHECK ADD  CONSTRAINT [fk_RegistrationUserAccount] FOREIGN KEY([UserAccountId])
REFERENCES [dbo].[UserAccounts] ([UserAccountId])
GO
ALTER TABLE [dbo].[Registrations] CHECK CONSTRAINT [fk_RegistrationUserAccount]
GO
ALTER TABLE [dbo].[StopListRecords]  WITH CHECK ADD  CONSTRAINT [fk_StopListRecordEvent] FOREIGN KEY([EventId])
REFERENCES [dbo].[Events] ([EventId])
GO
ALTER TABLE [dbo].[StopListRecords] CHECK CONSTRAINT [fk_StopListRecordEvent]
GO
ALTER TABLE [dbo].[StopListRecords]  WITH CHECK ADD  CONSTRAINT [fk_StopListRecordUserAccount] FOREIGN KEY([UserAccountId])
REFERENCES [dbo].[UserAccounts] ([UserAccountId])
GO
ALTER TABLE [dbo].[StopListRecords] CHECK CONSTRAINT [fk_StopListRecordUserAccount]
GO
ALTER TABLE [dbo].[UserAccounts]  WITH CHECK ADD  CONSTRAINT [fk_UserAccountUserType] FOREIGN KEY([UserTypeId])
REFERENCES [dbo].[UserTypes] ([UserTypeId])
GO
ALTER TABLE [dbo].[UserAccounts] CHECK CONSTRAINT [fk_UserAccountUserType]
GO
ALTER TABLE [dbo].[UserTypeClaim]  WITH CHECK ADD  CONSTRAINT [fk_ClaimUserType] FOREIGN KEY([ClaimId])
REFERENCES [dbo].[Claims] ([ClaimId])
GO
ALTER TABLE [dbo].[UserTypeClaim] CHECK CONSTRAINT [fk_ClaimUserType]
GO
ALTER TABLE [dbo].[UserTypeClaim]  WITH CHECK ADD  CONSTRAINT [fk_UserTypeClaimUserType] FOREIGN KEY([UserTypeId])
REFERENCES [dbo].[UserTypes] ([UserTypeId])
GO
ALTER TABLE [dbo].[UserTypeClaim] CHECK CONSTRAINT [fk_UserTypeClaimUserType]
GO
ALTER TABLE [dbo].[WhiteListRecords]  WITH CHECK ADD  CONSTRAINT [fk_WhiteListRecordEvent] FOREIGN KEY([EventId])
REFERENCES [dbo].[Events] ([EventId])
GO
ALTER TABLE [dbo].[WhiteListRecords] CHECK CONSTRAINT [fk_WhiteListRecordEvent]
GO
ALTER TABLE [dbo].[WhiteListRecords]  WITH CHECK ADD  CONSTRAINT [fk_WhiteListRecordUserAccount] FOREIGN KEY([UserAccountId])
REFERENCES [dbo].[UserAccounts] ([UserAccountId])
GO
ALTER TABLE [dbo].[WhiteListRecords] CHECK CONSTRAINT [fk_WhiteListRecordUserAccount]
GO
USE [master]
GO
ALTER DATABASE [EventEmitter] SET  READ_WRITE 
GO
