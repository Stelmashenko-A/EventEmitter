ALTER TABLE Events
ADD EventCreatorId UNIQUEIDENTIFIER

CONSTRAINT fk_EventUserAccount FOREIGN KEY (EventCreatorId)
	REFERENCES EventEmitter.dbo.[UserAccounts](UserAccountId)