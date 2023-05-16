// Guitar Tabs Generator Library
// Created by IntCat13 

using GeneratorLibrary.Models;

namespace GeneratorLibrary.Generator;

public class Test
{
    public static void Main (string[] args)
    {
         string positivePromt = "Fingerstyle theme for adventure computer game, harmonics, for experiences guitarists";
         string negativePromt = "unplayable elements, repetitive elements";
         
         Tabs tab = Generator.NewTabs(positivePromt,negativePromt,"");
         tab.Show();
    }
}