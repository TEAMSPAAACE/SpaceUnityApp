using UnityEngine;
using System.Collections;
using VRTK;

public class Button2 : BaseTask
{
    void OnEnable()
    {
        taskTextToDisplay = "Send an ADNIX TELEGRAPH!";

        taskTextUpdater = GameObject.FindGameObjectWithTag(Tags.TASK_TICKER_TEXT).GetComponent<TaskTextUpdater>();
        taskTextUpdater.SetTickerText(taskTextToDisplay);

        GameObject.FindGameObjectWithTag(Tags.BUTTON_ADNIX_TELEGRAPH).GetComponentInChildren<VRTK_Button>().events.OnPush.AddListener(HandleButtonPress);
    }

    private void HandleButtonPress()
    {
        OnTaskComplete(SetTaskCompleteEventArgs(true));
     //   taskTextUpdater.SetTickerText(taskCompleteText);
    }
}
