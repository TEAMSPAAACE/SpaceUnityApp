using UnityEngine;
using System.Collections;
using VRTK;

public class Button5 : BaseTask
{
    void OnEnable()
    {
        taskTextToDisplay = "You need to JUBBA CLOAK now!!";

        taskTextUpdater = GameObject.FindGameObjectWithTag(Tags.TASK_TICKER_TEXT).GetComponent<TaskTextUpdater>();
        taskTextUpdater.SetTickerText(taskTextToDisplay);

        GameObject.FindGameObjectWithTag(Tags.BUTTON_JUBBA_CLOAK).GetComponentInChildren<VRTK_Button>().events.OnPush.AddListener(HandleButtonPress);
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
