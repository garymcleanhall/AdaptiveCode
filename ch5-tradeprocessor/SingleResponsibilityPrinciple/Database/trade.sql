CREATE TABLE [dbo].[trade]
(
	[id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[sourceCurrency] CHAR(3) NOT NULL,
	[destinationCurrency] CHAR(3) NOT NULL,
	[lots] FLOAT NOT NULL,
	[price] MONEY NOT NULL
)
