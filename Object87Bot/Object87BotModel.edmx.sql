
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/05/2016 05:38:14
-- Generated from EDMX file: D:\Stilet\GitHub\Object87\Object87Bot\Object87Bot\Object87BotModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Object87BotDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'PlayerSet'
CREATE TABLE [dbo].[PlayerSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserID] bigint  NOT NULL,
    [Location] int  NOT NULL,
    [Position] int  NOT NULL,
    [Health] int  NOT NULL
);
GO

-- Creating table 'ItemsSet'
CREATE TABLE [dbo].[ItemsSet] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Players_Id] int  NOT NULL
);
GO

-- Creating table 'KeysSet'
CREATE TABLE [dbo].[KeysSet] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Items_Id] bigint  NOT NULL
);
GO

-- Creating table 'FlashlightSet'
CREATE TABLE [dbo].[FlashlightSet] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Items_Id] bigint  NOT NULL
);
GO

-- Creating table 'BlueKeySet'
CREATE TABLE [dbo].[BlueKeySet] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Keys_Id] bigint  NOT NULL
);
GO

-- Creating table 'GreenKeySet'
CREATE TABLE [dbo].[GreenKeySet] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Keys_Id] bigint  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'PlayerSet'
ALTER TABLE [dbo].[PlayerSet]
ADD CONSTRAINT [PK_PlayerSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ItemsSet'
ALTER TABLE [dbo].[ItemsSet]
ADD CONSTRAINT [PK_ItemsSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'KeysSet'
ALTER TABLE [dbo].[KeysSet]
ADD CONSTRAINT [PK_KeysSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'FlashlightSet'
ALTER TABLE [dbo].[FlashlightSet]
ADD CONSTRAINT [PK_FlashlightSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'BlueKeySet'
ALTER TABLE [dbo].[BlueKeySet]
ADD CONSTRAINT [PK_BlueKeySet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'GreenKeySet'
ALTER TABLE [dbo].[GreenKeySet]
ADD CONSTRAINT [PK_GreenKeySet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Players_Id] in table 'ItemsSet'
ALTER TABLE [dbo].[ItemsSet]
ADD CONSTRAINT [FK_PlayersItems]
    FOREIGN KEY ([Players_Id])
    REFERENCES [dbo].[PlayerSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PlayersItems'
CREATE INDEX [IX_FK_PlayersItems]
ON [dbo].[ItemsSet]
    ([Players_Id]);
GO

-- Creating foreign key on [Items_Id] in table 'KeysSet'
ALTER TABLE [dbo].[KeysSet]
ADD CONSTRAINT [FK_ItemsKeys]
    FOREIGN KEY ([Items_Id])
    REFERENCES [dbo].[ItemsSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ItemsKeys'
CREATE INDEX [IX_FK_ItemsKeys]
ON [dbo].[KeysSet]
    ([Items_Id]);
GO

-- Creating foreign key on [Keys_Id] in table 'BlueKeySet'
ALTER TABLE [dbo].[BlueKeySet]
ADD CONSTRAINT [FK_KeysBlueKey]
    FOREIGN KEY ([Keys_Id])
    REFERENCES [dbo].[KeysSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_KeysBlueKey'
CREATE INDEX [IX_FK_KeysBlueKey]
ON [dbo].[BlueKeySet]
    ([Keys_Id]);
GO

-- Creating foreign key on [Keys_Id] in table 'GreenKeySet'
ALTER TABLE [dbo].[GreenKeySet]
ADD CONSTRAINT [FK_KeysGreenKey]
    FOREIGN KEY ([Keys_Id])
    REFERENCES [dbo].[KeysSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_KeysGreenKey'
CREATE INDEX [IX_FK_KeysGreenKey]
ON [dbo].[GreenKeySet]
    ([Keys_Id]);
GO

-- Creating foreign key on [Items_Id] in table 'FlashlightSet'
ALTER TABLE [dbo].[FlashlightSet]
ADD CONSTRAINT [FK_ItemsFlashlight]
    FOREIGN KEY ([Items_Id])
    REFERENCES [dbo].[ItemsSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ItemsFlashlight'
CREATE INDEX [IX_FK_ItemsFlashlight]
ON [dbo].[FlashlightSet]
    ([Items_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------