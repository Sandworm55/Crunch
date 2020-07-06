using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
	public static List<Employee> employeesEnd;
	public static int BudgetEnd, CodeEnd, ArtEnd, TestEnd, BudgetStart, CodeStart, ArtStart, TestStart;


	public List<Employee> Employees;
	Employee CurrentEmployee;
	public GameObject EmployeePrefab, Que, Chair;

	public static Sentance _Sentence = new Sentance();

	public TopLeft TopLeft;
	public Buttons Buttons;
	public TopRight TopRight;
	public MoodList MoodList;

	public int Budget;
	public int StartingBudget = 1000;

	public int StartingStaff = 10;

	public int EmployeeWage;
	public float SecondsPerDay = 60, CurrentTime;
	public DateTime CurrentTimeClock = new DateTime(2020, 1, 1, 9, 0, 0);
	DateTime EndOfDay = new DateTime(2020, 1, 1, 18, 0, 0);
	const int SECONDS_IN_DAY = 28800;

	public int StartingDays = 20;
	public int DaysLeft;

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
			emp.job = (Job)UnityEngine.Random.Range(0, 2);
			Employees.Add(emp);

		}

		for (int i = 0; i < Employees.Count - 1; i++)
		{
			int ranNum = UnityEngine.Random.Range(i, Employees.Count);
			Employee temp = Employees[i];
			Employees[i] = Employees[ranNum];
			Employees[ranNum] = temp;
		}
		DaysLeft = StartingDays;
		MoodList.SetBars(Employees);
		Budget = StartingBudget;
		BudgetStart = StartingBudget;

		CodeStart = TopLeft.Coder.CurrentValue;
		ArtStart = TopLeft.Art.CurrentValue;
		TestStart = TopLeft.QA.CurrentValue;
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
			Application.Quit();

		if ((CurrentTime += Time.deltaTime) >= SecondsPerDay)
		{
			DaysLeft--;
			if (DaysLeft <= 0)
			{
				BudgetEnd = Budget;
				
				CodeEnd = TopLeft.Coder.CurrentValue;
				ArtEnd = TopLeft.Art.CurrentValue;
				TestEnd = TopLeft.QA.CurrentValue;

				employeesEnd = Employees;
				SceneManager.LoadScene("End");
			}
			AdvanceDay();
			CurrentTime = 0f;
		}

		if (CurrentEmployee == null)
		{
			NextEmployee();
			FillWords();

		}

		if (_Sentence.Verb != null && _Sentence.Adjective != null && _Sentence.Noun != null)
		{
			JudgeThem();
			ResetButtons();
		}


	}

	void AdvanceDay()
	{
		Budget -= (Employees.Count * EmployeeWage);
		Debug.Log(Budget);
	}
	private void ResetButtons()
	{
		Buttons.Reset();
	}

	private void JudgeThem()
	{
		if (_Sentence.Verb.MoodChange == MoodChange.Positive)
			CurrentEmployee.BoostMood();
		else if (CurrentEmployee.job != _Sentence.Verb.Job)
			CurrentEmployee.ChangeJob(_Sentence.Verb.Job);
		else
			CurrentEmployee.DropMood();

		MakeThemWork();

		Employees.RemoveAt(0);
		Employees.Add(CurrentEmployee);
		CurrentEmployee.transform.parent = Que.transform;
		CurrentEmployee.transform.localPosition = Vector3.zero;
		CurrentEmployee = null;
		_Sentence = new Sentance();

	}

	private void MakeThemWork()
	{
		int workDone = 0;

		switch (CurrentEmployee.mood)
		{
			case Mood.Angry:
				workDone = 0;
				break;
			case Mood.Neutral:
				workDone = 1;
				break;
			case Mood.Stressed:
			case Mood.Happy:
				workDone = 2;
				break;
			case Mood.Joyous:
				workDone = 3;
				break;
		}

		switch (CurrentEmployee.job)
		{
			case Job.Code:
				TopLeft.Coder.DoWork(workDone);
				break;
			case Job.Art:
				TopLeft.Art.DoWork(workDone);
				break;
			case Job.QA:
				TopLeft.QA.DoWork(workDone);
				break;
		}
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
		MoodList.SetBars(Employees);
	}
}

public class Sentance
{
	public Word Verb, Adjective, Noun;
}
