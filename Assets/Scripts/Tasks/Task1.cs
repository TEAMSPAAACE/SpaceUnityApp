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
        GameObject.FindGameObjectWithTag(Tags.BUTTON_TASK_1).GetComponentInChildren<VRTK_Button>().events.OnPush.AddListener(HandleButtonPress);
    }
    
    void Update()
    {

    }

    private void HandleButtonPress()
    {
            OnTaskComplete(SetTaskCompleteEventArgs(true));
    }

    /*
    void OnDisable()
    {
        GameObject.FindGameObjectWithTag(Tags.BUTTON_TASK_1).GetComponentInChildren<VRTK_Control>().defaultEvents.OnValueChanged.RemoveAllListeners();
    }
    */
}
