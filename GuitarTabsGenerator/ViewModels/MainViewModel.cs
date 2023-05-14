using System;
using Avalonia.Interactivity;
using GeneratorLibrary.Models;
using GeneratorLibrary.Generator;
using ReactiveUI;

namespace GuitarTabsGenerator.ViewModels;

public class MainViewModel : ViewModelBase
{
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

    public void GenerateTabs()
    {
        if (IsInputNotValid())
            return;

        Tabs = Generator.NewTabs(Promt, NegativePromt, ApiKey);
        
        Signature = "Time Signature:"+Tabs.TimeSignature;
        Tempo = "Tempo:"+Tabs.Tempo;
        Key = "Key:"+Tabs.Key;
        Tuning = "Tuning:"+Tabs.Tuning;
        Title = "Title:"+Tabs.Title;
        TabsText = Tabs.Content;
    }
    
    public bool IsInputNotValid()
    {
        if (string.IsNullOrEmpty(ApiKey))
            return true;
        
        if (string.IsNullOrEmpty(Promt))
            return true;
        
        if (string.IsNullOrEmpty(NegativePromt))
            return true;

        return false;
    }
}
