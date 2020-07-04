using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EmployeeBar : MonoBehaviour
{
    public GameObject Bar;
    public Image Icon;
    public int StartValue = 100;
    int CurrentValue;
    float StartingHeight;
    RectTransform rect;

    // Start is called before the first frame update
    void Start()
    {
        rect = (RectTransform)Bar.transform;
        StartingHeight = rect.sizeDelta.x;
    }

    public void DoWork(int work)
	{
        CurrentValue -= work;
        rect.sizeDelta = new Vector2( 
            (CurrentValue / StartValue) * StartingHeight, 
            rect.sizeDelta.y);
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
