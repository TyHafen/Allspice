CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture'
) default charset utf8 COMMENT '';
CREATE TABLE IF NOT EXISTS recipes(
  id INT AUTO_INCREMENT PRIMARY KEY,
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  title TEXT NOT NULL,
  subtitle TEXT NOT NULL,
  image,
  category TEXT NOT NULL,
  creatorId VARCHAR(255) NOT NULL,
  FOREIGN KEY (creatorId) REFERENCES accounts(id)
) default charset utf8 COMMENT '';
CREATE TABLE IF NOT EXISTS ingredients(
  id INT AUTO_INCREMENT PRIMARY KEY,
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name VARCHAR(255) not null,
  quantity VARCHAR(255) not null,
  recipeId VARCHAR(255) NOT NULL,
  FOREIGN KEY (recipeId) REFERENCES recipes(id)
) default charset utf8 COMMENT '';
CREATE TABLE IF NOT EXISTS steps(
  id INT AUTO_INCREMENT PRIMARY KEY,
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  recipeId INT,
  Position INT,
  body TEXT
) default charset utf8 COMMENT '';
CREATE TABLE IF NOT EXISTS favorites(
  id INT AUTO_INCREMENT PRIMARY KEY,
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  recipeId INT,
  AccountId VARCHAR(255),
  FOREIGN KEY (recipeId) REFERENCES recipes(id) ON DELETE CASCADE,
  FOREIGN KEY (AccountId) REFERENCES accounts(id) ON DELETE CASCADE
) default charset utf8 COMMENT '';
DROP TABLE recipes;
SELECT
  *
FROM
  recipes;
INSERT INTO
  recipes (title, subtitle, category, creatorId, image)
VALUES
  (
    'Club Sandwich',
    'So good',
    'American',
    '624f58fdaf82a511b148b903',
    'https://th.bing.com/th/id/OIP.Q3rHBYVTQPlO_Bp1DZt90wHaHa?pid=ImgDet&rs=1'
  );
SELECT
  LAST_INSERT_ID();