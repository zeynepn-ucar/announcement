using System.Net;

namespace Coren.OnlinePortal.Application.Models
{
    public class BaseServiceModel 
    {
        public BaseServiceModel()
        {
            ErrorMessages = new List<string>();
        }
        public HttpStatusCode StatusCode { get; set; }
        public bool IsSuccess { get; set; } = true;
        public List<string> ErrorMessages { get; set; }
        public object Result { get; set; }
    }
}
