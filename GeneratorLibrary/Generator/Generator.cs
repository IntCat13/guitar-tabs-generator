// Guitar Tabs Generator Library
// Created by IntCat13 

using GeneratorLibrary.ApiConnection;
using GeneratorLibrary.Models;
using GeneratorLibrary.Tools;
using OpenAI.GPT3.ObjectModels.RequestModels;

namespace GeneratorLibrary.Generator;

// Contains method for generating Tabs object
// Method NewTabs returns Tabs object
public class Generator
{
    // New Tabs object
    public static Tabs NewTabs (string positivePromt, string negativePromt, string apiKey)
    {
        // Create new GptConnection
        // GptConnection is a class that contains method for sending requests to OpenAI API
        GptConnection gptConnection = new GptConnection(apiKey);

        // Building promt for OpenAI API
        string promt =
            "Create the tabs for the guitar, the structure should be as follows Time Signature, Tempo, Key, Tuning, Tile, Guitar Tabs. The tabs have to be " +
            positivePromt+ ". ";
        if(string.IsNullOrEmpty(negativePromt) == false)
            promt += "The tabs must not be " + negativePromt;
        
        // Building request config for OpenAI API
        RequestConfig requestConfig = new RequestConfig(
            new List<ChatMessage>
            {
                ChatMessage.FromSystem("You are a guitar tabs creator"),
                ChatMessage.FromUser(promt)
            },
            OpenAI.GPT3.ObjectModels.Models.ChatGpt3_5Turbo
        );

        // Get response from OpenAI API
        Tabs tabs = gptConnection.GetResponse(requestConfig)[0].TryParseTabs();
        return tabs;
    }
}