using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class DayEnd : MonoBehaviour
{
    public TextMeshProUGUI days;

    public GameObject screen;

    public Game game;

    public TextMeshProUGUI BudgetStart, BudgetEnd, Code, Art, QA;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        days.text = game.DaysLeft.ToString();

        BudgetStart.text = "$ " + Game.BudgetStart;
        BudgetEnd.text = "$ " + Game.BudgetEnd;

        Code.text = "% " + math.round((1 - ((float)Game.CodeEnd / Game.CodeStart)) * 100);
        Art.text = "% " + math.round((1 - ((float)Game.ArtEnd / Game.ArtStart)) * 100);
        QA.text = "% " + math.round((1 - ((float)Game.TestEnd / Game.TestStart)) * 100);
    }

    public void Continue()
	{
        screen.SetActive(false);
        game.Paused = false;
	}
}
