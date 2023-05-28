// Guitar Tabs Generator Library
// Created by IntCat13 

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
    private readonly bool _isTest = false;
    
    // Connection constructor that creates a new OpenAIService object with api key from environment variable
    public GptConnection()
    {
        _openAiService = new OpenAIService(new OpenAiOptions()
        {
            ApiKey =  "Test"
        });
        _isTest = true;
    }
    
    public GptConnection(string key)
    {
        _openAiService = new OpenAIService(new OpenAiOptions()
        {
            ApiKey =  key
        });
        
        if(key == "Test")
            _isTest = true;
    }

    // Method that make request to OpenAI API with defined configuration
    private async Task<ChatCompletionCreateResponse> CreateRequest(RequestConfig config)
    {
        var result = await _openAiService.ChatCompletion.CreateCompletion(new ChatCompletionCreateRequest
        {
            Messages = config.Messages,
            Model = config.Model,
            Temperature = config.Temperature,
            MaxTokens = config.MaxTokens,
            N = config.N
        });
        return result;
    }

    // Method that returns response from OpenAI API
    public List<string> GetResponse(RequestConfig config)
    {
        if (_isTest)
            return GetTestResponse(config);
        
        //var completionResult = CreateRequest(config).Result;
        var completionResult = Task.Run(async delegate
        {
            await Task.Delay(1000);
            return CreateRequest(config).Result;
        });
        
        var response = new List<string>();
        
        if (completionResult.Result.Successful)
        {
            foreach (var choice in completionResult.Result.Choices)
                response.Add(choice.Message.Content);
        }
        else
        {
            // If there is no error, throw an exception
            if (completionResult.Result.Error == null)
                throw new Exception("Unknown Error");
            
            // If there is an error, add it to the response
            response.Add($"{completionResult.Result.Error.Code}: {completionResult.Result.Error.Message}");
        }

        return response;
    }
    
    // Method that returns simulated response for testing
    public List<string> GetTestResponse(RequestConfig config)
    {
        List<string> response = new List<string>();
        response.Add("Time Signature: 4/4\nTempo: 120 BPM\nKey: E minor\nTuning: Standard (EADGBE)\nTitle: \"Battle of the Strings\"\nGuitar Tabs:\ne|-------------------------------------------------------|\nB|-------------------------------------------------------|\nG|-------------------------------------------------------|\nD|---------2-------------2---------0-------0-------0------|\nA|-------0---0---------0---0-----0---0---0---0---0---0----|\nE|---0-----------0-------------3-------3-------3----------|\n\n    e|-------------------------------------------------------|\nB|-------------------------------------------------------|\nG|-------------------------------------------------------|\nD|---------2-------------2---------0-------0-------0------|\n    A|-------2---2---------2---2-----2---2---2---2---2---2----|\n    E|---0-----------0-------------3-------3-------3----------|\n        \n    e|-------------------------------------------------------|\nB|-------------------------------------------------------|\nG|------------------4------4-------------4--------4-------|\n    D|---------2------------2---------0----------------------|\n    A|-------2---2--------2---2-----2---2-----4---4----4---4--|\n    E|---0-----------0-------------3--------3------3----------|\n        \n    e|-------------------------------------------------------|\nB|-------------------------------------------------------|\nG|-------------------------------------------------------|\nD|---------2-------------2---------0-------0-------0------|\n    A|-------0---0---------0---0-----0---0---0---0---0---0----|\n    E|---0-----------0-------------3-------3-------3----------|");
        return response;
    }
}