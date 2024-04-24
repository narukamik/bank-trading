-- Create trigger
CREATE TRIGGER Trade_TradeCategory_Trigger
ON Trades AFTER INSERT
AS
BEGIN 
	DECLARE
    @TradeID INT,
    @VALUE DECIMAL(19,4),
    @ClientSectorID INT,
    @ResultTradeCategory VARCHAR(20)
    
    SELECT 
    @TradeID = i.TradeID,
    @VALUE = i.MonetaryValue,
    @ClientSectorID = i.ClientSectorID from INSERTED as i
    
    IF @ClientSectorID = 1
    	IF (@VALUE >= 1000000)
        	SELECT @ResultTradeCategory = 2 /*MEDIUMRISK*/
        ELSE 
        	SELECT @ResultTradeCategory = 1 /*LOWRISK*/  
    ELSE
    	IF @VALUE >= 1000000
        	SELECT @ResultTradeCategory = 3; /*HIGHRISK*/
       	ELSE 
        	SELECT @ResultTradeCategory = 4; /*UNKNOWRISK*/
         
    UPDATE Trades SET TradeCategoryID = @ResultTradeCategory WHERE TradeID = @TradeID
END
