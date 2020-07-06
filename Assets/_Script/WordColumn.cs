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
		foreach (var item in WordButtons)
		{
			item.interactable = false;
			item.image.color = Color.grey;
		}

		WordButtons[i].image.color = Color.green;
		switch (Words[i].WordClass)
		{
			case WordClass.Noun:
				Game._Sentence.Noun = Words[i];
				break;
			case WordClass.Verb:
				Game._Sentence.Verb = Words[i];
				break;
			case WordClass.Adjective:
				Game._Sentence.Adjective = Words[i];
				break;

		}
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
			item.image.color = Color.white;
		}
	}
}
