// Guitar Tabs Generator Library
// Created by IntCat13 

using GeneratorLibrary.ApiConnection;
using GeneratorLibrary.Models;
using GeneratorLibrary.Tools;
using OpenAI.GPT3.ObjectModels.RequestModels;
using System.Linq;

namespace GeneratorLibrary.Generator;

// Contains method for generating Tabs object
// Method NewTabs returns Tabs object
public class Generator
{
    // New Tabs object
    public static List<Tabs> NewTabs (RequestConfig config, string apiKey)
    {
        // Create new GptConnection
        // GptConnection is a class that contains method for sending requests to OpenAI API
        GptConnection gptConnection = new GptConnection(apiKey);

        // Building request config for OpenAI API
        RequestConfig requestConfig = config;

        // Get response from OpenAI API
        List<Tabs> tabs = gptConnection
            .GetResponse(requestConfig)
            .Select(x => x.TryParseTabs())
            .ToList();
        return tabs;
    }
}