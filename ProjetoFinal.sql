create database projetoFinal

CREATE LOGIN projetoFinal WITH PASSWORD='senha1234';
CREATE USER projetoFinal FROM LOGIN projetoFinal;
EXEC sp_addrolemember 'DB_DATAREADER', 'projetoFinal';
EXEC sp_addrolemember 'DB_DATAWRITER', 'projetoFinal';
