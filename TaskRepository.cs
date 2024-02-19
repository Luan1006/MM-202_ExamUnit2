using HTTPUtils;
using System.Text.Json;
using AnsiTools;
using Colors = AnsiTools.ANSICodes.Colors;

public class TaskRepository
{
    public static Response createStartResponse()
    {
        return HttpUtils.instance.Get(Constants.baseURL + Constants.startEndpoint + Constants.myPersonalID).Result;
    }
    public class Task1
    {

    }
}