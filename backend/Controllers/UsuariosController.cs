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

        public static bool CpfValido(string cpf)
        {
            if (string.IsNullOrWhiteSpace(cpf))
                return false;
           
            if (cpf.Distinct().Count() == 1)
                return false;

            // remove pontos, traços, letras, etc.
            cpf = new string(cpf.Where(char.IsDigit).ToArray());

            return cpf.Length == 11;
        }


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

            var emailExiste = await _context.Usuarios.AnyAsync(u => u.Email == dto.Email);
            if (emailExiste)
                return BadRequest("Já existe um usuário com esse Email.");

            var cpfExiste = await _context.Usuarios.AnyAsync(u => u.CPF == dto.CPF);
            if (cpfExiste)
                return BadRequest("Já existe um usuário com esse CPF.");

            if (!CpfValido(dto.CPF))
                return BadRequest("CPF inválido.");

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

    if (dto.Email is not null)
    {
        if (await _context.Usuarios.AnyAsync(u => u.Email == dto.Email && u.Id != id))
            return BadRequest("Já existe um usuário com esse Email.");
    }

    if (dto.CPF is not null)
    {
        string cpfSomenteDigitos = new string(dto.CPF.Where(char.IsDigit).ToArray());

        if (await _context.Usuarios.AnyAsync(u => u.CPF == cpfSomenteDigitos && u.Id != id))
            return BadRequest("Já existe um usuário com esse CPF.");
    }
    
    if (dto.Nome is not null)
    {
        if (string.IsNullOrWhiteSpace(dto.Nome))
            return BadRequest("Nome não pode ser vazio.");

        usuario.Nome = dto.Nome;
    }

    if (dto.Email is not null)
    {
        if (string.IsNullOrWhiteSpace(dto.Email))
            return BadRequest("Email não pode ser vazio.");

        usuario.Email = dto.Email;
    }

    if (dto.CPF is not null)
    {
        if (string.IsNullOrWhiteSpace(dto.CPF))
            return BadRequest("CPF não pode ser vazio.");

        if (!CpfValido(dto.CPF))
            return BadRequest("CPF deve conter apenas números e ter 11 dígitos!");

        usuario.CPF = new string(dto.CPF.Where(char.IsDigit).ToArray());
    }

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
