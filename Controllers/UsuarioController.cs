using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Connections.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using passagens_backend.Data;
using passagens_backend.Models;
using passagens_backend.Services;
using passagens_backend.ViewModels;

namespace passagens_backend.Controllers
{
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpPost("/api/account/registrar")]
        public async Task<IActionResult> PostRegistrar(
            [FromServices] AppDbContext context,
            [FromServices] TokenService tokenService,
            [FromBody] CreateAndUpdateUsuario usuario)
        {
            var usuarioDB = await context.Usuarios.FirstOrDefaultAsync(u => u.Email == usuario.Email);

            if (usuarioDB != null) 
                return StatusCode(401, "Email já está cadastrado");

            var novoUsuario = new Usuario()
            {
                Nome = usuario.Nome,
                Email = usuario.Email,
                Senha = Settings.GenerateHash(usuario.Senha),
                Role = "Cliente"
            };

            await context.Usuarios.AddAsync(novoUsuario);
            await context.SaveChangesAsync();

            try
            {
                var token = tokenService.GenerateToken(novoUsuario);

                return Ok(new
                {
                    userId = novoUsuario.Id,
                    Token = token
                });
            }
            catch (Exception)
            {
                return StatusCode(500, new { message = "Erro ao gerar Token JWT" });
            }
        }

        [HttpPost("/api/account/login")]
        public async Task<IActionResult> PostLogin(
            [FromServices] AppDbContext context,
            [FromServices] TokenService tokenService,
            [FromBody] LoginUsuario usuario)
        {
            var usuarioDB = await context.Usuarios.FirstOrDefaultAsync(u => u.Email == usuario.Email);

            if (usuarioDB is null) 
                return StatusCode(401, "Email ou senha estão incorretos");

            if (usuarioDB.Senha != Settings.GenerateHash(usuario.Senha)) 
                return StatusCode(401, "Email ou senha estão incorretos");

            try
            {
                var token = tokenService.GenerateToken(usuarioDB);

                Console.WriteLine(token);

                return Ok(new
                {
                    userId = usuarioDB.Id,
                    Token  = token
                });
            }
            catch (Exception)
            {
                return StatusCode(500, new { message = "Erro ao gerar Token JWT" });
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("/api/account/usuarios")]
        public async Task<IActionResult> GetUsuarios(
            [FromServices] AppDbContext context,
            [FromQuery] int page = 0,
            [FromQuery] int pageSize = 10)
        {
            var usuarios = await context
                .Usuarios
                .Skip(page * pageSize)
                .Take(pageSize)
                .AsNoTracking()
                .ToListAsync();

            return Ok(usuarios);
        }
    }
}
