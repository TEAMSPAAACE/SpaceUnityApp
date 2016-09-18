using UnityEngine;
using System.Collections;
using VRTK;

public class Slider2 : BaseTask
{
    private int chosenValue;
    private VRTK_Control sliderScript;

    void OnEnable()
    {
        sliderScript = GameObject.FindGameObjectWithTag(Tags.SLIDER_HUBRIZINE_RECEPTICLE).GetComponentInChildren<VRTK_Control>();

        chosenValue = Random.Range(1, 6);
        if (chosenValue == sliderScript.GetValue())
        {
            do
            {
                chosenValue = Random.Range(1, 5);
            } while (chosenValue == sliderScript.GetValue());
        }

        switch (chosenValue)
        {
            case 1:
                taskTextToDisplay = "Set the HUBRIZINE RECEPTICLE to receive PERTOSHKAS. (1)";
                break;

            case 2:
                taskTextToDisplay = "Set the HUBRIZINE RECEPTICLE to receive DONUTS. (2)";
                break;

            case 3:
                taskTextToDisplay = "Set the HUBRIZINE RECEPTICLE to receive PACHINKOS. (3)";
                break;

            case 4:
                taskTextToDisplay = "Set the HUBRIZINE RECEPTICLE to receive NDIARAS. (4)";
                break;

            case 5:
                taskTextToDisplay = "Set the HUBRIZINE RECEPTICLE to receive SUNCHISILLARS. (5)";
                break;

            default:
                Debug.LogError("Chosen Value outside range of slider.");
                break;
        }

        taskTextUpdater = GameObject.FindGameObjectWithTag(Tags.TASK_TICKER_TEXT).GetComponent<TaskTextUpdater>();
        taskTextUpdater.SetTickerText(taskTextToDisplay);

        sliderScript.defaultEvents.OnValueChanged.AddListener(HandleValueChange);
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
