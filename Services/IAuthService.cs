using EcommerceAuthToken.Models;

namespace EcommerceAuthToken.Services
{
    public interface IAuthService
    { 
        Task<Auth> RegisterAsync(Register model);
        Task<Auth> GetTokenAsync(TokenRequest model);
        Task<string> AddRoleAsync(AddRole model);
    }
}
