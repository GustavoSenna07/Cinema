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
    public class FilmesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public FilmesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetFilme()
        {
            var filme = await _context.Filmes.ToListAsync();
            return Ok(filme.Select(f => new FilmeResponseDTO(f)));
        }

        // GET api/filmes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFilme(int id)
        {
            var filme = await _context.Filmes.FindAsync(id);
            if (filme == null)
                return NotFound("Filme não encontrado");

            return Ok(new FilmeResponseDTO(filme));
        }

        // POST api/filmes
        [HttpPost]
        public async Task<IActionResult> CreateFilme([FromBody] CriarFilmeDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var filme = new Filme
            {
                Titulo = dto.Titulo,
                Genero = dto.Genero,
                Diretor = dto.Diretor,
                Estudio = dto.Estudio,
                DataLancamento = dto.DataLancamento,
                DuracaoMinutos = dto.DuracaoMinutos,
                Classificacao = dto.Classificacao,
                Sinopse = dto.Sinopse,
                ImagemURL = dto.ImagemURL,
                Elenco = dto.Elenco
            };

            _context.Filmes.Add(filme);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetFilme), new { id = filme.Id }, new FilmeResponseDTO(filme));
        }

        // PUT api/filmes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFilme(int id, [FromBody] AtualizarFilmeDTO dto)
        {
            var filme = await _context.Filmes.FindAsync(id);
            if (filme == null)
                return NotFound("Filme não encontrado");

            filme.Titulo = dto.Titulo;
            filme.Genero = dto.Genero;
            filme.Diretor = dto.Diretor;
            filme.Estudio = dto.Estudio;
            filme.DataLancamento = dto.DataLancamento;
            filme.DuracaoMinutos = dto.DuracaoMinutos;
            filme.Classificacao = dto.Classificacao;
            filme.Sinopse = dto.Sinopse;
            filme.ImagemURL = dto.ImagemURL;
            filme.Elenco = dto.Elenco;

            await _context.SaveChangesAsync();

            return Ok(new FilmeResponseDTO(filme));
        }

        // DELETE api/flmes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFilme(int id)
        {
            var filme = await _context.Filmes.FindAsync(id);
            if (filme == null)
                return NotFound("Filme não encontrado");

            _context.Filmes.Remove(filme);
            await _context.SaveChangesAsync();

            return Ok("Filme removido com sucesso.");
        }
    }
}
