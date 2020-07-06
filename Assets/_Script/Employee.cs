using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Employee : MonoBehaviour
{
	public Job job;
	public Mood mood;
	public Image JobIcon, Face, Poof;
	public bool StartReaction = false, Vacation = false, Quit = false, One = false, Done = false, Animating = false, fresh = true;

	public Sprite Art, Code, QA;
	public Sprite Joyfull, Happy, Neutral, Stressed, Angry;
	public Sprite PoofOne, PoofTwo;

	// Start is called before the first frame update
	void Start()
	{
		mood = (Mood)UnityEngine.Random.Range(0, 4);
		ChangeMood(false);
	}

	public void BoostMood()
	{
		mood++;
	}


	public void DropMood(int amountOverride = 0)
	{
		if (amountOverride != 0)
		{
			mood -= amountOverride;
			return;
		}

		switch (mood)
		{
			case Mood.Angry:
				break;
			case Mood.Stressed:
			case Mood.Neutral:
				mood--;
				break;
			case Mood.Happy:
				mood -= UnityEngine.Random.Range(1, 3);
				break;
			case Mood.Joyous:
				mood = Mood.Angry;
				break;
		}
	}

	public void ChangeJob(Job _job)
	{
		job = _job;
		if (mood-- < 0)
			mood = 0;
	}

	public void ChangeMood(bool audio = true)
	{
		switch (mood)
		{
			case Mood.Joyous:
				Face.sprite = Joyfull;
				if (audio)
					SFXManager.Singleton.Joyous.Play();
				break;
			case Mood.Happy:
				Face.sprite = Happy;
				if (audio)
					SFXManager.Singleton.Happy.Play();
				break;
			case Mood.Neutral:
				Face.sprite = Neutral;
				if (audio)
					SFXManager.Singleton.Neutral.Play();
				break;
			case Mood.Stressed:
				Face.sprite = Stressed;
				if (audio)
					SFXManager.Singleton.Stressed.Play();
				break;
			case Mood.Angry:
				Face.sprite = Angry;
				if (audio)
					SFXManager.Singleton.Angry.Play();
				break;
		}

		switch (job)
		{
			case Job.Code:
				JobIcon.sprite = Code;
				break;
			case Job.Art:
				JobIcon.sprite = Art;
				break;
			case Job.QA:
				JobIcon.sprite = QA;
				break;
		}
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		if (StartReaction)
			React();
	}

	public void React()
	{
		StartCoroutine(PoofShow());
		Animating = true;
	}

	public void EndDay()
	{
		if (Vacation && mood == Mood.Joyous)
		{
			mood = Mood.Neutral;
		}
		else if (mood == Mood.Joyous)
			Vacation = true;
		else if (mood == Mood.Neutral)
		{
			if (UnityEngine.Random.Range(0, 1) == 0)
				DropMood(1);
			else
				BoostMood();
		}
		else if (mood == Mood.Stressed)
			mood = Mood.Angry;
		else if (mood == Mood.Angry)
			Quit = true;
	}

	IEnumerator PoofShow()
	{
		Poof.gameObject.SetActive(true);
		for (int i = 0; i < 200; i++)
		{
			if ((i % 10) == 0)
			{
				if (One)
				{
					Poof.sprite = PoofTwo;
					One = false;
				}
				else
				{
					Poof.sprite = PoofOne;
					One = true;
				}
			}
			if (i >= 80)
			{
				Poof.gameObject.SetActive(false);
			}

			if (i >= 160)
			{
				gameObject.transform.localPosition = new Vector3(
					gameObject.transform.localPosition.x + 1,
					gameObject.transform.localPosition.y,
					gameObject.transform.localPosition.z);
			}

			yield return null;
		}
		Done = true;
		StartReaction = false;
		Animating = false;
	}
}

public enum Job
{
	Code,
	Art,
	QA
}
public enum Mood
{
	Angry,
	Stressed,
	Neutral,
	Happy,
	Joyous
}