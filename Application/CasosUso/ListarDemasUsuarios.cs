using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Dtos;
using Domain.Entidades;
using Domain.Repositorios;

namespace Application.CasosUso
{
    public class ListarDemasUsuarios
    {
        // Atributos para inyeccion
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        // Constructor
        public ListarDemasUsuarios(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        // Metodos
        public IEnumerable<UsuarioDto> Ejecutar(string username)
        {
            var usuarios = new List<UsuarioDto>();

            var usuarioList = _usuarioRepositorio.ObtenerDemasUsuarios(username);

            foreach (var usuario in usuarioList)
            {
                usuarios.Add(new UsuarioDto{
                    Id = usuario.Id,
                    Username = usuario.Username
                });
            }

            return usuarios;
        }
    }
}