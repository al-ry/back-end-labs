--1. (#15)  Напишите SQL запросы  для решения задач ниже. 
CREATE TABLE "PC" (
	"id"	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
	"cpu"	INTEGER NOT NULL,
	"memory"	INTEGER NOT NULL,
	"hdd"	INTEGER NOT NULL
);
INSERT INTO PC (cpu, memory, hdd) VALUES (1600, 2000, 500);
INSERT INTO PC (cpu, memory, hdd) VALUES (2400, 3000, 800);
INSERT INTO PC (cpu, memory, hdd) VALUES (3200, 3000, 1200);
INSERT INTO PC (cpu, memory, hdd) VALUES (2400, 2000, 500);

/* 1) Тактовые частоты CPU тех компьютеров
, у которых объем памяти 3000 Мб. Вывод: id, cpu, memory*/

SELECT id, cpu, memory
FROM PC
WHERE memory = 3000;

/* 2) Минимальный объём жесткого диска
, установленного в компьютере на складе. Вывод: hdd*/
SELECT MIN(hdd) AS min_hdd
FROM PC;
/* 3) Количество компьютеров с минимальным объемом жесткого диска
 , доступного на складе. Вывод: count, hdd*/

SELECT COUNT(hdd) AS count, hdd
FROM PC
WHERE hdd = (SELECT MIN(hdd) FROM PC);

--2. (#30) Есть таблица следующего вида:
CREATE TABLE "track_downloads" (
	"download_id"	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
	"track_id"	INTEGER NOT NULL,
	"user_id"	INTEGER NOT NULL,
	"download_time"	TEXT NOT NULL
);
INSERT INTO track_downloads (track_id, user_id, download_time) VALUES (2, 1, '2010-11-19');
INSERT INTO track_downloads (track_id, user_id, download_time) VALUES (3, 1, '2010-11-19');
INSERT INTO track_downloads (track_id, user_id, download_time) VALUES (8, 1, '2010-11-19');
INSERT INTO track_downloads (track_id, user_id, download_time) VALUES (2, 2, '2010-11-19');
INSERT INTO track_downloads (track_id, user_id, download_time) VALUES (10, 2, '2010-11-19');
INSERT INTO track_downloads (track_id, user_id, download_time) VALUES (2, 3, '2010-11-19');
INSERT INTO track_downloads (track_id, user_id, download_time) VALUES (5, 3, '2010-11-19');
INSERT INTO track_downloads (track_id, user_id, download_time) VALUES (8, 4, '2010-11-19');
/*Напишите SQL-запрос, возвращающий все пары (download_count, user_count), 
    удовлетворяющие следующему условию: 
    user_count — общее ненулевое число пользователей, сделавших 
    ровно download_count скачиваний 19 ноября 2010 года.*/
SELECT download_count, COUNT(*) AS user_count
FROM (
	SELECT track_id, COUNT(*) AS download_count
	FROM track_downloads
	WHERE download_time = '2010-11-19'
	GROUP BY user_id
) AS download_count
GROUP BY download_count;

/*3. (#10) Опишите разницу типов данных DATETIME и TIMESTAMP

DATETIME хранит дату в формате:  'YYYY-MM-DD hh:mm:ss' в виде целого числа,
И поддерживает диапазон значений: от '1000-01-01 00:00:00' до '9999-12-31 23:59:59'
Время записанное в DATETIME не зависит от временной зоны установленной на сервере
Занимает 8 байт.

TIMESTAMP хранит значения, равное количеству секунд прошедших с полуночи 1 января 1970 года по усреднённому
времени Гринвича.При получении значения из бд возвращает дату с учетом часового пояса
Занимает 4 байт. Значение TIMESTAMP не может быть пустым и хранит по умолчанию NOW()

Sqlite нету определенного типа данных для хранения даты и времени.
Дата хранится в текстовом формате. C помощью в функций datetime() и julianday()
можно извлечь дату и вермя подобно datetime и timestamp соответственно

 */

-- 4.(#20)  Необходимо создать таблицу студентов (поля id, name) и таблицу курсов (поля id, name).
-- Каждый студент может посещать несколько курсов. Названия курсов и имена студентов - произвольны.

CREATE TABLE course
(
    id_course INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    name TEXT NOT NULL
);

INSERT INTO course (name) VALUES ('OOP');
INSERT INTO course (name) VALUES ('Math');
INSERT INTO course (name) VALUES ('History');
INSERT INTO course (name) VALUES ('BackEnd');

CREATE TABLE student
(
    id_student INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    name TEXT NOT NULL
);

INSERT INTO student (name) VALUES ('Михаил');
INSERT INTO student (name) VALUES ('Иван');
INSERT INTO student (name) VALUES ('Захар');
INSERT INTO student (name) VALUES ('Илья');
INSERT INTO student (name) VALUES ('Виктор');
INSERT INTO student (name) VALUES ('Сергей');
INSERT INTO student (name) VALUES ('Леонид');
INSERT INTO student (name) VALUES ('Лев');
INSERT INTO student (name) VALUES ('Юлия');
INSERT INTO student (name) VALUES ('Екатерина');
INSERT INTO student (name) VALUES ('Елизавета');

CREATE TABLE student_on_course
(
    id_student_on_course INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    id_course  INTEGER NOT NULL,
    id_student INTEGER NOT NULL,
	FOREIGN KEY (id_course) REFERENCES course (id_course)
	FOREIGN KEY (id_student) REFERENCES  student (id_student)
);


INSERT INTO student_on_course (id_course, id_student) VALUES (1, 1);
INSERT INTO student_on_course (id_course, id_student) VALUES (1, 2);
INSERT INTO student_on_course (id_course, id_student) VALUES (1, 3);
INSERT INTO student_on_course (id_course, id_student) VALUES (1, 4);
INSERT INTO student_on_course (id_course, id_student) VALUES (1, 7);
INSERT INTO student_on_course (id_course, id_student) VALUES (1, 8);

INSERT INTO student_on_course (id_course, id_student) VALUES (6, 9);
INSERT INTO student_on_course (id_course, id_student) VALUES (6, 10);
INSERT INTO student_on_course (id_course, id_student) VALUES (6, 11);
INSERT INTO student_on_course (id_course, id_student) VALUES (6, 12);
INSERT INTO student_on_course (id_course, id_student) VALUES (6, 7);
INSERT INTO student_on_course (id_course, id_student) VALUES (6, 8);

INSERT INTO student_on_course (id_course, id_student) VALUES (2, 8);
INSERT INTO student_on_course (id_course, id_student) VALUES (3, 12);


--1. отобразить количество курсов, на которые ходит более 5 студентов
SELECT COUNT(amount) AS course_amount
FROM (
	SELECT COUNT(name) as amount
	FROM course 
	INNER JOIN student_on_course ON student_on_course.id_course = course.id_course
	GROUP BY name
	HAVING COUNT(*) > 5) AS amount;
	
--2. отобразить все курсы, на которые записан определенный студент.
SELECT id_student,name , GROUP_CONCAT(course.namename)
FROM student
INNER JOIN student_on_course ON student.id_student = student_on_course.id_student
INNER JOIN student_on_course ON student_on_course.id_course = course.id_course
GROUP BY student.id_student;

-- 5. (5#) Может ли значение в столбце(ах), на который наложено ограничение foreign key,
-- равняться null? Привидите пример.

--Может, если на него не наложено ограничение NOT NULL
--Пример
CREATE TABLE Foo
(
	id_foo INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT
);

CREATE TABLE Bar
(
	id_foo INTEGER NULL,
	FOREIGN	KEY (id_foo)
	REFERENCES Foo (id_foo)
);

INSERT INTO Foo (id_foo) 
VALUES (NULL);


/*6. (#15) Как удалить повторяющиеся строки с использованием ключевого слова Distinct?
Приведите пример таблиц с данными и запросы. */

--В качестве примера может подойти таблица со студентами из задания 4.
--Добавим людей с одинаковыми именами и удалим дубликаты с помощью оператора DISTINCT,
--который ищет уникальные значения и удаляет дубликаты при выборке

SELECT DISTINCT name FROM student;

--7. (#10) Есть две таблицы:
CREATE TABLE users 
(
	users_id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
	name TEXT NOT NULL
);

CREATE TABLE orders
(
	orders_id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
	user_id INTEGER NOT NULL,
	status INTEGER NOT NULL,
	FOREIGN	KEY (user_id)
	REFERENCES users (user_id)
);


INSERT INTO users (name) VALUES ('Петр');
INSERT INTO users (name) VALUES ('Василий');
INSERT INTO users (name) VALUES ('Сергей');
INSERT INTO users (name) VALUES ('Николай');
INSERT INTO users (name) VALUES ('Андрей');


INSERT INTO orders (users_id, status) VALUES ('1', 0);
INSERT INTO orders (users_id, status) VALUES ('2', 1);
INSERT INTO orders (users_id, status) VALUES ('3', 1);
INSERT INTO orders (users_id, status) VALUES ('4', 0);
INSERT INTO orders (users_id, status) VALUES ('5', 0);
INSERT INTO orders (users_id, status) VALUES ('5', 0);
INSERT INTO orders (users_id, status) VALUES ('1', 0);
INSERT INTO orders (users_id, status) VALUES ('4', 1);
INSERT INTO orders (users_id, status) VALUES ('3', 1);
INSERT INTO orders (users_id, status) VALUES ('3', 1);
INSERT INTO orders (users_id, status) VALUES ('3', 1);
INSERT INTO orders (users_id, status) VALUES ('3', 1);
INSERT INTO orders (users_id, status) VALUES ('3', 1);


-- 1) Выбрать всех пользователей из таблицы users,
-- у которых ВСЕ записи в таблице orders имеют status = 0
SELECT users.users_id, users.name, orders.status
FROM users
INNER JOIN orders ON users.users_id = orders.users_id
GROUP BY users.users_id
HAVING SUM(orders.status) = 0;


 --2) Выбрать всех пользователей из таблицы users
 --, у которых больше 5 записей в таблице orders имеют status = 1
SELECT users.users_id, users.name, orders.status
FROM users
INNER JOIN orders ON users.users_id = orders.users_id
GROUP BY users.users_id
HAVING orders.status = 1 AND COUNT(orders.status) > 5; 

/*8. (#10)  В чем различие между выражениями HAVING и WHERE?
WHERE сначала фильтрует по условию, а потом группирует(может быть идти с GROUP BY после WHERE так и без)
HAVING всегда идет c GROUP BY перед HAVING и сначала группирует, а потом фильтрует по условию, 
также вместе с HAVING можно использовать агрегирующие функции(count, sum, avg, min, max), а с WHERE - нет
HAVING используется только с SELECT, а выражение WHERE может использоваться с SELECT, UPDATE, DELETE.  
*/