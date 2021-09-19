using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SaudeMais.Data;
using SaudeMais.Models;
using Microsoft.AspNetCore.Authorization;

namespace Backoffice.Controllers
{
    [Route("v1/profissionais")]
    public class ProfissionaisController : Controller
    {
        [HttpGet]
        [Route("")]
        [AllowAnonymous]
        public async Task<ActionResult<List<Profissional>>> Get([FromServices] DataContext context)
        {
            var profissionais = await context.Profissionais.Include(x => x.Area).AsNoTracking().ToListAsync();
            return profissionais;
        }

        [HttpGet]
        [Route("{id:int}")]
        [AllowAnonymous]
        public async Task<ActionResult<Profissional>> GetById([FromServices] DataContext context, int id)
        {
            var profissional = await context.Profissionais.Include(x => x.Area).AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            return profissional;
        }

        [HttpGet]
        [Route("areas/{id:int}")]
        [AllowAnonymous]
        public async Task<ActionResult<List<Profissional>>> GetByArea([FromServices] DataContext context, int id)
        {
            var profissionais = await context.Profissionais.Include(x => x.Area).AsNoTracking().Where(x => x.AreaId == id).ToListAsync();
            return profissionais;
        }

        [HttpPost]
        [Route("")]
        [AllowAnonymous]
        public async Task<ActionResult<Profissional>> Post(
            [FromServices] DataContext context,
            [FromBody]Profissional model)
        {
            if (ModelState.IsValid)
            {
                context.Profissionais.Add(model);
                await context.SaveChangesAsync();
                return model;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}