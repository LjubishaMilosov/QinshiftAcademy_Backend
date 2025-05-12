namespace ExtensionMethods
{
    public static class StringHelper
    {
        public static string Shorten(this string text, int numberOdWords)
        {

            // validations
            if(numberOdWords <= 0)
            {
                return "";// string.Empty
            }
            if(string.IsNullOrEmpty(text))
            {
                return string.Empty;
            }
            string[] words = text.Split(" "); // we split the text by empty spaces

            if(words.Length < numberOdWords)
            {
                // either return a message with an error or return the whole text because the user wanted for example 10 words
                // but we only have 7 which is less than 10 (the max words that the user wanted shorened)
                return text;
            }
            // Take() returns IEnumerable and we can transform it ToList() or ToAray()
            List<string> resultWords = words.Take(numberOdWords).ToList(); // Some, text, about, G6
            string result = string.Join(" ", resultWords); // Some text about G6

            return result;

        }
    }
}
