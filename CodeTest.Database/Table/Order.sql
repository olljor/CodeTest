CREATE TABLE [dbo].[Order]
(
	[OrderId] INT NOT NULL PRIMARY KEY, 
    [CustomerNumber] INT NOT NULL IDENTITY, 
    CONSTRAINT [FK_Order_Customer] FOREIGN KEY ([CustomerNumber]) REFERENCES [Customer]([CustomerNumber]) 
)
