USE [Bankdb]
GO

/****** Object:  StoredProcedure [dbo].[editeAccount]    Script Date: 5/25/2025 09:54:56 م ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[editeAccount]
@AccountNumber varchar(10),
@newAccountType varchar(50),
@newPhone varchar(20)
as
begin
set NOCOUNT on;
BEGIN TRY
BEGIN TRANSACTION;
UPDATE C 
SET C.Phone=@newPhone from Customers as C
inner join Accounts as A on C.CustomerID=A.CustomerID
where A.AccountNumber=@AccountNumber;
update Accounts
set AccountType=@newAccountType where AccountNumber=@AccountNumber;
commit TRANSACTION;
END TRY
BEGIN CATCH IF XACT_STATE()<>0 ROLLBACK TRANSACTION;
THROW;
END CATCH 
END;
GO

