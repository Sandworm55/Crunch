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

    public void BoostMood(int amount)
	{
        mood = (Mood)((int)mood + amount);
	}

    public void DropMood(int amount)
	{
        mood = (Mood)((int)mood - amount);
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