USE [master]
GO
/****** Object:  Database [MovieTickets]    Script Date: 06/02/2017 14:33:45 ******/
CREATE DATABASE [MovieTickets] ON  PRIMARY 
( NAME = N'MovieTickets', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\MovieTickets.mdf' , SIZE = 2304KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'MovieTickets_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\MovieTickets_log.LDF' , SIZE = 832KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [MovieTickets] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MovieTickets].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MovieTickets] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [MovieTickets] SET ANSI_NULLS OFF
GO
ALTER DATABASE [MovieTickets] SET ANSI_PADDING OFF
GO
ALTER DATABASE [MovieTickets] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [MovieTickets] SET ARITHABORT OFF
GO
ALTER DATABASE [MovieTickets] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [MovieTickets] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [MovieTickets] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [MovieTickets] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [MovieTickets] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [MovieTickets] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [MovieTickets] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [MovieTickets] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [MovieTickets] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [MovieTickets] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [MovieTickets] SET  ENABLE_BROKER
GO
ALTER DATABASE [MovieTickets] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [MovieTickets] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [MovieTickets] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [MovieTickets] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [MovieTickets] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [MovieTickets] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [MovieTickets] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [MovieTickets] SET  READ_WRITE
GO
ALTER DATABASE [MovieTickets] SET RECOVERY FULL
GO
ALTER DATABASE [MovieTickets] SET  MULTI_USER
GO
ALTER DATABASE [MovieTickets] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [MovieTickets] SET DB_CHAINING OFF
GO
EXEC sys.sp_db_vardecimal_storage_format N'MovieTickets', N'ON'
GO
USE [MovieTickets]
GO
/****** Object:  StoredProcedure [dbo].[bookproc]    Script Date: 06/02/2017 14:33:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[bookproc]( @sid varchar(10),@sno nvarchar(max))
      as
      begin
      declare @sql nvarchar(max)
     set @sql='update Seats set ['+@sno+']=(select BookId.Bid from BookId )'+' where ShowId='+@sid
     exec sp_executesql @sql
     end
GO
/****** Object:  StoredProcedure [dbo].[colorproc1]    Script Date: 06/02/2017 14:33:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[colorproc1](@sno varchar(16), @sid varchar(10))
      as
      begin
   -- if exists(select ShowId from Seats where ShowId=@sid)
   -- begin
    declare @SQ nvarchar(max)
      set @SQ='select COUNT(*)from Seats where '+CAST(@sno AS varchar(16))+' is not null and ShowId ='+cast(@sid as varchar(16))
     exec sp_executesql @SQ 
     --end
   --  else
   --  begin
    -- declare @SQL nvarchar(max)
    --  set @SQL='select COUNT(*) from Seats where '+CAST(@sno AS varchar(16))+' is not null'
   --  exec sp_executesql @SQL 
   --  end
      end
GO
/****** Object:  Table [dbo].[Users]    Script Date: 06/02/2017 14:33:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Users](
	[Name] [varchar](20) NULL,
	[UserId] [varchar](50) NOT NULL,
	[Passwords] [varchar](20) NULL,
	[Answer] [varchar](100) NULL,
	[Mobile] [varchar](15) NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Shows]    Script Date: 06/02/2017 14:33:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Shows](
	[ShowId] [varchar](10) NOT NULL,
	[MovieName] [varchar](50) NOT NULL,
	[ShowDate] [date] NOT NULL,
	[StartTime] [time](7) NOT NULL,
	[EndTime] [time](7) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ShowId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[BookId]    Script Date: 06/02/2017 14:33:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookId](
	[Bid] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Price]    Script Date: 06/02/2017 14:33:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Price](
	[Type_of_seat] [varchar](10) NOT NULL,
	[Price] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Type_of_seat] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[loginproc]    Script Date: 06/02/2017 14:33:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure  [dbo].[loginproc](@user nvarchar(50), @pawd nvarchar(20))
      as
      begin
      if(select Count(*) from Users where UserId=@user and Passwords=@pawd and  UserId!='admin@admin.com' and Passwords!='admin123')=1
      select Count(*) from Users where UserId=@user and Passwords=@pawd
      else if(select COUNT(*) from Users where UserId='admin@admin.com' and Passwords='admin123' and UserId=@user and Passwords=@pawd)=1
      select (COUNT(*)+1) from Users where UserId='admin@admin.com' and Passwords='admin123'
      else
      print 'Error'  
      end
GO
/****** Object:  StoredProcedure [dbo].[insertproc]    Script Date: 06/02/2017 14:33:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure  [dbo].[insertproc](@name nvarchar(20), @mob varchar(15), @user nvarchar(50), @pawd nvarchar(20), @ans nvarchar(100))
      as
      begin
      insert into Users(Name,UserId,Mobile,Passwords,Answer) values(@name,@user, @mob, @pawd, @ans)
      end
GO
/****** Object:  StoredProcedure [dbo].[forgotproc]    Script Date: 06/02/2017 14:33:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure  [dbo].[forgotproc](@user nvarchar(50), @ans nvarchar(100))
      as
      if(select Count(*) from Users where UserId=@user and Answer=@ans)=1
      select Count(Answer) from Users where UserId=@user
      else
      print 'Error'
GO
/****** Object:  StoredProcedure [dbo].[existsproc]    Script Date: 06/02/2017 14:33:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure  [dbo].[existsproc](@sid varchar(5))
      as
      begin
      if exists(select ShowId from Shows where ShowId=@sid)
      select COUNT(@sid) from Shows where ShowId=@sid
      else
      select COUNT(@sid)+2 from Shows where ShowId=@sid
      end
GO
/****** Object:  StoredProcedure [dbo].[editproc]    Script Date: 06/02/2017 14:33:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure  [dbo].[editproc](@name nvarchar(20), @mob varchar(15), @user nvarchar(50), @pawd nvarchar(20), @ans nvarchar(100))
      as
      begin
     UPDATE Users
     SET Name= @name, Mobile=@mob, Passwords=@pawd, Answer=@ans
     WHERE UserId=@user and Passwords=@pawd
     end
GO
/****** Object:  StoredProcedure [dbo].[edit]    Script Date: 06/02/2017 14:33:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure  [dbo].[edit]( @user nvarchar(50))
      as
      begin
    select * from Users
     WHERE UserId=@user
     end
GO
/****** Object:  StoredProcedure [dbo].[currentproc]    Script Date: 06/02/2017 14:33:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[currentproc]
       as    
        select * from Shows where Showdate >=convert(date, getdate())
GO
/****** Object:  Table [dbo].[Booking]    Script Date: 06/02/2017 14:33:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Booking](
	[BookingId] [int] NOT NULL,
	[UserId] [varchar](50) NULL,
	[ShowId] [varchar](5) NULL,
	[Seatno] [varchar](16) NULL,
PRIMARY KEY CLUSTERED 
(
	[BookingId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[adminproc]    Script Date: 06/02/2017 14:33:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[adminproc](@name nvarchar(50), @dt datetime)
as
begin
if not exists(select MovieName, Timing from Shows where MovieName=@name and Timing=@dt)
begin
insert into Shows values(@name, @dt)
end
else
begin
print 'Data already exists'
end
end
GO
/****** Object:  StoredProcedure [dbo].[showproc]    Script Date: 06/02/2017 14:33:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[showproc]
as
 select * from Shows
GO
/****** Object:  StoredProcedure [dbo].[show]    Script Date: 06/02/2017 14:33:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[show](@sid int)
as
 select * from Shows where ShowId=@sid
GO
/****** Object:  Table [dbo].[Seats]    Script Date: 06/02/2017 14:33:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Seats](
	[ShowId] [varchar](10) NULL,
	[s1] [int] NULL,
	[s2] [int] NULL,
	[s3] [int] NULL,
	[s4] [int] NULL,
	[s5] [int] NULL,
	[s6] [int] NULL,
	[s7] [int] NULL,
	[s8] [int] NULL,
	[s9] [int] NULL,
	[s10] [int] NULL,
	[s11] [int] NULL,
	[s12] [int] NULL,
	[s13] [int] NULL,
	[s14] [int] NULL,
	[s15] [int] NULL,
	[s16] [int] NULL,
	[s17] [int] NULL,
	[s18] [int] NULL,
	[s19] [int] NULL,
	[s20] [int] NULL,
	[s21] [int] NULL,
	[s22] [int] NULL,
	[s23] [int] NULL,
	[s24] [int] NULL,
	[s25] [int] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[priceproc]    Script Date: 06/02/2017 14:33:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure  [dbo].[priceproc](@type varchar(10), @price int)
      as
      begin
     if exists(select Type_of_seat,Price from Price where Type_of_seat=@type)
     UPDATE Price
SET Type_of_seat= @type, Price=@price
WHERE Type_of_seat=@type

else

      insert into Price values(@type, @price)
      end
GO
/****** Object:  StoredProcedure [dbo].[updateproc]    Script Date: 06/02/2017 14:33:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure  [dbo].[updateproc](@sid varchar(5),@mname varchar(50), @sdate date, @stime time, @etime time)
      as
      begin
      if exists(select COUNT(*) from Shows where ShowId=@sid)
      begin
     update Shows set ShowId=@sid,MovieName=@mname,ShowDate= @sdate,StartTime= @stime,EndTime= @etime where ShowId=@sid
     end
     else
     print 'ShowId doesnot exists'
      end
GO
/****** Object:  StoredProcedure [dbo].[sp_use]    Script Date: 06/02/2017 14:33:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure  [dbo].[sp_use](@name nvarchar(20), @mob int, @user nvarchar(50), @pawd nvarchar(20))
      as
      insert into Users values (@name, @mob, @user , @pawd)
GO
/****** Object:  StoredProcedure [dbo].[cancelproc]    Script Date: 06/02/2017 14:33:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure  [dbo].[cancelproc](@bkid int, @user varchar(50))
      as
      begin
      if exists(select BookingId from Booking where BookingId=@bkid and UserId=@user)
      begin
     delete from Booking where BookingId=@bkid
      DECLARE @cnt int = 1
      WHILE @cnt < 25
BEGIN
       DECLARE @Prefix VARCHAR(10)='s'
      declare @sql nvarchar(max)
     set @sql=' update Seats set '+ @Prefix + CAST(@cnt AS VARCHAR(10)) +' = NULL  where ShowId = (Select Booking.ShowId from Booking where BookingId='+Cast(@bkid AS VARCHAR(10))+') and '+ @Prefix + Cast(@cnt AS VARCHAR(10)) +'='+Cast(@bkid AS VARCHAR(10))
    exec sp_executesql @sql
   SET @cnt = CAST(@cnt AS int)+1
END
end
end
GO
/****** Object:  StoredProcedure [dbo].[bookingtbl]    Script Date: 06/02/2017 14:33:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[bookingtbl](@user varchar(50), @sid varchar(10), @sno varchar(16))
as
begin
insert into Booking(BookingId) select Bid from BookId
UPDATE Booking
SET ShowId=@sid,UserId=@user,Seatno=@sno where BookingId =(select BookId.Bid from BookId)
select Bid from BookId
update BookId set Bid=Bid+1
end
GO
/****** Object:  StoredProcedure [dbo].[bookingproc]    Script Date: 06/02/2017 14:33:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[bookingproc](@sid nvarchar(10), @user nvarchar(50), @sc int)
      as
      begin
     select @sc= COUNT(@user)from Seats
     insert into Booking values(@user,@sc,@sid)
      end
GO
/****** Object:  StoredProcedure [dbo].[showticketproc]    Script Date: 06/02/2017 14:33:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[showticketproc](@user varchar(50), @bkid int)
       as    
        select * from Booking where UserId=@user and BookingId=@bkid
GO
/****** Object:  StoredProcedure [dbo].[showsproc]    Script Date: 06/02/2017 14:33:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[showsproc](@user varchar(50))
       as    
        select Seatno from Booking where UserId=@user
GO
/****** Object:  StoredProcedure [dbo].[bookdisp]    Script Date: 06/02/2017 14:33:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[bookdisp](@user varchar(50), @bkid varchar(20))
as
 select * from Booking where BookingId=@bkid
GO
/****** Object:  StoredProcedure [dbo].[addproc]    Script Date: 06/02/2017 14:33:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure  [dbo].[addproc](@sid varchar(10),@mname varchar(50), @sdate date, @stime time, @etime time)
      as
      begin
      insert into Shows values(@sid,@mname,CONVERT(varchar(15),CAST(@sdate AS date),100), CONVERT(varchar(15),CAST(@stime AS TIME),100), CONVERT(varchar(15),CAST(@etime AS TIME),100))
      insert into Seats(ShowId,s25) values (@sid,1)
      end
GO
/****** Object:  ForeignKey [fk_UserId]    Script Date: 06/02/2017 14:33:50 ******/
ALTER TABLE [dbo].[Booking]  WITH CHECK ADD  CONSTRAINT [fk_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Booking] CHECK CONSTRAINT [fk_UserId]
GO
/****** Object:  ForeignKey [FK__Seats__ShowId__0D7A0286]    Script Date: 06/02/2017 14:33:50 ******/
ALTER TABLE [dbo].[Seats]  WITH CHECK ADD FOREIGN KEY([ShowId])
REFERENCES [dbo].[Shows] ([ShowId])
GO
