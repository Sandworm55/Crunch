﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EmployeeBar : MonoBehaviour
{
    public GameObject Bar;
    public Image Icon;
    public int StartValue = 100;
    public int CurrentValue;
    float StartingHeight;
    RectTransform rect;

    // Start is called before the first frame update
    void Awake()
    {
        rect = (RectTransform)Bar.transform;
        StartingHeight = rect.sizeDelta.y;
        CurrentValue = StartValue;
    }

    public void DoWork(int work)
	{
        if((CurrentValue -= work) <= 0)
		{
            CurrentValue = 0;
		}
        rect.sizeDelta = new Vector2(
            rect.sizeDelta.x,
            (float)((float)CurrentValue / (float)StartValue) * StartingHeight);
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
