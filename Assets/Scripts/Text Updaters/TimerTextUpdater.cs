using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimerTextUpdater : MonoBehaviour {

    private Text text;

    void Start()
    {
        text = GetComponentInChildren<Text>();
        StartCoroutine(DelayTimerText());
    }
    
    IEnumerator DelayTimerText()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            
            text.text = Mathf.FloorToInt(GameManager.Instance.countdownTimer).ToString();
        }
    }
}

