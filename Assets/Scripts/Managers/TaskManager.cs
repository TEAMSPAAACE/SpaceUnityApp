﻿using UnityEngine;
using System.Collections;

public class TaskManager : MonoBehaviour
{
    private bool isTaskActive = false;
    private Transform currentTask;
    private Transform lastTask;
    private 
    void OnEnable()
    {
	    
	}
	
	void Update()
    {
        //TODO coroutine to delay between tasks
	    if (!isTaskActive && GameManager.Instance.hyperDriveGauge < 100)
        {
            lastTask = currentTask;
            currentTask = this.transform.GetChild(Random.Range(0, this.transform.childCount));
            if (lastTask == currentTask)
            {
                do
                {
                    currentTask = this.transform.GetChild(Random.Range(0, this.transform.childCount));
                    Debug.Log("Getting new task, was same as old task.");

                } while (lastTask == currentTask);
            }
            currentTask.gameObject.SetActive(true);

            currentTask.GetComponent<BaseTask>().TaskComplete += new TaskCompleteEventHandler(DoCompleteTask);
            isTaskActive = true;
            Debug.Log("Activated " + currentTask.name);
        }
    }

    private void DoCompleteTask(TaskCompleteEventArgs e)
    {
        currentTask.GetComponent<BaseTask>().TaskComplete -= new TaskCompleteEventHandler(DoCompleteTask);
        currentTask.gameObject.SetActive(false);
        GameManager.Instance.UpdateHyperDriveGauge(e.taskStatus, e.taskTag);
        isTaskActive = false;
        Debug.Log("Deactivated " + currentTask.name);
    }
}
