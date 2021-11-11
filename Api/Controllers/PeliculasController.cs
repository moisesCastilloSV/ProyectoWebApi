﻿using Api.CTX;
using Api.DTOs;
using Api.DTOs.Pelicula;
using Api.Helpers;
using Api.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/peliculas")]
    public class PeliculasController : ControllerBase
    {
        private readonly ApiCTX context;
        private readonly IMapper mapper;

        public PeliculasController(ApiCTX context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<PeliculaDTO>>> Get()
        {
            var entidades = await context.Peliculas.ToListAsync();
            return mapper.Map<List<PeliculaDTO>>(entidades);

        }

        [HttpGet("peliculadetalles/{id:int}", Name = "obtenerPeliculaDetalles")]
        public async Task<ActionResult<PeliculasDetallesDTO>> GetPeliculasActores(int id)
        {
            var entidad = await context.Peliculas
                                .Include(x=>x.PeliculaActores).ThenInclude(x=> x.Actor)
                                .FirstOrDefaultAsync(x => x.ID == id);
            if (entidad == null) { return NotFound(); }
            entidad.PeliculaActores=entidad.PeliculaActores.OrderBy(x=>x.Orden).ToList();//devuelve los actores en el orden guardado
            return mapper.Map<PeliculasDetallesDTO>(entidad);

        }

 




        [HttpGet("{id:int}", Name = "obtenerPelicula")]
        public async Task<ActionResult<PeliculaDTO>> Get(int id)
        {
            var entidad = await context.Peliculas.FirstOrDefaultAsync(x => x.ID == id);
            if (entidad == null) { return NotFound(); }
            return mapper.Map<PeliculaDTO>(entidad);
             
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PeliculaCreacionDTO peliculaCreacionDTO)
        {
            var entidad = mapper.Map<Pelicula>(peliculaCreacionDTO);

            if (peliculaCreacionDTO.Actors == null)
            {
                return BadRequest("No se puede crear un libro sin autores");
            }                       
            context.Add(entidad);
            await context.SaveChangesAsync();
            var peliculaDTO = mapper.Map<PeliculaDTO>(entidad);
            return new CreatedAtRouteResult("obtenerPelicula", new { id = peliculaDTO.ID }, peliculaDTO);
            //return Ok();


        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] PeliculaCreacionDTO peliculaCreacionDTO)
        {
            var entidad = mapper.Map<Pelicula>(peliculaCreacionDTO);
            entidad.ID = id;
            context.Entry(entidad).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await context.Peliculas.AnyAsync(x => x.ID == id);
            if (!existe)
            {
                return NotFound();
            }
            context.Remove(new Pelicula() { ID = id });
            await context.SaveChangesAsync();

            return NoContent();
        }

    }
}
