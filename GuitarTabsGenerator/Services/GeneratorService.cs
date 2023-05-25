// Guitar Tabs Generator
// Generation service
// Created by IntCat13 

using System.Collections.Generic;
using System.Threading.Tasks;
using GeneratorLibrary.Generator;
using GeneratorLibrary.Models;
using GuitarTabsGenerator.Controllers;
using GuitarTabsGenerator.ViewModels;
using OpenAI.GPT3.ObjectModels.RequestModels;

namespace GuitarTabsGenerator.Services;

public static class GeneratorService
{
    // Method for generating tabs
    public static void GenerateTabs(MainViewModel model)
    {
        // Check if input is valid
        if (Validator.IsInputNotValid(model))
            return;

        UIController.SetStatus(model, "Generating tabs...");
        
        // Request tabs from API
        Task.Run(async delegate
        {
            await Task.Delay(1000);
            RequestTabs(model);
        });
    }

    // Method for requesting tabs from API
    private static void RequestTabs(MainViewModel model)
    {
        // string positivePromt, string negativePromt, string model, float temperature = 0.5f, int maxTokens = 300, int n = 1
        RequestConfig requestConfig = new RequestConfig(
            model.Promt,
            model.NegativePromt, 
            OpenAI.GPT3.ObjectModels.Models.ChatGpt3_5Turbo,
            model.GenerationAccuracy,
            model.MaxTokens,
            model.GenerationAmount
        );
        
        var completionResult = Generator.NewTabs(
            requestConfig, 
            model.ApiKey
            );
        
        model.Tabs = completionResult;
        model.CurrentTabs = 0;
        model.LastGenerationAmount = model.GenerationAmount-1;
        UIController.ShowTabs(model);
    }
}