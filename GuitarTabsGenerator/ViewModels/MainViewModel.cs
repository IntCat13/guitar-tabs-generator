// Guitar Tabs Generator UI
// Created by IntCat13 

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Controls.Selection;
using Avalonia.Interactivity;
using GeneratorLibrary.Models;
using GeneratorLibrary.Generator;
using GuitarTabsGenerator.Controllers;
using GuitarTabsGenerator.Services;
using ReactiveUI;

namespace GuitarTabsGenerator.ViewModels;

public class MainViewModel : ViewModelBase, INotifyPropertyChanged
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
            UIController.ShowTabs(this);
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

    public List<Tabs> Tabs;

    // Method for generating tabs
    public void GenerateTabs()
    {
        GeneratorService.GenerateTabs(this);
    }
}
