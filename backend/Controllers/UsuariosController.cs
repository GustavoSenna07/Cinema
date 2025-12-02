using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backend.Data;
using backend.Models;
using backend.Services;
using backend.DTOs;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IPasswordHasher _passwordHasher;

        public UsuariosController(AppDbContext context, IPasswordHasher passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }

        // GET api/usuarios
        [HttpGet]
        public async Task<IActionResult> GetUsuarios()
        {
            var usuarios = await _context.Usuarios.ToListAsync();
            return Ok(usuarios.Select(u => new UsuarioResponseDTO(u)));
        }

        // GET api/usuarios/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUsuario(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
                return NotFound("Usuário não encontrado");

            return Ok(new UsuarioResponseDTO(usuario));
        }

        // POST api/usuarios
        [HttpPost]
        public async Task<IActionResult> CreateUsuario([FromBody] CriarUsuarioDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var usuario = new Usuarios
            {
                Nome = dto.Nome,
                Email = dto.Email,
                CPF = dto.CPF,
                DataCadastro = DateTime.UtcNow,
                Senha = _passwordHasher.HashSenha(dto.Senha)
            };

            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUsuario), new { id = usuario.Id }, new UsuarioResponseDTO(usuario));
        }

        // PUT api/usuarios/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUsuario(int id, [FromBody] AtualizarUsuarioDTO dto)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
                return NotFound("Usuário não encontrado");

            usuario.Nome = dto.Nome;
            usuario.Email = dto.Email;
            usuario.CPF = dto.CPF;

            await _context.SaveChangesAsync();

            return Ok(new UsuarioResponseDTO(usuario));
        }

        // DELETE api/usuarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
                return NotFound("Usuário não encontrado");

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();

            return Ok("Usuário removido com sucesso.");
        }
    }
}
