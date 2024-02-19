using System.Text.Json;

class Task
{
    public string? title { get; set; }
    public string? description { get; set; }
    public string? taskID { get; set; }
    public string? usierID { get; set; }
    public string? parameters { get; set; }
    
    public static string GetTaskTitleFromJson(string content)
    {
        JsonDocument jsonDocument = JsonDocument.Parse(content);
        return jsonDocument.RootElement.GetProperty("title").GetString();
    }

    public static string GetTaskDescriptionFromJson(string content)
    {
        JsonDocument jsonDocument = JsonDocument.Parse(content);
        return jsonDocument.RootElement.GetProperty("description").GetString();
    }

    public static string GetTaskIdFromJson(string content)
    {
        JsonDocument jsonDocument = JsonDocument.Parse(content);
        return jsonDocument.RootElement.GetProperty("taskID").GetString();
    }

    public static string GetUsierIdFromJson(string content)
    {
        JsonDocument jsonDocument = JsonDocument.Parse(content);
        return jsonDocument.RootElement.GetProperty("usierID").GetString();
    }

    public static string GetParametersFromJson(string content)
    {
        JsonDocument jsonDocument = JsonDocument.Parse(content);
        return jsonDocument.RootElement.GetProperty("parameters").GetString();
    }
}