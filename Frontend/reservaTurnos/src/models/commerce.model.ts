export class Commerce
{
  id_comercio: number = 0;
  nom_comercio: string = "";
  aforo_maximo: number = 0;

  constructor(id_comercio: number, nom_comercio: string, aforo_maximo: number){
    this.id_comercio = id_comercio;
    this.nom_comercio = nom_comercio;
    this.aforo_maximo = aforo_maximo;
  }

}
