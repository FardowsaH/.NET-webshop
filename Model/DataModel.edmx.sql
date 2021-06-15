
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/26/2021 21:06:31
-- Generated from EDMX file: C:\Users\Bart v. Eijkelenburg\source\repos\StoreApplication\Model\DataModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [StoreDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_StoreProduct]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProductSet] DROP CONSTRAINT [FK_StoreProduct];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[StoreSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[StoreSet];
GO
IF OBJECT_ID(N'[dbo].[ProductSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProductSet];
GO
IF OBJECT_ID(N'[dbo].[CustomerSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CustomerSet];
GO
IF OBJECT_ID(N'[dbo].[OrderSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OrderSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'StoreSet'
CREATE TABLE [dbo].[StoreSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ProductSet'
CREATE TABLE [dbo].[ProductSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Price] float  NOT NULL,
    [Number] int  NOT NULL,
    [StoreID] int  NOT NULL,
    [Store_Id] int  NOT NULL
);
GO

-- Creating table 'CustomerSet'
CREATE TABLE [dbo].[CustomerSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Username] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
    [Balance] float  NOT NULL
);
GO

-- Creating table 'OrderSet'
CREATE TABLE [dbo].[OrderSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Username] nvarchar(max)  NOT NULL,
    [Product] nvarchar(max)  NOT NULL,
    [OrderDate] datetime  NOT NULL,
    [Number] int  NOT NULL,
    [Price] float  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'StoreSet'
ALTER TABLE [dbo].[StoreSet]
ADD CONSTRAINT [PK_StoreSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ProductSet'
ALTER TABLE [dbo].[ProductSet]
ADD CONSTRAINT [PK_ProductSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CustomerSet'
ALTER TABLE [dbo].[CustomerSet]
ADD CONSTRAINT [PK_CustomerSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'OrderSet'
ALTER TABLE [dbo].[OrderSet]
ADD CONSTRAINT [PK_OrderSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Store_Id] in table 'ProductSet'
ALTER TABLE [dbo].[ProductSet]
ADD CONSTRAINT [FK_StoreProduct]
    FOREIGN KEY ([Store_Id])
    REFERENCES [dbo].[StoreSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_StoreProduct'
CREATE INDEX [IX_FK_StoreProduct]
ON [dbo].[ProductSet]
    ([Store_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------