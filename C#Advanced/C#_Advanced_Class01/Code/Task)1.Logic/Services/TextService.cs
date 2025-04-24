

using Task_1.Logic.Models;

namespace Task_1.Logic.Services
{
    public class TextService
    {
        public List<NameCountResult> CountNameAppearancesInText(string text, List<string> names)
        {
           var nwordsInText  = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var nameCountResults = new List<NameCountResult>();
            foreach (var name in names)
            {
                var count = nwordsInText.Count(word => string.Equals(word, name, StringComparison.OrdinalIgnoreCase));
                nameCountResults.Add(new NameCountResult(name, count));
            }
            return nameCountResults;
        }
    }
}
