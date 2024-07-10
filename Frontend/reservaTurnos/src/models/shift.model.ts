export class Shift{
  id_turno: number;
  id_servicio:number;
  fecha_turno: Date;
  hora_apertura: string;
  hora_cierre: string;
  estado: number;

  constructor(id_turno:number,id_servicio:number,fecha_turno:Date,hora_apertura:string,hora_cierre:string,estado: number){
    this.id_turno = id_turno;
    this.id_servicio = id_servicio;
    this.fecha_turno = fecha_turno;
    this.hora_apertura = hora_apertura;
    this.hora_cierre = hora_cierre;
    this.estado = estado
  }
}
