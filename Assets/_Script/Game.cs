using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public List<Employee> Employees;
    Employee CurrentEmployee;
    public GameObject EmployeePrefab, Que, Chair;

    public static List<Word> Sentence = new List<Word>();

    public TopLeft TopLeft;
    public Buttons Buttons;
    public TopRight TopRight;

    public int StartingStaff = 10;
    public int SecondsPerDay = 60;

    // Start is called before the first frame update
    void Start()
    {
        int num = StartingStaff / 3;
		for (int i = 0; i < num; i++)
		{
			for (int y = 0; y < 3; y++)
			{
                GameObject go = Instantiate(EmployeePrefab, Que.transform);
                Employee emp = go.GetComponent<Employee>();
                emp.job = (Job)y;
                Employees.Add(emp);
            }
        }

        int remainder = StartingStaff % 3;

		for (int i = 0; i < remainder; i++)
		{
            GameObject go = Instantiate(EmployeePrefab, Que.transform);
            Employee emp = go.GetComponent<Employee>();
            emp.job = (Job)UnityEngine.Random.Range(0,2);
            Employees.Add(emp);
            
		}

		for (int i = 0; i < Employees.Count - 1; i++)
		{
            int ranNum = UnityEngine.Random.Range(i, Employees.Count);
            Employee temp = Employees[i];
            Employees[i] = Employees[ranNum];
            Employees[ranNum] = temp;
		}
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();


        if(CurrentEmployee == null)
		{
            NextEmployee();
            FillWords();

		}
      
        if(Sentence.Count == 3)
		{
            JudgeThem();
            ResetButtons();
		}

    }

	private void ResetButtons()
	{
        Buttons.Reset();
	}

	private void JudgeThem()
	{
		switch (CurrentEmployee.job)
		{
			case Job.Code:
                TopLeft.Coder.DoWork((int)CurrentEmployee.mood);
				break;
			case Job.Art:
                TopLeft.Art.DoWork(2);
                break;
			case Job.QA:
                TopLeft.QA.DoWork(2);
                break;
		}

		if (CurrentEmployee.mood == Mood.Neutral)
		{
            CurrentEmployee.DropMood(1);
		}
		else if (CurrentEmployee.mood == Mood.Stressed)
		{
            CurrentEmployee.BoostMood(2);
		}

        Employees.RemoveAt(0);
        Employees.Add(CurrentEmployee);
        CurrentEmployee.transform.parent = Que.transform;
        CurrentEmployee.transform.localPosition = Vector3.zero;
        CurrentEmployee = null;
        Sentence = new List<Word>();
	}

	private void FillWords()
	{
        Buttons.SetWords();
    }

    private void NextEmployee()
	{
        CurrentEmployee = Employees[0];
        CurrentEmployee.transform.parent = Chair.transform;
        CurrentEmployee.transform.localPosition = Vector3.zero;
	}
}
