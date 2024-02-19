using HTTPUtils;
using System.Text.Json;
using AnsiTools;
using Colors = AnsiTools.ANSICodes.Colors;

public class TaskRepository
{
    public static Response CreateStartResponse()
    {
        return HttpUtils.instance.Get(Constants.baseURL + Constants.startEndpoint + Constants.myPersonalID).Result;
    }

    public static Response CreateTaskResponse(string taskID)
    {
        return HttpUtils.instance.Get(Constants.baseURL + Constants.taskEndpoint + Constants.myPersonalID + "/" + taskID).Result;
    }

    public static Response CreateSubmitResponse(string taskID, string answer)
    {
        return HttpUtils.instance.Post(Constants.baseURL + Constants.taskEndpoint + Constants.myPersonalID + "/" + taskID, answer).Result;
    }
    public class Task1
    {

    }
}