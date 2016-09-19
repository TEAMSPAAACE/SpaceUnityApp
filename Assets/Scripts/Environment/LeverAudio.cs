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
        if (leverAudio.isPlaying)
        {
            leverAudio.Stop();
        }

        leverAudio.Play();
    }

}
