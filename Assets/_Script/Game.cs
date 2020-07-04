using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public List<Employee> Employees;
    Employee CurrentEmployee;

    public TopLeft TopLeft;
    public Buttons Buttons;
    public TopRight TopRight;

    public int StartingStaff = 10;
    public int SecondsPerDay = 60;

    // Start is called before the first frame update
    void Start()
    {
        // set even split to 3 roles, random the last one
        //
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(CurrentEmployee == null)
		{
            NextEmployee();
            FillWords();

		}
      

        // wait for result

    }

	private void FillWords()
	{
        // fill words
    }

    private void NextEmployee()
	{  
        // move emp up
	}
}
