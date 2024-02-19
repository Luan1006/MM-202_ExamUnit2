using System.Text.Json;

class Task
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

        if (root.TryGetProperty("Message", out JsonElement messageElement))
        {
            Message = messageElement.GetString();
        }

        if (root.TryGetProperty("got", out JsonElement gotElement))
        {
            got = gotElement.GetString();
        }

        if (root.TryGetProperty("expected", out JsonElement expectedElement))
        {
            expected = expectedElement.GetString();
        }
    }
}