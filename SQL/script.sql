USE [Treading]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 1/22/2021 1:04:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[Email] [nvarchar](100) NULL,
	[Mobile] [nvarchar](12) NULL,
	[Username] [nvarchar](100) NULL,
	[Password] [nvarchar](100) NULL,
	[Status] [bigint] NULL,
	[CreatedOn] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [Name], [Email], [Mobile], [Username], [Password], [Status], [CreatedOn]) VALUES (2, N'Ravi', N'ravi@gmail.com', N'887930018', N'ravi', N'123', 1, CAST(N'2021-01-16T13:09:18.337' AS DateTime))
INSERT [dbo].[Users] ([Id], [Name], [Email], [Mobile], [Username], [Password], [Status], [CreatedOn]) VALUES (3, N'karan', N'support@equitec.in', N'88989999', N'ravi', N'123', 1, CAST(N'2021-01-20T10:52:23.577' AS DateTime))
INSERT [dbo].[Users] ([Id], [Name], [Email], [Mobile], [Username], [Password], [Status], [CreatedOn]) VALUES (4, N'karan', N'support@equitec.in', N'88989999', N'ravi', N'123', 1, CAST(N'2021-01-20T10:56:34.000' AS DateTime))
INSERT [dbo].[Users] ([Id], [Name], [Email], [Mobile], [Username], [Password], [Status], [CreatedOn]) VALUES (5, N'Kajal', N'kajal@gmail.com', N'8878457454', N'kajal', N'123', 1, CAST(N'2021-01-20T11:33:19.720' AS DateTime))
INSERT [dbo].[Users] ([Id], [Name], [Email], [Mobile], [Username], [Password], [Status], [CreatedOn]) VALUES (6, N'pawan', N'pawan@gmail.com', N'889787878', N'pawan', N'123', 1, CAST(N'2021-01-20T11:38:41.923' AS DateTime))
INSERT [dbo].[Users] ([Id], [Name], [Email], [Mobile], [Username], [Password], [Status], [CreatedOn]) VALUES (7, N'Rahul', N'rahul@gmail.com', N'887874554', N'rahul', N'123', 1, CAST(N'2021-01-20T16:58:32.860' AS DateTime))
INSERT [dbo].[Users] ([Id], [Name], [Email], [Mobile], [Username], [Password], [Status], [CreatedOn]) VALUES (1003, N'Divesh', N'divesh@gmail.com', N'8878878454', N'divesh', N'123', 1, CAST(N'2021-01-20T18:43:46.930' AS DateTime))
INSERT [dbo].[Users] ([Id], [Name], [Email], [Mobile], [Username], [Password], [Status], [CreatedOn]) VALUES (1004, N'Sanju', N'sanju@gmail.com', N'888784554', N'sanju', N'123', 1, CAST(N'2021-01-21T15:00:39.370' AS DateTime))
INSERT [dbo].[Users] ([Id], [Name], [Email], [Mobile], [Username], [Password], [Status], [CreatedOn]) VALUES (1005, N'kajal', N'kajal@gmail.com', N'887545475', N'kajal', N'123', 1, CAST(N'2021-01-21T15:02:25.700' AS DateTime))
INSERT [dbo].[Users] ([Id], [Name], [Email], [Mobile], [Username], [Password], [Status], [CreatedOn]) VALUES (2003, N'ram', N'ram@gmail.com', N'8879466012', N'ram', N'123', 1, CAST(N'2021-01-21T17:03:36.400' AS DateTime))
INSERT [dbo].[Users] ([Id], [Name], [Email], [Mobile], [Username], [Password], [Status], [CreatedOn]) VALUES (2004, N'Shankar', N'shan@gmail.com', N'8878787555', N'shan', N'123', 1, CAST(N'2021-01-21T17:10:05.833' AS DateTime))
INSERT [dbo].[Users] ([Id], [Name], [Email], [Mobile], [Username], [Password], [Status], [CreatedOn]) VALUES (2005, N'sanam', N'sanam@gmail.com', N'8879545121', N'sanam', N'123', 1, CAST(N'2021-01-21T17:22:13.490' AS DateTime))
INSERT [dbo].[Users] ([Id], [Name], [Email], [Mobile], [Username], [Password], [Status], [CreatedOn]) VALUES (2006, N'pawan', N'pawan@gmail.com', N'8878457454', N'pawan', N'123', 1, CAST(N'2021-01-21T17:23:58.857' AS DateTime))
INSERT [dbo].[Users] ([Id], [Name], [Email], [Mobile], [Username], [Password], [Status], [CreatedOn]) VALUES (2007, N'Mayur', N'mayur@gmail.com', N'8875454754', N'mayur', N'123', 1, CAST(N'2021-01-21T17:27:09.220' AS DateTime))
INSERT [dbo].[Users] ([Id], [Name], [Email], [Mobile], [Username], [Password], [Status], [CreatedOn]) VALUES (2008, N'pawan', N'pawanspallok@gmail.com', N'7208387127', N'jaaneman', N'jaaneman@1', 1, CAST(N'2021-01-21T20:52:59.540' AS DateTime))
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
/****** Object:  StoredProcedure [dbo].[sp_AuthenticateUser]    Script Date: 1/22/2021 1:04:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[sp_AuthenticateUser] 
(
@Username nvarchar(100),
@Password nvarchar(100)
)
as begin
   select * from Users where Username=@Username and Password=@Password and Status=1
end

GO
/****** Object:  StoredProcedure [dbo].[sp_SaveUsers]    Script Date: 1/22/2021 1:04:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create proc [dbo].[sp_SaveUsers]
(
@id int,
@name nvarchar(100),
@email nvarchar(50),
@mobile nvarchar(12),
@username nvarchar(100),
@password nvarchar(50),
@status bit
)
as
begin
   insert into Users(Name,Email,Mobile,Username,Password,Status,CreatedOn) values
   (@name,@email,@mobile, @username,@password,@status,GETDATE())
end




select * from Users
GO
