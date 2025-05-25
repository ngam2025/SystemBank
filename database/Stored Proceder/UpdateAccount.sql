USE [Bankdb]
GO

/****** Object:  StoredProcedure [dbo].[UpdateAccount]    Script Date: 5/25/2025 09:59:03 م ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[UpdateAccount]
    @AccountID   INT,
    @AccountType NVARCHAR(50) = NULL,
    @Balance     DECIMAL(10,2) = NULL,
    @BranchID    INT = NULL
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        BEGIN TRANSACTION;

        -- التحقق من وجود الحساب
        IF NOT EXISTS (SELECT 1 FROM Accounts WHERE AccountID = @AccountID)
        BEGIN
            THROW 50011, N'الحساب غير موجود.', 1;
        END

        -- تحديث البيانات
        UPDATE Accounts
        SET
            AccountType = ISNULL(@AccountType, AccountType),
            Balance     = ISNULL(@Balance, Balance),
            BranchID    = ISNULL(@BranchID, BranchID)
        WHERE AccountID = @AccountID;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF XACT_STATE() <> 0
            ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;

GO

