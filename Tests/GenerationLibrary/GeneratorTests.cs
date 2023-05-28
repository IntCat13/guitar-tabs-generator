using GeneratorLibrary.ApiConnection;
using GeneratorLibrary.Generator;
using GeneratorLibrary.Models;
using GeneratorLibrary.Tools;

namespace Tests.GenerationLibrary;

public class GeneratorTests
{
    [SetUp]
    public void SetUp()
    {
        
    }

    // A test to check if generator is working correctly
    [Test]
    public void IsGeneratorWorkCorrectly()
    {
        // Building promt
        string promt = "Battle theme from medieval theme";
        string model = OpenAI.GPT3.ObjectModels.Models.ChatGpt3_5Turbo;
        
        // Creating config
        RequestConfig config = new RequestConfig(promt, "", model);

        // Generating tabs
        List<Tabs> generatedTabs = Generator.NewTabs(config, "Test");

        foreach (var tabs in generatedTabs)
            Assert.IsTrue(IsParserCorrect(tabs), "Parsed tabs are incorrect");
    }
    
    // Compare tabs with default tabs
   private bool IsParserCorrect(Tabs tabs)
   {
       string tabsContent = "Guitar Tabs:\ne|-------------------------------------------------------|\nB|-------------------------------------------------------|\nG|-------------------------------------------------------|\nD|---------2-------------2---------0-------0-------0------|\nA|-------0---0---------0---0-----0---0---0---0---0---0----|\nE|---0-----------0-------------3-------3-------3----------|\n\n    e|-------------------------------------------------------|\nB|-------------------------------------------------------|\nG|-------------------------------------------------------|\nD|---------2-------------2---------0-------0-------0------|\n    A|-------2---2---------2---2-----2---2---2---2---2---2----|\n    E|---0-----------0-------------3-------3-------3----------|\n        \n    e|-------------------------------------------------------|\nB|-------------------------------------------------------|\nG|------------------4------4-------------4--------4-------|\n    D|---------2------------2---------0----------------------|\n    A|-------2---2--------2---2-----2---2-----4---4----4---4--|\n    E|---0-----------0-------------3--------3------3----------|\n        \n    e|-------------------------------------------------------|\nB|-------------------------------------------------------|\nG|-------------------------------------------------------|\nD|---------2-------------2---------0-------0-------0------|\n    A|-------0---0---------0---0-----0---0---0---0---0---0----|\n    E|---0-----------0-------------3-------3-------3----------|\n";
         
       
       return tabs.TimeSignature == " 4/4" && tabs.Tempo == " 120 BPM" && tabs.Key == " E minor" && tabs.Tuning == " Standard (EADGBE)" && tabs.Title == " \"Battle of the Strings\"" && tabs.Content == tabsContent;
   }
}