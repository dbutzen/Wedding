BEGIN
INSERT INTO dbo.tblFamily
	(Id, Name, Code)
VALUES
	(NEWID(), 'Dan Parents', 'AngryZebra'),
	(NEWID(), 'Dan Sister', 'GrowlingKoala'),
	(NEWID(), 'Dan Paternal Grandpa', 'HappyBadger'),
	(NEWID(), 'Dan Paternal Grandma', 'RadiantGoldfish'),
	(NEWID(), 'Dan Maternal Grandparents', 'WonderousSalmon'),
	(NEWID(), 'Dan Uncle Scott', 'TastyAnt'),
	(NEWID(), 'Dan Uncle Brian', 'HappyBear'),
	(NEWID(), 'Dan Aunt Jenny', 'UnhappyKing'),
	(NEWID(), 'Dan Uncle Dave', 'GratefulUndead'),
	(NEWID(), 'Dan Uncle Paul', 'BlackCat'),
	(NEWID(), 'Dan Aunt Karie', 'FastCar'),
	(NEWID(), 'Dan Uncle Al', 'RandomRelic'),
	(NEWID(), 'Dan Friend Ross', 'NarutoPikachu')
END