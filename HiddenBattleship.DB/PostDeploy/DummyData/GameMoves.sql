BEGIN 
INSERT INTO tblGameMoves (Id, GameId, PlayerId, TargetCoordinates, TimeStamp ) 
VALUES 
    (NEWID(), NEWID(), NEWID(), 'A1', CAST('12:00:00' AS TIME)),
    (NEWID(), NEWID(), NEWID(), 'B2', CAST('12:00:00' AS TIME)),
    (NEWID(), NEWID(), NEWID(), 'C3', CAST('12:00:00' AS TIME)),
    (NEWID(), NEWID(), NEWID(), 'D4', CAST('12:00:00' AS TIME)),
    (NEWID(), NEWID(), NEWID(), 'E5', CAST('12:00:00' AS TIME));
END