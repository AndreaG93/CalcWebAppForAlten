using CalcREST.Models;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Net.Mime;
using System.Text;
using System.Text.Json;

namespace CalcRESTTest
{
    public class UnitTest1
    {

        private HttpRequestMessage BuildHTTPGETRequest(string URL, string contentAsJSON)
        {
            HttpRequestMessage output = new HttpRequestMessage();

            output.Method = HttpMethod.Get;
            output.RequestUri = new Uri(URL);
            output.Content = new StringContent(contentAsJSON, Encoding.UTF8, MediaTypeNames.Application.Json);

            return output;
        }

        private async Task<HttpResponseMessage> GetHTTPResponseContentAsync(HttpClient client, HttpRequestMessage requestMessage)
        {
            HttpResponseMessage output;

            using (client)
            {
                try
                {
                    output = await client.SendAsync(requestMessage);  
                }
                catch (HttpRequestException e)
                {
                    throw new Exception("Error during 'GetResponseAsync'", e);
                }
            }

            return output;
        }

        private async Task<MathExpressionOutput> GetResultFromHTTPResponseAsync(HttpResponseMessage input)
        {
            MathExpressionOutput output;
            string rawOutputAsJSON;
            Exception exception;

            rawOutputAsJSON = await input.Content.ReadAsStringAsync();

            switch (input.StatusCode)
            {
                case HttpStatusCode.OK:   
                    
                    output = JsonSerializer.Deserialize<MathExpressionOutput>(rawOutputAsJSON);
                    break;

                case HttpStatusCode.InternalServerError:

                    exception = JsonSerializer.Deserialize<Exception>(rawOutputAsJSON);
                    throw exception;
                   
                default:

                    throw new Exception("Not expected status code");
                    break;
            }

            return output;
        }




        




        [Fact]
        public async Task Test1()
        {
            HttpResponseMessage httpResponseMessage;
            HttpClient client;
            HttpRequestMessage requestMessage;
            MathExpressionInput input;
            MathExpressionOutput output;
            string jsonInput;
            string jsonOutput;


            client = new HttpClient();       // new HttpClient(new HttpClientHandler { UseProxy = false });
            input = new MathExpressionInput
            {
                Content = "(30+5+5)*2"
            };

           
            try
            {
                jsonInput = input.SerializeToJSON();
                requestMessage = BuildHTTPGETRequest("https://localhost:7025/REST/Calc/Compute", jsonInput);
                httpResponseMessage = await GetHTTPResponseContentAsync(client, requestMessage);
                output = await GetResultFromHTTPResponseAsync(httpResponseMessage);
            }
            catch (Exception ex)
            {
                Assert.True(false, "Fail: " + ex.Message);
            }
        }
    }
}





// sql DATASET!!!  SQL SERVER 2016 (ANCHE 2008)
// FAI IL CALCOLO E SALVO IL CALCOLO !!! 
// QUERY ASINCRONE 
// LUNEDì MATTINA ALLE 9:10 (blazor) 