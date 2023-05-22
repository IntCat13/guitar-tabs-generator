// Guitar Tabs Generator UI
// Created by IntCat13 

using System;
using System.Collections.Generic;
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

    private int _currentTabs = 0;
    public int CurrentTabs
    {
        get => _currentTabs;
        set
        {
            this.RaiseAndSetIfChanged(ref _currentTabs, value);
            this.ShowTabs();
        }
    }


    private int _generationAmount = 1;
    public int GenerationAmount
    {
        get => _generationAmount;
        set => this.RaiseAndSetIfChanged(ref _generationAmount, value);
    }
    
    private int _lastGenerationAmount = 0;
    public int LastGenerationAmount
    {
        get => _lastGenerationAmount;
        set
        {
            if (value < 0)
                return;
            
            this.RaiseAndSetIfChanged(ref _lastGenerationAmount, value);
        }
    }
    
    private float _generationAccuracy = 0.5f;
    public float GenerationAccuracy
    {
        get => _generationAccuracy;
        set => this.RaiseAndSetIfChanged(ref _generationAccuracy, value);
    }
    
    private int _maxTokens = 300;
    public int MaxTokens
    {
        get => _maxTokens;
        set => this.RaiseAndSetIfChanged(ref _maxTokens, value);
    }

    private List<Tabs> _tabs;

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
        var completionResult = Generator.NewTabs(Promt, NegativePromt, GenerationAmount, GenerationAccuracy, MaxTokens, ApiKey);
        _tabs = completionResult;
        CurrentTabs = 0;
        LastGenerationAmount = GenerationAmount-1;
        ShowTabs();
    }

    // Method for showing tabs in UI
    private void ShowTabs()
    {
        if (_tabs.Count < CurrentTabs)
            return;
        
        Status = "Tabs generated";
        Signature = "Time Signature:"+_tabs[CurrentTabs].TimeSignature;
        Tempo = "Tempo:"+_tabs[CurrentTabs].Tempo;
        Key = "Key:"+_tabs[CurrentTabs].Key;
        Tuning = "Tuning:"+_tabs[CurrentTabs].Tuning;
        Title = "Title:"+_tabs[CurrentTabs].Title;
        TabsText = _tabs[CurrentTabs].Content;
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
