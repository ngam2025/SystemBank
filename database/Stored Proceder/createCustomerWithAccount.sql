USE [Bankdb]
GO

/****** Object:  StoredProcedure [dbo].[createCustomerWithAccount]    Script Date: 5/25/2025 09:53:50 م ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[createCustomerWithAccount]
    @FullName       NVARCHAR(100),
    @IDCard          VARCHAR(20),
    @Phone           NVARCHAR(20),
	@IDCardImage     varbinary(max),
	@Photo            varbinary(max),
    @AccountType     NVARCHAR(50),
    @Balance  DECIMAL(10,2),
    @BranchID        INT
AS
BEGIN
    

    BEGIN TRY
        -- 1. بدء المعاملة لضمان التماسك
        BEGIN TRANSACTION;

        -- 2. إدراج السجل الجديد في جدول Customers
        INSERT INTO Customers
            (FullName, IDCard, Phone, IDCardImage, Photo)
        VALUES
            (@FullName, @IDCard, @Phone, @IDCardImage, @Photo);

        -- 3. التقاط معرف العميل المولَّد تلقائيًا
        DECLARE @NewCustomerID INT = SCOPE_IDENTITY();

        -- 4. إدراج الحساب المرتبط بالعميل الجديد
        INSERT INTO Accounts
            (CustomerID, AccountType, Balance, BranchID)
        VALUES
            (@NewCustomerID, @AccountType, @Balance, @BranchID);

        -- 5. التقاط معرف الحساب المولَّد تلقائيًا
        DECLARE @NewAccountID INT = SCOPE_IDENTITY();

        -- 6. الالتزام النهائي إذا نجحت كل العمليات
        COMMIT TRANSACTION;

        -- 7. إرجاع المعرفين للجهة المستدعية
        SELECT
            @NewCustomerID AS CustomerID,
            @NewAccountID  AS AccountID;
    END TRY
    BEGIN CATCH
        -- 8. في حال خطأ، التراجع عن المعاملة كاملة
        IF XACT_STATE() <> 0
            ROLLBACK TRANSACTION;

        -- 9. إعادة إطلاق الخطأ للمعالجة الخارجية
        THROW;
    END CATCH
END;
GO

