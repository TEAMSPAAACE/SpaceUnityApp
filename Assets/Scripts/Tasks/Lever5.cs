using UnityEngine;
using System.Collections;
using VRTK;

public class Lever5 : BaseTask
{
    private int chosenValue;
    private VRTK_Lever lever;

    void OnEnable()
    {
        lever = GameObject.FindGameObjectWithTag(Tags.LEVER_DATUMPLANE).GetComponentInChildren<VRTK_Lever>();
        lever.defaultEvents.OnValueChanged.AddListener(HandleValueChange);

        if (lever.GetNormalizedValue() <= 50)
        {
            chosenValue = 100;
            taskTextToDisplay = "DATUMPLANE needs maximum FEELINGS. (100)";
        }
        else
        {
            chosenValue = 0;
            taskTextToDisplay = "DATUMPLANE needs and wants NO ONE. (0)";
        }

        taskTextUpdater = GameObject.FindGameObjectWithTag(Tags.TASK_TICKER_TEXT).GetComponent<TaskTextUpdater>();
        taskTextUpdater.SetTickerText(taskTextToDisplay);
    }

    private void HandleValueChange(float value, float normalizedValue)
    {
        if (normalizedValue == chosenValue)
        {
            OnTaskComplete(SetTaskCompleteEventArgs(true));
         //   taskTextUpdater.SetTickerText(taskCompleteText);
        }
    }

}
