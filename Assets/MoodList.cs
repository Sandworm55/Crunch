using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoodList : MonoBehaviour
{
    public MoodBar Joyous, Happy, Neutral, Stressed, Angry;
    public GameObject Pref;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetBars(List<Employee> employees)
	{
        ClearBars();
		foreach (var item in employees)
		{
			switch (item.mood)
			{
				case Mood.Angry:
                    AddEmployee(item, Angry);
                    break;
				case Mood.Stressed:
                    AddEmployee(item, Stressed);
                    break;
				case Mood.Neutral:
                    AddEmployee(item, Neutral);
                    break;
				case Mood.Happy:
                    AddEmployee(item, Happy);
                    break;
				case Mood.Joyous:
                    AddEmployee(item, Joyous);
					break;
			}
		}
	}

    void AddEmployee (Employee employee, MoodBar moodBar)
	{
        GameObject go = Instantiate(Pref, moodBar.EmployeeList.transform);

        Sprite job = employee.Code;
        switch (employee.job)
        {
            case Job.Code:
                job = employee.Code;
                break;
            case Job.Art:
                job = employee.Art;
                break;
            case Job.QA:
                job = employee.QA;
                break;
        }
        go.GetComponent<Image>().sprite = job;
	}

	void ClearBars()
	{
        foreach (Transform item in Joyous.EmployeeList.transform)
            GameObject.Destroy(item.gameObject);
        foreach (Transform item in Happy.EmployeeList.transform)
            GameObject.Destroy(item.gameObject);
        foreach (Transform item in Neutral.EmployeeList.transform)
            GameObject.Destroy(item.gameObject);
        foreach (Transform item in Stressed.EmployeeList.transform)
            GameObject.Destroy(item.gameObject);
        foreach (Transform item in Angry.EmployeeList.transform)
            GameObject.Destroy(item.gameObject);
    }
}
