USE [master]
GO
/****** Object:  Database [Elegencia]    Script Date: 10.03.2024 22:53:43 ******/
CREATE DATABASE [Elegencia]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Elegencia', FILENAME = N'C:\Users\hp\Desktop\MSSQL16.MSSQLSERVER\MSSQL\DATA\Elegencia.mdf' , SIZE = 73728KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Elegencia_log', FILENAME = N'C:\Users\hp\Desktop\MSSQL16.MSSQLSERVER\MSSQL\DATA\Elegencia_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [Elegencia] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Elegencia].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Elegencia] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Elegencia] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Elegencia] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Elegencia] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Elegencia] SET ARITHABORT OFF 
GO
ALTER DATABASE [Elegencia] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Elegencia] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Elegencia] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Elegencia] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Elegencia] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Elegencia] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Elegencia] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Elegencia] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Elegencia] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Elegencia] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Elegencia] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Elegencia] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Elegencia] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Elegencia] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Elegencia] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Elegencia] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [Elegencia] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Elegencia] SET RECOVERY FULL 
GO
ALTER DATABASE [Elegencia] SET  MULTI_USER 
GO
ALTER DATABASE [Elegencia] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Elegencia] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Elegencia] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Elegencia] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Elegencia] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Elegencia] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Elegencia', N'ON'
GO
ALTER DATABASE [Elegencia] SET QUERY_STORE = ON
GO
ALTER DATABASE [Elegencia] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [Elegencia]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 10.03.2024 22:53:43 ******/
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
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 10.03.2024 22:53:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 10.03.2024 22:53:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 10.03.2024 22:53:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 10.03.2024 22:53:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 10.03.2024 22:53:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 10.03.2024 22:53:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](25) NOT NULL,
	[Surname] [nvarchar](25) NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
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
	[Image] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 10.03.2024 22:53:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 10.03.2024 22:53:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[ModifiedAt] [datetime2](7) NULL,
	[CreatedBy] [nvarchar](max) NOT NULL,
	[ModifiedBy] [nvarchar](max) NULL,
	[IsDeleted] [bit] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Chefs]    Script Date: 10.03.2024 22:53:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Chefs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Surname] [nvarchar](25) NOT NULL,
	[Info] [text] NOT NULL,
	[Image] [nvarchar](max) NOT NULL,
	[Facebook] [nvarchar](max) NOT NULL,
	[Instagram] [nvarchar](max) NOT NULL,
	[Linkedin] [nvarchar](max) NOT NULL,
	[PositionId] [int] NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[ModifiedAt] [datetime2](7) NULL,
	[CreatedBy] [nvarchar](max) NOT NULL,
	[ModifiedBy] [nvarchar](max) NULL,
	[IsDeleted] [bit] NOT NULL,
	[Name] [nvarchar](25) NOT NULL,
 CONSTRAINT [PK_Chefs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contacts]    Script Date: 10.03.2024 22:53:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contacts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[CommentText] [text] NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[ModifiedAt] [datetime2](7) NULL,
	[CreatedBy] [nvarchar](max) NOT NULL,
	[ModifiedBy] [nvarchar](max) NULL,
	[IsDeleted] [bit] NOT NULL,
	[Name] [nvarchar](25) NOT NULL,
 CONSTRAINT [PK_Contacts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DessertCategories]    Script Date: 10.03.2024 22:53:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DessertCategories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[ModifiedAt] [datetime2](7) NULL,
	[CreatedBy] [nvarchar](max) NOT NULL,
	[ModifiedBy] [nvarchar](max) NULL,
	[IsDeleted] [bit] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_DessertCategories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DessertImages]    Script Date: 10.03.2024 22:53:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DessertImages](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Image] [nvarchar](max) NOT NULL,
	[Alternative] [nvarchar](max) NULL,
	[DessertId] [int] NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[ModifiedAt] [datetime2](7) NULL,
	[CreatedBy] [nvarchar](max) NOT NULL,
	[ModifiedBy] [nvarchar](max) NULL,
	[IsDeleted] [bit] NOT NULL,
	[IsPrimary] [bit] NULL,
 CONSTRAINT [PK_DessertImages] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Desserts]    Script Date: 10.03.2024 22:53:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Desserts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Price] [decimal](6, 2) NOT NULL,
	[Ingredients] [text] NOT NULL,
	[DessertCategoryId] [int] NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[ModifiedAt] [datetime2](7) NULL,
	[CreatedBy] [nvarchar](max) NOT NULL,
	[ModifiedBy] [nvarchar](max) NULL,
	[IsDeleted] [bit] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Desserts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DessertTags]    Script Date: 10.03.2024 22:53:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DessertTags](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DessertId] [int] NOT NULL,
	[TagId] [int] NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[CreatedBy] [nvarchar](max) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[ModifiedAt] [datetime2](7) NULL,
	[ModifiedBy] [nvarchar](max) NULL,
 CONSTRAINT [PK_DessertTags] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DrinkCategories]    Script Date: 10.03.2024 22:53:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DrinkCategories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[ModifiedAt] [datetime2](7) NULL,
	[CreatedBy] [nvarchar](max) NOT NULL,
	[ModifiedBy] [nvarchar](max) NULL,
	[IsDeleted] [bit] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_DrinkCategories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Drinks]    Script Date: 10.03.2024 22:53:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Drinks](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Price] [decimal](6, 2) NOT NULL,
	[Image] [nvarchar](max) NOT NULL,
	[Alternative] [nvarchar](max) NOT NULL,
	[DrinkCategoryId] [int] NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[ModifiedAt] [datetime2](7) NULL,
	[CreatedBy] [nvarchar](max) NOT NULL,
	[ModifiedBy] [nvarchar](max) NULL,
	[IsDeleted] [bit] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Drinks] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Famous]    Script Date: 10.03.2024 22:53:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Famous](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Surname] [nvarchar](max) NOT NULL,
	[Country] [nvarchar](max) NOT NULL,
	[Image] [nvarchar](max) NOT NULL,
	[Opinion] [nvarchar](max) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[ModifiedAt] [datetime2](7) NULL,
	[CreatedBy] [nvarchar](max) NOT NULL,
	[ModifiedBy] [nvarchar](max) NULL,
	[IsDeleted] [bit] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Famous] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MealImages]    Script Date: 10.03.2024 22:53:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MealImages](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Image] [nvarchar](max) NOT NULL,
	[IsPrimary] [bit] NOT NULL,
	[Alternative] [nvarchar](max) NOT NULL,
	[MealId] [int] NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[ModifiedAt] [datetime2](7) NULL,
	[CreatedBy] [nvarchar](max) NOT NULL,
	[ModifiedBy] [nvarchar](max) NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_MealImages] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Meals]    Script Date: 10.03.2024 22:53:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Meals](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Price] [decimal](6, 2) NOT NULL,
	[Ingredients] [text] NOT NULL,
	[CategoryId] [int] NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[ModifiedAt] [datetime2](7) NULL,
	[CreatedBy] [nvarchar](max) NOT NULL,
	[ModifiedBy] [nvarchar](max) NULL,
	[IsDeleted] [bit] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Meals] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MealTags]    Script Date: 10.03.2024 22:53:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MealTags](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MealId] [int] NOT NULL,
	[TagId] [int] NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[CreatedBy] [nvarchar](max) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[ModifiedAt] [datetime2](7) NULL,
	[ModifiedBy] [nvarchar](max) NULL,
 CONSTRAINT [PK_MealTags] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[News]    Script Date: 10.03.2024 22:53:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[News](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Image] [nvarchar](max) NOT NULL,
	[Description] [text] NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[ModifiedAt] [datetime2](7) NULL,
	[CreatedBy] [nvarchar](max) NOT NULL,
	[ModifiedBy] [nvarchar](max) NULL,
	[IsDeleted] [bit] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_News] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Positions]    Script Date: 10.03.2024 22:53:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Positions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[ModifiedAt] [datetime2](7) NULL,
	[CreatedBy] [nvarchar](max) NOT NULL,
	[ModifiedBy] [nvarchar](max) NULL,
	[IsDeleted] [bit] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Positions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reservations]    Script Date: 10.03.2024 22:53:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reservations](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[NumberOfPeople] [int] NOT NULL,
	[ArrivalDateTime] [datetime2](7) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[ModifiedAt] [datetime2](7) NULL,
	[CreatedBy] [nvarchar](max) NOT NULL,
	[ModifiedBy] [nvarchar](max) NULL,
	[IsDeleted] [bit] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Reservations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Salads]    Script Date: 10.03.2024 22:53:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Salads](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Price] [decimal](6, 2) NOT NULL,
	[Ingredients] [text] NOT NULL,
	[Image] [nvarchar](max) NOT NULL,
	[Alternative] [nvarchar](max) NOT NULL,
	[CategoryId] [int] NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[ModifiedAt] [datetime2](7) NULL,
	[CreatedBy] [nvarchar](max) NOT NULL,
	[ModifiedBy] [nvarchar](max) NULL,
	[IsDeleted] [bit] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Salads] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Settings]    Script Date: 10.03.2024 22:53:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Settings](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Key] [nvarchar](max) NOT NULL,
	[Value] [nvarchar](max) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[CreatedBy] [nvarchar](max) NOT NULL,
	[ModifiedAt] [datetime2](7) NULL,
	[ModifiedBy] [nvarchar](max) NULL,
 CONSTRAINT [PK_Settings] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tags]    Script Date: 10.03.2024 22:53:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tags](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[CreatedBy] [nvarchar](max) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[ModifiedAt] [datetime2](7) NULL,
	[ModifiedBy] [nvarchar](max) NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Tags] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240201125054_createdDbAppUsersPositionsChefsTables', N'6.0.25')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240201180242_createdCategoriesTable', N'6.0.25')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240201180333_createdTagsTable', N'6.0.25')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240201180448_createdMealsTable', N'6.0.25')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240201180604_createdMealImagesAndMealTagsTables', N'6.0.25')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240202111058_createdSettingsTable', N'6.0.25')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240202163238_createdDessertsAndOtherTables', N'6.0.25')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240202171859_addedIsPrimaryToDessertImages', N'6.0.25')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240212082021_createdContactTable', N'6.0.25')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240213132536_image', N'6.0.25')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240217080935_updateSettingsTable', N'6.0.25')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240217122414_updatedSettingsTable', N'6.0.25')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240218102328_createdNewsTable', N'6.0.25')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240218103128_createdNewsTable', N'6.0.25')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240219220548_nullable', N'6.0.25')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240219221709_notnullable', N'6.0.25')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240221131529_createdReservationTable', N'6.0.25')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240221141105_updated', N'6.0.25')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240303172606_createdFamousTable', N'6.0.25')
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'37a69716-cfbd-401e-94a7-f29f2a876266', N'Member', N'MEMBER', N'11a7fc98-93dd-4e7c-9e6e-59cada0f2e61')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'd7857798-8352-4093-90cd-b878081289e9', N'Moderator', N'MODERATOR', N'04b0ef4a-30bd-4771-b6ea-76b7c00cbb3b')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'ff86c60e-97aa-4c96-82bd-c1a58cb5f5b3', N'Admin', N'ADMIN', N'0083b84a-e037-4ce5-8e1e-cd415646f659')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'7df5e33f-3f18-4f95-a1b8-590b447df78c', N'37a69716-cfbd-401e-94a7-f29f2a876266')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'3e186928-deae-4dfe-a197-fe1e3e9e9920', N'd7857798-8352-4093-90cd-b878081289e9')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'251295ad-47b5-4709-b06a-fdecb8da2103', N'ff86c60e-97aa-4c96-82bd-c1a58cb5f5b3')
GO
INSERT [dbo].[AspNetUsers] ([Id], [Name], [Surname], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Image]) VALUES (N'251295ad-47b5-4709-b06a-fdecb8da2103', N'Ülvi', N'Asadzade', N'admin', N'ADMIN', N'admin@gmail.com', N'ADMIN@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAECW995e4odhyUuITJ74FI6SkcX0uniNmse/nIAliF02SczqoUZ8N5Rr1ds5kyUKD8Q==', N'5F2HRJH52MQHJGXLDYON5UCW4O4Y77MF', N'caa43208-d8b9-4ec8-8dee-207634e04e5f', NULL, 0, 0, NULL, 1, 0, N'd02fb69b-5beb-4999-b406-6ca4d8e5dff4admin.jpg')
INSERT [dbo].[AspNetUsers] ([Id], [Name], [Surname], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Image]) VALUES (N'3e186928-deae-4dfe-a197-fe1e3e9e9920', N'Moder', N'Moderatorr', N'moderator', N'MODERATOR', N'moderator@gmail.com', N'MODERATOR@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAENCAsd1UQo9RvQPC0dcFB/FERq+dlyymQzSGXzIq1sr2XgIYSLd2c/NsUNDyzQh5sg==', N'NEFQ632PGAMTYGJ36UMQRXTQTGMB2C5Z', N'ffd687c3-6d1e-469b-96ae-f7be10ef9601', NULL, 0, 0, NULL, 1, 0, N'8acf2b52-c3b7-4b1d-8271-464e4dae1fa3admin-image-2.jpg')
INSERT [dbo].[AspNetUsers] ([Id], [Name], [Surname], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Image]) VALUES (N'7df5e33f-3f18-4f95-a1b8-590b447df78c', N'Ayshen', N'Salahova', N'ayshen', N'AYSHEN', N'ayshensalahova@gmail.com', N'AYSHENSALAHOVA@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEGL5HxAaUmS4eVv1GWzdHuYYmhdTPNQ7cMhu3k4aIqIb1y0TrHMnDnIoH5s5GWLbPQ==', N'KBLLZ27J6HV3ENK36PNPCCGCMASTD6VH', N'13e3c6f8-8dbb-4a57-af54-6a6e456dc5a5', NULL, 0, 0, NULL, 1, 0, N'user-image.jpg')
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([Id], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted], [Name]) VALUES (12, CAST(N'2024-02-22T21:37:57.0986106' AS DateTime2), NULL, N'Admin Admin', NULL, 0, N'Soups')
INSERT [dbo].[Categories] ([Id], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted], [Name]) VALUES (13, CAST(N'2024-02-22T21:38:03.6927522' AS DateTime2), NULL, N'Admin Admin', NULL, 0, N'Salads')
INSERT [dbo].[Categories] ([Id], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted], [Name]) VALUES (14, CAST(N'2024-02-22T21:38:51.8225294' AS DateTime2), NULL, N'Admin Admin', NULL, 0, N'Sandwiches')
INSERT [dbo].[Categories] ([Id], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted], [Name]) VALUES (15, CAST(N'2024-02-22T21:38:58.3658240' AS DateTime2), NULL, N'Admin Admin', NULL, 0, N'Wraps')
INSERT [dbo].[Categories] ([Id], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted], [Name]) VALUES (16, CAST(N'2024-02-22T21:39:12.6840212' AS DateTime2), NULL, N'Admin Admin', NULL, 0, N'By Meat')
INSERT [dbo].[Categories] ([Id], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted], [Name]) VALUES (17, CAST(N'2024-02-22T21:39:31.0118206' AS DateTime2), NULL, N'Admin Admin', NULL, 0, N'Pasta')
INSERT [dbo].[Categories] ([Id], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted], [Name]) VALUES (18, CAST(N'2024-02-22T21:39:55.9292782' AS DateTime2), NULL, N'Admin Admin', NULL, 0, N'Italian')
INSERT [dbo].[Categories] ([Id], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted], [Name]) VALUES (19, CAST(N'2024-02-22T21:40:05.7803127' AS DateTime2), NULL, N'Admin Admin', NULL, 0, N'Mexican')
INSERT [dbo].[Categories] ([Id], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted], [Name]) VALUES (21, CAST(N'2024-03-02T14:06:06.6581096' AS DateTime2), NULL, N'Admin Admin', NULL, 0, N'Seafood')
INSERT [dbo].[Categories] ([Id], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted], [Name]) VALUES (22, CAST(N'2024-03-02T14:08:15.1495795' AS DateTime2), NULL, N'Admin Admin', NULL, 0, N'Beef')
INSERT [dbo].[Categories] ([Id], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted], [Name]) VALUES (23, CAST(N'2024-03-02T14:16:06.9408159' AS DateTime2), NULL, N'Admin Admin', NULL, 0, N'Poultry')
INSERT [dbo].[Categories] ([Id], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted], [Name]) VALUES (24, CAST(N'2024-03-02T14:20:04.3661302' AS DateTime2), NULL, N'Admin Admin', NULL, 0, N'Vegeterian')
INSERT [dbo].[Categories] ([Id], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted], [Name]) VALUES (25, CAST(N'2024-03-02T14:26:33.8081136' AS DateTime2), NULL, N'Admin Admin', NULL, 0, N'Pork')
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[Chefs] ON 

