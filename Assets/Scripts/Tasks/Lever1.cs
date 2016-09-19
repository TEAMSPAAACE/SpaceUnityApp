using UnityEngine;
using System.Collections;
using VRTK;

public class Lever1 : BaseTask
{
    private int chosenValue;
    private VRTK_Lever lever;

    void OnEnable()
    {
        lever = GameObject.FindGameObjectWithTag(Tags.LEVER_SERVOK_ADAMANTOR).GetComponentInChildren<VRTK_Lever>();
        lever.defaultEvents.OnValueChanged.AddListener(HandleValueChange);

        if (lever.GetNormalizedValue() <= 50)
        {
            chosenValue = 100;
            taskTextToDisplay = "Move the SERVOK ADAMANTOR to full power.";
        }
        else
        {
            chosenValue = 0;
            taskTextToDisplay = "Move the SERVOK ADAMANTOR to no power.";
        }

        taskTextUpdater = GameObject.FindGameObjectWithTag(Tags.TASK_TICKER_TEXT).GetComponent<TaskTextUpdater>();
        taskTextUpdater.SetTickerText(taskTextToDisplay);
    }

    private void HandleValueChange(float value, float normalizedValue)
    {
        if (normalizedValue == chosenValue)
        {
            OnTaskComplete(SetTaskCompleteEventArgs(true));
            //taskTextUpdater.SetTickerText(taskCompleteText);
        }
    }

}
