using Microservices.Web.Models;
using Microservices.Web.Service.IService;
using Microservices.Web.Utils;

namespace Microservices.Web.Service
{
    public class AuthService : IAuthService
    {

        private readonly IBaseService _baseService;
        public AuthService(IBaseService baseService)
        {
            _baseService = baseService;
        }
        public async Task<ResponseDTO?> LoginAsync(LoginRequestDTO loginRequestDTO)
        {
            return await _baseService.SendAsync(new RequestDTO()
            {
                ApiType = SD.ApyType.POST,
                Data = loginRequestDTO,
                Url = $"{SD.AuthAPIBase}/api/auth/login"

            }, withBeaerer: false);
        }

        public async Task<ResponseDTO?> ResgisterAsync(RegistrationRequestDTO registrationRequestDTO)
        {
            return await _baseService.SendAsync(new RequestDTO()
            {
                ApiType = SD.ApyType.POST,
                Data = registrationRequestDTO,
                Url = $"{SD.AuthAPIBase}/api/auth/register"

            }, withBeaerer: false);
        }

        public async Task<ResponseDTO?> AssignRoleAsync(RegistrationRequestDTO registrationRequestDTO)
        {
            return await _baseService.SendAsync(new RequestDTO()
            {
                ApiType = SD.ApyType.POST,
                Data = registrationRequestDTO,
                Url = $"{SD.AuthAPIBase}/api/auth/AssignRole"

            });
        }
    }
}
