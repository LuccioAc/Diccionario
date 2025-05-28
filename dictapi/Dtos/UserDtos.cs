namespace dictapi.Dtos
{
    public class UserDtos
    {
        public long Idusr { get; set; }
        public string Nameusr { get; set; } = null!;
        public string Codeusr { get; set; } = null!;
        public bool Rol { get; set; }
    }
    public class UserRegisterDto
    {
        public string Nameusr { get; set; } = null!;
        public string Passw { get; set; } = null!;
    }
    public class UserLoginDto
    {
        public string Codeusr { get; set; } = null!;
        public string Passw { get; set; } = null!;
    }
    public class UserUpdateDto
    {
        public string Nameusr { get; set; } = null!;
        public string Passw { get; set; } = null!;
    }
    public class UserAdminUpdateDto
    {
        public string Nameusr { get; set; } = null!;
        public string Passw { get; set; } = null!;
        public bool Rol { get; set; }
    }
    public class UserDeleteDto
    {
        public string Passw { get; set; } = null!;
    }
}
