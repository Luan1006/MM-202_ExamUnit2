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

        if (root.TryGetProperty(TaskProperty.title, out JsonElement titleElement))
        {
            title = titleElement.GetString();
        }

        if (root.TryGetProperty(TaskProperty.description, out JsonElement descriptionElement))
        {
            description = descriptionElement.GetString();
        }

        if (root.TryGetProperty(TaskProperty.taskID, out JsonElement taskIdElement))
        {
            taskID = taskIdElement.GetString();
        }

        if (root.TryGetProperty(TaskProperty.usierID, out JsonElement userIdElement))
        {
            usierID = userIdElement.GetString();
        }

        if (root.TryGetProperty(TaskProperty.parameters, out JsonElement parametersElement))
        {
            parameters = parametersElement.GetString();
        }

        if (root.TryGetProperty(TaskProperty.Message, out JsonElement messageElement))
        {
            Message = messageElement.GetString();
        }

        if (root.TryGetProperty(TaskProperty.got, out JsonElement gotElement))
        {
            got = gotElement.GetString();
        }

        if (root.TryGetProperty(TaskProperty.expected, out JsonElement expectedElement))
        {
            expected = expectedElement.GetString();
        }
    }
}