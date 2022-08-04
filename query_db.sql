
---execute query to create DB Login 

CREATE DATABASE LOGIN

USE [Login]
GO

CREATE TABLE Users(
	[Id]  [INT] NOT NULL IDENTITY(1,1) primary key,
	[Email] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NULL,	 
) 
GO

