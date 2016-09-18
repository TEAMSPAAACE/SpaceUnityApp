using UnityEngine;
using System.Collections;
using VRTK;

public class Lever4 : BaseTask
{
    private int chosenValue;
    private VRTK_Lever lever;

    void OnEnable()
    {
        lever = GameObject.FindGameObjectWithTag(Tags.LEVER_WHOLOGRAPHIK_DERT).GetComponentInChildren<VRTK_Lever>();
        lever.defaultEvents.OnValueChanged.AddListener(HandleValueChange);

        if (lever.GetNormalizedValue() <= 50)
        {
            chosenValue = 100;
            taskTextToDisplay = "Clamp the WHOLOGRAPHIK DERT lever to ON. (100)";
        }
        else
        {
            chosenValue = 0;
            taskTextToDisplay = "Clamp the WHOLOGRAPHIK DERT lever to OFF. (0)";
        }

        taskTextUpdater = GameObject.FindGameObjectWithTag(Tags.TASK_TICKER_TEXT).GetComponent<TaskTextUpdater>();
        taskTextUpdater.SetTickerText(taskTextToDisplay);
    }

    private void HandleValueChange(float value, float normalizedValue)
    {
        if (value == chosenValue)
        {
            OnTaskComplete(SetTaskCompleteEventArgs(true));
            taskTextUpdater.SetTickerText(taskCompleteText);
        }
    }

}
