using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WordColumn : MonoBehaviour
{
    public List<Button> Words;
    public List<TextMeshProUGUI> WordsLabels;
    // Start is called before the first frame update
    void Start()
    { 
    }

    public void SetWords(List<Word> words)
	{
		for (int i = 0; i < words.Count; i++)
		{
            WordsLabels[i].text = words[i].ActualWord;
		}
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
