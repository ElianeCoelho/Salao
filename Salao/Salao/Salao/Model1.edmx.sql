--CREATE DATABASE [salao]
--GO
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/28/2017 09:40:41
-- Generated from EDMX file: C:\Users\josle\Documents\ADS 4 Etapa\Computação em Nuvem\Salao\Salao\Salao\Salao\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [salao];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK__agenda__IdFuncio__2B3F6F97]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[agenda] DROP CONSTRAINT [FK__agenda__IdFuncio__2B3F6F97];
GO
IF OBJECT_ID(N'[dbo].[FK__funcionar__IdCar__276EDEB3]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[funcionario] DROP CONSTRAINT [FK__funcionar__IdCar__276EDEB3];
GO
IF OBJECT_ID(N'[dbo].[FK__funcionar__IdCli__286302EC]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[funcionario] DROP CONSTRAINT [FK__funcionar__IdCli__286302EC];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[agenda]', 'U') IS NOT NULL
    DROP TABLE [dbo].[agenda];
GO
IF OBJECT_ID(N'[dbo].[cargo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[cargo];
GO
IF OBJECT_ID(N'[dbo].[cliente]', 'U') IS NOT NULL
    DROP TABLE [dbo].[cliente];
GO
IF OBJECT_ID(N'[dbo].[funcionario]', 'U') IS NOT NULL
    DROP TABLE [dbo].[funcionario];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'agenda'
CREATE TABLE [dbo].[agenda] (
    [IdAgenda] int IDENTITY(1,1) NOT NULL,
    [NomeCliente] varchar(50)  NULL,
    [DataAgenda] datetime  NULL,
    [IdFuncionario] int  NULL
);
GO

-- Creating table 'cargo'
CREATE TABLE [dbo].[cargo] (
    [IdCargo] int IDENTITY(1,1) NOT NULL,
    [nomeCargo] varchar(30)  NULL
);
GO

-- Creating table 'cliente'
CREATE TABLE [dbo].[cliente] (
    [IdCliente] int IDENTITY(1,1) NOT NULL,
    [Nome] varchar(50)  NULL,
    [Cpf] varchar(11)  NULL,
    [Telefone] varchar(14)  NULL,
    [NomeSalao] varchar(60)  NULL,
    [Cep] varchar(14)  NULL,
    [Rua] varchar(60)  NULL,
    [Numero] varchar(11)  NULL,
    [Complemento] varchar(20)  NULL,
    [Bairro] varchar(60)  NULL,
    [Cidade] varchar(60)  NULL,
    [Estado] varchar(10)  NULL,
    [Email] varchar(60)  NULL,
    [Senha] varchar(30)  NULL,
    [ConfirmaSenha] varchar(30)  NULL
);
GO

-- Creating table 'funcionario'
CREATE TABLE [dbo].[funcionario] (
    [IdFuncionario] int IDENTITY(1,1) NOT NULL,
    [Nome] varchar(50)  NULL,
    [IdCargo] int  NULL,
    [IdCliente] int  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [IdAgenda] in table 'agenda'
ALTER TABLE [dbo].[agenda]
ADD CONSTRAINT [PK_agenda]
    PRIMARY KEY CLUSTERED ([IdAgenda] ASC);
GO

-- Creating primary key on [IdCargo] in table 'cargo'
ALTER TABLE [dbo].[cargo]
ADD CONSTRAINT [PK_cargo]
    PRIMARY KEY CLUSTERED ([IdCargo] ASC);
GO

-- Creating primary key on [IdCliente] in table 'cliente'
ALTER TABLE [dbo].[cliente]
ADD CONSTRAINT [PK_cliente]
    PRIMARY KEY CLUSTERED ([IdCliente] ASC);
GO

-- Creating primary key on [IdFuncionario] in table 'funcionario'
ALTER TABLE [dbo].[funcionario]
ADD CONSTRAINT [PK_funcionario]
    PRIMARY KEY CLUSTERED ([IdFuncionario] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [IdFuncionario] in table 'agenda'
ALTER TABLE [dbo].[agenda]
ADD CONSTRAINT [FK__agenda__IdFuncio__2B3F6F97]
    FOREIGN KEY ([IdFuncionario])
    REFERENCES [dbo].[funcionario]
        ([IdFuncionario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__agenda__IdFuncio__2B3F6F97'
CREATE INDEX [IX_FK__agenda__IdFuncio__2B3F6F97]
ON [dbo].[agenda]
    ([IdFuncionario]);
GO

-- Creating foreign key on [IdCargo] in table 'funcionario'
ALTER TABLE [dbo].[funcionario]
ADD CONSTRAINT [FK__funcionar__IdCar__276EDEB3]
    FOREIGN KEY ([IdCargo])
    REFERENCES [dbo].[cargo]
        ([IdCargo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__funcionar__IdCar__276EDEB3'
CREATE INDEX [IX_FK__funcionar__IdCar__276EDEB3]
ON [dbo].[funcionario]
    ([IdCargo]);
GO

-- Creating foreign key on [IdCliente] in table 'funcionario'
ALTER TABLE [dbo].[funcionario]
ADD CONSTRAINT [FK__funcionar__IdCli__286302EC]
    FOREIGN KEY ([IdCliente])
    REFERENCES [dbo].[cliente]
        ([IdCliente])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__funcionar__IdCli__286302EC'
CREATE INDEX [IX_FK__funcionar__IdCli__286302EC]
ON [dbo].[funcionario]
    ([IdCliente]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------