--DROP DATABASE MVCDemo1
CREATE DATABASE MVCDemo1
------------------------------------------------------------------------
USE MVCDemo1
CREATE TABLE tblEmployee
(
Id int IDENTITY(1,1) PRIMARY KEY,
Name VARCHAR(MAX) NOT NULL,
Gender VARCHAR(10) NOT NULL,
City VARCHAR(25) NOT NULL,
DateOfBirth DateTime NOT NULL
)
-------------------------------------------------------------------------
INSERT INTO tblEmployee(Name,Gender,City,DateOfBirth) 
VALUES('Arun','Male','Bangaloe','1999-09-29')
------------------------------------------------------------------------
CREATE PROCEDURE [dbo].[spGetAllEmployees] 
	-- Add the parameters for the stored procedure here
	AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT Id,Name,Gender,City,DateOfBirth from dbo.tblEmployee
END
---------------------------------------------------------------------------------
EXEC spGetAllEmployees
--------------------------------------------------------------------------------
Create procedure spAddEmployee    
@Name nvarchar(50),    
@Gender nvarchar(10),     
@City nvarchar (50),     
@DateOfBirth DateTime  
as    
Begin    
 Insert into tblEmployee (Name, Gender, City, DateOfBirth)    
 Values (@Name, @Gender, @City, @DateOfBirth)    
End
--------------------------------------------------------------------------------


