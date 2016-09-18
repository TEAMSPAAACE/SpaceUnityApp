﻿using UnityEngine;
using System.Collections;
using VRTK;

public class Task2 : BaseTask
{
    private int chosenValue;
    private VRTK_Control sliderScript;

    void OnEnable()
    {
        //TODO play sound
        //TODO play animation
        //TODO track time for task failure reasons
        sliderScript = GameObject.FindGameObjectWithTag(Tags.SLIDER_TASK_2).GetComponentInChildren<VRTK_Control>();

        chosenValue = Random.Range(1, 6);

        if (chosenValue == sliderScript.GetValue())
        {
            do
            {
                chosenValue = Random.Range(1, 5);
                Debug.Log("Getting new number, was same as old number.");

            } while (chosenValue == sliderScript.GetValue());
        }

        Debug.Log("Please move slider to " + chosenValue);

        sliderScript.defaultEvents.OnValueChanged.AddListener(HandleValueChange);
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