using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Employee : MonoBehaviour
{
    public Job job;
    public Mood mood;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void BoostMood()
	{

	}

    public void DropMood()
	{

	}

    // Update is called once per frame
    void Update()
    {
        
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
    Joyous,
    Happy,
    Neutral,
    Stressed,
    Angry
}