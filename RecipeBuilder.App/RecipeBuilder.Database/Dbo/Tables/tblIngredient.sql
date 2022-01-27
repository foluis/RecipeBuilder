CREATE TABLE [dbo].[tblIngredient]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] VARCHAR(50) NOT NULL, 
    [TypeId] INT NOT NULL
    ,CONSTRAINT [FK_tblIngredient_tblIngredientType] FOREIGN KEY ([TypeId]) REFERENCES [tblIngredientType]([Id])    
)
