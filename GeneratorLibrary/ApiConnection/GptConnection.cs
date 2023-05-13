using GeneratorLibrary.Models;
using OpenAI.GPT3;
using OpenAI.GPT3.Managers;
using OpenAI.GPT3.ObjectModels.RequestModels;
using OpenAI.GPT3.ObjectModels.ResponseModels;

namespace GeneratorLibrary.ApiConnection;

// Class that handles connection to OpenAI API
public class GptConnection
{
    private readonly OpenAIService _openAiService;
    
    // Connection constructor that creates a new OpenAIService object with api key from environment variable
    public GptConnection()
    {
        _openAiService = new OpenAIService(new OpenAiOptions()
        {
            ApiKey =  Environment.GetEnvironmentVariable("MY_OPEN_AI_API_KEY")
        });
    }
    
    // Method that make request to OpenAI API with defined configuration
    private async Task<ChatCompletionCreateResponse> CreateRequest(RequestConfig config)
    {
        return await _openAiService.ChatCompletion.CreateCompletion(new ChatCompletionCreateRequest
        {
            Messages = config.Messages,
            Model = config.Model,
            Temperature = config.Temperature,
            MaxTokens = config.MaxTokens,
            N = config.N
        });
    }

    // Method that returns response from OpenAI API
    public List<string> GetResponse(RequestConfig config)
    {
        var completionResult = CreateRequest(config).Result;
        var response = new List<string>();
        
        if (completionResult.Successful)
        {
            foreach (var choice in completionResult.Choices)
                response.Add(choice.Message.Content);
        }
        else
        {
            // If there is no error, throw an exception
            if (completionResult.Error == null)
                throw new Exception("Unknown Error");
            
            // If there is an error, add it to the response
            response.Add($"{completionResult.Error.Code}: {completionResult.Error.Message}");
        }

        return response;
    }
}