INSERT [dbo].[Chefs] ([Id], [Surname], [Info], [Image], [Facebook], [Instagram], [Linkedin], [PositionId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted], [Name]) VALUES (4, N'test', N'chef', N'7b3946a0-6718-49e3-bbb1-78f1a12bc46edessert-2.jpg', N'chef', N'chef', N'chef', 4, CAST(N'2024-02-23T03:23:30.9077395' AS DateTime2), NULL, N'Admin Admin', NULL, 1, N'test')
INSERT [dbo].[Chefs] ([Id], [Surname], [Info], [Image], [Facebook], [Instagram], [Linkedin], [PositionId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted], [Name]) VALUES (5, N'Smith', N'Lorem to our restaurant, where culinary artistry meets exceptional dining experiences. At, we strive to create a gastronomic haven that tantalizes your taste buds and leaves you with unforgettable memories. Welcome to our restaurant, where culinary artistry meets exceptional dining experiences. At, we strive to create a gastronomic.  Lorem to our restaurant, where culinary artistry meets exceptional dining experiences. At, we strive to create a gastronomic haven that. Lorem to our restaurant, where culinary artistry meets exceptional dining exp eriences. At, we strive to create a gastronomic haven that.', N'c839fdeb-4147-4d84-817d-9745ad3753d5byron.jpg', N'https://www.facebook.com/', N'https://www.instagram.com/', N'https://www.linkedin.com/', 4, CAST(N'2024-03-03T17:47:36.2795463' AS DateTime2), CAST(N'2024-03-03T17:48:34.9924526' AS DateTime2), N'Admin Admin', N'Admin Admin', 0, N'Byron')
INSERT [dbo].[Chefs] ([Id], [Surname], [Info], [Image], [Facebook], [Instagram], [Linkedin], [PositionId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted], [Name]) VALUES (6, N'Bottura', N'Lorem to our restaurant, where culinary artistry meets exceptional dining experiences. At, we strive to create a gastronomic haven that tantalizes your taste buds and leaves you with unforgettable memories. Welcome to our restaurant, where culinary artistry meets exceptional dining experiences. At, we strive to create a gastronomic.  Lorem to our restaurant, where culinary artistry meets exceptional dining experiences. At, we strive to create a gastronomic haven that. Lorem to our restaurant, where culinary artistry meets exceptional dining exp eriences. At, we strive to create a gastronomic haven that.', N'620be336-4b07-46e7-8b9c-a900463bb938massimo.jpg', N'https://www.facebook.com/', N'https://www.instagram.com/', N'https://www.linkedin.com/', 5, CAST(N'2024-03-03T17:53:57.5741211' AS DateTime2), NULL, N'Admin Admin', NULL, 0, N'Massimo')
INSERT [dbo].[Chefs] ([Id], [Surname], [Info], [Image], [Facebook], [Instagram], [Linkedin], [PositionId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted], [Name]) VALUES (7, N'Cannon', N'Lorem to our restaurant, where culinary artistry meets exceptional dining experiences. At, we strive to create a gastronomic haven that tantalizes your taste buds and leaves you with unforgettable memories. Welcome to our restaurant, where culinary artistry meets exceptional dining experiences. At, we strive to create a gastronomic.  Lorem to our restaurant, where culinary artistry meets exceptional dining experiences. At, we strive to create a gastronomic haven that. Lorem to our restaurant, where culinary artistry meets exceptional dining exp eriences. At, we strive to create a gastronomic haven that.', N'9d656a65-ce67-4390-a500-a2abe7e14b02commis.jpg', N'https://www.facebook.com/', N'https://www.instagram.com/', N'https://www.linkedin.com/', 6, CAST(N'2024-03-03T18:03:26.2555770' AS DateTime2), NULL, N'Admin Admin', NULL, 0, N'Andrew')
SET IDENTITY_INSERT [dbo].[Chefs] OFF
GO
SET IDENTITY_INSERT [dbo].[Contacts] ON 

