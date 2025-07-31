
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/02/2025 20:33:11
-- Generated from EDMX file: C:\Users\lapcell\source\repos\ProjectEf\ProjectEf\Project.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Project];
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

-- Creating table 'categorizes1'
CREATE TABLE [dbo].[categorizes1] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [UnitM] nvarchar(max)  NOT NULL,
    [Amount] int  NOT NULL
);
GO

-- Creating table 'Imports1'
CREATE TABLE [dbo].[Imports1] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [StoreName] nvarchar(max)  NOT NULL,
    [Date] datetime  NOT NULL,
    [SuppliersId] int  NOT NULL
);
GO

-- Creating table 'Exports'
CREATE TABLE [dbo].[Exports] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [StoreName] nvarchar(max)  NOT NULL,
    [Date] datetime  NOT NULL,
    [ClientsId] int  NOT NULL
);
GO

-- Creating table 'ImportedCategories'
CREATE TABLE [dbo].[ImportedCategories] (
    [ImportId] int  NOT NULL,
    [categorizesId] int  NOT NULL,
    [Amount] nvarchar(max)  NOT NULL,
    [prodDate] datetime  NOT NULL,
    [ExpDate] datetime  NOT NULL
);
GO

-- Creating table 'ExportedCategories'
CREATE TABLE [dbo].[ExportedCategories] (
    [ExportId] int  NOT NULL,
    [categorizesId] int  NOT NULL,
    [Amount] int  NOT NULL
);
GO

-- Creating table 'Movments'
CREATE TABLE [dbo].[Movments] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FromStore] nvarchar(max)  NOT NULL,
    [ToStore] nvarchar(max)  NOT NULL,
    [Amount] int  NOT NULL
);
GO

-- Creating table 'MovedCategories'
CREATE TABLE [dbo].[MovedCategories] (
    [MovmentsId] int  NOT NULL,
    [categorizesId] int  NOT NULL
);
GO

-- Creating table 'StoredCategories'
CREATE TABLE [dbo].[StoredCategories] (
    [storesId] int  NOT NULL,
    [categorizesId] int  NOT NULL,
    [AmountInStore] nvarchar(max)  NOT NULL,
    [ProdDate] nvarchar(max)  NOT NULL,
    [ExpDate] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'stores'
CREATE TABLE [dbo].[stores] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Adress] nvarchar(max)  NOT NULL,
    [ManagerName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Suppliers1'
CREATE TABLE [dbo].[Suppliers1] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [PhoneNum] int  NOT NULL,
    [Fax] nvarchar(max)  NOT NULL,
    [Tele] int  NOT NULL,
    [Mail] nvarchar(max)  NOT NULL,
    [WebSite] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Clients'
CREATE TABLE [dbo].[Clients] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CName] nvarchar(max)  NOT NULL,
    [CPhone] int  NOT NULL,
    [Fax] nvarchar(max)  NOT NULL,
    [Tele] int  NOT NULL,
    [Mail] nvarchar(max)  NOT NULL,
    [Website] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'categorizes1'
ALTER TABLE [dbo].[categorizes1]
ADD CONSTRAINT [PK_categorizes1]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Imports1'
ALTER TABLE [dbo].[Imports1]
ADD CONSTRAINT [PK_Imports1]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Exports'
ALTER TABLE [dbo].[Exports]
ADD CONSTRAINT [PK_Exports]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [ImportId], [categorizesId] in table 'ImportedCategories'
ALTER TABLE [dbo].[ImportedCategories]
ADD CONSTRAINT [PK_ImportedCategories]
    PRIMARY KEY CLUSTERED ([ImportId], [categorizesId] ASC);
GO

-- Creating primary key on [ExportId], [categorizesId] in table 'ExportedCategories'
ALTER TABLE [dbo].[ExportedCategories]
ADD CONSTRAINT [PK_ExportedCategories]
    PRIMARY KEY CLUSTERED ([ExportId], [categorizesId] ASC);
GO

-- Creating primary key on [Id] in table 'Movments'
ALTER TABLE [dbo].[Movments]
ADD CONSTRAINT [PK_Movments]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [MovmentsId], [categorizesId] in table 'MovedCategories'
ALTER TABLE [dbo].[MovedCategories]
ADD CONSTRAINT [PK_MovedCategories]
    PRIMARY KEY CLUSTERED ([MovmentsId], [categorizesId] ASC);
GO

