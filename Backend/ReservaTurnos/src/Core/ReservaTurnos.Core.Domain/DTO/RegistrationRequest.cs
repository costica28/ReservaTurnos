namespace ReservaTurnos.Core.Domain.DTO
{
    public class RegistrationRequest
    {
        public string nombre_usuario { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public string contrasena { get; set; } = string.Empty;
        public int id_rol { get; set; }
    }
}
