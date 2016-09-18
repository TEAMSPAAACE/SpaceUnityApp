using UnityEngine;
using System.Collections;
using VRTK;

public class Task3 : BaseTask
{
    private int chosenValue;

    void OnEnable()
    {
        //TODO play sound
        //TODO play animation
        //TODO track time for task failure reasons
        GameObject.FindGameObjectWithTag(Tags.SLIDER_TASK_2).GetComponentInChildren<VRTK_Slider>().defaultEvents.OnValueChanged.AddListener(HandleValueChange);
    }

    void Update()
    {

    }

    private void HandleValueChange(float value, float normalizedValue)
    {
        if (value == chosenValue)
        {
            OnTaskComplete(SetTaskCompleteEventArgs(true));
        }
    }

    /*
    void OnDisable()
    {
        GameObject.FindGameObjectWithTag(Tags.BUTTON_TASK_1).GetComponentInChildren<VRTK_Control>().defaultEvents.OnValueChanged.RemoveAllListeners();
    }
    */
}
