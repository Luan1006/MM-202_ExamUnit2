#pragma warning disable CS8618
#pragma warning disable CS8625

using System.Net.Http.Json;
using System.Text;

namespace HTTPUtils
{
    public class Response
    {
        public string? content { get; set; }
        public int statusCode { get; set; }
        public string url { get; set; }

        public override string ToString()
        {
            return $"Response ({statusCode})\n{url} \n{content}";
        }
    }

    public class HttpUtils
    {

        private HttpClient httpClient = new HttpClient();


        private static HttpUtils _instance = null;

        public static HttpUtils instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new HttpUtils();
                }
                return _instance;
            }
        }

        private HttpUtils()
        {

        }

        #region Helper Methods

        private Response CreateResponse(string respons, int responseStatusCode, string url)
        {
            return new Response() { content = respons, statusCode = responseStatusCode, url = url };
        }

        private Response HandleHttpRequestException(HttpRequestException e, string url)
        {
            int statusCode = (int)(e.StatusCode ?? 0);
            Console.Error.WriteLine($"Error : {statusCode} ");
            Console.Error.WriteLine(e.Message);

            return new Response() { content = null, statusCode = statusCode, url = url };
        }

        #endregion

        #region Get Methods
        private async Task<Response> CreateResponseFromHttpResponse(HttpResponseMessage response, string url)
        {
            string content = await response.Content.ReadAsStringAsync();
            int statusCode = (int)response.StatusCode;
            return CreateResponse(content, statusCode, url);
        }

        public async Task<Response> Get(string url)
        {
            return await SendGetRequest(url);
        }

        private async Task<Response> SendGetRequest(string url)
        {
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(url);
                return await CreateResponseFromHttpResponse(response, url);
            }
            catch (HttpRequestException e)
            {
                return HandleHttpRequestException(e, url);
            }
        }

        #endregion

        #region Post Methods

        private Answer CreateAnswer(string content)
        {
            return new Answer() { answer = content };
        }

        private async Task<HttpResponseMessage> SendRequest(string url, Answer answer)
        {
            return await httpClient.PostAsJsonAsync(url, answer);
        }

        private async Task<string> ReadResponseContent(HttpResponseMessage response)
        {
            return await response.Content.ReadAsStringAsync();
        }

        private async Task<Response> SendPostRequest(string url, string content)
        {
            try
            {
                Answer answer = CreateAnswer(content);
                HttpResponseMessage response = await SendRequest(url, answer);
                string respons = await ReadResponseContent(response);

                return CreateResponse(respons, (int)response.StatusCode, url);
            }
            catch (HttpRequestException e)
            {
                return HandleHttpRequestException(e, url);
            }
        }

        public async Task<Response> Post(string url, string content)
        {
            return await SendPostRequest(url, content);
        }


        #endregion
    }

    class Answer
    {
        public string answer { get; set; }
    }

}