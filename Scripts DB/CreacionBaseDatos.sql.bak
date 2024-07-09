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
	CONSTRAINT FK_id_comercio_servicios FOREIGN KEY (id_comercio) REFERENCES comercios(id_comercio)
)

CREATE TABLE turnos(
	id_turno int not null PRIMARY KEY IDENTITY(1,1),
	id_servicio int not null,
	fecha_turno date not null,
	hora_apertura time not null,
	hora_cierre time not null,
	estado int not null,
	CONSTRAINT Fk_id_Servicio_turnos FOREIGN KEY (id_servicio) REFERENCES servicios(id_servicio)
)