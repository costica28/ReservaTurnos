CREATE DATABASE BookingShifts

USE BookingShifts

CREATE TABLE comercios(
	id_comercio int not null identity(1,1) primary key,
	nom_comercio varchar(60) not null,
	aforo_maximo int not null
)

CREATE TABLE servicios(
	id_servicio int not null IDENTITY(1,1) PRIMARY KEY,
	id_comercio int not null,
	nom_servicio varchar(100) not null,
	hora_apertura time not null,
	hora_cierre time not null,
	duracion int not null,
	FOREIGN KEY (id_comercio) REFERENCES comercios(id_comercio)
)

CREATE TABLE turnos(
	id_turno int not null PRIMARY KEY IDENTITY(1,1),
	id_servicio int not null,
	fecha_turno date not null,
	hora_apertura time not null,
	hora_cierre time not null,
	estado int not null,
	FOREIGN KEY (id_servicio) REFERENCES servicios(id_servicio)
)


CREATE TABLE roles(
	id int not null PRIMARY KEY IDENTITY(1,1),
	nombre_rol varchar(40) not null
)

CREATE TABLE usuarios(
	id int not null PRIMARY KEY IDENTITY(1,1),
	nombre_usuario varchar(60) not null,
	email varchar(20) not null,
	contrasena varchar(60) not null,
	id_rol int not null,
	FOREIGN KEY(id_rol) REFERENCES roles(id)
)


INSERT INTO comercios VALUES('Sonria', 40),('Optica Vision Clara', 12),('Colsubsidio', 100)
INSERT INTO servicios VALUES(1, 'Brackets', '07:00:00','20:00:00', 40),(1, 'Blanqueamiento Dental', '07:00:00','20:00:00', 30),
							(2, 'Optimetria', '09:00:00','18:30:00', 30),(3, 'Consulta Generales', '07:00:00','22:00:00', 30),
							(3, 'Toma de Muestras', '08:00:00','20:00:00', 30),(3, 'Odontologia', '08:30:00', '18:00:00', 40)
							
INSERT INTO roles VALUES('Administrador')
INSERT INTO usuarios VALUES('prueba', 'admin@gmail.com','ZQ929BFdzslixVBMncL5sQ==', 1)
