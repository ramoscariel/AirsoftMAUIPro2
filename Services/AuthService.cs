using AirsoftCore_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirsoftCore_App.Services
{
    public class AuthService
    {
        private static readonly List<Usuario> UsuariosRegistrados = new List<Usuario>();

        public async Task<bool> RegistrarUsuarioAsync(string nombreUsuario, string contraseña)
        {
            if (UsuariosRegistrados.Any(u => u.NombreUsuario.ToLower() == nombreUsuario.ToLower()))
            {
                return false;
            }

            var nuevoUsuario = new Usuario { NombreUsuario = nombreUsuario, Contraseña = contraseña };
            UsuariosRegistrados.Add(nuevoUsuario);

            await Task.Delay(100);

            return true;
        }

        public async Task<bool> IniciarSesionAsync(string nombreUsuario, string contraseña)
        {
            var usuario = UsuariosRegistrados.FirstOrDefault(u =>
                u.NombreUsuario.ToLower() == nombreUsuario.ToLower() && u.Contraseña == contraseña);

            await Task.Delay(100);

            return usuario != null;
        }

        public async Task<bool> ActualizarDatosPerfilAsync(string nombreUsuario, string nuevaContraseña)
        {
            var usuario = UsuariosRegistrados.FirstOrDefault(u => u.NombreUsuario.ToLower() == nombreUsuario.ToLower());

            if (usuario != null)
            {
                usuario.Contraseña = nuevaContraseña;
                await Task.Delay(100);
                return true;
            }

            return false;
        }

        public async Task<bool> SubirFotoAsync(string nombreUsuario, byte[] fotoBytes)
        {
            var usuario = UsuariosRegistrados.FirstOrDefault(u => u.NombreUsuario.ToLower() == nombreUsuario.ToLower());

            if (usuario != null)
            {
                usuario.FotoPerfil = fotoBytes;
                await Task.Delay(100);
                return true;
            }

            return false;
        }

        public void CerrarSesion()
        {
            
        }
    }
}
