For the database, please note the following assumptions:

id: An integer field that serves as the primary key for uniquely identifying each student record. It is set to auto-increment using the IDENTITY(1,1) property, which means that SQL Server will automatically generate a unique value for each new record starting from 1 and incrementing by 1.
first_name: An NVARCHAR field that stores the first name of the student. The NVARCHAR data type is used to support storing Unicode characters, and the maximum length of this field is set to 50 characters.
last_name: An NVARCHAR field that stores the last name of the student. The maximum length of this field is set to 50 characters.
age: An integer field that stores the age of the student.
gender: An NVARCHAR field that stores the gender of the student. The maximum length of this field is set to 10 characters.
grade: An NVARCHAR field that stores the grade or class of the student. The maximum length of this field is set to 10 characters.



CREATE TABLE student (
  id INT IDENTITY(1,1) PRIMARY KEY,
  first_name NVARCHAR(50),
  last_name NVARCHAR(50),
  age INT,
  gender NVARCHAR(10),
  grade NVARCHAR(10)
);
