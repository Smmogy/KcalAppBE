using KcalAppBE.DTOs;
using KcalAppBE.Models;

namespace KcalAppBE.Services
{
    public interface IUserSerivce
    {
        Task<LogInResponseDTO> Authenticate(LogInDTO model, string userAgent);
        Task<LogInResponseDTO> Register(RegisterDTO model, string userAgent);
        Task<LogInResponseDTO> RefreshToken(string refreshToken);
        Task<LogInResponseDTO> LogOut(string refreshToken);
        Task<User> GetById(int id);
    }
    public class UserService : IUserSerivce
    {   
        private MainDbContext context;

        public UserService(MainDbContext mainDbContext) {
            this.context = mainDbContext;
        }
    }
}
