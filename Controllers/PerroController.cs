using Microsoft.AspNetCore.Mvc;
using ProtectoraAPI.Repositories;
using Models;

namespace ProtectoraAPI.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class PerroController : ControllerBase
   {
       private readonly IPerroRepository _repository;

       public PerroController(IPerroRepository repository)
       {
           _repository = repository;
       }

       [HttpGet]
       public async Task<ActionResult<List<Perro>>> GetPerros()
       {
           var perros = await _repository.GetAllAsync();
           return Ok(perros);
       }

       [HttpGet("{id}")]
       public async Task<ActionResult<Perro>> GetPerro(int id)
       {
           var perro = await _repository.GetByIdAsync(id);
           if (perro == null)
           {
               return NotFound();
           }
           return Ok(perro);
       }

       [HttpPost]
       public async Task<ActionResult<Perro>> CreatePerro(Perro perro)
       {
           await _repository.AddAsync(perro);
           return CreatedAtAction(nameof(GetPerro), new { id = perro.Id_Perro }, perro);
       }

       [HttpPut("{id}")]
       public async Task<IActionResult> UpdatePerro(int id, Perro updatedPerro)
       {
           var existingPerro = await _repository.GetByIdAsync(id);
           if (existingPerro == null)
           {
               return NotFound();
           }

           existingPerro.Nombre_Perro = updatedPerro.Nombre_Perro;
           existingPerro.Raza = updatedPerro.Raza;
           existingPerro.Edad = updatedPerro.Edad;
           existingPerro.Esterilizado = updatedPerro.Esterilizado;
           existingPerro.Sexo = updatedPerro.Sexo;
           existingPerro.Descripcion_Perro = updatedPerro.Descripcion_Perro;
           existingPerro.Imagen_Perro = updatedPerro.Imagen_Perro;

           await _repository.UpdateAsync(existingPerro);
           return NoContent();
       }

       [HttpDelete("{id}")]
       public async Task<IActionResult> DeletePerro(int id)
       {
           var perro = await _repository.GetByIdAsync(id);
           if (perro == null)
           {
               return NotFound();
           }
           await _repository.DeleteAsync(id);
           return NoContent();
       }
   }
}
