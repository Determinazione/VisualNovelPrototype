using Newtonsoft.Json;
using System.IO;

public class DialogueLoader
{
    public void ReadFromFile(string path)
    {
        using (StreamReader reader = new StreamReader(path))
        {
            string originalData = reader.ReadToEnd();
            Format convertedData = JsonConvert.DeserializeObject<Format>(originalData);
        }
    }
}
