export class User
{
  id: number = 0;
  nombre_usuario: string = "";
  email: string = "";
  contrasena: string = "";
  id_rol: number = 0;

  constructor(id: number, nombre_usuario: string, email: string, contrasena: string, id_rol: number) {
    this.id = id;
    this.nombre_usuario = nombre_usuario;
    this.email = email;
    this.contrasena = contrasena;
    this.id_rol = id_rol;
  }
}
