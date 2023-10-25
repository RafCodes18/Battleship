BEGIN 
INSERT INTO tblPlayer (Id, UserName, Email, Password ) 
VALUES 
(NEWID(), 'user1', '123@gmail.com', '1234!' ),
(NEWID(), 'user2', '456@gmail.com', '123!' ),
(NEWID(), 'user3', '789@gmail.com', '12!' ),
(NEWID(), 'user4', '123@yahoo.com', '1!' ),
(NEWID(), 'user5', '456@yahoo.com', '1' )
END