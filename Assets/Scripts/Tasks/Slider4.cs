using UnityEngine;
using System.Collections;
using VRTK;

public class Slider4 : BaseTask
{
    private int chosenValue;
    private VRTK_Control sliderScript;

    void OnEnable()
    {
        sliderScript = GameObject.FindGameObjectWithTag(Tags.SLIDER_KFT_TETHER).GetComponentInChildren<VRTK_Control>();

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
                taskTextToDisplay = "Lower the K.F.T. TETHER to SNAKE EYES levels. (1)";
                break;

            case 2:
                taskTextToDisplay = "Lower the K.F.T. TETHER to SUNRISE levels. (2)";
                break;

            case 3:
                taskTextToDisplay = "Lower the K.F.T. TETHER to SUPPLIES levels. (3)";
                break;

            case 4:
                taskTextToDisplay = "Lower the K.F.T. TETHER to SOME FRIES levels. (4)";
                break;

            case 5:
                taskTextToDisplay = "Lower the K.F.T. TETHER to SURPRISE levels. (5)";
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
