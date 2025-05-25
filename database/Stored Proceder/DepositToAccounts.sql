USE [Bankdb]
GO

/****** Object:  StoredProcedure [dbo].[DepositToAccounts]    Script Date: 5/25/2025 09:54:35 م ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DepositToAccounts]
    @AccountNumber VARCHAR(50),  
    @Amount DECIMAL(10,2),  
    @AccountID INT  
AS  
BEGIN  
    IF NOT EXISTS (  
        SELECT 1  
        FROM Accounts  
        WHERE AccountNumber = @AccountNumber  
    )  
    BEGIN  
        RETURN 0;  
    END  

    UPDATE Accounts  
    SET Balance = Balance + @Amount  
    WHERE AccountNumber = @AccountNumber;  

    INSERT INTO Transactions  
    (AccountID, EmployeeID, TransactionType, Amount, [Description])  
    VALUES  
    (@AccountID, NULL, N'إيداع', @Amount, N'إيداع نقدي');  

    RETURN 1;  
END
GO

