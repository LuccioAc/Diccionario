using dictapi.Dtos;

namespace dictapi.Interfaces
{
    public interface IUserRepository
    {
        // Login
        UserDtos? GetByCodeAndPassword(string codeusr, string passw);
        //
        UserDtos? GetById(long idusr);
        
        // Registrar usuario
        void Add(RegisterUserDto userRegisterDto);
        // Actualizar nombre o contraseña (por usuario)
        bool Update(long idusr, UpdateUserDto userUpdateDto);
        
        bool UpdateUserName(string codeusr, string newName);
        bool UpdatePassword(string codeusr, string currentPass, string newPass);
        bool DeleteByCodeAndPassword(string codeusr, string passw);
        //ONLY ADMIN------------------------------------------------------
        // Listar todos los usuarios
        IEnumerable<UserDtos> GetAll();
        // Crear usuario
        void AddByAdmin(UserAdminCUDto dto);
        // Actualizar usuario
        bool UpdateByAdmin(UserAdminCUDto dto);
        // Eliminar por ID
        void Delete(long idusr);
    }
}
