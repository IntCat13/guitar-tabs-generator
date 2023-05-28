using GeneratorLibrary.ApiConnection;
using GeneratorLibrary.Models;
using GeneratorLibrary.Tools;

namespace Tests.GenerationLibrary;

public class ParserTests
{
    [SetUp]
    public void SetUp()
    {
        
    }

    // A test to check if a parser of tabs is working correctly
    [Test]
    public void IsParserWorkCorrectly_DefaultTabs()
    {
        GptConnection testConnection = new GptConnection();
        
        List<Tabs> generatedTabs = testConnection
            .GetResponse(new RequestConfig("Battle theme from medieval game", "", OpenAI.GPT3.ObjectModels.Models.ChatGpt3_5Turbo))
            .Select(x => x.TryParseTabs())
            .ToList();

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