INSERT [dbo].[Contacts] ([Id], [Email], [CommentText], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted], [Name]) VALUES (19, N'ayshensalahova@gmail.com', N'Salam', CAST(N'2024-03-04T00:56:40.6035788' AS DateTime2), NULL, N'ayshen.salahova', NULL, 0, N'Ayshen')
INSERT [dbo].[Contacts] ([Id], [Email], [CommentText], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted], [Name]) VALUES (20, N'ayshensalahova@gmail.com', N'salam', CAST(N'2024-03-04T10:06:31.0660167' AS DateTime2), NULL, N'ayshen.salahova', NULL, 0, N'Ayshen')
SET IDENTITY_INSERT [dbo].[Contacts] OFF
GO
SET IDENTITY_INSERT [dbo].[DessertCategories] ON 

INSERT [dbo].[DessertCategories] ([Id], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted], [Name]) VALUES (6, CAST(N'2024-02-22T21:41:41.7490939' AS DateTime2), NULL, N'Admin Admin', NULL, 0, N'Pies')
INSERT [dbo].[DessertCategories] ([Id], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted], [Name]) VALUES (7, CAST(N'2024-02-22T21:42:15.6709623' AS DateTime2), NULL, N'Admin Admin', NULL, 0, N'Tarts')
INSERT [dbo].[DessertCategories] ([Id], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted], [Name]) VALUES (8, CAST(N'2024-02-22T21:43:13.5963507' AS DateTime2), NULL, N'Admin Admin', NULL, 0, N'Cookies')
INSERT [dbo].[DessertCategories] ([Id], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted], [Name]) VALUES (9, CAST(N'2024-02-22T21:43:50.3847835' AS DateTime2), NULL, N'Admin Admin', NULL, 0, N'Cakes')
INSERT [dbo].[DessertCategories] ([Id], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted], [Name]) VALUES (10, CAST(N'2024-02-22T21:44:51.2055766' AS DateTime2), NULL, N'Admin Admin', NULL, 0, N'Cheesecakes')
INSERT [dbo].[DessertCategories] ([Id], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted], [Name]) VALUES (11, CAST(N'2024-02-22T21:45:42.7645262' AS DateTime2), NULL, N'Admin Admin', NULL, 0, N'Puddings')
INSERT [dbo].[DessertCategories] ([Id], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted], [Name]) VALUES (12, CAST(N'2024-02-22T21:46:03.4888813' AS DateTime2), NULL, N'Admin Admin', NULL, 0, N'Gelatins')
INSERT [dbo].[DessertCategories] ([Id], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted], [Name]) VALUES (13, CAST(N'2024-02-22T21:47:00.5673302' AS DateTime2), NULL, N'Admin Admin', NULL, 0, N'Frozen Desserts')
INSERT [dbo].[DessertCategories] ([Id], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted], [Name]) VALUES (14, CAST(N'2024-03-02T16:03:23.3208992' AS DateTime2), NULL, N'Admin Admin', NULL, 0, N'Custard')
INSERT [dbo].[DessertCategories] ([Id], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted], [Name]) VALUES (15, CAST(N'2024-03-02T16:15:34.3360143' AS DateTime2), NULL, N'Admin Admin', NULL, 0, N'Sponge')
INSERT [dbo].[DessertCategories] ([Id], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted], [Name]) VALUES (16, CAST(N'2024-03-02T16:32:05.8452107' AS DateTime2), NULL, N'Admin Admin', NULL, 0, N'Crispe')
INSERT [dbo].[DessertCategories] ([Id], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted], [Name]) VALUES (17, CAST(N'2024-03-02T16:36:00.3091053' AS DateTime2), NULL, N'Admin Admin', NULL, 0, N'Sundae')
SET IDENTITY_INSERT [dbo].[DessertCategories] OFF
GO
SET IDENTITY_INSERT [dbo].[DessertImages] ON 

INSERT [dbo].[DessertImages] ([Id], [Image], [Alternative], [DessertId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted], [IsPrimary]) VALUES (7, N'af4b6bec-1d2b-421d-b0d1-f20fe19ea6e2mango-coconut.jpg', N'Mango Coconut Panna Cotta', 3, CAST(N'2024-03-02T16:04:23.8422721' AS DateTime2), NULL, N'ayshen.salahova', NULL, 0, 1)
INSERT [dbo].[DessertImages] ([Id], [Image], [Alternative], [DessertId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted], [IsPrimary]) VALUES (8, N'1781fcb4-45ee-4afc-879b-5fc095c1dabcmango-coconut.jpg', N'Mango Coconut Panna Cotta', 3, CAST(N'2024-03-02T16:04:23.8508469' AS DateTime2), NULL, N'ayshen.salahova', NULL, 0, 0)
INSERT [dbo].[DessertImages] ([Id], [Image], [Alternative], [DessertId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted], [IsPrimary]) VALUES (9, N'943aaa68-bbb5-4d27-9df1-ef6cf0ab99baraspberry.jpg', N'Raspberry Lemon Tart', 4, CAST(N'2024-03-02T16:09:27.8352707' AS DateTime2), NULL, N'ayshen.salahova', NULL, 0, 1)
INSERT [dbo].[DessertImages] ([Id], [Image], [Alternative], [DessertId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted], [IsPrimary]) VALUES (10, N'352a68f4-4725-459c-9090-f3e59df84f45raspberry-2.jpg', N'Raspberry Lemon Tart', 4, CAST(N'2024-03-02T16:09:27.8528927' AS DateTime2), NULL, N'ayshen.salahova', NULL, 0, 0)
INSERT [dbo].[DessertImages] ([Id], [Image], [Alternative], [DessertId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted], [IsPrimary]) VALUES (11, N'e9a2c00b-3d86-42f6-8c86-3411e112e276lava.jpg', N'Chocolate Lava Cake', 5, CAST(N'2024-03-02T16:13:03.6660415' AS DateTime2), NULL, N'ayshen.salahova', NULL, 0, 1)
INSERT [dbo].[DessertImages] ([Id], [Image], [Alternative], [DessertId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted], [IsPrimary]) VALUES (12, N'394979b1-f80f-459c-b330-05518f8e1ee7chocolate-lava-cake.jpg', N'Chocolate Lava Cake', 5, CAST(N'2024-03-02T16:13:03.6698288' AS DateTime2), NULL, N'ayshen.salahova', NULL, 0, 0)
INSERT [dbo].[DessertImages] ([Id], [Image], [Alternative], [DessertId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted], [IsPrimary]) VALUES (13, N'b8d9506e-ae8c-4bd9-a002-cc25985891a7tiramisu.jpg', N'Tiramisu', 6, CAST(N'2024-03-02T16:16:04.5802834' AS DateTime2), NULL, N'ayshen.salahova', NULL, 0, 1)
INSERT [dbo].[DessertImages] ([Id], [Image], [Alternative], [DessertId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted], [IsPrimary]) VALUES (14, N'33eb9601-f39a-4ce4-bf5d-ca3a632bb502tiramisu-2.jpg', N'Tiramisu', 6, CAST(N'2024-03-02T16:16:04.5823510' AS DateTime2), NULL, N'ayshen.salahova', NULL, 0, 0)
INSERT [dbo].[DessertImages] ([Id], [Image], [Alternative], [DessertId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted], [IsPrimary]) VALUES (15, N'c1d875f6-e075-4e1d-a8a9-9ac6e79747c8cremee-2.jpg', N'Creme Brulee', 7, CAST(N'2024-03-02T16:17:58.9295292' AS DateTime2), NULL, N'ayshen.salahova', NULL, 0, 1)
INSERT [dbo].[DessertImages] ([Id], [Image], [Alternative], [DessertId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted], [IsPrimary]) VALUES (16, N'c728143b-0e3a-4b8c-8488-cc430b7607fccremee-2.jpg', N'Creme Brulee', 7, CAST(N'2024-03-02T16:17:58.9312159' AS DateTime2), NULL, N'ayshen.salahova', NULL, 0, 0)
INSERT [dbo].[DessertImages] ([Id], [Image], [Alternative], [DessertId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted], [IsPrimary]) VALUES (17, N'dcf26d92-ffc0-4afc-b744-f629103e12cckey_lima.jpg', N'Key Lime Pie', 8, CAST(N'2024-03-02T16:23:25.3716399' AS DateTime2), NULL, N'ayshen.salahova', NULL, 0, 1)
INSERT [dbo].[DessertImages] ([Id], [Image], [Alternative], [DessertId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted], [IsPrimary]) VALUES (18, N'2ba53f92-01db-478b-8f78-255ac0433c57key-lima-2.jpg', N'Key Lime Pie', 8, CAST(N'2024-03-02T16:23:25.3734475' AS DateTime2), NULL, N'ayshen.salahova', NULL, 0, 0)
INSERT [dbo].[DessertImages] ([Id], [Image], [Alternative], [DessertId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted], [IsPrimary]) VALUES (19, N'cbfd9134-220b-4e80-8f52-d5daca3ebdeabread-pudding.jpeg', N'Bread Pudding', 9, CAST(N'2024-03-02T16:27:24.6790073' AS DateTime2), NULL, N'ayshen.salahova', NULL, 0, 1)
INSERT [dbo].[DessertImages] ([Id], [Image], [Alternative], [DessertId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted], [IsPrimary]) VALUES (20, N'c24d8df5-7460-4f9b-a579-b46b50be1347bread-pudding-2.jpg', N'Bread Pudding', 9, CAST(N'2024-03-02T16:27:24.6802072' AS DateTime2), NULL, N'ayshen.salahova', NULL, 0, 0)
INSERT [dbo].[DessertImages] ([Id], [Image], [Alternative], [DessertId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted], [IsPrimary]) VALUES (21, N'13328206-c848-4cf7-8c52-4d562cb7266ered-velvet.jpg', N'Red Velvet Cake', 10, CAST(N'2024-03-02T16:31:00.1558029' AS DateTime2), NULL, N'ayshen.salahova', NULL, 0, 1)
INSERT [dbo].[DessertImages] ([Id], [Image], [Alternative], [DessertId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted], [IsPrimary]) VALUES (22, N'41be97a7-f4ab-428b-ad39-2261265393fered-.jpg', N'Red Velvet Cake', 10, CAST(N'2024-03-02T16:31:00.1582073' AS DateTime2), NULL, N'ayshen.salahova', NULL, 0, 0)
INSERT [dbo].[DessertImages] ([Id], [Image], [Alternative], [DessertId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted], [IsPrimary]) VALUES (23, N'7b8e487a-d85b-4ce2-87ad-9f3faffc169capple-crispe.jpg', N'Apple Crisp', 11, CAST(N'2024-03-02T16:32:43.6038630' AS DateTime2), NULL, N'ayshen.salahova', NULL, 0, 1)
INSERT [dbo].[DessertImages] ([Id], [Image], [Alternative], [DessertId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted], [IsPrimary]) VALUES (24, N'33d60685-aa75-4a4d-a2dc-dc4125f8c788apple-crispe-2.jpg', N'Apple Crisp', 11, CAST(N'2024-03-02T16:32:43.6095316' AS DateTime2), NULL, N'ayshen.salahova', NULL, 0, 0)
INSERT [dbo].[DessertImages] ([Id], [Image], [Alternative], [DessertId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted], [IsPrimary]) VALUES (25, N'0403e89e-4911-4b2f-9785-78e0dac388e2Panna-Cotta.jpg', N'Vanilla Bean Panna Cotta', 12, CAST(N'2024-03-02T16:34:19.4401599' AS DateTime2), NULL, N'ayshen.salahova', NULL, 0, 1)
INSERT [dbo].[DessertImages] ([Id], [Image], [Alternative], [DessertId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted], [IsPrimary]) VALUES (26, N'206fc6e4-88ee-44e4-a1cd-15ef7b467ef3home-family-vanilla-bean-panna-cotta.jpg', N'Vanilla Bean Panna Cotta', 12, CAST(N'2024-03-02T16:34:19.4420932' AS DateTime2), NULL, N'ayshen.salahova', NULL, 0, 0)
INSERT [dbo].[DessertImages] ([Id], [Image], [Alternative], [DessertId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted], [IsPrimary]) VALUES (27, N'0ac8efab-5318-40c9-9a95-aea832ffc697choco.jpg', N'Chocolate Chip Cookie Sundae', 13, CAST(N'2024-03-02T16:35:46.8883299' AS DateTime2), NULL, N'ayshen.salahova', NULL, 0, 1)
INSERT [dbo].[DessertImages] ([Id], [Image], [Alternative], [DessertId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted], [IsPrimary]) VALUES (28, N'ca66c277-8cf8-4267-ad2d-11f461569775choco.jpg', N'Chocolate Chip Cookie Sundae', 13, CAST(N'2024-03-02T16:35:46.8904395' AS DateTime2), NULL, N'ayshen.salahova', NULL, 0, 0)
SET IDENTITY_INSERT [dbo].[DessertImages] OFF
GO
SET IDENTITY_INSERT [dbo].[Desserts] ON 

