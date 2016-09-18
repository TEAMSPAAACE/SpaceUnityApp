using UnityEngine;
using System.Collections;
using VRTK;

public class Lever3 : BaseTask
{
    private int chosenValue;
    private VRTK_Lever lever;

    void OnEnable()
    {
        lever = GameObject.FindGameObjectWithTag(Tags.LEVER_CHEMOTACTIC_ARTIFICIAL_JELLYFISH).GetComponentInChildren<VRTK_Lever>();
        lever.defaultEvents.OnValueChanged.AddListener(HandleValueChange);

        if (lever.GetNormalizedValue() <= 50)
        {
            chosenValue = 100;
            taskTextToDisplay = "Rate the CHEMOTACTIC ARTIFICIAL JELLYFISH as FULLY ENERGETIC. (100)";
        }
        else
        {
            chosenValue = 0;
            taskTextToDisplay = "Rate the CHEMOTACTIC ARTIFICIAL JELLYFISH as NO ENERGY. (0)";
        }

        taskTextUpdater = GameObject.FindGameObjectWithTag(Tags.TASK_TICKER_TEXT).GetComponent<TaskTextUpdater>();
        taskTextUpdater.SetTickerText(taskTextToDisplay);
    }

    private void HandleValueChange(float value, float normalizedValue)
    {
        if (normalizedValue == chosenValue)
        {
            OnTaskComplete(SetTaskCompleteEventArgs(true));
            taskTextUpdater.SetTickerText(taskCompleteText);
        }
    }

}
