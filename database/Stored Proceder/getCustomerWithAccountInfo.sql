USE [Bankdb]
GO

/****** Object:  StoredProcedure [dbo].[getCustomerWithAccountInfo]    Script Date: 5/25/2025 09:55:54 م ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[getCustomerWithAccountInfo]
@AccountNumber varchar(10)
AS
BEGIN
    SET NOCOUNT ON;  
    SELECT
        C.CustomerID,
        C.FullName,
        C.Phone,
		C.Photo,
		C.IDCard,
        A.AccountNumber,
        A.AccountType,
        A.Balance,
        A.OpenedDate
    FROM Customers AS C
    INNER JOIN Accounts AS A
        ON C.CustomerID = A.CustomerID
		where A.AccountNumber=@AccountNumber;

END;

GO

