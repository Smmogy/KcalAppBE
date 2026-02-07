using KcalAppBE.Auth;
using KcalAppBE.DTOs;
using KcalAppBE.Models;

namespace KcalAppBE.Services
{
    public interface IUserService
    {
        Task<LogInResponseDTO> Authenticate(LogInDTO model, string userAgent);
        Task<LogInResponseDTO> Register(RegisterDTO model, string userAgent);
        Task<LogInResponseDTO> RefreshToken(string refreshToken);
        Task<LogInResponseDTO> LogOut(string refreshToken);
        Task<User> GetById(int id);
    }
    public class UserService : IUserService
    {   
        private MainDbContext context;

        private IJwtService jwtService;

        public UserService(MainDbContext mainDbContext) {
            this.context = mainDbContext;
            this.jwtService = jwtService;
        }

        public async Task<LogInResponseDTO> Authenticate(LogInDTO model, string userAgent)
        {

            return new LogInResponseDTO() { };
        }
    }
}
