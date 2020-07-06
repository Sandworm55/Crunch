using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{
    public TextMeshProUGUI BudgetStart, BudgetEnd, Code, Art, QA, Quit, Vacation;

    // Start is called before the first frame update
    void Start()
    {
        BudgetStart.text = "$ " + Game.BudgetStart;
        BudgetEnd.text = "$ " + Game.BudgetEnd;

        Code.text = "% " + math.round((1 - ((float) Game.CodeEnd / Game.CodeStart)) * 100);
        Art.text = "% " + math.round((1 - ((float)Game.ArtEnd / Game.ArtStart)) * 100);
        QA.text = "% " + math.round((1 - ((float)Game.TestEnd / Game.TestStart)) * 100);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            SceneManager.LoadScene("Credit");
    }
}
