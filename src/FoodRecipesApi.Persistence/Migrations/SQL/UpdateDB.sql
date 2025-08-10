IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
CREATE TABLE [Authors] (
    [AuthorId] int NOT NULL IDENTITY,
    [Name] nvarchar(20) NOT NULL,
    [Surname] nvarchar(20) NOT NULL,
    [ImageUrl] nvarchar(100) NOT NULL,
    [Born] datetime2 NOT NULL,
    CONSTRAINT [PK_Authors] PRIMARY KEY ([AuthorId])
);

CREATE TABLE [Recipes] (
    [RecipeId] int NOT NULL IDENTITY,
    [Title] nvarchar(30) NOT NULL,
    [Description] nvarchar(500) NOT NULL,
    [AuthorId] int NOT NULL,
    [ImageUrl] nvarchar(100) NOT NULL,
    [PreparationTime] time NOT NULL,
    [TotalTime] time NOT NULL,
    CONSTRAINT [PK_Recipes] PRIMARY KEY ([RecipeId]),
    CONSTRAINT [FK_Recipes_Authors_AuthorId] FOREIGN KEY ([AuthorId]) REFERENCES [Authors] ([AuthorId]) ON DELETE CASCADE
);

CREATE TABLE [Ingredient] (
    [IngredientId] int NOT NULL IDENTITY,
    [Name] nvarchar(50) NOT NULL,
    [QuantityId] int NOT NULL,
    [RecipeId] int NULL,
    CONSTRAINT [PK_Ingredient] PRIMARY KEY ([IngredientId]),
    CONSTRAINT [FK_Ingredient_Recipes_RecipeId] FOREIGN KEY ([RecipeId]) REFERENCES [Recipes] ([RecipeId])
);

CREATE TABLE [RecipeStep] (
    [RecipeStepId] int NOT NULL IDENTITY,
    [RecipeId] int NOT NULL,
    [Instruction] nvarchar(500) NOT NULL,
    [ImageUrl] nvarchar(100) NOT NULL,
    CONSTRAINT [PK_RecipeStep] PRIMARY KEY ([RecipeStepId]),
    CONSTRAINT [FK_RecipeStep_Recipes_RecipeId] FOREIGN KEY ([RecipeId]) REFERENCES [Recipes] ([RecipeId]) ON DELETE CASCADE
);

CREATE TABLE [IngredientQuantity] (
    [IngredientQuantityId] int NOT NULL IDENTITY,
    [Amount] real NOT NULL,
    [MeasurementUnit] nvarchar(20) NOT NULL,
    [IngredientId] int NOT NULL,
    CONSTRAINT [PK_IngredientQuantity] PRIMARY KEY ([IngredientQuantityId]),
    CONSTRAINT [FK_IngredientQuantity_Ingredient_IngredientId] FOREIGN KEY ([IngredientId]) REFERENCES [Ingredient] ([IngredientId]) ON DELETE CASCADE
);

CREATE TABLE [RecipeIngredient] (
    [RecipeId] int NOT NULL,
    [IngredientId] int NOT NULL,
    CONSTRAINT [PK_RecipeIngredient] PRIMARY KEY ([RecipeId], [IngredientId]),
    CONSTRAINT [FK_RecipeIngredient_Ingredient_IngredientId] FOREIGN KEY ([IngredientId]) REFERENCES [Ingredient] ([IngredientId]) ON DELETE CASCADE,
    CONSTRAINT [FK_RecipeIngredient_Recipes_RecipeId] FOREIGN KEY ([RecipeId]) REFERENCES [Recipes] ([RecipeId]) ON DELETE CASCADE
);

CREATE INDEX [IX_Ingredient_RecipeId] ON [Ingredient] ([RecipeId]);

CREATE UNIQUE INDEX [IX_IngredientQuantity_IngredientId] ON [IngredientQuantity] ([IngredientId]);

CREATE INDEX [IX_RecipeIngredient_IngredientId] ON [RecipeIngredient] ([IngredientId]);

CREATE INDEX [IX_Recipes_AuthorId] ON [Recipes] ([AuthorId]);

CREATE INDEX [IX_RecipeStep_RecipeId] ON [RecipeStep] ([RecipeId]);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250810103549_InitialCreate', N'9.0.0');

COMMIT;
GO

