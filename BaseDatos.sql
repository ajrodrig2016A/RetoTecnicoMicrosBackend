USE [RetoTecnicoBDD]
GO
ALTER TABLE [dbo].[Movimientos] DROP CONSTRAINT [FK_Movimientos_Cuentas_CuentaId]
GO
ALTER TABLE [dbo].[Cuentas] DROP CONSTRAINT [FK_Cuentas_Clientes_ClienteId]
GO
/****** Object:  Table [dbo].[Movimientos]    Script Date: 9/29/2024 1:05:53 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Movimientos]') AND type in (N'U'))
DROP TABLE [dbo].[Movimientos]
GO
/****** Object:  Table [dbo].[Cuentas]    Script Date: 9/29/2024 1:05:53 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Cuentas]') AND type in (N'U'))
DROP TABLE [dbo].[Cuentas]
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 9/29/2024 1:05:53 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Clientes]') AND type in (N'U'))
DROP TABLE [dbo].[Clientes]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 9/29/2024 1:05:53 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[__EFMigrationsHistory]') AND type in (N'U'))
DROP TABLE [dbo].[__EFMigrationsHistory]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 9/29/2024 1:05:53 AM ******/
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
/****** Object:  Table [dbo].[Clientes]    Script Date: 9/29/2024 1:05:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](200) NOT NULL,
	[Genero] [nvarchar](1) NOT NULL,
	[Edad] [int] NOT NULL,
	[Identificacion] [nvarchar](20) NOT NULL,
	[Direccion] [nvarchar](255) NOT NULL,
	[Telefono] [nvarchar](50) NOT NULL,
	[Contrasenia] [nvarchar](255) NOT NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cuentas]    Script Date: 9/29/2024 1:05:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cuentas](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Numero] [nvarchar](100) NOT NULL,
	[Tipo] [nvarchar](64) NOT NULL,
	[SaldoInicial] [decimal](18, 2) NOT NULL,
	[Estado] [bit] NOT NULL,
	[ClienteId] [int] NOT NULL,
 CONSTRAINT [PK_Cuentas] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Movimientos]    Script Date: 9/29/2024 1:05:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movimientos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Fecha] [datetime2](7) NOT NULL,
	[Tipo] [nvarchar](64) NOT NULL,
	[Valor] [decimal](18, 2) NOT NULL,
	[Saldo] [decimal](18, 2) NOT NULL,
	[CuentaId] [int] NOT NULL,
 CONSTRAINT [PK_Movimientos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240927170209_RetoTecnicoBDD_v1.0', N'8.0.5')
GO
SET IDENTITY_INSERT [dbo].[Clientes] ON 

INSERT [dbo].[Clientes] ([Id], [Nombre], [Genero], [Edad], [Identificacion], [Direccion], [Telefono], [Contrasenia], [Estado]) VALUES (1, N'Andrés Rodriguez', N'M', 41, N'1713071965', N'Magdalena', N'2675680', N'13579', 0)
INSERT [dbo].[Clientes] ([Id], [Nombre], [Genero], [Edad], [Identificacion], [Direccion], [Telefono], [Contrasenia], [Estado]) VALUES (2, N'Myriam Simbaña', N'F', 38, N'1717171095', N'El Bosque', N'3524789', N'6789', 1)
INSERT [dbo].[Clientes] ([Id], [Nombre], [Genero], [Edad], [Identificacion], [Direccion], [Telefono], [Contrasenia], [Estado]) VALUES (4, N'Fabian Torres', N'M', 35, N'1425639874', N'Solanda', N'0993666590', N'1547896', 1)
INSERT [dbo].[Clientes] ([Id], [Nombre], [Genero], [Edad], [Identificacion], [Direccion], [Telefono], [Contrasenia], [Estado]) VALUES (6, N'Pedro Zapata', N'M', 34, N'1717170102', N'manta', N'7841563', N'456321', 1)
INSERT [dbo].[Clientes] ([Id], [Nombre], [Genero], [Edad], [Identificacion], [Direccion], [Telefono], [Contrasenia], [Estado]) VALUES (7, N'Miguel Orquera', N'M', 45, N'1717170110', N'Ambato', N'7456328', N'125896', 1)
INSERT [dbo].[Clientes] ([Id], [Nombre], [Genero], [Edad], [Identificacion], [Direccion], [Telefono], [Contrasenia], [Estado]) VALUES (12, N'Ana Proaño', N'F', 36, N'1452369873', N'Quevedo', N'7456328', N'125896', 1)
SET IDENTITY_INSERT [dbo].[Clientes] OFF
GO
SET IDENTITY_INSERT [dbo].[Cuentas] ON 

INSERT [dbo].[Cuentas] ([Id], [Numero], [Tipo], [SaldoInicial], [Estado], [ClienteId]) VALUES (1, N'3383692400', N'Ahorros', CAST(1450.00 AS Decimal(18, 2)), 1, 2)
INSERT [dbo].[Cuentas] ([Id], [Numero], [Tipo], [SaldoInicial], [Estado], [ClienteId]) VALUES (2, N'3383692400', N'Ahorros', CAST(1450.00 AS Decimal(18, 2)), 1, 1)
INSERT [dbo].[Cuentas] ([Id], [Numero], [Tipo], [SaldoInicial], [Estado], [ClienteId]) VALUES (3, N'1278349652', N'Corriente', CAST(150.00 AS Decimal(18, 2)), 0, 2)
INSERT [dbo].[Cuentas] ([Id], [Numero], [Tipo], [SaldoInicial], [Estado], [ClienteId]) VALUES (4, N'458963214', N'Ahorros', CAST(300.00 AS Decimal(18, 2)), 1, 4)
INSERT [dbo].[Cuentas] ([Id], [Numero], [Tipo], [SaldoInicial], [Estado], [ClienteId]) VALUES (5, N'336587412', N'Ahorros', CAST(300.00 AS Decimal(18, 2)), 1, 6)
SET IDENTITY_INSERT [dbo].[Cuentas] OFF
GO
SET IDENTITY_INSERT [dbo].[Movimientos] ON 

INSERT [dbo].[Movimientos] ([Id], [Fecha], [Tipo], [Valor], [Saldo], [CuentaId]) VALUES (1, CAST(N'2024-09-27T00:00:00.0000000' AS DateTime2), N'Ahorro', CAST(85.50 AS Decimal(18, 2)), CAST(1585.50 AS Decimal(18, 2)), 2)
INSERT [dbo].[Movimientos] ([Id], [Fecha], [Tipo], [Valor], [Saldo], [CuentaId]) VALUES (2, CAST(N'2024-09-28T00:00:00.0000000' AS DateTime2), N'Ahorros', CAST(15.00 AS Decimal(18, 2)), CAST(300.00 AS Decimal(18, 2)), 2)
INSERT [dbo].[Movimientos] ([Id], [Fecha], [Tipo], [Valor], [Saldo], [CuentaId]) VALUES (3, CAST(N'2024-09-28T00:00:00.0000000' AS DateTime2), N'Ahorros', CAST(18.00 AS Decimal(18, 2)), CAST(380.00 AS Decimal(18, 2)), 2)
INSERT [dbo].[Movimientos] ([Id], [Fecha], [Tipo], [Valor], [Saldo], [CuentaId]) VALUES (10, CAST(N'2024-09-28T00:00:00.0000000' AS DateTime2), N'Ahorros', CAST(100.00 AS Decimal(18, 2)), CAST(100.00 AS Decimal(18, 2)), 3)
INSERT [dbo].[Movimientos] ([Id], [Fecha], [Tipo], [Valor], [Saldo], [CuentaId]) VALUES (11, CAST(N'2024-09-28T00:00:00.0000000' AS DateTime2), N'Ahorros', CAST(100.00 AS Decimal(18, 2)), CAST(200.00 AS Decimal(18, 2)), 3)
INSERT [dbo].[Movimientos] ([Id], [Fecha], [Tipo], [Valor], [Saldo], [CuentaId]) VALUES (12, CAST(N'2024-09-28T00:00:00.0000000' AS DateTime2), N'Ahorros', CAST(50.00 AS Decimal(18, 2)), CAST(250.00 AS Decimal(18, 2)), 3)
INSERT [dbo].[Movimientos] ([Id], [Fecha], [Tipo], [Valor], [Saldo], [CuentaId]) VALUES (13, CAST(N'2024-09-28T00:00:00.0000000' AS DateTime2), N'Ahorros', CAST(-50.00 AS Decimal(18, 2)), CAST(200.00 AS Decimal(18, 2)), 3)
INSERT [dbo].[Movimientos] ([Id], [Fecha], [Tipo], [Valor], [Saldo], [CuentaId]) VALUES (14, CAST(N'2024-09-28T00:00:00.0000000' AS DateTime2), N'Ahorros', CAST(-50.00 AS Decimal(18, 2)), CAST(150.00 AS Decimal(18, 2)), 3)
INSERT [dbo].[Movimientos] ([Id], [Fecha], [Tipo], [Valor], [Saldo], [CuentaId]) VALUES (15, CAST(N'2024-09-28T00:00:00.0000000' AS DateTime2), N'Ahorros', CAST(-30.00 AS Decimal(18, 2)), CAST(120.00 AS Decimal(18, 2)), 3)
INSERT [dbo].[Movimientos] ([Id], [Fecha], [Tipo], [Valor], [Saldo], [CuentaId]) VALUES (16, CAST(N'2024-09-28T00:00:00.0000000' AS DateTime2), N'Ahorros', CAST(30.00 AS Decimal(18, 2)), CAST(150.00 AS Decimal(18, 2)), 3)
SET IDENTITY_INSERT [dbo].[Movimientos] OFF
GO
ALTER TABLE [dbo].[Cuentas]  WITH CHECK ADD  CONSTRAINT [FK_Cuentas_Clientes_ClienteId] FOREIGN KEY([ClienteId])
REFERENCES [dbo].[Clientes] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Cuentas] CHECK CONSTRAINT [FK_Cuentas_Clientes_ClienteId]
GO
ALTER TABLE [dbo].[Movimientos]  WITH CHECK ADD  CONSTRAINT [FK_Movimientos_Cuentas_CuentaId] FOREIGN KEY([CuentaId])
REFERENCES [dbo].[Cuentas] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Movimientos] CHECK CONSTRAINT [FK_Movimientos_Cuentas_CuentaId]
GO
