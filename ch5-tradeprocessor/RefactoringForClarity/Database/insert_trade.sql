CREATE PROCEDURE [dbo].[insert_trade]
	@sourceCurrency CHAR(3),
	@destinationCurrency CHAR(3),
	@lots FLOAT,
	@price MONEY
AS
	
	INSERT INTO trade(sourceCurrency, destinationCurrency, lots, price)
	VALUES(@sourceCurrency, @destinationCurrency, @lots, @price)

RETURN 0
