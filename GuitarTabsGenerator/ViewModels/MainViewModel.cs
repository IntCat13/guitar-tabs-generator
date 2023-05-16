// Guitar Tabs Generator UI
// Created by IntCat13 

using System;
using System.Threading.Tasks;
using GeneratorLibrary.Models;
using GeneratorLibrary.Generator;
using ReactiveUI;

namespace GuitarTabsGenerator.ViewModels;

public class MainViewModel : ViewModelBase
{
    // Properties for binding
    private string _status;
    public string Status
    {
        get => _status;
        set => this.RaiseAndSetIfChanged(ref _status, value);
    }
    
    private string _signature;
    public string Signature
    {
        get => _signature;
        set => this.RaiseAndSetIfChanged(ref _signature, value);
    }
    
    private string _tempo;
    public string Tempo
    {
        get => _tempo;
        set => this.RaiseAndSetIfChanged(ref _tempo, value);
    }
    private string _key;
    public string Key
    {
        get => _key;
        set => this.RaiseAndSetIfChanged(ref _key, value);
    }
    
    private string _tuning;
    public string Tuning
    {
        get => _tuning;
        set => this.RaiseAndSetIfChanged(ref _tuning, value);
    }

    private string _title;
    public string Title
    {
        get => _title;
        set => this.RaiseAndSetIfChanged(ref _title, value);
    }
    
    private string _tabsText;
    public string TabsText
    {
        get => _tabsText;
        set => this.RaiseAndSetIfChanged(ref _tabsText, value);
    }
    

    public string ApiKey { get; set; }
    public string Promt { get; set; }
    public string NegativePromt { get; set; }

    public Tabs Tabs;

    // Method for generating tabs
    public void GenerateTabs()
    {
        // Check if input is valid
        if (IsInputNotValid())
            return;

        SetStatus("Generating tabs...");
        
        // Request tabs from API
        Task.Run(async delegate
        {
            await Task.Delay(1000);
            RequestTabs();
        });
    }

    // Method for requesting tabs from API
    private void RequestTabs()
    {
        var completionResult = Generator.NewTabs(Promt, NegativePromt, ApiKey);
        Tabs = completionResult;
        ShowTabs();
    }

    // Method for showing tabs in UI
    private void ShowTabs()
    {
        Status = "Tabs generated";
        Signature = "Time Signature:"+Tabs.TimeSignature;
        Tempo = "Tempo:"+Tabs.Tempo;
        Key = "Key:"+Tabs.Key;
        Tuning = "Tuning:"+Tabs.Tuning;
        Title = "Title:"+Tabs.Title;
        TabsText = Tabs.Content;
    }

    // Input validation method
    private bool IsInputNotValid()
    {
        bool isInputNotValid = false;
        string errorMessage = "Input is not valid: ";

        if (string.IsNullOrEmpty(ApiKey))
        {
            isInputNotValid = true;
            errorMessage += "Api key is empty, ";
        }

        if (string.IsNullOrEmpty(Promt))
        {
            isInputNotValid = true;
            errorMessage += "Promt is empty, ";
        }

        if (isInputNotValid)
            SetStatus(errorMessage);

        return isInputNotValid;
    }
    
    private void SetStatus(string status)
    {
        Status = status;
    }
}
