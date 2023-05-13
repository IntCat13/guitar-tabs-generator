using GeneratorLibrary.Models;

namespace GeneratorLibrary.Tools;

public static class TabsExtensions
{
   // Returns Tabs object if string has correct structure
   public static Tabs TryParseTabs(this string text)
   {
      string? timeSignature = null;
      string? tempo = null;
      string? key = null;
      string? tuning = null;
      string? title = null;
      string content = "";
      
      string[] lines = text.Split("\n");

      foreach (var line in lines)
      {
         if (line.IsContainsElement("signature:"))
         {
            timeSignature = line.GetElement();
            continue;
         }

         if (line.IsContainsElement("tempo:"))
         {
            tempo = line.GetElement();
            continue;
         }
         
         if (line.IsContainsElement("key:"))
         {
            key = line.GetElement();
            continue;
         }
         
         if (line.IsContainsElement("tuning:"))
         {
            tuning = line.GetElement();
            continue;
         }
         
         if (line.IsContainsElement("title:"))
         {
            title = line.GetElement();
            continue;
         }
         
         content += line+"\n";
      }

      return new Tabs(timeSignature, tempo, key, tuning, title, content);
   }

   // Returns element if it contains in string
   private static bool IsContainsElement(this string text, string element)
   {
      string[] words = text.ToLower().Split(" ");
      
      return words.Contains(element);
   }

   // Check if string has incorrect structure
   private static bool IsHasIncorrectStructure(this string text)
   {
      if (text.Contains(":") == false)
         return true;

      if (text.LastIndexOf(':') + 1 > text.Length)
         return true;

      return false;
   }
   
   // Returns element after ":" element
   private static string? GetElement(this string text)
   {
      if (text.IsHasIncorrectStructure())
         return null;

      return text.Substring(text.LastIndexOf(':') + 1);
   }
}