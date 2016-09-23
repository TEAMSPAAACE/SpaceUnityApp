using UnityEngine;
using System.Collections;
using VRTK;

public class SliderAudio : MonoBehaviour 
{
	private AudioSource sliderAudio;

	void OnEnable()
	{
		sliderAudio = GetComponent<AudioSource>();
		GetComponentInChildren<VRTK_Control>().defaultEvents.OnValueChanged.AddListener(SliderSound);
	}

	private void SliderSound(float a, float b)
	{
        //TODO ugly workaround to not spam sounds on level load 09/22/16
        if (!sliderAudio.enabled && GameManager.Instance.countdownTimer <= GameManager.Instance.gameSessionLength - 1f)
            sliderAudio.enabled = true;

        if (sliderAudio.isPlaying) 
		{
			sliderAudio.Stop();
		}

		sliderAudio.Play();
	}

}
