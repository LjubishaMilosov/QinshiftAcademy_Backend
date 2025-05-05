//Create two classes Document and WebPage that implement the Searchable interface and provide their own implementations of the Search() method.

using Microsoft.VisualBasic;
using Task_01.Domain.Interfaces;

namespace Task_01.Domain.Models
{
    public class Document : ISearchable
    {
        public string Content { get; set; }

        public Document(string content)
        {
            Content = content;
        }

        public void Search(string word)
        {
            // Why Use StringComparison.OrdinalIgnoreCase?
            //Ordinal comparisons are faster because they don't consider culture-specific rules.
           
            if (Content.Contains(word, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"The word '{word}' was found in the document.");
            }
            else
            {
                Console.WriteLine($"The word '{word}' was not found in the document.");
            }
        }
    }

}
    