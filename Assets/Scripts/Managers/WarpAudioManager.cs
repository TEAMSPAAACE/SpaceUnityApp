using UnityEngine;
using System.Collections;

public class WarpAudioManager : MonoBehaviour
{
    private AudioSource[] audios;
    private AudioSource halfChargeAudio;
    private AudioSource fullChargeAudio;

    void Start()
    {
        audios = GetComponents<AudioSource>();
        halfChargeAudio = audios[0];
        fullChargeAudio = audios[1];
    }

    public void playHalfChargeAudio()
    {
        if (!halfChargeAudio.isPlaying)
            halfChargeAudio.Play();
    }

    public void playFullChargeAudio()
    {
        if (!fullChargeAudio.isPlaying)
            fullChargeAudio.Play();
    }
}