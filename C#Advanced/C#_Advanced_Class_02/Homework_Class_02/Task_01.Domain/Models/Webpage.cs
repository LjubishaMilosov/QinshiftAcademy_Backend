// //Create two classes Document and WebPage that implement the Searchable interface and provide their own implementations of the Search() method.

using Task_01.Domain.Interfaces;

namespace Task_01.Domain.Models
{
    public class Webpage : ISearchable
    {
        public string HtmlContent { get; set; }

        public Webpage(string htmlContent)
        {
            HtmlContent = htmlContent;
        }

        public void Search(string word)
        {
            if (HtmlContent.Contains(word, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"The word '{word}' was found on the webpage.");
            }
            else
            {
                Console.WriteLine($"The word '{word}' was not found on the webpage.");
            }
        }
    }
}
