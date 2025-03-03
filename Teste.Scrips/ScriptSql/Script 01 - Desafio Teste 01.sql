if not exists(select top 1 1 from sys.databases where name = 'dbTeste')
begin
	create database dbTeste;
end
GO

use dbTeste;
GO

if object_id('tbTabela1') is null
begin
	create table dbo.tbTabela1
	(
		Tabela1ID bigint identity(1,1) not null,
		UsuarioID bigint null,
		Data datetime null,
		QTD decimal(14,6) null,
		primary key (Tabela1ID)
	);
end
GO

if object_id('tbTabela2') is null
begin
	create table dbo.tbTabela2
	(
		Tabela2ID bigint identity(1,1) not null,
		Tabela1ID bigint not null,
		Agrupador1 bigint null,
		Agrupador2 bigint null,
		Agrupador3 bigint null,
		Agrupador4 bigint null,
		Agrupador5 bigint null,
		Agrupador6 bigint null,
		Agrupador7 bigint null,
		Agrupador8 bigint null,
		Agrupador9 bigint null,
		Agrupador10 bigint null,
		foreign key (Tabela1ID) references tbTabela1(Tabela1ID),
		primary key (Tabela2ID, Tabela1ID)
	);
end
GO

if object_id('tbTabela3') is null
begin
	create table dbo.tbTabela3
	(
		Tabela1ID bigint not null,
		Nome bigint null,
		Valor datetime null,
		foreign key (Tabela1ID) references tbTabela1(Tabela1ID)
	);
end
GO

declare @seedCount int = 100;
declare @Tabela1ID bigint = 0;

while (@seedCount > 0)
begin

	insert into dbo.tbTabela1 
		( UsuarioID, Data, QTD )
	values
		( floor(rand() * 100), dateadd(day, abs(checksum(newid())) % datediff(day, '2025-01-01', '2025-12-31'), '2025-01-01'), (rand() * (100 - 0)) ); 

	set @Tabela1ID = @@IDENTITY;

	insert into dbo.tbTabela2 
		( Tabela1ID, Agrupador1, Agrupador2, Agrupador3, Agrupador4, Agrupador5, Agrupador6, Agrupador7, Agrupador8, Agrupador9, Agrupador10 )
	values
		( @Tabela1ID, floor(rand() * 100), floor(rand() * 100), floor(rand() * 100), floor(rand() * 100), floor(rand() * 100), floor(rand() * 100), floor(rand() * 100), floor(rand() * 100), floor(rand() * 100), floor(rand() * 100) ); 

	insert into dbo.tbTabela3 
		( Tabela1ID, Nome, Valor )
	values
		( @Tabela1ID, floor(rand() * 100), dateadd(day, abs(checksum(newid())) % datediff(day, '2025-01-01', '2025-12-31'), '2025-01-01') ); 

	set @seedCount = @seedCount - 1;
end
