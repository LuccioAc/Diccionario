using dictapi.Dtos;
using dictapi.Interfaces;
using dictapi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace dictapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")] // Solo accesible por administradores
    public class UsuariosController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UsuariosController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // GET: api/Usuarios
        [HttpGet]
        public ActionResult<IEnumerable<UserDtos>> GetUsuarios()
        {
            var usuarios = _userRepository.GetAll();
            return Ok(usuarios);
        }

        // GET: api/Usuarios/5
        [HttpGet("{id}")]
        public ActionResult<UserDtos> GetUsuario(long id)
        {
            var usuario = _userRepository.GetById(id);
            if (usuario == null)
                return NotFound();

            return Ok(usuario);
        }

        // POST: api/Usuarios
        [HttpPost]
        public IActionResult PostUsuario(UserAdminCreateDto dto)
        {
            _userRepository.AddByAdmin(dto);
            return Ok(new { message = "Usuario creado exitosamente" });
        }

        // PUT: api/Usuarios
        [HttpPut]
        public IActionResult PutUsuario(UserAdminUpdateDto dto)
        {
            if (dto == null)
                return BadRequest(new { message = "DTO es nulo" });

            var actualizado = _userRepository.UpdateByAdmin(dto);

            if (!actualizado)
                return NotFound(new { message = "Usuario no encontrado" });

            return Ok(new { message = "Usuario actualizado exitosamente" });
        }

        // DELETE: api/Usuarios/5
        [HttpDelete("{id}")]
        public IActionResult DeleteUsuario(long id)
        {
            var usuario = _userRepository.GetById(id);
            if (usuario == null)
                return NotFound(new { message = "Usuario no encontrado" });

            _userRepository.Delete(id);
            return Ok(new { message = "Usuario eliminado exitosamente" });
        }
    }
}
