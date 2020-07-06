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
	public List<Image> Icons;
	public Sprite Art, Code, Test;

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

		if (words[0].WordClass == WordClass.Verb)
		{
			for (int i = 0; i < words.Count; i++)
			{
				Icons[i].gameObject.SetActive(false);
				switch (words[i].ActualWord)
				{
					case "Art":
						Icons[i].sprite = Art;
						Icons[i].gameObject.SetActive(true);
						break;
					case "Code":
						Icons[i].sprite = Code;
						Icons[i].gameObject.SetActive(true);
						break;
					case "Test":
						Icons[i].sprite = Test;
						Icons[i].gameObject.SetActive(true);
						break;
				}
			}
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
