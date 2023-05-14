using GeneratorLibrary.ApiConnection;
using GeneratorLibrary.Models;
using GeneratorLibrary.Tools;
using OpenAI.GPT3.ObjectModels.RequestModels;

namespace GeneratorLibrary.Generator;

public class Generator
{
    public static Tabs NewTabs (string positivePromt, string negativePromt, string apiKey)
    {
        GptConnection gptConnection = new GptConnection(apiKey);
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

        Tabs tabs = gptConnection.GetResponse(requestConfig)[0].TryParseTabs();
        return tabs;
    }
}