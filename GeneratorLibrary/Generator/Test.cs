using GeneratorLibrary.ApiConnection;
using OpenAI.GPT3.ObjectModels;
using GeneratorLibrary.Models;
using GeneratorLibrary.Tools;
using OpenAI.GPT3.ObjectModels.RequestModels;

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