-- INIT database
CREATE TABLE ClientSectors (
  ClientSectorID INT PRIMARY KEY IDENTITY,
  Name VARCHAR(20) NOT NULL
);

CREATE TABLE TradeCategories (
  TradeCategoryID INT PRIMARY KEY IDENTITY,
  Name VARCHAR(20) NOT NULL
);

CREATE TABLE Trades (
  TradeID INT IDENTITY(1,1),
  MonetaryValue DECIMAL(19,4) NOT NULL,
  ClientSectorID INT NOT NULL FOREIGN KEY REFERENCES ClientSectors(ClientSectorID),
  TradeCategoryID INT FOREIGN KEY REFERENCES TradeCategories(TradeCategoryID),
);

INSERT INTO ClientSectors(Name) VALUES ('Public');
INSERT INTO ClientSectors(Name) VALUES ('Private');

INSERT INTO TradeCategories(Name) VALUES ('LOWRISK');
INSERT INTO TradeCategories(Name) VALUES ('MEDIUMRISK');
INSERT INTO TradeCategories(Name) VALUES ('HIGHRISK');
INSERT INTO TradeCategories(Name) VALUES ('UNKNOWNRISK');
