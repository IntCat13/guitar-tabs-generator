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
         
         List<Tabs> tab = Generator.NewTabs(positivePromt,negativePromt,2,0.5f, 300,"");
         tab.ForEach(x => x.Show());
    }
}