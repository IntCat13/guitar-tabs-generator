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
         GptConnection gptConnection = new GptConnection();

         string positivePromt = "Fingerstyle theme for adventure computer game, harmonics, for experiences guitarists";
         string negativePromt = "unplayable elements, repetitive elements";
         
         RequestConfig requestConfig = new RequestConfig(
             new List<ChatMessage>
             {
                 ChatMessage.FromSystem("You are a guitar tabs creator"),
                 ChatMessage.FromUser("Create the tabs for the guitar, the structure should be as follows Time Signature, Tempo, Key, Tuning, Tile, Guitar Tabs. The tabs have to be "+
                                      positivePromt
                                      +". The tabs must not be "
                                      +negativePromt)
             },
             OpenAI.GPT3.ObjectModels.Models.ChatGpt3_5Turbo
         );

         List<Tabs> tabs = new List<Tabs>();

         foreach (var response in gptConnection.GetResponse(requestConfig))
         {
             Tabs newTabs = response.TryParseTabs();
             tabs.Add(newTabs);
         }

         foreach (var tab in tabs)
         {
             Console.WriteLine(tabs.IndexOf(tab));
             tab.Show();
         }
    }
}