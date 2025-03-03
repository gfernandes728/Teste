if not exists(select top 1 1 from sys.databases where name = 'dbTeste')
begin
	create database dbTeste;
end
GO

use dbTeste;
GO

if object_id('tbSelecoes') is null
begin
	create table dbo.tbSelecoes
	(
		SelecaoId bigint identity(1,1) not null,
		Nome varchar(50) null,
		primary key (SelecaoId)
	);
end
GO

if not exists(select top 1 1 from dbo.tbSelecoes with(nolock))
begin
	insert into dbo.tbSelecoes
		( Nome )
	values
		( 'Selecao 1' ),
		( 'Selecao 2' ),
		( 'Selecao 3' ),
		( 'Selecao 4' ),
		( 'Selecao 5' ),
		( 'Selecao 6' ),
		( 'Selecao 7' );
end
GO

if object_id('tbCampos') is null
begin
	create table dbo.tbCampos
	(
		CampoId bigint identity(1,1) not null,
		Nome varchar(50) null,
		primary key (CampoId)
	);
end
GO

if not exists(select top 1 1 from dbo.tbCampos with(nolock))
begin
	insert into dbo.tbCampos
		( Nome )
	values
		( 'Texto Simples' ),
		( 'Dropdown' ),
		( 'Html' );
end
GO

if object_id('tbFormularios') is null
begin
	create table dbo.tbFormularios
	(
		FormularioId bigint identity(1,1) not null,
		SelecaoId bigint null,
		CampoId bigint null,
		primary key (FormularioId)
	);
end
GO


if object_id('tbArquivos') is null
begin
	create table dbo.tbArquivos
	(
		ArquivoId bigint identity(1,1) not null,
		SelecaoId bigint null,
		Arquivo varbinary(max) null,
		primary key (ArquivoId)
	);
end
GO


