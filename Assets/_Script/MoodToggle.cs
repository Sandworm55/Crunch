using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoodToggle : MonoBehaviour
{
	public GameObject MoodList;
	public Game Game;
	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}
	public void Toggle()
	{
		if (MoodList.activeSelf)
		{
			MoodList.SetActive(false);
			Game.Paused = false;
		}
		else
		{
			MoodList.SetActive(true);
			Game.Paused = true;
		}

		SFXManager.Singleton.HRScreen.Play();
	}


}
