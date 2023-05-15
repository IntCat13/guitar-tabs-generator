using System;
using System.Threading.Tasks;
using Avalonia.Interactivity;
using GeneratorLibrary.Models;
using GeneratorLibrary.Generator;
using ReactiveUI;

namespace GuitarTabsGenerator.ViewModels;

public class MainViewModel : ViewModelBase
{
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

    public async void GenerateTabs()
    {
        if (IsInputNotValid())
        {
            Status = "Input is not valid";
            return;
        }

        Status = "Generating tabs...";
        Task.Run(async delegate
        {
            await Task.Delay(1000);
            TryToRequestTabs();
        });
    }

    private async void TryToRequestTabs()
    {
        var completionResult = Task.Run(async delegate
        {
            await Task.Delay(1000);
            return Generator.NewTabs(Promt, NegativePromt, ApiKey);
        });
        Tabs = completionResult.Result;
        ShowTabs();
    }

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
