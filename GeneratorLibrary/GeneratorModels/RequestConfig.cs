// Guitar Tabs Generator Library
// Created by IntCat13 

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
    
    public RequestConfig(string positivePromt, string negativePromt, string model, float temperature = 0.5f, int maxTokens = 300, int n = 1)
    {
        string promt =
            "Create the tabs for the guitar, the structure should be as follows Time Signature, Tempo, Key, Tuning, Tile, Guitar Tabs. The tabs have to be " +
            positivePromt+ ". ";
        if(string.IsNullOrEmpty(negativePromt) == false)
            promt += "The tabs must not be " + negativePromt;

        Messages = new List<ChatMessage>
        {
            ChatMessage.FromSystem("You are a guitar tabs creator"),
            ChatMessage.FromUser(promt)
        };
        Model = model;
        Temperature = temperature;
        MaxTokens = maxTokens;
        N = n;
    }
}