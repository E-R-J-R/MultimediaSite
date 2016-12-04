CREATE TABLE NEWS
(
	NEWSID int NOT NULL identity primary key,
	HEADLINE nvarchar(500) NOT NULL,
	CONTENT nvarchar(MAX),
	CONTENTTYPE nvarchar(10),
	EMBEDCODE nvarchar(1000),
	NEWSDATE date,
	PUBLISHEDDATE date,
	SOURCENAME nvarchar(100),
	SOURCEURL nvarchar(200),
	IMAGEFILENAME nvarchar(100)
);