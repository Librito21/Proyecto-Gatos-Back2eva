using Microsoft.AspNetCore.Mvc;
using ProtectoraAPI.Repositories;
using Models;

namespace ProtectoraAPI.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class UsuarioController : ControllerBase
   {
       private readonly IUsuarioRepository _repository;

       public UsuarioController(IUsuarioRepository repository)
       {
           _repository = repository;
       }

       [HttpGet]
       public async Task<ActionResult<List<Usuario>>> GetUsuarios()
       {
           var usuarios = await _repository.GetAllAsync();
           return Ok(usuarios);
       }

       [HttpGet("{id}")]
       public async Task<ActionResult<Usuario>> GetUsuario(int id)
       {
           var usuario = await _repository.GetByIdAsync(id);
           if (usuario == null)
           {
               return NotFound();
           }
           return Ok(usuario);
       }

       [HttpPost]
       public async Task<ActionResult<Usuario>> CreateUsuario(Usuario usuario)
       {
           await _repository.AddAsync(usuario);
           return CreatedAtAction(nameof(GetUsuario), new { id = usuario.Id_Usuario }, usuario);
       }

       [HttpPut("{id}")]
       public async Task<IActionResult> UpdateUsuario(int id, Usuario updatedUsuario)
       {
           var existingUsuario = await _repository.GetByIdAsync(id);
           if (existingUsuario == null)
           {
               return NotFound();
           }

           existingUsuario.Nombre = updatedUsuario.Nombre;
           existingUsuario.Apellido = updatedUsuario.Apellido;
           existingUsuario.Email = updatedUsuario.Email;
           existingUsuario.Fecha_Registro = updatedUsuario.Fecha_Registro;

           await _repository.UpdateAsync(existingUsuario);
           return NoContent();
       }

       [HttpDelete("{id}")]
       public async Task<IActionResult> DeleteUsuario(int id)
       {
           var usuario = await _repository.GetByIdAsync(id);
           if (usuario == null)
           {
               return NotFound();
           }
           await _repository.DeleteAsync(id);
           return NoContent();
       }
   }
}
