USE [Bankdb]
GO

/****** Object:  StoredProcedure [dbo].[getAllEmployeesBranch]    Script Date: 5/25/2025 09:55:34 م ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[getAllEmployeesBranch]
AS
BEGIN
    SET NOCOUNT ON;  -- يمنع إرجاع عدد الصفوف المتأثرة
    SELECT 
        E.EmployeeID,
        E.Username,
        E.FullName,
        E.HireDate,
		E.Salary,
        B.[Name]
    FROM Employees AS E
    INNER JOIN Branches AS B
        ON E.BrancheID = B.BranchID;
END;


GO

