
--crear una base de datos.
CREATE DATABASE UHUNIVERSIDAD

--Para borrar base una base de datos:
--DROP DATABASE UHUNIVERSIDAD

--Para cambiar el nombre master 
USE UHUNIVERSIDAD

--Crear tabla
create table Usuario(

Codigo int identity (1,1),
Nombre varchar(50) not null,
Clave varchar(30) not null,
Edad smallint 
)

--Para borrar la tabla:
--Drop table Usuario

--Insertar registros
insert into Usuario (Nombre, Clave, Edad) values('Luis','123', 20)
insert into Usuario values ('Ana','456',18),('Maria','789',22)

--Consulta de registros
Select * from Usuario
--select Codigo, Nombre from Usuario
--select * from Usuario where Nombre = 'Luis'
--select * from Usuario where Nombre like 'M%'

--Borrar registros
--delete Usuario where Nombre ='Maria'

--Actualizar registros(ejemplos)
--update Usuario set Clave='777' where Codigo=7
--update Usuario set Nombre ='Anita', Clave '999' where Clave='999'
