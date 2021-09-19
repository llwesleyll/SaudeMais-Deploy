using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SaudeMais.Data;
using SaudeMais.Models;
using System;
using Microsoft.AspNetCore.Authorization;

namespace Backoffice.Controllers
{
    [Route("v1/servicos")]
    public class ServicosController : Controller
    {
        [HttpGet]
        [Route("")]
        [AllowAnonymous]
        [ResponseCache(VaryByHeader = "User-Agent", Location = ResponseCacheLocation.Any, Duration = 30)]
        // [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<ActionResult<List<Servico>>> Get([FromServices] DataContext context)
        {
            var servico = await context.Servicos.AsNoTracking().ToListAsync();
            return servico;
        }

        [HttpGet]
        [Route("{id:int}")]
        [AllowAnonymous]
        public async Task<ActionResult<Servico>> GetById([FromServices] DataContext context, int id)
        {
            var servico = await context.Servicos.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            return servico;
        }

        [HttpPost]
        [Route("")]
        // [Authorize(Roles = "employee")]
        [AllowAnonymous]
        public async Task<ActionResult<Servico>> Post(
            [FromServices] DataContext context,
            [FromBody]Servico model)
        {
            // Verifica se os dados são válidos
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                context.Servicos.Add(model);
                await context.SaveChangesAsync();
                return model;
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possível criar o serviço" });

            }
        }

        [HttpPut]
        [Route("{id:int}")]
        [AllowAnonymous]
        public async Task<ActionResult<Servico>> Put(
            [FromServices] DataContext context,
            int id,
            [FromBody]Servico model)
        {
            // Verifica se o ID informado é o mesmo do modelo
            if (id != model.Id)
                return NotFound(new { message = "Serviço não encontrado" });

            // Verifica se os dados são válidos
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                context.Entry<Servico>(model).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return model;
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest(new { message = "Não foi possível atualizar o serviço" });

            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        [AllowAnonymous]
        public async Task<ActionResult<Servico>> Delete(
            [FromServices] DataContext context,
            int id)
        {
            var servico = await context.Servicos.FirstOrDefaultAsync(x => x.Id == id);
            if (servico == null)
                return NotFound(new { message = "Serviço não encontrado" });

            try
            {
                context.Servicos.Remove(servico);
                await context.SaveChangesAsync();
                return servico;
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possível remover o serviço" });

            }
        }
    }
}