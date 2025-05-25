USE [Bankdb]
GO

/****** Object:  StoredProcedure [dbo].[serchAcount]    Script Date: 5/25/2025 09:58:06 م ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[serchAcount]
    @AccountNumber varchar(10)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        C.FullName,
		C.Phone,
        A.AccountType
    FROM Accounts A
    INNER JOIN Customers C ON A.CustomerID = C.CustomerID
    WHERE A.AccountNumber= @AccountNumber;
END;
GO

