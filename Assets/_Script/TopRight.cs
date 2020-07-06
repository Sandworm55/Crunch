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
        TimeValue.text = (math.round( Game.CurrentTime)).ToString();
        Days.text = Game.DaysLeft.ToString();
    }

    void SetTime()
	{
        
	}
}
