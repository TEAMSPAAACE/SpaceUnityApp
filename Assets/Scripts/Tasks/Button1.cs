using UnityEngine;
using System.Collections;
using VRTK;

public class Button1 : BaseTask
{
    void OnEnable()
    {
        taskTextToDisplay = "Activate the POSITRONIC BRAIN CORE!";

        taskTextUpdater = GameObject.FindGameObjectWithTag(Tags.TASK_TICKER_TEXT).GetComponent<TaskTextUpdater>();
        taskTextUpdater.SetTickerText(taskTextToDisplay);

        GameObject.FindGameObjectWithTag(Tags.BUTTON_POSITRONIC_BRAIN_CORE).GetComponentInChildren<VRTK_Button>().events.OnPush.AddListener(HandleButtonPress);
    }

    private void HandleButtonPress()
    {
            OnTaskComplete(SetTaskCompleteEventArgs(true));
            taskTextUpdater.SetTickerText(taskCompleteText);
    }
}
