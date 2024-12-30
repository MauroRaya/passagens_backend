using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using passagens_backend.Data;
using passagens_backend.Models;
using passagens_backend.ViewModels;
using System.Data;

namespace passagens_backend.Controllers
{
    [ApiController]
    public class PassagensController : ControllerBase
    {
        [Authorize(Roles = "Admin")]
        [HttpPost("/api/passagens")]
        public async Task<IActionResult> PostPassagem(
            [FromServices] AppDbContext context, 
            [FromBody] CreateAndUpdatePassagem passagem)
        {
            var novaPassagem = new Passagem
            {
                Origem = passagem.Origem,
                Destino = passagem.Destino,
                DataChegada = passagem.DataChegada,
                DataPartida = passagem.DataPartida,
                Preco = passagem.Preco,
                CompanhiaAerea = passagem.CompanhiaAerea,
                StatusReservada = passagem.StatusReservada
            };

            await context.Passagens.AddAsync(novaPassagem);
            await context.SaveChangesAsync();

            return Created($"/{novaPassagem.Id}", passagem);
        }

        [Authorize(Roles = "Admin,Cliente")]
        [HttpGet("/api/passagens")]
        public async Task<IActionResult> GetPassagens(
            [FromServices] AppDbContext context,
            [FromQuery] int page = 0,
            [FromQuery] int pageSize = 6,
            [FromQuery] string sort = "...")
        {
            var count = await context.Passagens.CountAsync();

            IQueryable<Passagem> query = context.Passagens.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(sort))
            {
                if      (sort == "ASC")  query = query.OrderBy(p => p.Preco);
                else if (sort == "DESC") query = query.OrderByDescending(p => p.Preco);
            }

            var passagens = await query
                .Skip(page * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return Ok(new
            {
                count,
                page,
                pageSize,
                passagens
            });
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("/api/passagens/{id:int}")]
        public async Task<IActionResult> PutPassagem(
            [FromServices] AppDbContext context,
            [FromRoute] int id,
            [FromBody] CreateAndUpdatePassagem passagem)
        {
            var passagemDB = await context.Passagens.FindAsync(id);

            if (passagemDB is null) 
                return BadRequest("Passagem com esse ID não existe");

            passagemDB.Origem = passagem.Origem;
            passagemDB.Destino = passagem.Destino;
            passagemDB.DataPartida = passagem.DataPartida;
            passagemDB.DataChegada = passagem.DataChegada;
            passagemDB.Preco = passagem.Preco;
            passagemDB.CompanhiaAerea = passagem.CompanhiaAerea;
            passagemDB.StatusReservada = passagem.StatusReservada;

            await context.SaveChangesAsync();

            return NoContent();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("/api/passagens/{id:int}")]
        public async Task<IActionResult> DeletePassagem(
            [FromServices] AppDbContext context,
            [FromRoute] int id)
        {
            var passagemDB = await context.Passagens.FindAsync(id);

            if (passagemDB is null) 
                return BadRequest("Passagem com esse ID não existe");

            context.Passagens.Remove(passagemDB);
            await context.SaveChangesAsync();

            return NoContent();
        }
    }
}
