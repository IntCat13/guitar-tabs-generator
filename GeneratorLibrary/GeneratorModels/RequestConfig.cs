using OpenAI.GPT3;
using OpenAI.GPT3.Managers;
using OpenAI.GPT3.ObjectModels;
using OpenAI.GPT3.ObjectModels.RequestModels;

namespace GeneratorLibrary.Models;

public struct RequestConfig
{
    public readonly List<ChatMessage> Messages;
    public readonly string Model;
    public readonly float Temperature;
    public readonly int MaxTokens;
    public readonly int N;
    
    public RequestConfig(List<ChatMessage> messages, string model, float temperature = 0.5f, int maxTokens = 300, int n = 1)
    {
        Messages = messages;
        Model = model;
        Temperature = temperature;
        MaxTokens = maxTokens;
        N = n;
    }
}