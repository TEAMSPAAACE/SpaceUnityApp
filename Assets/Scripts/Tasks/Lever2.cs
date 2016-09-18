using UnityEngine;
using System.Collections;
using VRTK;

public class Lever2 : BaseTask
{
    private int chosenValue;
    private VRTK_Lever lever;

    void OnEnable()
    {
        lever = GameObject.FindGameObjectWithTag(Tags.LEVER_CARNICULTURE_VAT).GetComponentInChildren<VRTK_Lever>();
        lever.defaultEvents.OnValueChanged.AddListener(HandleValueChange);

        if (lever.GetNormalizedValue() <= 50)
        {
            chosenValue = 100;
            taskTextToDisplay = "Set the CARNICULTURE VAT to YES slice. (100)";
        }
        else
        {
            chosenValue = 0;
            taskTextToDisplay = "Set the CARNICULTURE VAT to NO slice. (0)";
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
