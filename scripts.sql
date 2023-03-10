USE [master]
GO
/****** Object:  Database [Reservation]    Script Date: 2/3/2023 4:58:34 PM ******/
CREATE DATABASE [Reservation]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Reservation', FILENAME = N'E:\new hard\dev\Tasks\Reservation\Reservation.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Reservation_log', FILENAME = N'E:\new hard\dev\Tasks\Reservation\Reservation_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Reservation] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Reservation].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Reservation] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Reservation] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Reservation] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Reservation] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Reservation] SET ARITHABORT OFF 
GO
ALTER DATABASE [Reservation] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Reservation] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Reservation] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Reservation] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Reservation] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Reservation] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Reservation] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Reservation] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Reservation] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Reservation] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Reservation] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Reservation] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Reservation] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Reservation] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Reservation] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Reservation] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Reservation] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Reservation] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Reservation] SET  MULTI_USER 
GO
ALTER DATABASE [Reservation] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Reservation] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Reservation] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Reservation] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Reservation] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Reservation] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Reservation] SET QUERY_STORE = OFF
GO
USE [Reservation]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 2/3/2023 4:58:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Appointment]    Script Date: 2/3/2023 4:58:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Appointment](
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NOT NULL,
	[Type] [tinyint] NOT NULL,
	[Status] [tinyint] NOT NULL,
	[Paient_Id] [int] NOT NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Period] [int] NOT NULL,
 CONSTRAINT [PK_Appointment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[claims]    Script Date: 2/3/2023 4:58:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[claims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](max) NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_claims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Paient]    Script Date: 2/3/2023 4:58:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Paient](
	[FullName] [nvarchar](250) NOT NULL,
	[Address] [nvarchar](250) NOT NULL,
	[Phone] [nvarchar](13) NOT NULL,
	[Geneder] [tinyint] NOT NULL,
	[BirthDate] [date] NOT NULL,
	[Country] [nvarchar](50) NOT NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Paient] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[role]    Script Date: 2/3/2023 4:58:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[role](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[NormalizedName] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_role] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[roles]    Script Date: 2/3/2023 4:58:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[roles](
	[UserId] [nvarchar](max) NULL,
	[RoleId] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 2/3/2023 4:58:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
	[UserName] [nvarchar](max) NULL,
	[NormalizedUserName] [nvarchar](max) NULL,
	[NormalizedEmail] [nvarchar](max) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230202160859_addUser', N'7.0.2')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230202161111_addOwnUser', N'7.0.2')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230202161857_addClaims', N'7.0.2')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230202162138_addroles', N'7.0.2')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230202162256_addrole', N'7.0.2')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230203120502_id', N'7.0.2')
GO
SET IDENTITY_INSERT [dbo].[Appointment] ON 

INSERT [dbo].[Appointment] ([StartDate], [EndDate], [Type], [Status], [Paient_Id], [Id], [Period]) VALUES (CAST(N'2022-01-01T08:00:00.000' AS DateTime), CAST(N'2022-01-02T10:00:00.000' AS DateTime), 1, 2, 2, 8, 26)
INSERT [dbo].[Appointment] ([StartDate], [EndDate], [Type], [Status], [Paient_Id], [Id], [Period]) VALUES (CAST(N'2023-01-26T18:10:00.000' AS DateTime), CAST(N'2023-01-27T18:10:00.000' AS DateTime), 3, 3, 3, 9, 24)
INSERT [dbo].[Appointment] ([StartDate], [EndDate], [Type], [Status], [Paient_Id], [Id], [Period]) VALUES (CAST(N'2023-02-03T18:10:00.000' AS DateTime), CAST(N'2023-02-04T18:10:00.000' AS DateTime), 3, 1, 3, 10, 24)
INSERT [dbo].[Appointment] ([StartDate], [EndDate], [Type], [Status], [Paient_Id], [Id], [Period]) VALUES (CAST(N'2023-03-11T18:10:00.000' AS DateTime), CAST(N'2023-03-13T18:10:00.000' AS DateTime), 2, 2, 3, 11, 48)
INSERT [dbo].[Appointment] ([StartDate], [EndDate], [Type], [Status], [Paient_Id], [Id], [Period]) VALUES (CAST(N'2023-01-14T18:24:00.000' AS DateTime), CAST(N'2023-01-28T18:24:00.000' AS DateTime), 1, 2, 2, 12, 336)
INSERT [dbo].[Appointment] ([StartDate], [EndDate], [Type], [Status], [Paient_Id], [Id], [Period]) VALUES (CAST(N'2024-01-03T14:29:00.000' AS DateTime), CAST(N'2024-02-03T14:29:00.000' AS DateTime), 1, 1, 2, 14, 744)
SET IDENTITY_INSERT [dbo].[Appointment] OFF
GO
SET IDENTITY_INSERT [dbo].[claims] ON 

