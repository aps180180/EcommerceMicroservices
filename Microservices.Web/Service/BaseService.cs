using Microservices.Web.Models;
using Microservices.Web.Service.IService;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using static Microservices.Web.Utils.SD;

namespace Microservices.Web.Service
{
    public class BaseService : IBaseService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ITokenProvider _tokenProvider;
        public BaseService(IHttpClientFactory httpClientFactory, ITokenProvider tokenProvider)
        {

            _httpClientFactory = httpClientFactory;
            _tokenProvider = tokenProvider; 
        }
        public async Task<ResponseDTO?> SendAsync(RequestDTO requestDTO, bool withBeaerer = true)
        {
            try
            {
                HttpClient client = _httpClientFactory.CreateClient("MicroservicesAPI");
                HttpRequestMessage message = new();
                message.Headers.Add("Accept", "application/json");
                // token
                if (withBeaerer)
                {
                    var token = _tokenProvider.GetToken();
                    message.Headers.Add("Authorization", $"Bearer {token}");
                }
                message.RequestUri = new Uri(requestDTO.Url);
                if (requestDTO.Data != null)
                {
                    message.Content = new StringContent(JsonConvert.SerializeObject(requestDTO.Data),
                         Encoding.UTF8, "application/json"
                        );
                }
                HttpResponseMessage? apiResponse = null;
                switch (requestDTO.ApiType)
                {
                    case ApyType.GET:
                        message.Method = HttpMethod.Get;
                        break;
                    case ApyType.POST:
                        message.Method = HttpMethod.Post;
                        break;
                    case ApyType.PUT:
                        message.Method = HttpMethod.Put;
                        break;
                    case ApyType.DELETE:
                        message.Method = HttpMethod.Delete;
                        break;
                    default:
                        message.Method = HttpMethod.Get;
                        break;
                }

                apiResponse = await client.SendAsync(message);
                switch (apiResponse.StatusCode)
                {
                    case HttpStatusCode.NotFound:
                        return new ResponseDTO() { IsSuccess = false, Message = "Not found" };
                    case HttpStatusCode.Forbidden:
                        return new ResponseDTO() { IsSuccess = false, Message = "Acess Denied" };
                    case HttpStatusCode.Unauthorized:
                        return new ResponseDTO() { IsSuccess = false, Message = "Unauthorized" };
                    case HttpStatusCode.InternalServerError:
                        return new ResponseDTO() { IsSuccess = false, Message = "Internal Server Error" };
                    default:
                        var apiContent = await apiResponse.Content.ReadAsStringAsync();
                        var apiResponseDto = JsonConvert.DeserializeObject<ResponseDTO>(apiContent);
                        return apiResponseDto;

                }
            }
            catch (Exception ex) 
            {
                var dto = new ResponseDTO()
                {
                    IsSuccess = false,
                    Message = ex.Message,
                };
                return dto;
            }

        }
    }
}
