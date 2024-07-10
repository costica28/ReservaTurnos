export class Service {
  id_servicio: number;
  id_comercio: number;
  nom_servicio: string;
  hora_apertura: Date;
  hora_cierre: Date;
  duracion: number;

  constructor(id_servicio:number,id_comercio:number,nom_servicio:string,hora_apertura:Date,hora_cierre:Date,duracion: number){
    this.id_servicio = id_servicio;
    this.id_comercio = id_comercio;
    this.nom_servicio = nom_servicio;
    this.hora_apertura = hora_apertura;
    this.hora_cierre = hora_cierre;
    this.duracion = duracion
  }

}