INSERT [dbo].[Desserts] ([Id], [Price], [Ingredients], [DessertCategoryId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted], [Name]) VALUES (3, CAST(20.00 AS Decimal(6, 2)), N'mango, coconut milk, gelatin, sugar, vanilla extract', 14, CAST(N'2024-03-02T16:04:23.8853294' AS DateTime2), NULL, N'Admin Admin', NULL, 0, N'Mango Coconut Panna Cotta')
INSERT [dbo].[Desserts] ([Id], [Price], [Ingredients], [DessertCategoryId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted], [Name]) VALUES (4, CAST(30.00 AS Decimal(6, 2)), N'raspberries, lemon curd, butter, flour, sugar.', 7, CAST(N'2024-03-02T16:09:27.8753128' AS DateTime2), NULL, N'Admin Admin', NULL, 0, N'Raspberry Lemon Tart')
INSERT [dbo].[Desserts] ([Id], [Price], [Ingredients], [DessertCategoryId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted], [Name]) VALUES (5, CAST(57.00 AS Decimal(6, 2)), N'dark chocolate, butter, sugar, eggs, flour.', 9, CAST(N'2024-03-02T16:13:03.6747992' AS DateTime2), NULL, N'Admin Admin', NULL, 0, N'Chocolate Lava Cake')
INSERT [dbo].[Desserts] ([Id], [Price], [Ingredients], [DessertCategoryId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted], [Name]) VALUES (6, CAST(17.00 AS Decimal(6, 2)), N'ladyfingers, coffee, mascarpone cheese, eggs, sugar. ', 15, CAST(N'2024-03-02T16:16:04.5922756' AS DateTime2), NULL, N'Admin Admin', NULL, 0, N'Tiramisu')
INSERT [dbo].[Desserts] ([Id], [Price], [Ingredients], [DessertCategoryId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted], [Name]) VALUES (7, CAST(39.00 AS Decimal(6, 2)), N'cream, sugar, vanilla bean, egg yolks.', 14, CAST(N'2024-03-02T16:17:58.9400749' AS DateTime2), NULL, N'Admin Admin', NULL, 0, N'Creme Brulee')
INSERT [dbo].[Desserts] ([Id], [Price], [Ingredients], [DessertCategoryId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted], [Name]) VALUES (8, CAST(40.00 AS Decimal(6, 2)), N'key lime juice, condensed milk, graham cracker crust. ', 6, CAST(N'2024-03-02T16:23:25.3786664' AS DateTime2), NULL, N'Admin Admin', NULL, 0, N'Key Lime Pie')
INSERT [dbo].[Desserts] ([Id], [Price], [Ingredients], [DessertCategoryId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted], [Name]) VALUES (9, CAST(20.00 AS Decimal(6, 2)), N'bread, milk, eggs, sugar, cinnamon.', 11, CAST(N'2024-03-02T16:27:24.6853710' AS DateTime2), NULL, N'Admin Admin', NULL, 0, N'Bread Pudding')
INSERT [dbo].[Desserts] ([Id], [Price], [Ingredients], [DessertCategoryId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted], [Name]) VALUES (10, CAST(60.00 AS Decimal(6, 2)), N'flour, cocoa powder, buttermilk, red food coloring, cream cheese frosting.', 9, CAST(N'2024-03-02T16:31:00.1693045' AS DateTime2), NULL, N'Admin Admin', NULL, 0, N'Red Velvet Cake')
INSERT [dbo].[Desserts] ([Id], [Price], [Ingredients], [DessertCategoryId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted], [Name]) VALUES (11, CAST(19.00 AS Decimal(6, 2)), N'apples, oats, brown sugar, cinnamon, butter. ', 16, CAST(N'2024-03-02T16:32:43.6170063' AS DateTime2), NULL, N'Admin Admin', NULL, 0, N'Apple Crisp')
INSERT [dbo].[Desserts] ([Id], [Price], [Ingredients], [DessertCategoryId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted], [Name]) VALUES (12, CAST(30.00 AS Decimal(6, 2)), N'cream, sugar, gelatin, vanilla bean. ', 14, CAST(N'2024-03-02T16:34:19.4487700' AS DateTime2), NULL, N'Admin Admin', NULL, 0, N'Vanilla Bean Panna Cotta')
INSERT [dbo].[Desserts] ([Id], [Price], [Ingredients], [DessertCategoryId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted], [Name]) VALUES (13, CAST(10.00 AS Decimal(6, 2)), N'chocolate chip cookies, vanilla ice cream, chocolate sauce, whipped cream. ', 17, CAST(N'2024-03-02T16:35:46.9013946' AS DateTime2), CAST(N'2024-03-02T16:36:13.0063528' AS DateTime2), N'Admin Admin', N'Admin Admin', 1, N'Chocolate Chip Cookie Sundae')
SET IDENTITY_INSERT [dbo].[Desserts] OFF
GO
SET IDENTITY_INSERT [dbo].[DrinkCategories] ON 

INSERT [dbo].[DrinkCategories] ([Id], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted], [Name]) VALUES (3, CAST(N'2024-02-22T21:48:01.2735435' AS DateTime2), NULL, N'Admin Admin', NULL, 0, N' Alcoholic Beverages')
INSERT [dbo].[DrinkCategories] ([Id], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted], [Name]) VALUES (4, CAST(N'2024-02-22T21:48:35.6429719' AS DateTime2), NULL, N'Admin Admin', NULL, 1, N'Soda/Soft Drinks')
INSERT [dbo].[DrinkCategories] ([Id], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted], [Name]) VALUES (5, CAST(N'2024-02-22T21:49:16.3705832' AS DateTime2), NULL, N'Admin Admin', NULL, 0, N'Fruit Juice')
INSERT [dbo].[DrinkCategories] ([Id], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted], [Name]) VALUES (6, CAST(N'2024-02-22T21:49:34.8039300' AS DateTime2), CAST(N'2024-02-23T02:15:59.1550951' AS DateTime2), N'Admin Admin', N'Admin Admin', 0, N'Coffee')
INSERT [dbo].[DrinkCategories] ([Id], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted], [Name]) VALUES (7, CAST(N'2024-02-22T21:49:41.9767193' AS DateTime2), CAST(N'2024-02-22T21:56:20.6652210' AS DateTime2), N'Admin Admin', N'Admin Admin', 0, N'Tea')
INSERT [dbo].[DrinkCategories] ([Id], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted], [Name]) VALUES (9, CAST(N'2024-03-02T16:43:08.5320962' AS DateTime2), NULL, N'Admin Admin', NULL, 0, N'Cocktail')
SET IDENTITY_INSERT [dbo].[DrinkCategories] OFF
GO
SET IDENTITY_INSERT [dbo].[Drinks] ON 

