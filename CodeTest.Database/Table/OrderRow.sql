CREATE TABLE [dbo].[OrderRow]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [OrderId] INT NOT NULL, 
    [ArticleId] INT NOT NULL, 
    [Amount] INT NOT NULL, 
    CONSTRAINT [FK_OrderRow_Order] FOREIGN KEY ([OrderId]) REFERENCES [Order]([OrderId]), 
    CONSTRAINT [FK_OrderRow_Article] FOREIGN KEY ([ArticleId]) REFERENCES [Article]([ArticleId])
)
