using Domain.Entidades;
using Domain.Repositorios;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositorios
{
    public class UsuarioSeguidoRepositorio : IUsuarioSeguidoRepositorio
    {
        // Atributo para manejar el dbContext
        private readonly AppDatabaseContext _context;

        // Constructor
        public UsuarioSeguidoRepositorio(AppDatabaseContext context)
        {
            _context = context;
        }

        // Implementacion de la interfaz (contrato)
        public void AgregarSeguidor(int idSeguidor, int idSeguido)
        {
            var seguimiento = new UsuarioSeguido
            {
                IdSeguidor = idSeguidor,
                IdSeguido = idSeguido
            };

            _context.UsuarioSeguidos.Add(seguimiento);
            _context.SaveChanges();
        }

        public void EliminarSeguidor(int idSeguidor, int idSeguido)
        {
            var seguimiento = _context.UsuarioSeguidos
                .SingleOrDefault(s => s.IdSeguidor == idSeguidor && s.IdSeguido == idSeguido);

            if (seguimiento != null)
            {
                _context.UsuarioSeguidos.Remove(seguimiento);
                _context.SaveChanges();
            }
        }

        public bool EsSeguidor(int idSeguidor, int idSeguido)
        {
            return _context.UsuarioSeguidos
                .Any(s => s.IdSeguidor == idSeguidor && s.IdSeguido == idSeguido);
        }

        public IEnumerable<int> ObtenerSeguidosId(int idSeguidor)
        {
            return _context.UsuarioSeguidos
                .Where(us => us.IdSeguidor == idSeguidor)
                .Select(us => us.IdSeguidor)
                .ToList();
        }
    }
}
