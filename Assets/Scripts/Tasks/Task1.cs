using UnityEngine;
using System.Collections;
using VRTK;

public class Task1 : BaseTask
{
    void OnEnable()
    {
        //TODO play sound
        //TODO play animation
        //TODO track time for task failure reasons
        GameObject.FindGameObjectWithTag(Tags.BUTTON_TASK_1).GetComponentInChildren<VRTK_Control>().defaultEvents.OnValueChanged.AddListener(HandleValueChange);
    }
    
    void Update()
    {

    }

    private void HandleValueChange(float value, float normalizedValue)
    {
        if (normalizedValue >= 80)
        {
            OnTaskComplete(SetTaskCompleteEventArgs(true));
        }
    }

    void OnDisable()
    {
        GameObject.FindGameObjectWithTag(Tags.BUTTON_TASK_1).GetComponentInChildren<VRTK_Control>().defaultEvents.OnValueChanged.RemoveAllListeners();
    }
}
