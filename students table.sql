CREATE TABLE student (
  id INT IDENTITY(1,1) PRIMARY KEY,
  first_name NVARCHAR(50),
  last_name NVARCHAR(50),
  age INT,
  gender NVARCHAR(10),
  grade NVARCHAR(10)
);
