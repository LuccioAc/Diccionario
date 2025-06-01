using dictapi.Dtos;
using dictapi.Interfaces;
using dictapi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace dictapi.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DictdbContext _context;

        public UserRepository(DictdbContext context)
        {
            _context = context;
        }

        public string Add(RegisterUserDto userRegisterDto)
        {
            var hasher = new PasswordHasher<Usuario>();
            var user = new Usuario
            {
                Nameusr = userRegisterDto.Nameusr,
                Rol = false // Por defecto usuario común
            };

            // Hashea la contraseña
            user.Passw = hasher.HashPassword(user, userRegisterDto.Passw);

            _context.Usuarios.Add(user);
            _context.SaveChanges();
            // Procesa el Nameusr para el codeusr
            var processedNameusr = user.Nameusr.ToUpper().Replace(" ", "");
            if (processedNameusr.Length > 10)
                processedNameusr = processedNameusr.Substring(0, 10);

            // Genera codeusr (ej. USERNAME#id)
            user.Codeusr = $"{processedNameusr}#{user.Idusr}";
            _context.SaveChanges();

            return user.Codeusr;
        }

        public void AddByAdmin(UserAdminCreateDto dto)
        {
            var hasher = new PasswordHasher<Usuario>();
            var user = new Usuario
            {
                Nameusr = dto.Nameusr,
                Rol = dto.Rol
            };

            user.Passw = hasher.HashPassword(user, dto.Passw);
            _context.Usuarios.Add(user);
            _context.SaveChanges();

            user.Codeusr = $"{user.Nameusr}#{user.Idusr}";
            _context.SaveChanges();
        }
        //Delete por ID Admin
        public void Delete(long idusr)
        {
            var user = _context.Usuarios.FirstOrDefault(u => u.Idusr == idusr);
            if (user != null)
            {
                _context.Usuarios.Remove(user);
                _context.SaveChanges();
            }
        }

        public bool DeleteByCodeAndPassword(string codeusr, string passw)
        {
            var user = _context.Usuarios.FirstOrDefault(u => u.Codeusr == codeusr);
            if (user == null) return false;

            var hasher = new PasswordHasher<Usuario>();
            var result = hasher.VerifyHashedPassword(user, user.Passw, passw);

            if (result == PasswordVerificationResult.Failed) return false;

            _context.Usuarios.Remove(user);
            _context.SaveChanges();
            return true;
        }

        public IEnumerable<UserDtos> GetAll()
        {
            return _context.Usuarios
        .Select(u => new UserDtos
        {
            Idusr = u.Idusr,
            Nameusr = u.Nameusr,
            Codeusr = u.Codeusr,
            Rol = u.Rol
        }).ToList();
        }

        public UserDtos? GetByCodeAndPassword(string codeusr, string passw)
        {
            var user = _context.Usuarios.FirstOrDefault(u => u.Codeusr == codeusr);
            if (user == null) return null;

            var hasher = new PasswordHasher<Usuario>();
            var result = hasher.VerifyHashedPassword(user, user.Passw, passw);

            if (result == PasswordVerificationResult.Failed) return null;

            return new UserDtos
            {
                Idusr = user.Idusr,
                Nameusr = user.Nameusr,
                Codeusr = user.Codeusr,
                Rol = user.Rol
            };
        }

        public UserDtos? GetById(long idusr)
        {
            var user = _context.Usuarios.FirstOrDefault(u => u.Idusr == idusr);
            if (user == null) return null;

            return new UserDtos
            {
                Idusr = user.Idusr,
                Nameusr = user.Nameusr,
                Codeusr = user.Codeusr,
                Rol = user.Rol
            };
        }

        public bool Update(long idusr, UpdateUserDto userUpdateDto)
        {
            var user = _context.Usuarios.FirstOrDefault(u => u.Idusr == idusr);
            if (user == null) return false;

            if (!string.IsNullOrWhiteSpace(userUpdateDto.Nameusr))
            {
                bool exists = _context.Usuarios.Any(u => u.Nameusr == userUpdateDto.Nameusr && u.Idusr != idusr);
                if (exists) return false;

                user.Nameusr = userUpdateDto.Nameusr;
            }

            if (!string.IsNullOrWhiteSpace(userUpdateDto.Passw))
            {
                var hasher = new PasswordHasher<Usuario>();
                user.Passw = hasher.HashPassword(user, userUpdateDto.Passw);
            }

            _context.SaveChanges();
            return true;
        }


        public bool UpdateByAdmin(UserAdminUpdateDto dto)
        {
            var user = _context.Usuarios.FirstOrDefault(u => u.Idusr == dto.Idusr);
            if (user == null) return false;

            user.Nameusr = dto.Nameusr;
            user.Rol = dto.Rol;

            // Solo actualizar la contraseña si es proporcionada
            if (!string.IsNullOrEmpty(dto.Passw))
            {
                var hasher = new PasswordHasher<Usuario>();
                user.Passw = hasher.HashPassword(user, dto.Passw);
            }

            _context.SaveChanges();
            return true;
        }

        public bool UpdatePassword(string codeusr, string currentPass, string newPass)
        {
            var user = _context.Usuarios.FirstOrDefault(u => u.Codeusr == codeusr);
            if (user == null) return false;

            var hasher = new PasswordHasher<Usuario>();
            var result = hasher.VerifyHashedPassword(user, user.Passw, currentPass);

            if (result == PasswordVerificationResult.Failed) return false;

            user.Passw = hasher.HashPassword(user, newPass);
            _context.SaveChanges();
            return true;
        }

        public bool UpdateUserName(string codeusr, string newName)
        {
            var user = _context.Usuarios.FirstOrDefault(u => u.Codeusr == codeusr);
            if (user == null) return false;

            user.Nameusr = newName;
            _context.SaveChanges();
            return true;
        }
    }
}

