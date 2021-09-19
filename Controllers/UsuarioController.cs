using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SaudeMais.Data;
using SaudeMais.Models;
using System;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using SaudeMais.Services;

namespace Backoffice.Controllers
{
    [Route("v1/usuarios")]
    public class UsuarioController : Controller
    {
        [HttpGet]
        [Route("")]
        [AllowAnonymous]
        public async Task<ActionResult<List<Usuario>>> Get([FromServices] DataContext context)
        {
            var usuarios = await context
                .Usuarios
                .AsNoTracking()
                .ToListAsync();
            return usuarios;
        }

        [HttpPost]
        [Route("")]
        [AllowAnonymous]
        // [Authorize(Roles = "manager")]
        public async Task<ActionResult<Usuario>> Post(
            [FromServices] DataContext context,
            [FromBody]Usuario model)
        {
            // Verifica se os dados são válidos
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                context.Usuarios.Add(model);
                await context.SaveChangesAsync();

                // Esconde a senha
                model.Senha = "";
                return model;
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possível criar o usuário" });

            }
        }

        [HttpPut]
        [Route("{id:int}")]
        [AllowAnonymous]
        public async Task<ActionResult<Usuario>> Put(
            [FromServices] DataContext context,
            int id,
            [FromBody]Usuario model)
        {
            // Verifica se os dados são válidos
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Verifica se o ID informado é o mesmo do modelo
            if (id != model.Id)
                return NotFound(new { message = "Usuário não encontrado" });

            try
            {
                context.Entry(model).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return model;
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possível criar o usuário" });

            }
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Authenticate(
                    [FromServices] DataContext context,
                    [FromBody]Usuario model)
        {
            var usuario = await context.Usuarios
                .AsNoTracking()
                .Where(x => x.NomeUsuario == model.NomeUsuario && x.Senha == model.Senha)
                .FirstOrDefaultAsync();

            if (usuario == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            var token = TokenService.GenerateToken(usuario);
            // Esconde a senha
            usuario.Senha = "";
            return new
            {
                usuario = usuario,
                token = token
            };
        }
    }
}