using Api.CTX;
using Api.DTOs.Genero;
using Api.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers;

[ApiController]
[Route("api/generos")]
public class GenerosController : CustomBaseController
{
    private readonly ApiCTX context;
    private readonly IMapper mapper;

    public GenerosController(ApiCTX context,IMapper mapper)
        :base(context,mapper)
    {
        this.context = context;
        this.mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<List<GeneroDTO>>> Get()
    {
        return await Get<Genero, GeneroDTO>();
          
    }

    [HttpGet("{id:int}", Name="obtenerGenero")]
    public async Task<ActionResult<GeneroDTO>> Get(int id)
    {
         return await Get<Genero,GeneroDTO>(id);
    }

    [HttpPost]
    public  async Task<ActionResult>Post([FromBody] GeneroCreacionDTO generoCreacionDTO)
    {
        return await Post<GeneroCreacionDTO, Genero, GeneroDTO>(generoCreacionDTO, "obtenerGenero");
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, [FromBody] GeneroCreacionDTO generoCreacionDTO)
    {
        return await Put<GeneroCreacionDTO, Genero>(id, generoCreacionDTO);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        return await Delete<Genero>(id);
    }

}
 