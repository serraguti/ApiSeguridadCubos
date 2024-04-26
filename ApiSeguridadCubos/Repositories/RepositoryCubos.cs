using ApiSeguridadCubos.Data;
using ApiSeguridadCubos.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiSeguridadCubos.Repositories
{
    public class RepositoryCubos
    {
        private CubosContext context;

        public RepositoryCubos(CubosContext context)
        {
            this.context = context;
        }

        public async Task<List<Cubo>> GetCubosAsync()
        {
            return await this.context.Cubos.ToListAsync();
        }

        public async Task<List<Cubo>> GetCubosMarcaAsync
            (string marca)
        {
            return await this.context.Cubos
                .Where(x => x.Marca == marca)
                .ToListAsync();
        }

        public async Task<List<Usuario>> GetUsuarioAsync
            (int idusuario)
        {
            return await this.context.Usuarios
                .Where(x => x.IdUsuario == idusuario)
                .ToListAsync();
        }

        public async Task<List<Compra>> GetComprasUsuarioAsync
            (int idusuario)
        {
            return await this.context.Compras
                .Where(x => x.IdUsuario == idusuario)
                .ToListAsync();
        }

        public async Task<Usuario> LoginUsuarioAsync
            (string email, string password)
        {
            return await this.context.Usuarios
                .Where(z => z.Email == email
                && z.Password == password).FirstOrDefaultAsync();
        }
    }
}
