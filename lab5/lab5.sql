-- 2. Добавление таблиц в БД
CREATE TABLE dvd 
(
	dvd_id	INTEGER PRIMARY KEY AUTOINCREMENT,
	title	TEXT NOT NULL,
	production_year	TEXT NOT NULL
);

CREATE TABLE customer 
(
	customer_id	INTEGER PRIMARY KEY AUTOINCREMENT,
	first_name	TEXT NOT NULL,
	last_name	TEXT NOT NULL,
	passport_code	TEXT NOT NULL,
	registration_date	TEXT NOT NULL
);

CREATE TABLE offer 
(
	offer_id	INTEGER PRIMARY KEY AUTOINCREMENT,
	dvd_id	INTEGER NOT NULL,
	customer_id	INTEGER NOT NULL,
	offer_date	TEXT NOT NULL,
	return_date	TEXT NOT NULL
);		

-- 3.  Подготовьте SQL запросы для заполнения таблиц данными.
INSERT INTO dvd (title, production_year) VALUES ('Алёша Попович и Тугарин Змей', '2004');
INSERT INTO dvd (title, production_year) VALUES ('Железный человек 2', '2010');
INSERT INTO dvd (title, production_year) VALUES ('Шрек навсегда', '2010');
INSERT INTO dvd (title, production_year) VALUES ('Гарри Поттер и Дары Смерти. Часть 1', '2010');
INSERT INTO dvd (title, production_year) VALUES ('Дети шпионов', '2001');
INSERT INTO dvd (title, production_year) VALUES ('Форрест Гамп', '1994');
INSERT INTO dvd (title, production_year) VALUES ('Терминатор', '1984');
INSERT INTO dvd (title, production_year) VALUES ('Титаник', '1997');
INSERT INTO dvd (title, production_year) VALUES ('Матрица', '1999');


INSERT INTO customer (first_name, last_name, passport_code, registration_date)
VALUES ('Вася', 'Пупкин', '8814 302390', '2015-03-25');

INSERT INTO customer (first_name, last_name, passport_code, registration_date)
VALUES ('Иван', 'Иванов', '8810 557788', '2016-12-12');

INSERT INTO customer (first_name, last_name, passport_code, registration_date)
VALUES ('Вера', 'Петрова', '8810 348787', '2017-02-25');

INSERT INTO customer (first_name, last_name, passport_code, registration_date)
VALUES ('Виктор', 'Петров', '8816 665334', '2017-08-30');

INSERT INTO customer (first_name, last_name, passport_code, registration_date)
VALUES ('Галина', 'Викторова', '8816 101314', '2018-06-22');

INSERT INTO customer (first_name, last_name, passport_code, registration_date)
VALUES ('Петр', 'Сидоров', '8813 557754', '2019-11-20');

INSERT INTO customer (first_name, last_name, passport_code, registration_date)
VALUES ('Вениамин', 'Васильев', '8811 123899', '2018-11-21');

INSERT INTO customer (first_name, last_name, passport_code, registration_date)
VALUES ('Алексей', 'Никитин', '8811 111279', '2020-01-11');


INSERT INTO offer (dvd_id, customer_id, offer_date, return_date)
VALUES(1, 1, '2019-06-12', '2019-07-12');

INSERT INTO offer (dvd_id, customer_id, offer_date, return_date)
VALUES(5, 1, '2019-06-12', '2019-07-12');

INSERT INTO offer (dvd_id, customer_id, offer_date, return_date)
VALUES(9, 1, '2019-07-20', '2019-08-20');

INSERT INTO offer (dvd_id, customer_id, offer_date, return_date)
VALUES(5, 6, '2010-01-20', '2010-02-20');

INSERT INTO offer (dvd_id, customer_id, offer_date, return_date)
VALUES(8, 8, '2020-03-20', '2020-03-20');

INSERT INTO offer (dvd_id, customer_id, offer_date, return_date)
VALUES(8, 2, '2020-01-20', '2020-01-20');

INSERT INTO offer (dvd_id, customer_id, offer_date, return_date)
VALUES(8, 7, '2020-01-20', '2020-01-20');

INSERT INTO offer (dvd_id, customer_id, offer_date, return_date)
VALUES(2, 3, '2020-01-20', '2020-01-20');

INSERT INTO offer (dvd_id, customer_id, offer_date, return_date)
VALUES(6, 6, '2020-04-20', '2020-05-20');

INSERT INTO offer (dvd_id, customer_id, offer_date, return_date)
VALUES(5, 2, '2020-04-05', '2020-05-10');

-- 4.  Подготовьте SQL запрос получения списка всех DVD, год выпуска которых 2010, 
--	отсортированных в алфавитном порядке по названию DVD.
SELECT *
FROM 
	dvd
WHERE production_year = '2010'
ORDER BY title ASC;	

--5.  Подготовьте SQL запрос для получения списка DVD дисков, которые в настоящее время
--	находятся у клиентов.
SELECT title
FROM
	dvd
WHERE dvd_id IN
(
	SELECT dvd_id
	FROM 
		offer
	WHERE offer_date <= date('now') AND date('now') <= return_date
);
--6.  Напишите SQL запрос для получения списка клиентов, которые брали какие-либо DVD 
--	диски в текущем году. В результатах запроса необходимо также отразить какие диски 
--	брали клиенты.

SELECT 
	customer.customer_id, 
	customer.first_name, 
	customer.last_name, 
	dvd.dvd_id, 
	dvd.title,
	dvd.production_year
FROM customer
LEFT JOIN offer ON customer.customer_id = offer.customer_id
LEFT JOIN dvd ON dvd.dvd_id = offer.dvd_id
WHERE 
	strftime('%Y', offer.offer_date) = '2020';



