using UnityEngine;
using System.Collections;
using VRTK;

public class Button4 : BaseTask
{
    void OnEnable()
    {
        taskTextToDisplay = "Quantize with QUANTUM COMMUNICATIONS.";

        taskTextUpdater = GameObject.FindGameObjectWithTag(Tags.TASK_TICKER_TEXT).GetComponent<TaskTextUpdater>();
        taskTextUpdater.SetTickerText(taskTextToDisplay);

        GameObject.FindGameObjectWithTag(Tags.BUTTON_QUANTUM_COMMUNICATIONS).GetComponentInChildren<VRTK_Button>().events.OnPush.AddListener(HandleButtonPress);
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
