using UnityEngine;
using System.Collections;
using VRTK;

public class SliderAudio : MonoBehaviour 
{
	private AudioSource sliderAudio;

	void OnEnable()
	{
		sliderAudio = GetComponent<AudioSource>();
		GameObject.FindGameObjectWithTag(Tags.SLIDER_TASK_2).GetComponentInChildren<VRTK_Control>().defaultEvents.OnValueChanged.AddListener(SliderSound);
	}

	private void SliderSound(float a, float b)
	{
		if (sliderAudio.isPlaying) 
		{
			sliderAudio.Stop();
		}

		sliderAudio.Play();
	}

}
