export class GenerateShiftsRequest{
  FechaInicio: string;
  FechaFin: string;
  IdServicio:number;

  constructor(FechaInicio: string, FechaFin: string, IdServicio:number){
    this.FechaInicio = FechaInicio;
    this.FechaFin = FechaFin;
    this.IdServicio = IdServicio;
  }

}
