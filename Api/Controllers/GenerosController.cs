using Api.CTX;
using Api.DTOs.Genero;
using Api.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers;

[ApiController]
[Route("api/generos")]
public class GenerosController : ControllerBase
{
    private readonly ApiCTX context;
    private readonly IMapper mapper;

    public GenerosController(ApiCTX context,IMapper mapper)
    {
        this.context = context;
        this.mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<List<GeneroDTO>>> Get()
    {
        var entidades= await context.Generos.ToListAsync();
        var dtos = mapper.Map <List<GeneroDTO>>(entidades);
        return dtos;
    }
    [HttpGet("{id:int}", Name="obtenerGenero")]
    public async Task<ActionResult<GeneroDTO>> Get(int id)
    {
         var entidad = await context.Generos.FirstOrDefaultAsync(x=> x.ID == id);
        if (entidad == null) { return NotFound(); }
        var dtos = mapper.Map<GeneroDTO>(entidad);
        return dtos;
    }

    [HttpPost]
    public  async Task<ActionResult>Post([FromBody] GeneroCreacionDTO generoCreacionDTO)
    {
        var entidad =mapper.Map<Genero>(generoCreacionDTO);
        context.Add(entidad);
        await context.SaveChangesAsync();
        var generoDTO = mapper.Map<GeneroDTO>(entidad);
        return new CreatedAtRouteResult("obtenerGenero", new { id = generoDTO.ID }, generoDTO);


    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, [FromBody] GeneroCreacionDTO generoCreacionDTO)
    {
        var entidad = mapper.Map<Genero>(generoCreacionDTO);
        entidad.ID= id;
        context.Entry(entidad).State = EntityState.Modified;
        await context.SaveChangesAsync(); 
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var existe= await context.Generos.AnyAsync(x=>x.ID==id);
        if (!existe)
        {
            return NotFound();
        }
        context.Remove(new Genero() { ID=id});
        await context.SaveChangesAsync();

        return NoContent();
    }

}
 