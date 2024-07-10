export class RegistrationRequest{
  nombre_usuario: string;
  email: string;
  contrasena: string;
  id_rol:number;

  constructor(nombre_usuario: string, email:string, contrasena:string, id_rol: number){
    this.nombre_usuario = nombre_usuario;
    this.email = email;
    this.contrasena = contrasena;
    this.id_rol = id_rol;
  }
}
