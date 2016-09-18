using UnityEngine;
using System.Collections;
using VRTK;

public struct TaskCompleteEventArgs
{
    public bool taskStatus;
    public string taskTag;
}

public delegate void TaskCompleteEventHandler(TaskCompleteEventArgs e);


public class BaseTask : MonoBehaviour
{
    public event TaskCompleteEventHandler TaskComplete;

    public virtual void OnTaskComplete(TaskCompleteEventArgs e)
    {
        if (TaskComplete != null)
            TaskComplete(e);
    }

    protected TaskCompleteEventArgs SetTaskCompleteEventArgs(bool taskStatus)
    {
        TaskCompleteEventArgs e;
        e.taskStatus = taskStatus;
        e.taskTag = this.transform.tag;
        return e;
    }

    protected string taskTextToDisplay;

    private TaskTextUpdater taskTextUpdater;
    private string taskCompleteText = "Task Complete!";

    void OnEnable()
    {
        //TODO not sure if base class needs the following TODOs
        //TODO play sound
        //TODO play animation
        //TODO track time for task failure reasons
        taskTextUpdater = GameObject.FindGameObjectWithTag(Tags.TASK_SCREEN_TEXT).GetComponent<TaskTextUpdater>();
        taskTextUpdater.SetTickerText(taskTextToDisplay);
    }

    void Update()
    {

    }

    void OnDisable()
    {
        taskTextUpdater.SetTickerText(taskCompleteText);
    }

}
