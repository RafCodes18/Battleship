BEGIN 
INSERT INTO tblChatHistory (Id, Sender, Receiver, GameId, Message, Timestamp ) 
VALUES 
 (NEWID(), NEWID(), NEWID(), NEWID(), 'Hello', CAST('12:00:00' AS TIME)),
    (NEWID(), NEWID(), NEWID(), NEWID(), 'Hi there', CAST('12:00:00' AS TIME)),
    (NEWID(), NEWID(), NEWID(), NEWID(), 'How are you?', CAST('12:00:00' AS TIME)),
    (NEWID(), NEWID(), NEWID(), NEWID(), 'Im good, thanks!', CAST('12:00:00' AS TIME)),
    ( NEWID(), NEWID(), NEWID(), NEWID(), 'Nice chatting with you.', CAST('12:00:00' AS TIME));
END