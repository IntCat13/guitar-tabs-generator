// Guitar Tabs Generator Library
// Created by IntCat13 

namespace GeneratorLibrary.Models;

public struct Tabs
{
    public readonly string? TimeSignature;
    public readonly string? Tempo;
    public readonly string? Key;
    public readonly string? Tuning;
    public readonly string? Title;
    public readonly string Content;
    
    public Tabs(string timeSignature, string tempo, string key, string tuning, string title, string content)
    {
        TimeSignature = timeSignature;
        Tempo = tempo;
        Key = key;
        Tuning = tuning;
        Title = title;
        Content = content;
    }

    // Test constructor that create test content of tabs type
    public Tabs()
    {
        TimeSignature = "4/4";
        Tempo = "120";
        Key = "C";
        Tuning = "EADGBE";
        Title = "Test";
        Content = "e|-----------------|\nB|-----------------|\nG|-----------------|\nD|-----------------|\nA|-----------------|\nE|-----------------|\n";
    }

    // Show Tabs object in console
    public void Show()
    {
        if(TimeSignature != null)
            Console.WriteLine($"Time Signature:{TimeSignature}");
        
        if(Tempo != null)
            Console.WriteLine($"Tempo:{Tempo}");
        
        if(Key != null)
            Console.WriteLine($"Key:{Key}");
        
        if(Tuning != null)
            Console.WriteLine($"Tuning: {Tuning}");
        
        if(Title != null)
            Console.WriteLine($"Title: {Title}");
        
        Console.WriteLine($"{Content}");
    }
}