CREATE TABLE [dbo].[tblRecipeIngredients]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [RecipeId] INT NOT NULL, 
    [IngredientId] INT NOT NULL,
    [SysStart] DATETIME2 (7) GENERATED ALWAYS AS ROW START NOT NULL,
	[SysEnd] DATETIME2 (7) GENERATED ALWAYS AS ROW END NOT NULL,
	PERIOD FOR SYSTEM_TIME ([SysStart], [SysEnd])
    ,CONSTRAINT [FK_tblRecipeIngredients_tblRecipe] FOREIGN KEY ([RecipeId]) REFERENCES [tblRecipe]([Id])    
    ,CONSTRAINT [FK_tblRecipeIngredients_tblIngredient] FOREIGN KEY ([IngredientId]) REFERENCES [tblIngredient]([Id])    
)
WITH (SYSTEM_VERSIONING = ON(HISTORY_TABLE=[dbo].[tblRecipeIngredients_HISTORY], DATA_CONSISTENCY_CHECK=ON))
