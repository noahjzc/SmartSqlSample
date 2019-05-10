Create Database SmartSqlSample

GO

Use SmartSqlSample

GO

Create Table T_Article (
	Id bigint not null primary key identity(1,1),
	Title nvarchar(255) not null,
	Content nvarchar(max) null,
	Author nvarchar(255) null,
	Status int not null,
	CreateTime datetime not null default getdate(),
	ModifiedTime datetime not null default getdate()
)