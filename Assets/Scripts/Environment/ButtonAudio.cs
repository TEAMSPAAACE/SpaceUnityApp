using UnityEngine;
using System.Collections;
using VRTK;

public class ButtonAudio : MonoBehaviour 
{
	private AudioSource buttonAudio;

	void OnEnable()
	{
		buttonAudio = GetComponent<AudioSource>();
		GetComponent<VRTK_Button>().events.OnPush.AddListener(ButtonPressSound);
	}

	private void ButtonPressSound()
	{
		if (buttonAudio.isPlaying) 
		{
			buttonAudio.Stop();
		}

		buttonAudio.Play();
	}

}
