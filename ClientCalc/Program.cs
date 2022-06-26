using CalcREST.Models;
using System.Net;
using System.Net.Mime;
using System.Text;
using System.Text.Json;

namespace ClientCalc;

public class ClientCalc
{
    private static async Task<HttpResponseMessage> SendPOSTAsync(HttpClient client, string URL, string contentAsJSON)
    {
        HttpResponseMessage output;

        using (client)
        {
            try
            {
                StringContent content  = new StringContent(contentAsJSON, Encoding.UTF8, MediaTypeNames.Application.Json);
                output = await client.PostAsync(URL, content);
            }
            catch (Exception e)
            {
                throw new Exception("Error during 'GetResponseAsync'", e);
            }
        }

        return output;
    }

    private static async Task<MathExpressionOutput> GetResultFromHTTPResponseAsync(HttpResponseMessage input)
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
        }

        return output;
    }

    public static async Task Main(string[] argv)
    {
        HttpResponseMessage httpResponseMessage;
        HttpClient client;
        HttpRequestMessage requestMessage;
        MathExpressionInput input;
        MathExpressionOutput output;
        string jsonInput;
        string jsonOutput;


        client = new HttpClient(); //new HttpClient(new HttpClientHandler { UseProxy = false });
        input = new MathExpressionInput
        {
            Content = @"(30+5+5)*2"
        };

        try
        {
            jsonInput = input.SerializeToJSON();
            httpResponseMessage = await SendPOSTAsync(client, "https://localhost:7025/REST/Calc/Compute", jsonInput);
            output = await GetResultFromHTTPResponseAsync(httpResponseMessage);

            Console.WriteLine(output.Result);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        Console.ReadLine();
    }
}