INSERT [dbo].[claims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (1, N'2d5a5d04-60f0-4733-8dbd-a7fee16c38a6', N'UserRole', N'Admin')
SET IDENTITY_INSERT [dbo].[claims] OFF
GO
SET IDENTITY_INSERT [dbo].[Paient] ON 

INSERT [dbo].[Paient] ([FullName], [Address], [Phone], [Geneder], [BirthDate], [Country], [Id]) VALUES (N'medo updated', N'this is address updated', N'+201061705223', 0, CAST(N'2000-12-02' AS Date), N'egypt', 2)
INSERT [dbo].[Paient] ([FullName], [Address], [Phone], [Geneder], [BirthDate], [Country], [Id]) VALUES (N'mona ali', N'this is address updated', N'+201061705223', 1, CAST(N'2000-12-14' AS Date), N'egypt', 3)
SET IDENTITY_INSERT [dbo].[Paient] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([Id], [Name], [Email], [Password], [UserName], [NormalizedUserName], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (1, N'ali', N'ali@gmail.com', N'ali123', N'ali@gmail.com', N'ALI@GMAIL.COM', NULL, 0, N'AQAAAAEAACcQAAAAEJSoBCeyKCXsMzomZiBh3PahYfaQD6S/ukwN12pWeh4tC7nDvKY+y1pVnOreQVRwLw==', N'ZTD6DBXWUXXSHGAZJ3U4VY5AOA7EA2BI', N'548f25a7-1d34-4ae5-bc44-1a0664552fb6', NULL, 0, 0, NULL, 1, 0)
SET IDENTITY_INSERT [dbo].[User] OFF
GO
ALTER TABLE [dbo].[Appointment]  WITH CHECK ADD  CONSTRAINT [FK_Appointment_Paient] FOREIGN KEY([Paient_Id])
REFERENCES [dbo].[Paient] ([Id])
GO
ALTER TABLE [dbo].[Appointment] CHECK CONSTRAINT [FK_Appointment_Paient]
GO
/****** Object:  StoredProcedure [dbo].[addOrEditAppointment]    Script Date: 2/3/2023 4:58:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[addOrEditAppointment] 
@startDate datetime, @endDate datetime,@type tinyint, @status tinyint, @paientId int, @id int
as 

	declare @Msg as nvarchar(50) = ''; 
	declare @NewId as INT = -1; 
	
	if(@id is null or @id = 0)
	begin 
		
		if(@paientId = 0) 
		begin 
			set @Msg = 'Cannot add Appointment without paient id '
		end
		if(@startDate is not null and @endDate is not null and @endDate >= @startDate and @paientId  > 0) 
		begin 
			declare @countConfilectsWithAdd as int ; 
			select @countConfilectsWithAdd = count(*)  from Appointment where
			(@startDate >= StartDate and @startDate <= EndDate )
			or 
			(@endDate >= StartDate and @endDate <= EndDate);
			
			if(@countConfilectsWithAdd = 0) 
			begin 
				insert into Appointment values(@startDate, @endDate, @type, @status, @paientId, DATEDIFF(hour, @startDate, @endDate) ) 
				set @NewId= SCOPE_IDENTITY()
				set @Msg = 'Inserted Successfully'; 
				--return @Msg
			end
			if(@countConfilectsWithAdd > 0) 
			begin 
				--print 'this Appointment dates is busy'
				set @Msg = 'this Appointment dates is busy'
				
			end
		end
	end
	if(@id is not null and @id > 0)
	begin 
		--validate the dates first 
		declare @countConfilectsWithUpdate as int = 0;
		
		select @countConfilectsWithUpdate = count(*) from Appointment where Id != @id and (
		(@startDate >= StartDate and @startDate <= EndDate )
		or 
		(@endDate >= StartDate and @endDate <= EndDate) );
		
		if(@countConfilectsWithUpdate = 0)
		begin 
			update Appointment set Type = @type, Status = @status, StartDate = @startDate, EndDate = @endDate, Period =  DATEDIFF(hour, @startDate, @endDate)
			where Id = @id

			set @Msg = 'Updated Successfully'
			set @NewId = 1
		end
		if(@countConfilectsWithUpdate > 0) 
		begin 
			set @Msg = 'this Appointment dates is busy'
		end
	end
	select @Msg as ReturnedMsg,
			   @NewId AS ID
GO
/****** Object:  StoredProcedure [dbo].[addOrEditPaient]    Script Date: 2/3/2023 4:58:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[addOrEditPaient] 
@fullName nvarchar(250),@address nvarchar(250), @phone nvarchar(13), @gender bit, @birthdate date,@country nvarchar(50), @id int
as 
	declare @Msg as nvarchar(50) = ''; 
	declare @NewId as INT = -1; 

	if(@id is not null and @id > 0)
	begin 
		update Paient 
		set FullName = @fullName, Address = @address, Phone = @phone, Geneder = @gender, BirthDate = @birthdate, Country = @country 
		where Id = @id

		set @Msg = 'Updated Successfully' 
		set @NewId = 1
	end
	if(@id is null or @id = 0)
	begin 
		insert into Paient values(@fullName, @address, @phone, @gender, @birthdate, @country)

		set @Msg = 'Inserted Successfully' 
		set @NewId = SCOPE_IDENTITY()
	end

	select @Msg as ReturnedMsg, @NewId as ID
GO
/****** Object:  StoredProcedure [dbo].[addOrEditUser]    Script Date: 2/3/2023 4:58:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[addOrEditUser] 
@name nvarchar(250), @email nvarchar(250), @password text, @id int
as  
	declare @Msg as nvarchar(50) = ''; 
	declare @NewId as INT = -1; 
	
	if(@id is null or @id = 0)
	begin 
		insert into [dbo].[User] values(@name, @email, @password)
		set @Msg = 'Inserted Successfully' 
		set @NewId = SCOPE_IDENTITY()
	end 
	if(@id is not null and @id > 0) 
	begin 
		update [dbo].[User] set Name = @name, Email = @email, Password = @password 
		where Id = @id;

		set @Msg = 'Updated Successfully' 
		set @NewId = 1
	end

	select @Msg as ReturnedMsg, @NewId as ID
GO
/****** Object:  StoredProcedure [dbo].[addUser]    Script Date: 2/3/2023 4:58:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[addUser] 
@name nvarchar(250), @email nvarchar(250), @password text
as 
	insert into [dbo].[User] values(@name, @email, @password) 
GO
/****** Object:  StoredProcedure [dbo].[deleteAppointment]    Script Date: 2/3/2023 4:58:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[deleteAppointment]
@id int
as 
	declare @Msg as nvarchar(50) = ''; 
	declare @NewId as INT = -1; 

	if(@id is not null) 
	begin 
		delete from Appointment where Id = @id

		set @Msg = 'Deleted Successfully' 
		set @NewId = 1
	end

	if(@id is null)
	begin 
		set @Msg = 'Id Shouldnot be null' 
	end

	select @Msg as ReturnedMsg, @NewId as ID
GO
/****** Object:  StoredProcedure [dbo].[deletePaient]    Script Date: 2/3/2023 4:58:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[deletePaient] 
@id int
as  
	declare @Msg as nvarchar(50) = ''; 
	declare @NewId as INT = -1;  

	if(@id is not null) 
	begin 
		delete from Paient where Id = @id

		set @Msg = 'Deleted Successfully' 
		set @NewId = 1
	end

	select @Msg as ReturnedMsg, @NewId as ID
GO
/****** Object:  StoredProcedure [dbo].[deleteUser]    Script Date: 2/3/2023 4:58:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[deleteUser]
@id int
as
	declare @Msg as nvarchar(50) = ''; 
	declare @NewId as INT = -1;
	delete from [dbo].[User] where Id = @id
	set @Msg = 'Deletd Successfully' 
	set @NewId = 1
	select @Msg as ReturnedMsg, @NewId as ID 
GO
/****** Object:  StoredProcedure [dbo].[getAppointmentByDate]    Script Date: 2/3/2023 4:58:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[getAppointmentByDate]
@startDate datetime, @endDate datetime
as 
	select * from Appointment where  (StartDate between @startDate and @endDate )  and (EndDate between @startDate and @endDate)
GO
/****** Object:  StoredProcedure [dbo].[getAppointmentById]    Script Date: 2/3/2023 4:58:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[getAppointmentById]
@id int
as 
	select * from Appointment where Id = @id
GO
/****** Object:  StoredProcedure [dbo].[getAppointments]    Script Date: 2/3/2023 4:58:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[getAppointments] 
as 
	select * from Appointment
GO
/****** Object:  StoredProcedure [dbo].[getPaientByBirthDate]    Script Date: 2/3/2023 4:58:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[getPaientByBirthDate]
@birthDate date
as 
	select * from Paient where BirthDate = @birthDate
GO
/****** Object:  StoredProcedure [dbo].[getPaientById]    Script Date: 2/3/2023 4:58:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[getPaientById] 
@id int
as 
	select * from Paient where Id = @id 
GO
/****** Object:  StoredProcedure [dbo].[getPaientByName]    Script Date: 2/3/2023 4:58:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[getPaientByName]
@name nvarchar(250)
as 
	select * from Paient where FullName like CONCAT('%', @name, '%')
GO
/****** Object:  StoredProcedure [dbo].[getPaients]    Script Date: 2/3/2023 4:58:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[getPaients] 
as
	select * from Paient
GO
/****** Object:  StoredProcedure [dbo].[getUser]    Script Date: 2/3/2023 4:58:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[getUser]
@id int 
as	
	select * from [dbo].[User] where Id = @id
GO
/****** Object:  StoredProcedure [dbo].[getUserByEmail]    Script Date: 2/3/2023 4:58:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[getUserByEmail]
@email varchar(250) 
as	
	select * from [dbo].[User] where Email = @email; 
GO
USE [master]
GO
ALTER DATABASE [Reservation] SET  READ_WRITE 
GO
