using HTTPUtils;
using Colors = AnsiTools.ANSICodes.Colors;
using static Constants;

public class TaskProcessor
{
    public static string ProcessTask(Func<Task, string> taskProcessor, string taskId = null)
    {
        Task task = GetTaskFromResponse(taskId);
        string taskAnswer = taskProcessor(task);
        return CreateSubmitResponse(task.taskID, taskAnswer);
    }

    private static Response CreateTaskResponse(string taskID)
    {
        if (taskID == null)
        {
            return HttpUtils.instance.Get(baseURL + startEndpoint + myPersonalID).Result;
        }

        return HttpUtils.instance.Get(baseURL + taskEndpoint + myPersonalID + SLASH + taskID).Result;
    }

    public static Task GetTaskFromResponse(string content = null)
    {
        Response response = CreateTaskResponse(content);
        string responseContent = response.content;
        Task task = new Task(responseContent);

        return task;
    }

    private static string CreateSubmitResponse(string taskID, string answer)
    {
        Response response = HttpUtils.instance.Post(baseURL + taskEndpoint + myPersonalID + SLASH + taskID, answer).Result;

        return EvaluateTaskResponse(response);
    }

    private static string EvaluateTaskResponse(Response taskSubmitResponse)
    {
        Task task = new Task(taskSubmitResponse.content);

        if (task.taskID is not null)
        {
            Print.PrintTaskCorrect();
        }
        else if (task.got is null)
        {
            Print.PrintColoredMessage(task.Message, Colors.Green);
        }
        else
        {
            Print.PrintTaskFailed(task);
            throw new Exception(Text.TaskFailed);
        }

        Print.PrintDivider();

        return taskSubmitResponse.content;
    }

}