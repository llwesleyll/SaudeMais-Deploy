using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SaudeMais.Data;
using SaudeMais.Models;

namespace Backoffice.Controllers
{
    [Route("v1")]
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<dynamic>> Get([FromServices] DataContext context)
        {
            var usuario = new Usuario { Id = 1,  NomeUsuario = "Teste", Senha = "1234"};
            var area = new Area { Id = 1, Titulo = "Teste" };
            var profissional = new Profissional { Id = 1, Nome = "Teste", Area = area };
            var servico = new Servico { Id = 1, Usuario = usuario, Profissional = profissional};
            context.Usuarios.Add(usuario);
            context.Areas.Add(area);
            context.Profissionais.Add(profissional);
            context.Servicos.Add(servico);
            await context.SaveChangesAsync();

            return Ok(new
            {
                message = "Dados configurados"
            });
        }
    }
}