using Microsoft.AspNetCore.Mvc;
using ProtectoraAPI.Repositories;
using Models;

namespace ProtectoraAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConejoController : ControllerBase
    {
        private readonly IConejoRepository _repository;

        public ConejoController(IConejoRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Conejo>>> GetConejos()
        {
            var conejos = await _repository.GetAllAsync();
            return Ok(conejos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Conejo>> GetConejo(int id)
        {
            var conejo = await _repository.GetByIdAsync(id);
            if (conejo == null)
            {
                return NotFound();
            }
            return Ok(conejo);
        }

        [HttpPost]
        public async Task<ActionResult<Conejo>> CreateConejo(Conejo conejo)
        {
            await _repository.AddAsync(conejo);
            return CreatedAtAction(nameof(GetConejo), new { id = conejo.Id_Conejo }, conejo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateConejo(int id, Conejo updatedConejo)
        {
            var existingConejo = await _repository.GetByIdAsync(id);
            if (existingConejo == null)
            {
                return NotFound();
            }

            existingConejo.Nombre_Conejo = updatedConejo.Nombre_Conejo;
            existingConejo.Raza = updatedConejo.Raza;
            existingConejo.Edad = updatedConejo.Edad;
            existingConejo.Sexo = updatedConejo.Sexo;
            existingConejo.Imagen_Conejo = updatedConejo.Imagen_Conejo;

            await _repository.UpdateAsync(existingConejo);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConejo(int id)
        {
            var existingConejo = await _repository.GetByIdAsync(id);
            if (existingConejo == null)
            {
                return NotFound();
            }

            await _repository.DeleteAsync(id);
            return NoContent();
        }
    }
}