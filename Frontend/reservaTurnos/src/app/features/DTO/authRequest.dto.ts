export class AuthRequest
{
  email: string;
  contrasena: string;

  constructor(email:string, contrasena:string){
    this.email = email;
    this.contrasena = contrasena;
  }
}
