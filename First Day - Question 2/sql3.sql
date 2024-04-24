-- Insert Trades
INSERT INTO Trades(MonetaryValue, ClientSectorID) VALUES (999999, 1)
INSERT INTO Trades(MonetaryValue, ClientSectorID) VALUES (1000001, 1)
INSERT INTO Trades(MonetaryValue, ClientSectorID) VALUES (999999, 2)
INSERT INTO Trades(MonetaryValue, ClientSectorID) VALUES (1000001, 2)

-- Query trades 
SELECT t.MonetaryValue, cs.Name, tc.Name FROM Trades t
JOIN ClientSectors cs ON t.ClientSectorID = cs.ClientSectorID
JOIN TradeCategories tc ON t.TradeCategoryID = tc.TradeCategoryID;
