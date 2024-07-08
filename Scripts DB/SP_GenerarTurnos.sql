CREATE PROCEDURE SP_GenerarTurnos
    @IdServicio INT,
    @FechaInicio DATE,
    @FechaFin DATE
AS
BEGIN
    DECLARE @HoraApertura TIME;
    DECLARE @HoraCierre TIME;
    DECLARE @Duracion INT;

    -- Obtener los datos de apertura, cierre y duración del servicio
    SELECT @HoraApertura = hora_apertura, @HoraCierre = hora_cierre, @Duracion = duracion
    FROM BookingShifts.dbo.servicios
    WHERE id_servicio = @IdServicio;

    -- Variable para iterar sobre las fechas
    DECLARE @FechaActual DATE = @FechaInicio;
    -- Bucle para iterar sobre los dias desde la fecha de inicio hasta la fecha de fin
	WHILE @FechaActual <= @FechaFin
    BEGIN
        -- Variables para los turnos
        DECLARE @HoraActual TIME = @HoraApertura;
        DECLARE @HoraFin TIME;	
		
        -- Bucle para generar turnos en un día
        WHILE @HoraActual < @HoraCierre
        BEGIN
            SET @HoraFin = DATEADD(MINUTE, @Duracion, @HoraActual);
            
			-- Insertar el turno en la tabla de turnos
            INSERT INTO turnos(id_servicio, fecha_turno, hora_apertura, hora_cierre, estado)
            VALUES (@IdServicio, @FechaActual, @HoraActual, @HoraFin, 1);
            
			-- Actualizar la hora actual al final del turno
            SET @HoraActual = @HoraFin;
        END

        -- Avanzar al dia siguiente para salir del bucle 
        SET @FechaActual = DATEADD(DAY, 1, @FechaActual);
    END
     --Devuelve los turnos generados
    SELECT * FROM Turnos WHERE id_servicio = @IdServicio AND fecha_turno BETWEEN @FechaInicio AND @FechaFin;
END
