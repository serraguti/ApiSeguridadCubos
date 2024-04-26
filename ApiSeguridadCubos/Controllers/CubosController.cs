using ApiSeguridadCubos.Models;
using ApiSeguridadCubos.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;

namespace ApiSeguridadCubos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CubosController : ControllerBase
    {
        private RepositoryCubos repo;

        public CubosController(RepositoryCubos repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Cubo>>>
            GetCubos()
        {
            return await this.repo.GetCubosAsync();
        }

        [HttpGet]
        [Route("[action]/{marca}")]
        public async Task<ActionResult<List<Cubo>>>
            CubosMarca(string marca)
        {
            return await this.repo.GetCubosMarcaAsync(marca);
        }

        [Authorize]
        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<Usuario>>
            PerfilUsuario()
        {
            //INTERNAMENTE, CUANDO RECIBIMOS EL TOKEN 
            //EL USUARIO ES VALIDADO Y ALMACENA DATOS 
            //COMO HttpContext.User.Identity.IsAuthenticated
            //COMO HEMOS INCLUIDO LA KEY DE LOS Claims, 
            //AUTOMATICAMENTE TAMBIEN TENEMOS DICHOS CLAIMS
            //COMO EN LAS APLICACIONES MVC
            Claim claim = HttpContext.User
                .FindFirst(x => x.Type == "UserData");
            //RECUPERAMOS EL JSON DEL EMPLEADO
            string jsonUser = claim.Value;
            Usuario usuario =
                JsonConvert.DeserializeObject<Usuario>(jsonUser);
            return usuario;
        }

        [Authorize]
        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<List<Compra>>>
            Pedidos()
        {
            string jsonUser =
                HttpContext.User.FindFirst(x => x.Type == "UserData")
                .Value;
            Usuario usuario =
                JsonConvert.DeserializeObject<Usuario>(jsonUser);
            List<Compra> compras =
                await this.repo.GetComprasUsuarioAsync
                (usuario.IdUsuario);
            return compras;
        }
    }
}
