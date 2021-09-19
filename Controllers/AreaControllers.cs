using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SaudeMais.Data;
using SaudeMais.Models;
using System;
using Microsoft.AspNetCore.Authorization;

namespace SaudeMais.Controllers
{
    [Route("v1/areas")]
    public class AreaController : Controller
    {
        [HttpGet]
        [Route("")]
        [AllowAnonymous]
        [ResponseCache(VaryByHeader = "User-Agent", Location = ResponseCacheLocation.Any, Duration = 30)]
        // [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<ActionResult<List<Area>>> Get([FromServices] DataContext context)
        {
            var areas = await context.Areas.AsNoTracking().ToListAsync();
            return areas;
        }

        [HttpGet]
        [Route("{id:int}")]
        [AllowAnonymous]
        public async Task<ActionResult<Area>> GetById([FromServices] DataContext context, int id)
        {
            var area = await context.Areas.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            return area;
        }

        [HttpPost]
        [Route("")]
        // [Authorize(Roles = "employee")]
        [AllowAnonymous]
        public async Task<ActionResult<Area>> Post(
            [FromServices] DataContext context,
            [FromBody]Area model)
        {
            // Verifica se os dados são válidos
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                context.Areas.Add(model);
                await context.SaveChangesAsync();
                return model;
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possível criar a área" });

            }
        }

        [HttpPut]
        [Route("{id:int}")]
        [AllowAnonymous]
        public async Task<ActionResult<Area>> Put(
            [FromServices] DataContext context,
            int id,
            [FromBody]Area model)
        {
            // Verifica se o ID informado é o mesmo do modelo
            if (id != model.Id)
                return NotFound(new { message = "Área não encontrada" });

            // Verifica se os dados são válidos
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                context.Entry<Area>(model).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return model;
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest(new { message = "Não foi possível atualizar a área" });

            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        [AllowAnonymous]
        public async Task<ActionResult<Area>> Delete(
            [FromServices] DataContext context,
            int id)
        {
            var area = await context.Areas.FirstOrDefaultAsync(x => x.Id == id);
            if (area == null)
                return NotFound(new { message = "Área não encontrada" });

            try
            {
                context.Areas.Remove(area);
                await context.SaveChangesAsync();
                return area;
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possível remover a área" });

            }
        }
    }
}