-- Creating primary key on [storesId], [categorizesId], [ProdDate] in table 'StoredCategories'
ALTER TABLE [dbo].[StoredCategories]
ADD CONSTRAINT [PK_StoredCategories]
    PRIMARY KEY CLUSTERED ([storesId], [categorizesId], [ProdDate] ASC);
GO

-- Creating primary key on [Id] in table 'stores'
ALTER TABLE [dbo].[stores]
ADD CONSTRAINT [PK_stores]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Suppliers1'
ALTER TABLE [dbo].[Suppliers1]
ADD CONSTRAINT [PK_Suppliers1]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Clients'
ALTER TABLE [dbo].[Clients]
ADD CONSTRAINT [PK_Clients]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [categorizesId] in table 'ExportedCategories'
ALTER TABLE [dbo].[ExportedCategories]
ADD CONSTRAINT [FK_categorizesExportedCategory]
    FOREIGN KEY ([categorizesId])
    REFERENCES [dbo].[categorizes1]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_categorizesExportedCategory'
CREATE INDEX [IX_FK_categorizesExportedCategory]
ON [dbo].[ExportedCategories]
    ([categorizesId]);
GO

-- Creating foreign key on [categorizesId] in table 'MovedCategories'
ALTER TABLE [dbo].[MovedCategories]
ADD CONSTRAINT [FK_categorizesMovedCategory]
    FOREIGN KEY ([categorizesId])
    REFERENCES [dbo].[categorizes1]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_categorizesMovedCategory'
CREATE INDEX [IX_FK_categorizesMovedCategory]
ON [dbo].[MovedCategories]
    ([categorizesId]);
GO

-- Creating foreign key on [categorizesId] in table 'StoredCategories'
ALTER TABLE [dbo].[StoredCategories]
ADD CONSTRAINT [FK_categorizesStoredCategory]
    FOREIGN KEY ([categorizesId])
    REFERENCES [dbo].[categorizes1]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_categorizesStoredCategory'
CREATE INDEX [IX_FK_categorizesStoredCategory]
ON [dbo].[StoredCategories]
    ([categorizesId]);
GO

-- Creating foreign key on [ExportId] in table 'ExportedCategories'
ALTER TABLE [dbo].[ExportedCategories]
ADD CONSTRAINT [FK_ExportExportedCategory]
    FOREIGN KEY ([ExportId])
    REFERENCES [dbo].[Exports]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [MovmentsId] in table 'MovedCategories'
ALTER TABLE [dbo].[MovedCategories]
ADD CONSTRAINT [FK_MovmentsMovedCategory]
    FOREIGN KEY ([MovmentsId])
    REFERENCES [dbo].[Movments]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [storesId] in table 'StoredCategories'
ALTER TABLE [dbo].[StoredCategories]
ADD CONSTRAINT [FK_storesStoredCategory]
    FOREIGN KEY ([storesId])
    REFERENCES [dbo].[stores]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [categorizesId] in table 'ImportedCategories'
ALTER TABLE [dbo].[ImportedCategories]
ADD CONSTRAINT [FK_categorizesImportedCategory]
    FOREIGN KEY ([categorizesId])
    REFERENCES [dbo].[categorizes1]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_categorizesImportedCategory'
CREATE INDEX [IX_FK_categorizesImportedCategory]
ON [dbo].[ImportedCategories]
    ([categorizesId]);
GO

-- Creating foreign key on [ImportId] in table 'ImportedCategories'
ALTER TABLE [dbo].[ImportedCategories]
ADD CONSTRAINT [FK_ImportImportedCategory]
    FOREIGN KEY ([ImportId])
    REFERENCES [dbo].[Imports1]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [SuppliersId] in table 'Imports1'
ALTER TABLE [dbo].[Imports1]
ADD CONSTRAINT [FK_SuppliersImport]
    FOREIGN KEY ([SuppliersId])
    REFERENCES [dbo].[Suppliers1]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SuppliersImport'
CREATE INDEX [IX_FK_SuppliersImport]
ON [dbo].[Imports1]
    ([SuppliersId]);
GO

-- Creating foreign key on [ClientsId] in table 'Exports'
ALTER TABLE [dbo].[Exports]
ADD CONSTRAINT [FK_ClientsExport]
    FOREIGN KEY ([ClientsId])
    REFERENCES [dbo].[Clients]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ClientsExport'
CREATE INDEX [IX_FK_ClientsExport]
ON [dbo].[Exports]
    ([ClientsId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------