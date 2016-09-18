using UnityEngine;
using System.Collections;
using VRTK;

public class Slider1 : BaseTask
{
    private int chosenValue;
    private VRTK_Control sliderScript;

    void OnEnable()
    {
        sliderScript = GameObject.FindGameObjectWithTag(Tags.SLIDER_UBER_F_RAY).GetComponentInChildren<VRTK_Control>();

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
                taskTextToDisplay = "Set the UBER F-RAY to the SPIDER ROBOT (1) setting.";
                break;

            case 2:
                taskTextToDisplay = "Set the UBER F-RAY to the NASTY OLD MAN (2) setting.";
                break;

            case 3:
                taskTextToDisplay = "Set the UBER F-RAY to the POTATO (3) setting.";
                break;

            case 4:
                taskTextToDisplay = "Set the UBER F-RAY to the SPACE KITTEN (4) setting.";
                break;

            case 5:
                taskTextToDisplay = "Set the UBER F-RAY to the GOLDEN GOLD (5) setting.";
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
