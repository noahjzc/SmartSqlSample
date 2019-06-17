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



-- use on chapter three
GO

Create Table T_User (
	Id bigint not null primary key identity(1,1),
	LoginName nvarchar(50) not null,
	Password varchar(128) null,	
	Status int not null,
	CreateTime datetime not null default getdate(),
	ModifiedTime datetime not null default getdate()
)

GO

Create Table T_UserDetail (
	Id bigint not null primary key identity(1,1),
	UserId bigint not null,	 
	Nickname nvarchar(50) not null,
	Avatar varchar(255) null,	
	Sex bit null,
	Status int not null,
	CreateTime datetime not null default getdate(),
	ModifiedTime datetime not null default getdate()
)
