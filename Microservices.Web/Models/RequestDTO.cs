using static Microservices.Web.Utils.SD;

namespace Microservices.Web.Models
{
    public class RequestDTO
    {
        public ApyType ApiType { get; set; } = ApyType.GET;
        public string Url { get; set; }
        public object Data { get; set; }
        public string AccessToken { get; set; }

    }
}
