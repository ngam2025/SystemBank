USE [Bankdb]
GO

/****** Object:  StoredProcedure [dbo].[stopsarchAccount]    Script Date: 5/25/2025 09:58:25 م ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[stopsarchAccount]
  @AccountNumber varchar(10)
  
AS
BEGIN

    SELECT
        C.FullName,
		C.Phone,
        A.AccountType,
		A.Balance,
		A.[Status]
    FROM Accounts A
    INNER JOIN Customers C ON A.CustomerID = C.CustomerID
    WHERE A.AccountNumber= @AccountNumber;

 
UPDATE  Accounts
set [Status]='stoped' where AccountNumber=@AccountNumber;

end;
GO

