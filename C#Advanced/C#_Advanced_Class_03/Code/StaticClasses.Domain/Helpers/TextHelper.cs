namespace StaticClasses.Domain.Helpers
{
    public static class TextHelper
    {
        public static int ValidateInput(string input)
        {
            bool success = int.TryParse(input, out int choice);
            if (success)
            {
                return choice;
            }
            else
            {
                return - 1;
            }
        }
    }
}
