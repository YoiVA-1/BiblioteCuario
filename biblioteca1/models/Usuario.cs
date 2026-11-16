
namespace biblioteca1.models
{
    public class Usuario
    {
        private static int ContadorUsuario = 100;
        public int UsuarioId { get; set; } = 0;
        public string UsuarioNombre { get; set; } = string.Empty;
        public string UsuarioApellido { get; set; } = string.Empty;
        public string UsuarioEmail { get; set; } = string.Empty;
        public string UsuarioTelefono { get; set; } = string.Empty;

        public bool Activo { get; set; } = true;

        public Usuario()
        {
        }

        public Usuario(string usuarioNombre, string usuarioApellido, string usuarioEmail, string usuarioTelefono)
        {
            ContadorUsuario++;
            UsuarioId = ContadorUsuario;
            UsuarioNombre = usuarioNombre;
            UsuarioApellido = usuarioApellido;
            UsuarioEmail = usuarioEmail;
            UsuarioTelefono = usuarioTelefono;
        }

        public string ResumenCorto()
        {
            string estadoTexto = Activo ? "Activo" : "Inactivo";
            return $"ID: {UsuarioId}, Nombre: {UsuarioNombre}, Apellido: {UsuarioApellido}, Estado: {estadoTexto}";
        }
    }
}