using Microsoft.AspNetCore.Mvc;
using dictapi.Dtos;
using dictapi.Interfaces;
using dictapi.Services;
using Microsoft.AspNetCore.Authorization;

namespace dictapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly JWTService _jwtService;
        private readonly IUserRepository _userRepository; // Debes tener una interfaz para acceder a usuarios

        public AuthController(JWTService jwtService, IUserRepository userRepository)
        {
            _jwtService = jwtService;
            _userRepository = userRepository;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] UserLoginDto loginDto)
        {
            // Busca el usuario en la base de datos
            var user = _userRepository.GetByCodeAndPassword(loginDto.Codeusr, loginDto.Passw);

            if (user == null)
                return Unauthorized(new { message = "Credenciales inválidas" });

            // Genera el token JWT
            var token = _jwtService.GenerateToken(user.Codeusr, user.Rol);

            return Ok(new
            {
                token,
                user
            });
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterUserDto dto)
        {
            var codeusr = _userRepository.Add(dto);
            return Ok(new { codeusr });
        }


        [Authorize]
        [HttpPut("update")]
        public IActionResult UpdateUser([FromBody] UpdateUserDto dto)
        {
            var codeusr = User.Identity?.Name;
            if (codeusr == null) return Unauthorized();

            var user = _userRepository.GetByCodeAndPassword(codeusr, dto.Passw);
            if (user == null) return Unauthorized("Contraseña incorrecta");

            _userRepository.Update(user.Idusr, dto);
            return Ok();
        }

        [Authorize]
        [HttpDelete("delete")]
        public IActionResult DeleteUser([FromBody] UserDeleteDto dto)
        {
            var codeusr = User.Identity?.Name;
            if (codeusr == null) return Unauthorized();

            var eliminado = _userRepository.DeleteByCodeAndPassword(codeusr, dto.Passw);
            return eliminado ? Ok() : BadRequest("No se pudo eliminar el usuario");
        }

    }
}