INSERT [dbo].[Drinks] ([Id], [Price], [Image], [Alternative], [DrinkCategoryId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted], [Name]) VALUES (3, CAST(125.00 AS Decimal(6, 2)), N'91f04d68-7826-48c3-a733-c9341399d3dbfrench75.jpg', N'French 75', 9, CAST(N'2024-03-02T16:43:43.6059485' AS DateTime2), NULL, N'Admin Admin', NULL, 0, N'French 75')
INSERT [dbo].[Drinks] ([Id], [Price], [Image], [Alternative], [DrinkCategoryId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted], [Name]) VALUES (4, CAST(90.00 AS Decimal(6, 2)), N'383859a4-55fd-4496-b876-bb47da468a8dcassis.jpg', N'Cassis', 9, CAST(N'2024-03-02T16:48:42.2542328' AS DateTime2), NULL, N'Admin Admin', NULL, 0, N'Cassis')
INSERT [dbo].[Drinks] ([Id], [Price], [Image], [Alternative], [DrinkCategoryId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted], [Name]) VALUES (5, CAST(70.00 AS Decimal(6, 2)), N'66dafd06-aeab-4e29-be9f-64c69b979f3ebluebird.jpeg', N'Bluebird', 9, CAST(N'2024-03-02T16:53:16.9384423' AS DateTime2), NULL, N'Admin Admin', NULL, 0, N'Bluebird')
INSERT [dbo].[Drinks] ([Id], [Price], [Image], [Alternative], [DrinkCategoryId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted], [Name]) VALUES (6, CAST(107.00 AS Decimal(6, 2)), N'fde67b8d-bef5-4d3d-a89f-233a3b782176pink.jpg', N'Pink Martini', 9, CAST(N'2024-03-02T16:55:34.2667375' AS DateTime2), NULL, N'Admin Admin', NULL, 0, N'Pink Martini')
INSERT [dbo].[Drinks] ([Id], [Price], [Image], [Alternative], [DrinkCategoryId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted], [Name]) VALUES (7, CAST(10.00 AS Decimal(6, 2)), N'9621872f-4c9b-483b-a98d-531ac15b9cccapple-juice.jpg', N'Apple Juice', 5, CAST(N'2024-03-02T17:00:31.8950680' AS DateTime2), NULL, N'Admin Admin', NULL, 0, N'Apple Juice')
INSERT [dbo].[Drinks] ([Id], [Price], [Image], [Alternative], [DrinkCategoryId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted], [Name]) VALUES (8, CAST(15.00 AS Decimal(6, 2)), N'6f34b6a9-111d-4764-a7dd-9c350a62e6f4blueberry.jpg', N'Blueberry juice', 5, CAST(N'2024-03-02T17:02:05.1706213' AS DateTime2), NULL, N'Admin Admin', NULL, 0, N'Blueberry juice')
INSERT [dbo].[Drinks] ([Id], [Price], [Image], [Alternative], [DrinkCategoryId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted], [Name]) VALUES (9, CAST(22.00 AS Decimal(6, 2)), N'eb19b73c-23cb-45be-9de4-dcf75083d5ccespresso.jpg', N'Espresso', 6, CAST(N'2024-03-02T17:04:03.4505005' AS DateTime2), NULL, N'Admin Admin', NULL, 0, N'Espresso')
INSERT [dbo].[Drinks] ([Id], [Price], [Image], [Alternative], [DrinkCategoryId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted], [Name]) VALUES (10, CAST(27.00 AS Decimal(6, 2)), N'c3fe34cd-276f-49f5-affd-b1ef1dff9747americano.jpeg', N'Americano', 6, CAST(N'2024-03-02T17:08:34.7276072' AS DateTime2), NULL, N'Admin Admin', NULL, 0, N'Americano')
INSERT [dbo].[Drinks] ([Id], [Price], [Image], [Alternative], [DrinkCategoryId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted], [Name]) VALUES (11, CAST(17.00 AS Decimal(6, 2)), N'1fd0b33f-fabc-4803-9013-9774d4a90132strawberry_tea.jpg', N'Strawberry tea', 7, CAST(N'2024-03-02T17:12:24.1808398' AS DateTime2), NULL, N'Admin Admin', NULL, 0, N'Strawberry tea')
INSERT [dbo].[Drinks] ([Id], [Price], [Image], [Alternative], [DrinkCategoryId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted], [Name]) VALUES (12, CAST(17.00 AS Decimal(6, 2)), N'77815848-b1bf-4b82-83c5-223177cef953orange.jpg', N'Orange tea', 7, CAST(N'2024-03-02T17:14:38.2767700' AS DateTime2), NULL, N'Admin Admin', NULL, 0, N'Orange tea')
INSERT [dbo].[Drinks] ([Id], [Price], [Image], [Alternative], [DrinkCategoryId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted], [Name]) VALUES (13, CAST(17.00 AS Decimal(6, 2)), N'92df023b-f3f2-47bf-9cbc-ffd780cbda6akiwi_tea.jpg', N'Kiwi tea', 7, CAST(N'2024-03-02T17:16:19.9973792' AS DateTime2), NULL, N'Admin Admin', NULL, 1, N'Kiwi tea')
SET IDENTITY_INSERT [dbo].[Drinks] OFF
GO
SET IDENTITY_INSERT [dbo].[Famous] ON 

INSERT [dbo].[Famous] ([Id], [Surname], [Country], [Image], [Opinion], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted], [Name]) VALUES (1, N'Sottile ', N'USA', N'fam.jpg', N'Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry''s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.', CAST(N'2024-03-03T00:00:00.0000000' AS DateTime2), NULL, N'ayshen', NULL, 0, N'Luciana')
INSERT [dbo].[Famous] ([Id], [Surname], [Country], [Image], [Opinion], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted], [Name]) VALUES (6, N'Smith', N'Italia', N'd3b19f77-c59c-46ca-8da4-b2f2788474c9admin-image-2.jpg', N'Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry''s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. ', CAST(N'2024-03-03T22:32:29.0404927' AS DateTime2), NULL, N'Admin Admin', NULL, 0, N'Byron')
SET IDENTITY_INSERT [dbo].[Famous] OFF
GO
SET IDENTITY_INSERT [dbo].[MealImages] ON 

