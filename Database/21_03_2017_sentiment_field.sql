ALTER TABLE Messages
ADD Sentiment INT NOT NULL DEFAULT(1)
GO

ALTER TABLE Messages
ADD CONSTRAINT chk_Sentiment CHECK (Sentiment IN (-1, 1))
