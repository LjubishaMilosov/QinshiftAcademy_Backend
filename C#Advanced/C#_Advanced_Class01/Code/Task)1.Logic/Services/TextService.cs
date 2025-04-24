

using Task_1.Logic.Models;

namespace Task_1.Logic.Services
{
    public class TextService
    {
        public List<NameCountResult> CountNameAppearancesInText(string text, List<string> names)
        {
           var nwordsInText  = text.Split(new char[] {' ', '.', ',' }, StringSplitOptions.RemoveEmptyEntries);

            List<NameCountResult> namesCountResult = names
                .Select(name => new NameCountResult
                {
                    Name = name,
                    Count = nwordsInText.Count(word => word.Equals(name, StringComparison.OrdinalIgnoreCase))
                })
                .ToList();
         
            // Step by Step
            List<NameCountResult> namesCountResultExample = new();
            foreach(string name in names)
            {
                int nameCounter = 0;
                foreach (var word in nwordsInText)
                {
                    if (name.ToLower() == word.ToLower())
                    {
                        nameCounter++;
                    }
                }
                NameCountResult nameCount = new NameCountResult(name,nameCounter);
                namesCountResultExample.Add(nameCount);
            }

            return namesCountResultExample;
        }
    }
}