INSERT [dbo].[MealImages] ([Id], [Image], [IsPrimary], [Alternative], [MealId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted]) VALUES (37, N'806d141e-854a-4e97-9cd5-aad187a1144dahi_tuna_2.jpg', 1, N'Seared Ahi Tuna Steak', 15, CAST(N'2024-03-02T14:05:13.4104206' AS DateTime2), NULL, N'ayshen.salahova', NULL, 0)
INSERT [dbo].[MealImages] ([Id], [Image], [IsPrimary], [Alternative], [MealId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted]) VALUES (38, N'6b80c437-150b-48e5-a7e2-799a53576801ahi_tuna_2.jpg', 0, N'Seared Ahi Tuna Steak', 15, CAST(N'2024-03-02T14:05:13.4290872' AS DateTime2), NULL, N'ayshen.salahova', NULL, 0)
INSERT [dbo].[MealImages] ([Id], [Image], [IsPrimary], [Alternative], [MealId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted]) VALUES (40, N'53f8b72a-565e-44df-99f3-a531f8abbadfbeef_wellington.jpg', 0, N'Beef Wellington', 16, CAST(N'2024-03-02T14:09:24.6835559' AS DateTime2), NULL, N'ayshen.salahova', NULL, 0)
INSERT [dbo].[MealImages] ([Id], [Image], [IsPrimary], [Alternative], [MealId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted]) VALUES (41, N'aae0b932-e88d-4496-87d1-cc7de32b1d57beef_wellington.jpg', 1, N'Beef Wellington', 16, CAST(N'2024-03-02T14:09:54.7816673' AS DateTime2), NULL, N'ayshen.salahova', NULL, 0)
INSERT [dbo].[MealImages] ([Id], [Image], [IsPrimary], [Alternative], [MealId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted]) VALUES (42, N'15e186ba-c79a-4adf-b0c2-d81f66e92561lemon_herbs.jpg', 1, N'Lemon Herb Roasted Chicken', 17, CAST(N'2024-03-02T14:15:36.4063292' AS DateTime2), NULL, N'ayshen.salahova', NULL, 0)
INSERT [dbo].[MealImages] ([Id], [Image], [IsPrimary], [Alternative], [MealId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted]) VALUES (43, N'2579cdc4-45d5-4491-8b32-780d51561878lemon_herbs.jpg', 0, N'Lemon Herb Roasted Chicken', 17, CAST(N'2024-03-02T14:15:36.4162141' AS DateTime2), NULL, N'ayshen.salahova', NULL, 0)
INSERT [dbo].[MealImages] ([Id], [Image], [IsPrimary], [Alternative], [MealId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted]) VALUES (44, N'2446e8cd-2293-41ed-bfbb-94e03f9dbe01EGGPLANT-PARMESANE.jpeg', 1, N'Eggplant Parmesan', 18, CAST(N'2024-03-02T14:20:43.2243209' AS DateTime2), NULL, N'ayshen.salahova', NULL, 0)
INSERT [dbo].[MealImages] ([Id], [Image], [IsPrimary], [Alternative], [MealId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted]) VALUES (45, N'ce9e64c7-1736-435e-8e77-15ace140faeaEGGPLANT-PARMESANE.jpeg', 0, N'Eggplant Parmesan', 18, CAST(N'2024-03-02T14:20:43.2332977' AS DateTime2), NULL, N'ayshen.salahova', NULL, 0)
INSERT [dbo].[MealImages] ([Id], [Image], [IsPrimary], [Alternative], [MealId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted]) VALUES (46, N'071e871b-8f48-43f7-8fa6-1f7d40462598Shrimp_Scampi.jpg', 1, N'Shrimp Scampi', 19, CAST(N'2024-03-02T14:23:44.3362632' AS DateTime2), NULL, N'ayshen.salahova', NULL, 0)
INSERT [dbo].[MealImages] ([Id], [Image], [IsPrimary], [Alternative], [MealId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted]) VALUES (47, N'1a3eb0bd-4d5c-4a02-9f39-0c06bcd7f332Shrimp_Scampi.jpg', 0, N'Shrimp Scampi', 19, CAST(N'2024-03-02T14:23:44.3415479' AS DateTime2), NULL, N'ayshen.salahova', NULL, 0)
INSERT [dbo].[MealImages] ([Id], [Image], [IsPrimary], [Alternative], [MealId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted]) VALUES (48, N'52b6a851-81cb-4449-bfb9-6aca499e42ffPork.jpg', 1, N'Pork Tenderloin with Apple Glaze', 20, CAST(N'2024-03-02T14:27:11.4778538' AS DateTime2), NULL, N'ayshen.salahova', NULL, 0)
INSERT [dbo].[MealImages] ([Id], [Image], [IsPrimary], [Alternative], [MealId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted]) VALUES (49, N'4b30e07d-ab91-472d-b14f-e738dd00817fPork.jpg', 0, N'Pork Tenderloin with Apple Glaze', 20, CAST(N'2024-03-02T14:27:11.4819060' AS DateTime2), NULL, N'ayshen.salahova', NULL, 0)
INSERT [dbo].[MealImages] ([Id], [Image], [IsPrimary], [Alternative], [MealId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted]) VALUES (50, N'3df8f6be-c37e-4883-a259-73be5f939254spaghetti_carbonara.jpg', 1, N'Spaghetti Carbonara', 21, CAST(N'2024-03-02T14:29:18.6144439' AS DateTime2), NULL, N'ayshen.salahova', NULL, 0)
INSERT [dbo].[MealImages] ([Id], [Image], [IsPrimary], [Alternative], [MealId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted]) VALUES (51, N'9b2945ba-678d-4f52-a710-775a7bf88c56spaghetti_carbonara.jpg', 0, N'Spaghetti Carbonara', 21, CAST(N'2024-03-02T14:29:18.6239770' AS DateTime2), NULL, N'ayshen.salahova', NULL, 0)
INSERT [dbo].[MealImages] ([Id], [Image], [IsPrimary], [Alternative], [MealId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted]) VALUES (52, N'717a2ad3-bc8f-4724-afea-3bf69c26427fgrilled.jpg', 1, N'Grilled Salmon with Dill Sauce', 22, CAST(N'2024-03-02T14:32:05.5764500' AS DateTime2), NULL, N'ayshen.salahova', NULL, 0)
INSERT [dbo].[MealImages] ([Id], [Image], [IsPrimary], [Alternative], [MealId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted]) VALUES (53, N'09dd06e1-5310-4941-9bf7-d3046be6cf6cgrilled.jpg', 0, N'Grilled Salmon with Dill Sauce', 22, CAST(N'2024-03-02T14:32:05.5831188' AS DateTime2), NULL, N'ayshen.salahova', NULL, 0)
INSERT [dbo].[MealImages] ([Id], [Image], [IsPrimary], [Alternative], [MealId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted]) VALUES (54, N'c864bce6-0a7b-497b-bd34-9a063932debestir-frai.jpg', 1, N'Stir-Fry', 23, CAST(N'2024-03-02T14:34:17.1372041' AS DateTime2), NULL, N'ayshen.salahova', NULL, 0)
INSERT [dbo].[MealImages] ([Id], [Image], [IsPrimary], [Alternative], [MealId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted]) VALUES (55, N'ac4d22b6-952f-41f6-a28e-9e5d8e2fe5e9stir-frai.jpg', 0, N'Stir-Fry', 23, CAST(N'2024-03-02T14:34:17.1451634' AS DateTime2), NULL, N'ayshen.salahova', NULL, 0)
INSERT [dbo].[MealImages] ([Id], [Image], [IsPrimary], [Alternative], [MealId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted]) VALUES (56, N'cfab3d35-87c0-4e54-afdb-7c72c426b421filetred.jpg', 1, N'Filet Mignon with Red Wine Reduction', 24, CAST(N'2024-03-02T14:36:13.4849734' AS DateTime2), NULL, N'ayshen.salahova', NULL, 0)
INSERT [dbo].[MealImages] ([Id], [Image], [IsPrimary], [Alternative], [MealId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted]) VALUES (57, N'4ecbac0a-7fbf-4278-90b0-7d07c13b6ea8filetred.jpg', 0, N'Filet Mignon with Red Wine Reduction', 24, CAST(N'2024-03-02T14:36:13.4887099' AS DateTime2), NULL, N'ayshen.salahova', NULL, 0)
INSERT [dbo].[MealImages] ([Id], [Image], [IsPrimary], [Alternative], [MealId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted]) VALUES (58, N'6be1ddaf-4e36-4fdc-9428-87d0d4380d2eEGGPLANT-PARMESANE.jpeg', 1, N'jjdfhjdfsjdhs', 25, CAST(N'2024-03-02T15:56:53.9690978' AS DateTime2), NULL, N'ayshen.salahova', NULL, 0)
INSERT [dbo].[MealImages] ([Id], [Image], [IsPrimary], [Alternative], [MealId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted]) VALUES (59, N'09de76e4-5ddb-4c04-9bc6-25e574c35028beef-taco-2.jpg', 0, N'jjdfhjdfsjdhs', 25, CAST(N'2024-03-02T15:56:53.9750106' AS DateTime2), NULL, N'ayshen.salahova', NULL, 0)
INSERT [dbo].[MealImages] ([Id], [Image], [IsPrimary], [Alternative], [MealId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted]) VALUES (60, N'73f23cea-0d21-454d-a433-4d40bed420f7ahi_tuna_2.jpg', 1, N'asadd', 26, CAST(N'2024-03-04T10:10:57.7940580' AS DateTime2), NULL, N'ayshen.salahova', NULL, 0)
INSERT [dbo].[MealImages] ([Id], [Image], [IsPrimary], [Alternative], [MealId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted]) VALUES (61, N'f58ebc63-669b-4bf1-8769-c34feaec5819apple-crispe.jpg', 0, N'asadd', 26, CAST(N'2024-03-04T10:10:57.8037517' AS DateTime2), NULL, N'ayshen.salahova', NULL, 0)
SET IDENTITY_INSERT [dbo].[MealImages] OFF
GO
SET IDENTITY_INSERT [dbo].[Meals] ON 

INSERT [dbo].[Meals] ([Id], [Price], [Ingredients], [CategoryId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted], [Name]) VALUES (15, CAST(40.00 AS Decimal(6, 2)), N'Fresh ahi tuna steak, soy sauce, sesame oil, garlic, ginger, green onions', 21, CAST(N'2024-03-02T14:05:13.4559323' AS DateTime2), CAST(N'2024-03-02T14:06:27.8650350' AS DateTime2), N'Admin Admin', N'Admin Admin', 0, N'Seared Ahi Tuna Steak')
INSERT [dbo].[Meals] ([Id], [Price], [Ingredients], [CategoryId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted], [Name]) VALUES (16, CAST(132.00 AS Decimal(6, 2)), N'Filet mignon, puff pastry, mushrooms, shallots, Dijon mustard, egg wash', 22, CAST(N'2024-03-02T14:09:24.7131135' AS DateTime2), CAST(N'2024-03-02T14:09:54.7978297' AS DateTime2), N'Admin Admin', N'Admin Admin', 0, N'Beef Wellington')
INSERT [dbo].[Meals] ([Id], [Price], [Ingredients], [CategoryId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted], [Name]) VALUES (17, CAST(36.00 AS Decimal(6, 2)), N'Whole chicken, lemon, garlic, rosemary, thyme, olive oil', 23, CAST(N'2024-03-02T14:15:36.4308371' AS DateTime2), CAST(N'2024-03-02T14:16:19.0830071' AS DateTime2), N'Admin Admin', N'Admin Admin', 0, N'Lemon Herb Roasted Chicken')
INSERT [dbo].[Meals] ([Id], [Price], [Ingredients], [CategoryId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted], [Name]) VALUES (18, CAST(70.00 AS Decimal(6, 2)), N'Eggplant, marinara sauce, mozzarella cheese, parmesan cheese, breadcrumbs', 24, CAST(N'2024-03-02T14:20:43.2524668' AS DateTime2), NULL, N'Admin Admin', NULL, 0, N'Eggplant Parmesan')
INSERT [dbo].[Meals] ([Id], [Price], [Ingredients], [CategoryId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted], [Name]) VALUES (19, CAST(110.00 AS Decimal(6, 2)), N'Shrimp, garlic, butter, white wine, lemon juice, parsley', 21, CAST(N'2024-03-02T14:23:44.3639638' AS DateTime2), NULL, N'Admin Admin', NULL, 0, N'Shrimp Scampi')
INSERT [dbo].[Meals] ([Id], [Price], [Ingredients], [CategoryId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted], [Name]) VALUES (20, CAST(98.00 AS Decimal(6, 2)), N'Pork tenderloin, apples, apple cider vinegar, honey, cinnamon, nutmeg

', 25, CAST(N'2024-03-02T14:27:11.5007246' AS DateTime2), NULL, N'Admin Admin', NULL, 0, N'Pork Tenderloin with Apple Glaze')
INSERT [dbo].[Meals] ([Id], [Price], [Ingredients], [CategoryId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted], [Name]) VALUES (21, CAST(57.00 AS Decimal(6, 2)), N'Spaghetti, pancetta, eggs, parmesan cheese, black pepper', 17, CAST(N'2024-03-02T14:29:18.6444287' AS DateTime2), NULL, N'Admin Admin', NULL, 0, N'Spaghetti Carbonara')
INSERT [dbo].[Meals] ([Id], [Price], [Ingredients], [CategoryId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted], [Name]) VALUES (22, CAST(122.00 AS Decimal(6, 2)), N'Salmon fillets, dill, lemon juice, sour cream, garlic, salt', 21, CAST(N'2024-03-02T14:32:05.5979313' AS DateTime2), NULL, N'Admin Admin', NULL, 0, N'Grilled Salmon with Dill Sauce')
INSERT [dbo].[Meals] ([Id], [Price], [Ingredients], [CategoryId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted], [Name]) VALUES (23, CAST(35.00 AS Decimal(6, 2)), N'Assorted vegetables (bell peppers, broccoli, carrots), tofu, soy sauce, ginger, garlic', 24, CAST(N'2024-03-02T14:34:17.1605088' AS DateTime2), NULL, N'Admin Admin', NULL, 0, N'Stir-Fry')
INSERT [dbo].[Meals] ([Id], [Price], [Ingredients], [CategoryId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted], [Name]) VALUES (24, CAST(147.00 AS Decimal(6, 2)), N'Filet mignon, red wine, beef broth, shallots, butter, thyme', 22, CAST(N'2024-03-02T14:36:13.5025557' AS DateTime2), NULL, N'Admin Admin', NULL, 0, N'Filet Mignon with Red Wine Reduction')
INSERT [dbo].[Meals] ([Id], [Price], [Ingredients], [CategoryId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted], [Name]) VALUES (25, CAST(23.00 AS Decimal(6, 2)), N'hdsjff', 16, CAST(N'2024-03-02T15:56:53.9890422' AS DateTime2), NULL, N'Admin Admin', NULL, 1, N'jjdfhjdfsjdhs')
INSERT [dbo].[Meals] ([Id], [Price], [Ingredients], [CategoryId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted], [Name]) VALUES (26, CAST(12.00 AS Decimal(6, 2)), N'lorem', 22, CAST(N'2024-03-04T10:10:57.8134582' AS DateTime2), NULL, N'Admin Admin', NULL, 1, N'asadd')
SET IDENTITY_INSERT [dbo].[Meals] OFF
GO
SET IDENTITY_INSERT [dbo].[News] ON 

INSERT [dbo].[News] ([Id], [Image], [Description], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted], [Name]) VALUES (4, N'7ff421d1-87b9-463e-9c3e-6c2e7bf6b52dcake.jpg', N'Elegencia has great news to share with you!

Special promotion for everyone whose name day it is!

1. Everyone celebrating his/her name day will receive a compliment provided on own birthday by Elegencia restaurant team – one serving of our special dessert course.

2. Everyone celebrating his/her name, when making an order for a certain amount, will receive a compliment provided on own birthday by Elegencia restaurant team – the whole cake with a candle, baked following an unique recipe of brand chef.', CAST(N'2024-03-03T18:14:32.4995633' AS DateTime2), NULL, N'Admin Admin', NULL, 0, N'BIRTHDAY CAKE FROM ELEGENCIA')
SET IDENTITY_INSERT [dbo].[News] OFF
GO
SET IDENTITY_INSERT [dbo].[Positions] ON 

INSERT [dbo].[Positions] ([Id], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted], [Name]) VALUES (4, CAST(N'2024-02-22T22:09:20.1961246' AS DateTime2), NULL, N'Admin Admin', NULL, 0, N'Head of Chef')
INSERT [dbo].[Positions] ([Id], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted], [Name]) VALUES (5, CAST(N'2024-03-03T17:43:12.4672465' AS DateTime2), NULL, N'Admin Admin', NULL, 0, N'Italian Specialist')
INSERT [dbo].[Positions] ([Id], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted], [Name]) VALUES (6, CAST(N'2024-03-03T17:56:15.8381870' AS DateTime2), NULL, N'Admin Admin', NULL, 0, N'Commis Chef')
SET IDENTITY_INSERT [dbo].[Positions] OFF
GO
SET IDENTITY_INSERT [dbo].[Reservations] ON 

