using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using backend.Data;
using backend.Models;
using backend.DTOs;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SalasController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetSala()
        {
            var sala = await _context.Salas.ToListAsync();
            return Ok(sala.Select(s => new SalaResponseDTO(s)));
        }

        // GET api/sala/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSala(int id)
        {
            var sala = await _context.Salas.FindAsync(id);
            if (sala == null)
                return NotFound("Sala não encontrada");

            return Ok(new SalaResponseDTO(sala));
        }

        // POST api/sala
        [HttpPost]
        public async Task<IActionResult> CreateSala([FromBody] CriarSalaDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var sala = new Salas
            {
                Numero = dto.Numero,
                Capacidade = dto.Capacidade,
                TipoSala = dto.TipoSala
            };

            _context.Salas.Add(sala);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSala), new { id = sala.Id }, new SalaResponseDTO(sala));
        }

        // PUT api/sala/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSala(int id, [FromBody] AtualizarSalaDTO dto)
        {
            var sala = await _context.Salas.FindAsync(id);
            if (sala == null)
                return NotFound("Sala não encontrada");

            sala.Numero = dto.Numero;
            sala.Capacidade = dto.Capacidade;
            sala.TipoSala = dto.TipoSala;

            await _context.SaveChangesAsync();

            return Ok(new SalaResponseDTO(sala));
        }

        // DELETE api/sala/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSala(int id)
        {
            var sala = await _context.Salas.FindAsync(id);
            if (sala == null)
                return NotFound("Sala não encontrada");

            _context.Salas.Remove(sala);
            await _context.SaveChangesAsync();

            return Ok("Sala removida com sucesso.");
        }
    }
}
