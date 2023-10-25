BEGIN 
INSERT INTO tblGameMoves (Id, GameId, PlayerId, TargetCoordinates, TimeStamp, GameMoveId ) 
VALUES 
    (NEWID(), NEWID(), NEWID(), 'A1', CAST('12:00:00' AS TIME), 1),
    (NEWID(), NEWID(), NEWID(), 'B2', CAST('12:00:00' AS TIME), 2),
    (NEWID(), NEWID(), NEWID(), 'C3', CAST('12:00:00' AS TIME), 3),
    (NEWID(), NEWID(), NEWID(), 'D4', CAST('12:00:00' AS TIME), 4),
    (NEWID(), NEWID(), NEWID(), 'E5', CAST('12:00:00' AS TIME), 5);
END