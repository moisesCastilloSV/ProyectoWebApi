using Api.CTX;
using Api.DTOs.Actor;
using Api.Models;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/actores")]
    public class ActoresController : ControllerBase
    {

        private readonly ApiCTX context;
        private readonly IMapper mapper;

        public ActoresController(ApiCTX context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<ActorDTO>>> Get()
        {
            var entidades = await context.Actors.ToListAsync();
            var dtos = mapper.Map<List<ActorDTO>>(entidades);
            return dtos;
        }

        [HttpGet("{id:int}", Name = "obtenerActor")]
        public async Task<ActionResult<ActorDTO>> Get(int id)
        {
            var entidad = await context.Actors.FirstOrDefaultAsync(x => x.ID == id);
            if (entidad == null) { return NotFound(); }
            var dtos = mapper.Map<ActorDTO>(entidad);
            return dtos;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ActorCreacionDTO actorCreacionDTO)
        {
            var entidad = mapper.Map<Actor>(actorCreacionDTO);
            context.Add(entidad);
            await context.SaveChangesAsync();
            var actorDTO = mapper.Map<ActorDTO>(entidad);
            return new CreatedAtRouteResult("obtenerActor", new { id = actorDTO.ID }, actorDTO);


        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] ActorCreacionDTO actorCreacionDTO)
        {
            var entidad = mapper.Map<Actor>(actorCreacionDTO);
            entidad.ID = id;
            context.Entry(entidad).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await context.Actors.AnyAsync(x => x.ID == id);
            if (!existe)
            {
                return NotFound();
            }
            context.Remove(new Actor() { ID = id });
            await context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult>Patch(int id ,[FromBody]JsonPatchDocument<ActorPatchDTO> patchDocument)
        {
            if (patchDocument == null) { return BadRequest(); }

            var entidadDB= await context.Actors.FirstOrDefaultAsync(x => x.ID == id);
            if (entidadDB == null) { return NotFound(); }

            var entidadDTO=mapper.Map<ActorPatchDTO>(entidadDB);
            patchDocument.ApplyTo(entidadDTO, ModelState);

            var esValido=TryValidateModel(entidadDTO);
            if (!esValido) { return BadRequest(ModelState); }

            mapper.Map(entidadDTO, entidadDB);
            await context.SaveChangesAsync();
            return NoContent();
        }


    }
}
