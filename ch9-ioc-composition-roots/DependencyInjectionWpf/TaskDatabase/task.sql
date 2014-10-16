CREATE TABLE [dbo].[task]
(
	[id] INT NOT NULL PRIMARY KEY, 
    [description] NVARCHAR(50) NOT NULL, 
    [priority] NCHAR(20) NULL, 
    [due_date] DATETIME NULL, 
    [completed] BIT NOT NULL
)
