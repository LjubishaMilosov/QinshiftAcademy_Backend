using System.Data;

namespace NotesApp.Helpers
{
    public static class ValidationHelper
    {
        public static void ValidateRequiredStringColumnLength(string value, string field, int maxNumOfChar)
        {
            if(string.IsNullOrEmpty(value))
            {
                throw new DataException($"{field} is required.");
            }
            if(value.Length > maxNumOfChar)
            {
                throw new DataException($"{field} cannot be longer than {maxNumOfChar} characters.");
            }

        }

        public static void ValidateColumnLength(string value, string field, int maxNumOfChar)
        {
            var length = value == null ? 0 : value.Length;
            if (length > maxNumOfChar)
            {
                throw new DataException($"{field} cannot be longer than {maxNumOfChar} characters.");
            }

        }
    }
}
