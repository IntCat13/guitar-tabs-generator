using GeneratorLibrary.Models;

namespace Tests.GenerationLibrary;

public class ConfigTests
{

    [SetUp]
    public void SetUp()
    {
        
    }

    // A test to check if a request is created correctly in the configuration constructor
    [Test]
    public void IsPromtBuiltCorrectly_NoNegativePromt()
    {
        // Building promt
        string promt = "Battle theme from medieval theme";
        string model = OpenAI.GPT3.ObjectModels.Models.ChatGpt3_5Turbo;
        
        // Creating config
        RequestConfig config = new RequestConfig(promt, "", model);
        var result = IsPromtCorrect_NoNegativePromt(config.Messages[1].Content);        

        Assert.IsTrue(result, "Built promt is incorrect");
    }
    
    // A test to check if a request is created correctly in the configuration constructor
    [Test]
    public void IsPromtBuiltCorrectly_WithNegativePromt()
    {
        // Building promt
        string positivePromt = "Battle theme from medieval theme";
        string negativePromt = "Repetitive";
        string model = OpenAI.GPT3.ObjectModels.Models.ChatGpt3_5Turbo;
        
        // Creating config
        RequestConfig config = new RequestConfig(positivePromt, negativePromt, model);
        var result = IsPromtCorrect_NoNegativePromt(config.Messages[1].Content);        

        Assert.IsTrue(result, "Built promt is incorrect");
    }
    
    private bool IsPromtCorrect_NoNegativePromt(string promt)
    {
        return promt.Contains("Create the tabs for the guitar, the structure should be as follows Time Signature, Tempo, Key, Tuning, Tile, Guitar Tabs. The tabs have to be Battle theme from medieval theme.");
    }
    
    private bool IsPromtCorrect_WithNegativePromt(string promt)
    {
        return promt.Contains("Create the tabs for the guitar, the structure should be as follows Time Signature, Tempo, Key, Tuning, Tile, Guitar Tabs. The tabs have to be Battle theme from medieval theme. The tabs must not be Repetitive");
    }
}