using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.Mathematics;
using System;

public class TopRight : MonoBehaviour
{
    public TextMeshProUGUI BudgetValue, TimeValue, TimeAMPM, Days;
    public Game Game;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        BudgetValue.text = "$ " + Game.Budget;

        int time = (int)(Game.CurrentTime / 7) + 9;
		if (time <= 12f)
		{
            TimeValue.text = time + ":00";
            TimeAMPM.text = "AM";
		}
        else if (time > 12f)
        {
            TimeValue.text = (time - 12) + ":00";
            TimeAMPM.text = "PM";
        }
        Days.text = Game.DaysLeft.ToString();
    }

    void SetTime()
	{
        
	}
}
