using System;
using System.Collections.Generic;
using System.Linq;
using biblioteca1.models;

namespace biblioteca1.services
{
    public class UsuarioService
    {
        private readonly List<Usuario> usuarios = new List<Usuario>();

        // --- Operaciones básicas ---
        public void AgregarUsuario(Usuario usuario)
        {
            if (usuario == null) throw new ArgumentNullException(nameof(usuario));
            usuarios.Add(usuario);
        }

        public bool EliminarUsuario(int usuarioId)
        {
            Usuario? usuario = usuarios.FirstOrDefault(u => u.UsuarioId == usuarioId);
            if (usuario == null) return false;
            return usuarios.Remove(usuario);
        }

        // Lógica simulada: desactivar usuario en lugar de borrarlo
        public bool DesactivarUsuario(int usuarioId)
        {
            Usuario? usuario = usuarios.FirstOrDefault(u => u.UsuarioId == usuarioId);
            if (usuario == null) return false;
            usuario.Activo = false;
            return true;
        }

        public List<Usuario> ObtenerTodos()
        {
            return new List<Usuario>(usuarios);
        }

        // --- Búsquedas ---
        public Usuario? BuscarPorDocumentoOId(int usuarioId)
        {
            return usuarios.FirstOrDefault(u => u.UsuarioId == usuarioId);
        }

        public List<Usuario> BuscarPorDocumento(string documento)
        {
            if (string.IsNullOrWhiteSpace(documento)) return new List<Usuario>();
            string criterio = documento.Trim();

            if (int.TryParse(criterio, out int id))
            {
                return usuarios.Where(u => u.UsuarioId == id).ToList();
            }

            return usuarios
                .Where(u => u.UsuarioId.ToString().Equals(criterio, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        public List<Usuario> BuscarPorNombre(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre)) return new List<Usuario>();
            string criterio = nombre.Trim();

            return usuarios
                .Where(u =>
                    u.UsuarioNombre.Contains(criterio, StringComparison.OrdinalIgnoreCase) ||
                    u.UsuarioApellido.Contains(criterio, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        // --- Ordenación ---
        public List<Usuario> OrdenarPorNombre()
        {
            return usuarios
                .OrderBy(u => u.UsuarioNombre, StringComparer.OrdinalIgnoreCase)
                .ThenBy(u => u.UsuarioApellido, StringComparer.OrdinalIgnoreCase)
                .ToList();
        }

        // --- KPIs / Estadísticas ---
        public int ObtenerTotalUsuarios()
        {
            return usuarios.Count;
        }

        public int ObtenerUsuariosActivos()
        {
            return usuarios.Count(u => u.Activo);
        }

        public int ObtenerUsuariosInactivos()
        {
            return usuarios.Count(u => !u.Activo);
        }

        public string ObtenerResumenKpis()
        {
            int total = ObtenerTotalUsuarios();
            int activos = ObtenerUsuariosActivos();
            int inactivos = ObtenerUsuariosInactivos();
            return $"KPIs Usuarios -> Total: {total} | Activos: {activos} | Inactivos: {inactivos}";
        }
    }
}