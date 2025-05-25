USE [Bankdb]
GO

/****** Object:  StoredProcedure [dbo].[InsertData]    Script Date: 5/25/2025 09:56:52 م ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[InsertData]
@name varchar(100),
@password varchar(50),
@role varchar(30),
@branchID int,
@salary decimal(12,2)
as
INSERT INTO Employees(FullName,[Password],[Role],BrancheID,Salary)
VALUES(@NAME,@password,@role,@branchID,@salary);
GO

