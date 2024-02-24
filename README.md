Step After Cloning The Project and Opening It In Visual Studio 2022
Step 1:- 
    go to -> Tool
          -> NuGet Package Manager 
          -> Manage Nuget Package For Solution
          -> Browse -> Install the Library
          -> Microsoft.Data.SqlClient (5.1.2)
 
Step 2 :-
   go to -> view  
         -> SQL Server Object Explorer -> SQL Server
         -> (localdb)\MSSQLLocalDB -> DataBases
         ->  Create Database with Name "EmployeeDB"
         ->  EmployeeDB -> Create Table 
         -> Paste This Query to Create Table
         CREATE TABLE [dbo].[Tbl_Student] (
             [StudentNo] INT          IDENTITY (1, 1) NOT NULL,
             [Name]      VARCHAR (50) NOT NULL,
             [Branch]    VARCHAR (20) NOT NULL,
             [Section]   INT          NOT NULL,
             [EmailId]   VARCHAR (50) NOT NULL,
             PRIMARY KEY CLUSTERED ([StudentNo] ASC)
         );


         
