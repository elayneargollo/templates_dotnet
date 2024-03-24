CREATE TABLE fileDetails(
   id INT NOT NULL AUTO_INCREMENT,
   fileName varchar(255) NOT NULL,
   contentType varchar(255) NOT NULL,
   fileData VARBINARY(8000) NOT NULL,
   PRIMARY KEY(id)
);
