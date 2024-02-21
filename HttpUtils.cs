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

        private Response HandleHttpRequestException(HttpRequestException e, string url)
        {
            int statusCode = (int)(e.StatusCode ?? 0);
            Console.Error.WriteLine($"Error : {statusCode} ");
            Console.Error.WriteLine(e.Message);

            return new Response() { content = null, statusCode = statusCode, url = url };
        }

        public async Task<Response> Get(string url)
        {
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(url);
                string content = await response.Content.ReadAsStringAsync();

                return new Response() { content = content, statusCode = (int)response.StatusCode, url = url };
            }
            catch (HttpRequestException e)
            {
                return HandleHttpRequestException(e, url);
            }
        }

        public async Task<Response> Post(string url, string content)
        {
            try
            {
                Answer answer = new Answer() { answer = content };
                var response = await httpClient.PostAsJsonAsync(url, answer);
                string respons = await response.Content.ReadAsStringAsync();

                return new Response() { content = respons, statusCode = (int)response.StatusCode, url = url };
            }
            catch (HttpRequestException e)
            {
                return HandleHttpRequestException(e, url);
            }
        }
    }

    class Answer
    {
        public string answer { get; set; }
    }

}