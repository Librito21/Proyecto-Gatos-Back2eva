using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net;
using ProtectoraAPI.Services;
using ProtectoraAPI.Repositories;
using Models;

namespace ProtectoraAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IUsuarioRepository _repository;

        public UsuarioController(IUsuarioService usuarioService, IUsuarioRepository repository)
        {
            _usuarioService = usuarioService;
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
            existingUsuario.Telefono = updatedUsuario.Telefono;

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

        // Nuevo endpoint para enviar correos
        [HttpPost("enviar-email")]
        public async Task<IActionResult> EnviarEmail([FromBody] EmailDto emailDto)
        {
            // Obtener el usuario autenticado por su ID
            var usuario = await _usuarioService.GetByIdAsync(emailDto.IdUsuario);
            if (usuario == null)
            {
                return NotFound(new { message = "Usuario no encontrado" });
            }

            try
            {
                var fromAddress = new MailAddress(usuario.Email, $"{usuario.Nombre} {usuario.Apellido}");
                var toAddress = new MailAddress(emailDto.To, "Protectora");
                const string smtpServer = "smtp.gmail.com"; // Cambiar según proveedor
                const int port = 587;
                const string smtpUser = "tuCorreo@gmail.com"; // Cambiar
                const string smtpPass = "tuContraseña"; // Cambiar

                var smtp = new SmtpClient
                {
                    Host = smtpServer,
                    Port = port,
                    EnableSsl = true,
                    Credentials = new NetworkCredential(smtpUser, smtpPass)
                };

                using var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = emailDto.Subject,
                    Body = emailDto.Message
                };

                smtp.Send(message);
                return Ok(new { message = "Correo enviado con éxito" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Error enviando correo", error = ex.Message });
            }
        }
    }

    public class EmailDto
    {
        public int IdUsuario { get; set; } // ID del usuario autenticado
        public string To { get; set; } // Email de la protectora
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}
