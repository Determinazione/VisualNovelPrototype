using Newtonsoft.Json;

class Format
{
    [JsonProperty("Scenes")]
    SceneData[] Scenes { get; set; }
}

class SceneData
{
    [JsonProperty("SceneNumber")]
    public int SceneNumber { get; set; }

    [JsonProperty("Content")]
    public Content[] Contents { get; set; }

    [JsonProperty("Choice")]
    public Choice[] Choices { get; set; }
}

class Content
{
    [JsonProperty("Dialogue")]
    public string Dialogue { get; set; }

    [JsonProperty("FontColour")]
    public string FontColour { get; set; }
}

class Choice
{
    [JsonProperty("FontColour")]
    public string FontColour { get; set; }

    [JsonProperty("OptionContent")]
    public string OptionContent { get; set; }

    [JsonProperty("NextSceneNumber")]
    public int NextSceneNumber { get; set; }
}