INSERT [dbo].[Reservations] ([Id], [Email], [NumberOfPeople], [ArrivalDateTime], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted], [Name]) VALUES (23, N'ayshensalahova@gmail.com', 4, CAST(N'2024-03-26T15:00:00.0000000' AS DateTime2), CAST(N'2024-03-04T00:56:12.8001027' AS DateTime2), NULL, N'ayshen.salahova', NULL, 0, N'Ayshen')
INSERT [dbo].[Reservations] ([Id], [Email], [NumberOfPeople], [ArrivalDateTime], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted], [Name]) VALUES (24, N'ayshensalahova@gmail.com', 2, CAST(N'2024-03-06T13:00:00.0000000' AS DateTime2), CAST(N'2024-03-04T10:08:15.7226396' AS DateTime2), NULL, N'ayshen.salahova', NULL, 0, N'Ayshen')
SET IDENTITY_INSERT [dbo].[Reservations] OFF
GO
SET IDENTITY_INSERT [dbo].[Salads] ON 

INSERT [dbo].[Salads] ([Id], [Price], [Ingredients], [Image], [Alternative], [CategoryId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted], [Name]) VALUES (20, CAST(25.00 AS Decimal(6, 2)), N'This creamy and luxurious soup is made with lobster stock, heavy cream, and chunks of tender lobster meat.', N'c4c81a12-7707-494b-911f-270edf96cdb1Seafood-Bisque.jpg', N'Lobster Bisque', 12, CAST(N'2024-03-02T14:46:13.1306894' AS DateTime2), NULL, N'Admin Admin', NULL, 0, N'Lobster Bisque')
INSERT [dbo].[Salads] ([Id], [Price], [Ingredients], [Image], [Alternative], [CategoryId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted], [Name]) VALUES (21, CAST(28.00 AS Decimal(6, 2)), N'This refreshing salad features peppery arugula, sweet sliced pears, toasted walnuts, and a balsamic vinaigrette.', N'ddebca70-b379-4f57-91be-8dc9b05cd781argula.jpg', N'Arugula and Pear Salad', 13, CAST(N'2024-03-02T15:18:01.3341743' AS DateTime2), NULL, N'Admin Admin', NULL, 0, N'Arugula and Pear Salad')
INSERT [dbo].[Salads] ([Id], [Price], [Ingredients], [Image], [Alternative], [CategoryId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted], [Name]) VALUES (22, CAST(37.00 AS Decimal(6, 2)), N'Made with roasted butternut squash, onions, vegetable broth, and a touch of cream, this soup is both comforting and elegant.', N'1e12e30c-f572-4685-b90e-8dd0de9eaa24SquashSoup.jpg', N'Butternut Squash Soup', 12, CAST(N'2024-03-02T15:19:10.1848937' AS DateTime2), NULL, N'Admin Admin', NULL, 0, N'Butternut Squash Soup')
INSERT [dbo].[Salads] ([Id], [Price], [Ingredients], [Image], [Alternative], [CategoryId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted], [Name]) VALUES (23, CAST(17.00 AS Decimal(6, 2)), N'A classic Italian salad made with fresh tomatoes, mozzarella cheese, basil leaves, and a drizzle of balsamic glaze.', N'24fbcb6b-79f4-43f1-8093-ab5bf1c9d96cCapreseSalad.jpeg', N'Caprese Salad', 13, CAST(N'2024-03-02T15:21:54.2128862' AS DateTime2), NULL, N'Admin Admin', NULL, 0, N'Caprese Salad')
INSERT [dbo].[Salads] ([Id], [Price], [Ingredients], [Image], [Alternative], [CategoryId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted], [Name]) VALUES (24, CAST(34.00 AS Decimal(6, 2)), N'This rich and flavorful soup is made with caramelized onions, beef broth, and topped with crusty bread and melted Gruyere cheese.', N'0d25a97d-0eeb-4287-8a97-2a204ad97c46onion-soup.jpg', N'French Onion Soup', 12, CAST(N'2024-03-02T15:29:18.4441747' AS DateTime2), NULL, N'Admin Admin', NULL, 0, N'French Onion Soup')
INSERT [dbo].[Salads] ([Id], [Price], [Ingredients], [Image], [Alternative], [CategoryId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted], [Name]) VALUES (25, CAST(44.00 AS Decimal(6, 2)), N'Roasted beets, creamy goat cheese, toasted walnuts, and a tangy vinaigrette make for a vibrant and delicious salad.', N'6da7052f-5fba-4ab3-91f9-3b7952fde9d3Beet.jpg', N'Beet and Goat Cheese Salad', 13, CAST(N'2024-03-02T15:31:33.8236725' AS DateTime2), NULL, N'Admin Admin', NULL, 0, N'Beet and Goat Cheese Salad')
INSERT [dbo].[Salads] ([Id], [Price], [Ingredients], [Image], [Alternative], [CategoryId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted], [Name]) VALUES (26, CAST(22.00 AS Decimal(6, 2)), N' A simple but delicious soup made with ripe tomatoes, fresh basil, garlic, and a splash of cream.', N'341ef1bc-84e6-4484-90aa-b47b1458f730tomatoşjpg.jpg', N'Tomato Basil Soup', 12, CAST(N'2024-03-02T15:34:44.4541029' AS DateTime2), NULL, N'Admin Admin', NULL, 0, N'Tomato Basil Soup')
INSERT [dbo].[Salads] ([Id], [Price], [Ingredients], [Image], [Alternative], [CategoryId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted], [Name]) VALUES (27, CAST(69.00 AS Decimal(6, 2)), N'This colorful salad features baby spinach, sliced strawberries, toasted almonds, and a poppyseed dressing.', N'25ad5d69-848a-4561-99a8-2803162a152cstraüberrysalad.jpg', N'Spinach and Strawberry Salad', 13, CAST(N'2024-03-02T15:36:11.8683234' AS DateTime2), NULL, N'Admin Admin', NULL, 0, N'Spinach and Strawberry Salad')
INSERT [dbo].[Salads] ([Id], [Price], [Ingredients], [Image], [Alternative], [CategoryId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted], [Name]) VALUES (28, CAST(40.00 AS Decimal(6, 2)), N'A velvety soup made with a blend of earthy mushrooms, onions, garlic, and a touch of sherry.', N'8bcdc25c-6d27-4eee-97aa-11a81f236225MushroomBisque-2.jpg', N'Mushroom Bisque', 12, CAST(N'2024-03-02T15:40:56.1868843' AS DateTime2), CAST(N'2024-03-02T15:41:42.0875194' AS DateTime2), N'Admin Admin', N'Admin Admin', 0, N'Mushroom Bisque')
INSERT [dbo].[Salads] ([Id], [Price], [Ingredients], [Image], [Alternative], [CategoryId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted], [Name]) VALUES (29, CAST(29.00 AS Decimal(6, 2)), N'Crisp lettuce, ripe tomatoes, cucumbers, Kalamata olives, feta cheese, and a lemon-herb vinaigrette come together in this classic Mediterranean salad.', N'7e10240e-5f12-479c-8fcc-6e60c802a675greek_salad.jpg', N'Greek Salad', 13, CAST(N'2024-03-02T15:46:14.1304210' AS DateTime2), NULL, N'Admin Admin', NULL, 0, N'Greek Salad')
INSERT [dbo].[Salads] ([Id], [Price], [Ingredients], [Image], [Alternative], [CategoryId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [IsDeleted], [Name]) VALUES (30, CAST(60.00 AS Decimal(6, 2)), N'This bright and flavorful soup is made with roasted carrots, fresh ginger, onions, and vegetable broth, and is topped with a dollop of Greek yogurt and a sprinkle of toasted seeds.', N'2b9a3b0a-efc2-4892-a341-62cf9f5e2cc4CarrotGingerSoup.jpg', N'Carrot Ginger Soup', 12, CAST(N'2024-03-02T15:53:38.8971046' AS DateTime2), NULL, N'Admin Admin', NULL, 1, N'Carrot Ginger Soup')
SET IDENTITY_INSERT [dbo].[Salads] OFF
GO
SET IDENTITY_INSERT [dbo].[Settings] ON 

INSERT [dbo].[Settings] ([Id], [Key], [Value], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy]) VALUES (1, N'Phone#1', N'+1 999 999 99 99', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'', CAST(N'2024-03-02T13:46:17.0265555' AS DateTime2), N'Admin Admin')
INSERT [dbo].[Settings] ([Id], [Key], [Value], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy]) VALUES (2, N'Location#1', N'New York, PONTA DELGADA', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'', CAST(N'2024-03-03T21:16:47.8865553' AS DateTime2), N'Admin Admin')
INSERT [dbo].[Settings] ([Id], [Key], [Value], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy]) VALUES (3, N'Weekdays', N'09:00AM - 11:00PM', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'', NULL, NULL)
INSERT [dbo].[Settings] ([Id], [Key], [Value], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy]) VALUES (4, N'Weekend', N'10:00AM - 11:00PM', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'', NULL, NULL)
INSERT [dbo].[Settings] ([Id], [Key], [Value], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy]) VALUES (5, N'Phone#2', N'+111 111 11 11', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'', NULL, NULL)
INSERT [dbo].[Settings] ([Id], [Key], [Value], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy]) VALUES (6, N'Location#2', N'Los Angeles', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'', NULL, NULL)
INSERT [dbo].[Settings] ([Id], [Key], [Value], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy]) VALUES (7, N'Email', N'eelegencia@gmail.com', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'', CAST(N'2024-03-02T13:48:33.2366586' AS DateTime2), N'Admin Admin')
INSERT [dbo].[Settings] ([Id], [Key], [Value], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy]) VALUES (8, N'Year', N'2024', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'', NULL, NULL)
INSERT [dbo].[Settings] ([Id], [Key], [Value], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy]) VALUES (9, N'CapacityIcon', N'<i class="bi bi-people"></i>', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'', NULL, NULL)
INSERT [dbo].[Settings] ([Id], [Key], [Value], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy]) VALUES (10, N'Capacity', N'up to 250 guests', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'', NULL, NULL)
INSERT [dbo].[Settings] ([Id], [Key], [Value], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy]) VALUES (11, N'OpeningIcon', N'<i class="bi bi-calendar"></i>', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'', NULL, NULL)
SET IDENTITY_INSERT [dbo].[Settings] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetRoleClaims_RoleId]    Script Date: 10.03.2024 22:53:43 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId] ON [dbo].[AspNetRoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 10.03.2024 22:53:43 ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserClaims_UserId]    Script Date: 10.03.2024 22:53:43 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserLogins_UserId]    Script Date: 10.03.2024 22:53:43 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserRoles_RoleId]    Script Date: 10.03.2024 22:53:43 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [EmailIndex]    Script Date: 10.03.2024 22:53:43 ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUsers_Email]    Script Date: 10.03.2024 22:53:43 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_AspNetUsers_Email] ON [dbo].[AspNetUsers]
(
	[Email] ASC
)
WHERE ([Email] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUsers_UserName]    Script Date: 10.03.2024 22:53:43 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_AspNetUsers_UserName] ON [dbo].[AspNetUsers]
(
	[UserName] ASC
)
WHERE ([UserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 10.03.2024 22:53:43 ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Categories_Name]    Script Date: 10.03.2024 22:53:43 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Categories_Name] ON [dbo].[Categories]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Chefs_PositionId]    Script Date: 10.03.2024 22:53:43 ******/
CREATE NONCLUSTERED INDEX [IX_Chefs_PositionId] ON [dbo].[Chefs]
(
	[PositionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_DessertImages_DessertId]    Script Date: 10.03.2024 22:53:43 ******/
CREATE NONCLUSTERED INDEX [IX_DessertImages_DessertId] ON [dbo].[DessertImages]
(
	[DessertId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Desserts_DessertCategoryId]    Script Date: 10.03.2024 22:53:43 ******/
CREATE NONCLUSTERED INDEX [IX_Desserts_DessertCategoryId] ON [dbo].[Desserts]
(
	[DessertCategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Desserts_Name]    Script Date: 10.03.2024 22:53:43 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Desserts_Name] ON [dbo].[Desserts]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_DessertTags_DessertId]    Script Date: 10.03.2024 22:53:43 ******/
CREATE NONCLUSTERED INDEX [IX_DessertTags_DessertId] ON [dbo].[DessertTags]
(
	[DessertId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_DessertTags_TagId]    Script Date: 10.03.2024 22:53:43 ******/
CREATE NONCLUSTERED INDEX [IX_DessertTags_TagId] ON [dbo].[DessertTags]
(
	[TagId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Drinks_DrinkCategoryId]    Script Date: 10.03.2024 22:53:43 ******/
CREATE NONCLUSTERED INDEX [IX_Drinks_DrinkCategoryId] ON [dbo].[Drinks]
(
	[DrinkCategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Drinks_Name]    Script Date: 10.03.2024 22:53:43 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Drinks_Name] ON [dbo].[Drinks]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_MealImages_MealId]    Script Date: 10.03.2024 22:53:43 ******/
CREATE NONCLUSTERED INDEX [IX_MealImages_MealId] ON [dbo].[MealImages]
(
	[MealId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Meals_CategoryId]    Script Date: 10.03.2024 22:53:43 ******/
CREATE NONCLUSTERED INDEX [IX_Meals_CategoryId] ON [dbo].[Meals]
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Meals_Name]    Script Date: 10.03.2024 22:53:43 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Meals_Name] ON [dbo].[Meals]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_MealTags_MealId]    Script Date: 10.03.2024 22:53:43 ******/
CREATE NONCLUSTERED INDEX [IX_MealTags_MealId] ON [dbo].[MealTags]
(
	[MealId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_MealTags_TagId]    Script Date: 10.03.2024 22:53:43 ******/
CREATE NONCLUSTERED INDEX [IX_MealTags_TagId] ON [dbo].[MealTags]
(
	[TagId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Positions_Name]    Script Date: 10.03.2024 22:53:43 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Positions_Name] ON [dbo].[Positions]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Salads_CategoryId]    Script Date: 10.03.2024 22:53:43 ******/
