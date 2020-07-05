using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WordColumn : MonoBehaviour
{
    public List<Button> WordButtons;
    public List<TextMeshProUGUI> WordsLabels;
    public List<Word> Words;
    // Start is called before the first frame update
    void Start()
    { 
    }

    public void SetWords(List<Word> words)
	{
        Words = words;
		for (int i = 0; i < words.Count; i++)
		{
            WordsLabels[i].text = words[i].ActualWord;
		}
	}

    public void WordPick(int i)
	{
        WordButtons[i].interactable = false;
        Game.Sentence.Add(Words[i]);
	}

	// Update is called once per frame
	void Update()
    {
        
    }

	internal void Reset()
	{
		foreach (var item in WordButtons)
		{
            item.interactable = true; 
		}
	}
}
