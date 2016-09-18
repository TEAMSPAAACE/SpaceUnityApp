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
    protected TaskTextUpdater taskTextUpdater;
    protected string taskCompleteText = "Task Complete!";

    /*
    public virtual void OnEnable()
    {
        //TODO not sure if base class needs the following TODOs
        //TODO play sound
        //TODO play animation
        //TODO track time for task failure reasons
    }
    */

    void Update()
    {

    }

    void OnDisable()
    {
    }

}
