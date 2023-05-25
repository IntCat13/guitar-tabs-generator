// Guitar Tabs Generator
// UI controller
// Created by IntCat13 

using GeneratorLibrary.Models;
using GuitarTabsGenerator.ViewModels;

namespace GuitarTabsGenerator.Controllers;

public static class UIController
{
    // Method for showing tabs in UI
    public static void ShowTabs(MainViewModel model)
    {
        if (model.Tabs.Count < model.CurrentTabs)
            return;
        
        Tabs tabs = model.Tabs[model.CurrentTabs];
        
        model.Status = "Tabs generated";
        model.Signature = "Time Signature:"+tabs.TimeSignature;
        model.Tempo = "Tempo:"+tabs.Tempo;
        model.Key = "Key:"+tabs.Key;
        model.Tuning = "Tuning:"+tabs.Tuning;
        model.Title = "Title:"+tabs.Title;
        model.TabsText = tabs.Content;
    }
    
    // Method for setting status in UI
    public static void SetStatus(MainViewModel model, string status)
    {
        model.Status = status;
    }
}