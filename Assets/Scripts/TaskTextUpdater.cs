using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TaskTextUpdater : MonoBehaviour {

    private Text text;
    private string taskText;

    void Start()
    {
        text = GetComponentInChildren<Text>();
    }

    public void SetTickerText(string newTaskText)
    {
        text.text = newTaskText;
    }
}
