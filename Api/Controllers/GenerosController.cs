using Api.CTX;
using Api.DTOs;
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


}
 