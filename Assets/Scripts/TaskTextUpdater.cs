using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TaskTextUpdater : MonoBehaviour {

    private Text text;
    private string taskText;

    void Start()
    {
        text = GetComponent<Text>();
        StartCoroutine(TextUpdateDelay());
    }

    IEnumerator TextUpdateDelay()
    {
        while (true)
        {
            text.text = taskText;
            yield return new WaitForSeconds(.1f);
        }
    }

    public void SetTickerText(string newTaskText)
    {
        taskText = newTaskText;
    }
}
