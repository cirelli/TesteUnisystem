using API.DTO;
using AutoMapper;
using Contracts;
using Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IRepositoryWrapper repository;
        private readonly IMapper mapper;

        public UsuariosController(IRepositoryWrapper repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<Usuario>>> GetAll(CancellationToken cancellationToken)
        {
            var result = await repository.Usuario.GetAllAsync(cancellationToken);
            return Ok(result);
        }

        [HttpGet("{id}", Name = "UsuarioById")]
        public async Task<ActionResult<Usuario>> GetById(int id, CancellationToken cancellationToken)
        {
            var entity = await repository.Usuario.GetByIdAsync(id, cancellationToken);

            if (entity is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(entity);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Usuario>> Create([FromBody] UsuarioDTO usuario, CancellationToken cancellationToken)
        {
            if (usuario is null)
            {
                return BadRequest("Usuário é nulo");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entity = mapper.Map<Usuario>(usuario);
            repository.Usuario.Create(entity);
            await repository.SaveAsync(cancellationToken);
            return CreatedAtRoute("UsuarioById", new { id = entity.Id }, entity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UsuarioDTO usuario, CancellationToken cancellationToken)
        {
            if (usuario is null)
            {
                return BadRequest("Usuário é nulo");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entity = await repository.Usuario.GetByIdAsync(id, cancellationToken);
            if (entity is null)
            {
                return NotFound();
            }

            mapper.Map(usuario, entity);
            repository.Usuario.Update(entity);
            _ = repository.SaveAsync(cancellationToken);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            var entity = await repository.Usuario.GetByIdAsync(id, cancellationToken);

            if (entity == null)
            {
                return NotFound();
            }

            repository.Usuario.Delete(entity);
            _ = repository.SaveAsync(cancellationToken);

            return NoContent();
        }
    }
}