CREATE NONCLUSTERED INDEX [IX_Salads_CategoryId] ON [dbo].[Salads]
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Salads_Name]    Script Date: 10.03.2024 22:53:43 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Salads_Name] ON [dbo].[Salads]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Tags_Name]    Script Date: 10.03.2024 22:53:43 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Tags_Name] ON [dbo].[Tags]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Meals] ADD  DEFAULT ((0)) FOR [CategoryId]
GO
ALTER TABLE [dbo].[Settings] ADD  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Settings] ADD  DEFAULT (N'') FOR [CreatedBy]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Chefs]  WITH CHECK ADD  CONSTRAINT [FK_Chefs_Positions_PositionId] FOREIGN KEY([PositionId])
REFERENCES [dbo].[Positions] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Chefs] CHECK CONSTRAINT [FK_Chefs_Positions_PositionId]
GO
ALTER TABLE [dbo].[DessertImages]  WITH CHECK ADD  CONSTRAINT [FK_DessertImages_Desserts_DessertId] FOREIGN KEY([DessertId])
REFERENCES [dbo].[Desserts] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DessertImages] CHECK CONSTRAINT [FK_DessertImages_Desserts_DessertId]
GO
ALTER TABLE [dbo].[Desserts]  WITH CHECK ADD  CONSTRAINT [FK_Desserts_DessertCategories_DessertCategoryId] FOREIGN KEY([DessertCategoryId])
REFERENCES [dbo].[DessertCategories] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Desserts] CHECK CONSTRAINT [FK_Desserts_DessertCategories_DessertCategoryId]
GO
ALTER TABLE [dbo].[DessertTags]  WITH CHECK ADD  CONSTRAINT [FK_DessertTags_Desserts_DessertId] FOREIGN KEY([DessertId])
REFERENCES [dbo].[Desserts] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DessertTags] CHECK CONSTRAINT [FK_DessertTags_Desserts_DessertId]
GO
ALTER TABLE [dbo].[DessertTags]  WITH CHECK ADD  CONSTRAINT [FK_DessertTags_Tags_TagId] FOREIGN KEY([TagId])
REFERENCES [dbo].[Tags] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DessertTags] CHECK CONSTRAINT [FK_DessertTags_Tags_TagId]
GO
ALTER TABLE [dbo].[Drinks]  WITH CHECK ADD  CONSTRAINT [FK_Drinks_DrinkCategories_DrinkCategoryId] FOREIGN KEY([DrinkCategoryId])
REFERENCES [dbo].[DrinkCategories] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Drinks] CHECK CONSTRAINT [FK_Drinks_DrinkCategories_DrinkCategoryId]
GO
ALTER TABLE [dbo].[MealImages]  WITH CHECK ADD  CONSTRAINT [FK_MealImages_Meals_MealId] FOREIGN KEY([MealId])
REFERENCES [dbo].[Meals] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MealImages] CHECK CONSTRAINT [FK_MealImages_Meals_MealId]
GO
ALTER TABLE [dbo].[Meals]  WITH CHECK ADD  CONSTRAINT [FK_Meals_Categories_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Meals] CHECK CONSTRAINT [FK_Meals_Categories_CategoryId]
GO
ALTER TABLE [dbo].[MealTags]  WITH CHECK ADD  CONSTRAINT [FK_MealTags_Meals_MealId] FOREIGN KEY([MealId])
REFERENCES [dbo].[Meals] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MealTags] CHECK CONSTRAINT [FK_MealTags_Meals_MealId]
GO
ALTER TABLE [dbo].[MealTags]  WITH CHECK ADD  CONSTRAINT [FK_MealTags_Tags_TagId] FOREIGN KEY([TagId])
REFERENCES [dbo].[Tags] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MealTags] CHECK CONSTRAINT [FK_MealTags_Tags_TagId]
GO
ALTER TABLE [dbo].[Salads]  WITH CHECK ADD  CONSTRAINT [FK_Salads_Categories_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Salads] CHECK CONSTRAINT [FK_Salads_Categories_CategoryId]
GO
USE [master]
GO
ALTER DATABASE [Elegencia] SET  READ_WRITE 
GO
