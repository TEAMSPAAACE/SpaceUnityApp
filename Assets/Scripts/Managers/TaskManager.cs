using UnityEngine;
using System.Collections;

public class TaskManager : MonoBehaviour
{
    private bool isTaskActive = false;
    private Transform currentTask;

	void OnEnable()
    {
	
	}
	
	void Update()
    {
	    if (!isTaskActive)
        {
            currentTask = this.transform.GetChild(Random.Range(0, this.transform.childCount - 1));
            currentTask.gameObject.SetActive(true);
            currentTask.GetComponent<BaseTask>().TaskComplete += new TaskCompleteEventHandler(DoCompleteTask);
            isTaskActive = true;
            Debug.Log("Activated " + currentTask.name);
        }
    }

    private void DoCompleteTask(TaskCompleteEventArgs e)
    {
        currentTask.gameObject.SetActive(false);
        GameManager.Instance.UpdateHypeDriveGauge(e.taskStatus, e.taskTag);
        currentTask.GetComponent<BaseTask>().TaskComplete -= new TaskCompleteEventHandler(DoCompleteTask);
        isTaskActive = false;
        Debug.Log("Deactivated " + currentTask.name);
    }
}
