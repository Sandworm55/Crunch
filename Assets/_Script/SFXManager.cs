using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SFXManager : MonoBehaviour
{
	public AudioSource Angry, EndOfDay, Happy, HRScreen, Joyous, Neutral, Stressed;
	public AudioMixer SFXMixer;
	public Slider SFX;

	public static SFXManager Singleton;

	// Start is called before the first frame update
	void Start()
	{
		if (Singleton == null)
			Singleton = this;
		else
			GameObject.Destroy(this);
	}

	// Update is called once per frame
	void Update()
	{

	}

	public void SetVolumes()
	{
		float vol = SFX.value;

		Angry.volume = vol;
		EndOfDay.volume = vol;
		Happy.volume = vol;
		HRScreen.volume = vol;
		Joyous.volume = vol;
		Neutral.volume = vol;
		Stressed.volume = vol;
	}
}
