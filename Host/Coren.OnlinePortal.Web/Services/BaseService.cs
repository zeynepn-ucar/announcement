using Coren.OnlinePortal.Web.Models;
using Coren.OnlinePortal.Web.Services.İnterfaces;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace Coren.OnlinePortal.Web.Services
{
    public class BaseService : IBaseService
    {
        public ApiResponse ResponseModel { get; set; }
        public IHttpClientFactory HttpClientFactory { get; set; }
        public BaseService(IHttpClientFactory httpClientFactory)
        {
            ResponseModel = new();
            HttpClientFactory = httpClientFactory;
        }
        public async Task<T> SendAsync<T>(ApiRequest apiRequest)
        {
            try
            {
                var client = HttpClientFactory.CreateClient("OnlinePortalApi");
                var message = new HttpRequestMessage
                {
                    Headers = { { "Accept", "application/json" } },
                    RequestUri = new Uri(apiRequest.Url)
                };
                if (apiRequest.Data != null)
                {
                    message.Content = new StringContent(JsonConvert.SerializeObject(apiRequest.Data),
                        Encoding.UTF8, "application/json");
                }
                message.Method = apiRequest.ApiType switch
                {
                    ApiType.POST => HttpMethod.Post,
                    ApiType.PUT => HttpMethod.Put,
                    ApiType.DELETE => HttpMethod.Delete,
                    _ => HttpMethod.Get
                };

                if (!string.IsNullOrEmpty(apiRequest.Token))
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiRequest.Token);
                }

                var response = await client.SendAsync(message);
                var apiContent = await response.Content.ReadAsStringAsync();

                try
                {
                    var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(apiContent);

                    if (apiResponse != null && (response.StatusCode == System.Net.HttpStatusCode.BadRequest
                        || response.StatusCode == System.Net.HttpStatusCode.NotFound))
                    {
                        apiResponse.StatusCode = System.Net.HttpStatusCode.BadRequest;
                        apiResponse.IsSuccess = false;
                        var res = JsonConvert.SerializeObject(apiResponse);
                        var returnData = JsonConvert.DeserializeObject<T>(res);
                        return returnData;
                    }
                }
                catch
                {
                    var exceptionResponse = JsonConvert.DeserializeObject<T>(apiContent);
                    return exceptionResponse;
                }

                var result = JsonConvert.DeserializeObject<T>(apiContent);
                return result;
            }
            catch (Exception e)
            {
                var errorDto = new ApiResponse
                {
                    ErrorMessages = new List<string> { Convert.ToString(e.Message) },
                    IsSuccess = false
                };

                var error = JsonConvert.SerializeObject(errorDto);
                var errorResult = JsonConvert.DeserializeObject<T>(error);
                return errorResult;
            }
        }
    }
}
