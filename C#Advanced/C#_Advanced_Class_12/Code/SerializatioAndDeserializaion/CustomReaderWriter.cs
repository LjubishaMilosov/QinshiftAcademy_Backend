

namespace SerializationAndDeserializaion
{
    public class CustomReaderWriter
    {
        public string ReadFromFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new Exception();
            }
        }
    }
}
