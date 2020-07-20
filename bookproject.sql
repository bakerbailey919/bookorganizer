
USE master;
GO

DROP DATABASE IF EXISTS BookDatabase;
GO

CREATE DATABASE BookDatabase;
GO

USE BookDatabase
GO

BEGIN TRANSACTION;

CREATE TABLE genre
(
	genreId			integer				identity NOT NULL,
	genre			varchar(64)		not null,

	constraint pk_genre primary key (genreId)
);

CREATE TABLE publisher
(
	publisherId		integer				identity NOT NULL,
	name			varchar(64)		not null,

	constraint pk_publisher primary key (publisherId)
);

CREATE TABLE author
(
	authorId		integer				identity NOT NULL,
	name			varchar(64)		not null,

	constraint pk_author primary key (authorId)
);

CREATE TABLE book
(
	bookId			integer				identity NOT NULL,
	title			varchar(64)		not null,
    description     varchar(512)    null,
    releaseYear     smallint        null,
    pageLength      smallint        null,
    rating          integer				null,
	genreId			integer				not null,
	authorId		integer				not null,
	publisherId		integer				not null,

	constraint pk_book primary key (bookId),
	constraint fk_genre foreign key (genreId) references genre (genreId),
	constraint fk_author foreign key (authorId) references author (authorId),
	constraint fk_publisher foreign key (publisherId) references publisher (publisherId)
);

CREATE TABLE reader
(
	readerId		int				identity(1,1),
	firstName		varchar(64)		not null,
	lastName		varchar(64)		not null,

	constraint pk_reader primary key (readerId)
);

CREATE TABLE bookReader
(
	readerId		int				not null,
	bookId			int				not null,

	constraint pk_book_reader primary key (readerId, bookId),
	constraint fk_reader foreign key (readerId) references reader (readerId),
	constraint fk_book foreign key (bookId) references book (bookId)
);

SET IDENTITY_INSERT genre ON 
INSERT INTO genre (genreId, genre) VALUES (1, 'Fiction');
INSERT INTO genre (genreId, genre) VALUES (2, 'Memoir');
INSERT INTO genre (genreId, genre) VALUES (3, 'Horror');
INSERT INTO genre (genreId, genre) VALUES (4, 'Fantasy');
INSERT INTO genre (genreId, genre) VALUES (5, 'Nonfiction');
SET IDENTITY_INSERT genre OFF

SET IDENTITY_INSERT publisher ON 
INSERT INTO publisher (publisherId, name) VALUES (1, 'Dutton');
INSERT INTO publisher (publisherId, name) VALUES (2, 'The Dial Press');
INSERT INTO publisher (publisherId, name) VALUES (3, 'Scribner');
INSERT INTO publisher (publisherId, name) VALUES (4, 'Scholastic Press');
INSERT INTO publisher (publisherId, name) VALUES (5, 'Little, Brown and Company');
SET IDENTITY_INSERT publisher OFF

SET IDENTITY_INSERT author ON 
INSERT INTO author (authorId, name) VALUES (1, 'Abi Dare');
INSERT INTO author (authorId, name) VALUES (2, 'Glennon Doyle');
INSERT INTO author (authorId, name) VALUES (3, 'Stephen King');
INSERT INTO author (authorId, name) VALUES (4, 'J.K. Rowling');
INSERT INTO author (authorId, name) VALUES (5, 'Malcolm Gladwell');
SET IDENTITY_INSERT author OFF

SET IDENTITY_INSERT reader ON 
INSERT INTO reader (readerId, firstName, lastName) VALUES (1, 'Bailey', 'Baker');
SET IDENTITY_INSERT reader OFF

SET IDENTITY_INSERT book ON 
INSERT INTO book (bookId, title, description, releaseYear, pageLength, rating, genreId, authorId, publisherId) VALUES (1, 'The Girl with the Louding Voice', 'A powerful, emotional debut novel told in the unforgettable voice of a young Nigerian woman who is trapped in a life of servitude but determined to fight for her dreams and choose her own future.', 2020, 384, 5, 1, 1, 1);
INSERT INTO book (bookId, title, description, releaseYear, pageLength, rating, genreId, authorId, publisherId) VALUES (2, 'Untamed', 'Soulful and uproarious, forceful and tender, Untamed is both a memoir and a galvanizing wake-up call. It offers a piercing, electrifying examination of the restrictive expectations women are issued from birth; shows how hustling to meet those expectations leaves women feeling dissatisfied and lost; and reveals that when we quit abandoning ourselves and instead abandon the world’s expectations of us, we become women who can finally look at ourselves and recognize: There She Is.', 2020, 352, 4, 2, 2, 2);
INSERT INTO book (bookId, title, description, releaseYear, pageLength, rating, genreId, authorId, publisherId) VALUES (3, 'The Institute', 'As psychically terrifying as Firestarter, and with the spectacular kid power of It, The Institute is Stephen King’s gut-wrenchingly dramatic story of good vs. evil in a world where the good guys don’t always win.', 2019, 576, 4, 3, 3, 3);
INSERT INTO book (bookId, title, description, releaseYear, pageLength, rating, genreId, authorId, publisherId) VALUES (4, 'Harry Potter and the Deathly Hallows', 'Harry Potter is leaving Privet Drive for the last time. But as he climbs into the sidecar of Hagrid’s motorbike and they take to the skies, he knows Lord Voldemort and the Death Eaters will not be far behind. The protective charm that has kept him safe until now is broken. But the Dark Lord is breathing fear into everything he loves. And he knows he can’t keep hiding.', 2007, 759, 5, 4, 4, 4);
INSERT INTO book (bookId, title, description, releaseYear, pageLength, rating, genreId, authorId, publisherId) VALUES (5, 'Talking to Strangers', 'Talking to Strangers is a classically Gladwellian intellectual adventure, a challenging and controversial excursion through history, psychology, and scandals taken straight from the news. He revisits the deceptions of Bernie Madoff, the trial of Amanda Knox, the suicide of Sylvia Plath, the Jerry Sandusky pedophilia scandal at Penn State University, and the death of Sandra Bland---throwing our understanding of these and other stories into doubt.', 2019, 401, 3, 5, 5, 5);
SET IDENTITY_INSERT book OFF

INSERT INTO bookReader (readerId, bookId) VALUES (1, 1);
INSERT INTO bookReader (readerId, bookId) VALUES (1, 2);
INSERT INTO bookReader (readerId, bookId) VALUES (1, 3);
INSERT INTO bookReader (readerId, bookId) VALUES (1, 4);
INSERT INTO bookReader (readerId, bookId) VALUES (1, 5);

COMMIT TRANSACTION;
