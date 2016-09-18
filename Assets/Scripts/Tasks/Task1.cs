using UnityEngine;
using System.Collections;
using VRTK;

public class Task1 : BaseTask
{
    void OnEnable()
    {
        taskTextUpdater = GameObject.FindGameObjectWithTag(Tags.TASK_TICKER_TEXT).GetComponent<TaskTextUpdater>();
        taskTextToDisplay = "Press the button";
        taskTextUpdater.SetTickerText(taskTextToDisplay);

        //TODO play sound
        //TODO play animation
        //TODO track time for task failure reasons
        GameObject.FindGameObjectWithTag(Tags.BUTTON_TASK_1).GetComponentInChildren<VRTK_Button>().events.OnPush.AddListener(HandleButtonPress);
    }

    private void HandleButtonPress()
    {
            OnTaskComplete(SetTaskCompleteEventArgs(true));
            taskTextUpdater.SetTickerText(taskCompleteText);
    }

    /*
    void OnDisable()
    {
        GameObject.FindGameObjectWithTag(Tags.BUTTON_TASK_1).GetComponentInChildren<VRTK_Control>().defaultEvents.OnValueChanged.RemoveAllListeners();
    }
    */
}
