using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Employee : MonoBehaviour
{
	public Job job;
	public Mood mood = Mood.Neutral;
	public Image JobIcon, Face;

	public Sprite Art, Code, QA;
	public Sprite Joyfull, Happy, Neutral, Stressed, Angry;

	// Start is called before the first frame update
	void Start()
	{

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
				mood -= Random.Range(1, 3);
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

	// Update is called once per frame
	void FixedUpdate()
	{
		switch (mood)
		{
			case Mood.Joyous:
				Face.sprite = Joyfull;
				break;
			case Mood.Happy:
				Face.sprite = Happy;
				break;
			case Mood.Neutral:
				Face.sprite = Neutral;
				break;
			case Mood.Stressed:
				Face.sprite = Stressed;
				break;
			case Mood.Angry:
				Face.sprite = Angry;
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