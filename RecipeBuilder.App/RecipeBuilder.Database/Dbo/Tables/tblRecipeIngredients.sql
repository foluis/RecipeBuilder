CREATE TABLE [dbo].[tblRecipeIngredients]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [RecipeId] INT NOT NULL, 
    [IngredientId] INT NOT NULL
    ,CONSTRAINT [FK_tblRecipeIngredients_tblRecipe] FOREIGN KEY ([RecipeId]) REFERENCES [tblRecipe]([Id])    
    ,CONSTRAINT [FK_tblRecipeIngredients_tblIngredient] FOREIGN KEY ([IngredientId]) REFERENCES [tblIngredient]([Id])    
)
