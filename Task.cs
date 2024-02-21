using System.Text.Json;
using static Constants;

public class Task
{
    public string? title { get; set; }
    public string? description { get; set; }
    public string? taskID { get; set; }
    public string? usierID { get; set; }
    public string? parameters { get; set; }
    public string? Message { get; set; }
    public string? got { get; set; }
    public string? expected { get; set; }
    
    public Task(string jsonContent)
    {
        JsonDocument jsonDocument = JsonDocument.Parse(jsonContent);
        JsonElement root = jsonDocument.RootElement;

        title = GetProperty(root, TaskProperty.title);
        description = GetProperty(root, TaskProperty.description);
        taskID = GetProperty(root, TaskProperty.taskID);
        usierID = GetProperty(root, TaskProperty.usierID);
        parameters = GetProperty(root, TaskProperty.parameters);
        Message = GetProperty(root, TaskProperty.Message);
        got = GetProperty(root, TaskProperty.got);
        expected = GetProperty(root, TaskProperty.expected);
    }

    private string GetProperty(JsonElement root, string propertyName)
    {
        if (root.TryGetProperty(propertyName, out JsonElement element))
        {
            return element.GetString();
        }

        return null;
    }
}