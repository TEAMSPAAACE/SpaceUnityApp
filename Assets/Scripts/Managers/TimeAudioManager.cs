using UnityEngine;
using System.Collections;

public class TimeAudioManager : MonoBehaviour {

    private float countdownTimer;
    private AudioSource[] audios;
    private AudioSource audioTwoMinuteWarning;
    private AudioSource audio90SecondsWarning;
    private AudioSource audio60SecondsWarning;
    private AudioSource audio30SecondsWarning;
    private AudioSource audioFinalCountdown;

    void Start()
    {
        audios = GetComponents<AudioSource>();
        audioTwoMinuteWarning = audios[0];
        audio90SecondsWarning = audios[1];
        audio60SecondsWarning = audios[2];
        audio30SecondsWarning = audios[3];
        audioFinalCountdown   = audios[4];
        StartCoroutine(DelayTimerText());
    }

    //TODO shudder 09/22/16
    IEnumerator DelayTimerText()
    {
        while (GameManager.Instance.countdownTimer >= 0f)
        {
            yield return new WaitForSeconds(1f);
            countdownTimer = GameManager.Instance.countdownTimer;

            if (Mathf.Floor(countdownTimer) == 118)
            {
                if (!audioTwoMinuteWarning.isPlaying)
                    audioTwoMinuteWarning.Play();
            }
            else if (Mathf.Floor(countdownTimer) == 90)
            {
                if (!audio90SecondsWarning.isPlaying)
                    audio90SecondsWarning.Play();
            }
            else if (Mathf.Floor(countdownTimer) == 60)
            {
                if (!audio60SecondsWarning.isPlaying)
                    audio60SecondsWarning.Play();
            }
            else if (Mathf.Floor(countdownTimer) == 30)
            {
                if (!audio30SecondsWarning.isPlaying)
                    audio30SecondsWarning.Play();
            }
            else if (Mathf.Floor(countdownTimer) == 10)
            {
                if (!audioFinalCountdown.isPlaying)
                    audioFinalCountdown.Play();
            }
        }
    }
}