namespace dictapi.Dtos
{
    public class UserDtos
    {
        public long Idusr { get; set; }
        public string Nameusr { get; set; } = null!;
        public string Codeusr { get; set; } = null!;
        public bool Rol { get; set; }
    }
    public class RegisterUserDto
    {
        public string Nameusr { get; set; } = null!;
        public string Passw { get; set; } = null!;
    }
    public class UpdateUserDto
    {
        public string? Nameusr { get; set; }
        public string? Passw { get; set; }
    }
    //Dto para login
    public class UserLoginDto
    {
        public string Codeusr { get; set; } = null!;
        public string Passw { get; set; } = null!;
    }
    //Dto para registrar y actualizar usuarios por admin
    public class UserAdminCUDto
    {
        public long Idusr { get; set; }
        public string Nameusr { get; set; } = null!;
        public string Passw { get; set; } = null!;
        public bool Rol { get; set; }
    }
    //Dto para confirmación de eliminación de la cuenta mediante passw
    public class UserDeleteDto
    {
        public string Passw { get; set; } = null!;
    }
}
