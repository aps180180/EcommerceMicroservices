using Microservices.Web.Models;

namespace Microservices.Web.Service.IService
{
    public interface IBaseService
    {
      Task<ResponseDTO?> SendAsync(RequestDTO requestDTO, bool withBeaerer =true);
    }
}
