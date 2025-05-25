USE [Bankdb]
GO

/****** Object:  StoredProcedure [dbo].[SelectData]    Script Date: 5/25/2025 09:57:46 م ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


create proc [dbo].[SelectData] 
as
SELECT * FROM Employees;
EXEC SelectData;

GO

