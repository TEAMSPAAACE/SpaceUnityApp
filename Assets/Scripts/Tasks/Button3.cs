using UnityEngine;
using System.Collections;
using VRTK;

public class Button3 : BaseTask
{
    void OnEnable()
    {
        taskTextToDisplay = "Toggle the WHUFFIE TOGGLER... if you dare.";

        taskTextUpdater = GameObject.FindGameObjectWithTag(Tags.TASK_TICKER_TEXT).GetComponent<TaskTextUpdater>();
        taskTextUpdater.SetTickerText(taskTextToDisplay);

        GameObject.FindGameObjectWithTag(Tags.BUTTON_WHUFFIE_TOGGLER).GetComponentInChildren<VRTK_Button>().events.OnPush.AddListener(HandleButtonPress);
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
