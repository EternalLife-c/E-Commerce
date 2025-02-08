using E_Commerce.Application.DTOs.Common;

namespace E_Commerce.Application.DTOs.User
{
    public class CreateUserDto : IUserDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
    }
}
