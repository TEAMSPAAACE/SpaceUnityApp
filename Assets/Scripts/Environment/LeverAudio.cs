using UnityEngine;
using System.Collections;
using VRTK;

public class LeverAudio : MonoBehaviour
{
    private AudioSource leverAudio;

    void OnEnable()
    {
        leverAudio = GetComponent<AudioSource>();
        GetComponentInChildren<VRTK_Control>().defaultEvents.OnValueChanged.AddListener(LeverPressSound);
    }

    private void LeverPressSound(float a, float b)
    {
        //TODO ugly workaround to not spam sounds on level load 09/22/16
        if (!leverAudio.enabled && GameManager.Instance.countdownTimer <= GameManager.Instance.gameSessionLength - 1f)
            leverAudio.enabled = true;

        if (leverAudio.isPlaying)
        {
            leverAudio.Stop();
        }

        leverAudio.Play();
    }

}
