using AulaCrud.Context;
using AulaCrud.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AulaCrud.Controllers;

[ApiController]
[Route("Controller")]

public class MovieController : ControllerBase
{

    private readonly MovieContext _context;

    public MovieController(MovieContext context)
    {
        _context = context;
    }
    [HttpGet]
    public IActionResult Get()
    {
        var movies = _context.Movies.ToList();
        return Ok(movies);
    }

    [HttpGet]
    [Route("{id}")]
    public IActionResult Get(int id)
    {
        var movies = _context.Movies.FirstOrDefault(x => x.Id.Equals(id));
        return Ok(movies);
    }

    [HttpPost]
    public IActionResult Create([FromBody] Movie movie)
    {
        _context.Movies.Add(movie);
        _context.SaveChanges();

        return CreatedAtAction(nameof(MovieController.Get), new { id = movie.Id }, movie);
    }

    // [HttpPut]
    // [Route("id")]
    // public IActionResult Edit(int id, [FromBody] Movie movieAtualizado)
    // {
    //     var movie = _context.Movies.FirstOrDefault(x => x.Id.Equals(id));

    //     if (movie == null)
    //     {
    //         return NotFound();
    //     }
    //     movie.Titulo = movieDto
    // }


    //TEACHER RALF LIMA

    [HttpPost("Salvar")]
    public async Task<ActionResult> cadastrar([FromBody] Movie mo)
    {
        _context.Movies.Add(mo);
        await _context.SaveChangesAsync();

        return Created("Objeto filme", mo);
    }

    [HttpGet("Obter")]
    public async Task<ActionResult> listar()
    {
        var dados = await _context.Movies.ToListAsync();

        return Ok(dados);

    }

    [HttpGet("ObterPorId{id}")]
    public Movie filtrar(int id)
    {
        Movie mo = _context.Movies.Find(id);
        return mo;
    }

    [HttpPut("Editar")]
    public async Task<ActionResult> editar([FromBody] Movie mo)
    {
        _context.Movies?.Update(mo);
        await _context.SaveChangesAsync();
        return Ok(mo);
    }

    [HttpDelete("Apagar/{id}")]
    public async Task<ActionResult> remover(int id)
    {
        Movie mo = filtrar(id);
        if (mo == null)
        {
            return NotFound("Filme não encontrado");
        }
        else
        {
            _context.Movies.Remove(mo);
            await _context.SaveChangesAsync();
            return Ok();
        }

    }
}










