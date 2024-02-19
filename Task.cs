using System.Text.Json;

class Task
{
    public string? title { get; set; }
    public string? description { get; set; }
    public string? taskID { get; set; }
    public string? usierID { get; set; }
    public string? parameters { get; set; }

    public Task(string jsonContent)
    {
        JsonDocument jsonDocument = JsonDocument.Parse(jsonContent);
        JsonElement root = jsonDocument.RootElement;

        if (root.TryGetProperty("title", out JsonElement titleElement))
        {
            title = titleElement.GetString();
        }

        if (root.TryGetProperty("description", out JsonElement descriptionElement))
        {
            description = descriptionElement.GetString();
        }

        if (root.TryGetProperty("taskID", out JsonElement taskIdElement))
        {
            taskID = taskIdElement.GetString();
        }

        if (root.TryGetProperty("usierID", out JsonElement userIdElement))
        {
            usierID = userIdElement.GetString();
        }

        if (root.TryGetProperty("parameters", out JsonElement parametersElement))
        {
            parameters = parametersElement.GetString();
        }
    }
}