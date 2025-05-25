USE [Bankdb]
GO

/****** Object:  StoredProcedure [dbo].[getAllCostemersWithAcountsInfo]    Script Date: 5/25/2025 09:55:14 م ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[getAllCostemersWithAcountsInfo]
AS
BEGIN
    SET NOCOUNT ON;  
    SELECT
        C.CustomerID,
        C.FullName,
        C.Phone,
		C.IDCard,
        A.AccountNumber,
        A.AccountType,
        A.Balance,
        A.OpenedDate
    FROM Customers AS C
    INNER JOIN Accounts AS A
        ON C.CustomerID = A.CustomerID

END;
GO

