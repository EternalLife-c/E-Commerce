namespace E_Commerce.Application.DTOs.User
{
    public interface IUserDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
