USE [Bankdb]
GO

/****** Object:  StoredProcedure [dbo].[DeleteAccount]    Script Date: 5/25/2025 09:54:16 م ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[DeleteAccount]
    @AccountNumber VARCHAR(10)
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        BEGIN TRANSACTION;

        
        IF NOT EXISTS (SELECT 1 FROM Accounts WHERE AccountNumber = @AccountNumber)
        BEGIN
            THROW 50010, N'الحساب غير موجود.', 1;
        END

        -- حذف الحساب
        DELETE FROM Accounts WHERE AccountNumber = @AccountNumber;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF XACT_STATE() <> 0
            ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;

IF OBJECT_ID('GetAccountInfo', 'P') IS NOT NULL
    DROP PROCEDURE GetAccountInfo;

GO

