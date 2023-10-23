CREATE TABLE [dbo].[tblChatHistory]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [Sender] UNIQUEIDENTIFIER not NULL,
	[Receiver] uniqueidentifier not null,
	[GameId] uniqueidentifier not null,
	[Message] varchar(100) not null,
	[Timestamp] time not null

)
