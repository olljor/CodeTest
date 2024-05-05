CREATE TABLE [dbo].[Article]
(
	[ArticleId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Description] VARCHAR(50) NOT NULL, 
    [Price] DECIMAL(8, 2) NOT NULL
)
