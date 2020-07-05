using System.Collections.Generic;
using UnityEngine;

public class WordsData : MonoBehaviour
{
	public TextAsset File;
	List<Word> 
		Verb = new List<Word>(), 
		Adjective = new List<Word>(), 
		Noun = new List<Word>();
	public bool set = false;

	void Start()
	{
		string[] lines = new string[0];
		lines = File.ToString().Split('\n');
		Debug.Log("There are " + lines.Length + " words to be added");
		if (lines.Length > 500)
			throw new System.Exception("Theres waaay to many ostriches. More then 500 items.");
		for (int i = 1; i < lines.Length; i++)
		{
			string[] parts = lines[i].Split(',');

			Word word = new Word(parts);

			switch (parts[1])
			{
				case "Verb":
					Verb.Add(word);
					break;
				case "Adjective":
					Adjective.Add(word);
					break;
				case "Noun":
					Noun.Add(word);
					break;
			}
		}
		set = true;
	}

	public List<Word> GetWords(WordClass wordClass)
	{
		List<Word> words = new List<Word>();
		switch (wordClass)
		{
			case WordClass.Noun:
				words = Noun;
				break;
			case WordClass.Verb:
				words = Verb;
				break;
			case WordClass.Adjective:
				words = Adjective;
				break;
		}

		List<int> ids = new List<int>();
		for (int i = 0; i < 3; i++)
		{
			int num;
			do
			{
				num = Random.Range(0, words.Count - 1);

			} while (ids.Contains(num));
			ids.Add(num);
		}

		List<Word> val = new List<Word>();
		foreach (var item in ids)
		{
			val.Add(words[item]);
		}
		return val;

	}
}
	public class Word
{
	public Word(string[] parts)
	{
		ActualWord = parts[0];
		Type = GetTags(parts[2]);
		Negative = parts[3] == "Negative" ? true : false ;
		int.TryParse(parts[4], out Syllables);
	}

	public string ActualWord;
	public bool Negative;
	public int Syllables;
	public List<Tags> Type;

	List<Tags> GetTags(string tag)
	{
		List<Tags> returnVal = new List<Tags>();

		switch (tag)
		{
			case "Animal":
				returnVal.Add(Tags.Animal);
				break;
			case "Body":
				returnVal.Add(Tags.Body);
				break;
			case "Food":
				returnVal.Add(Tags.Food);
				break;
			case "Machine":
				returnVal.Add(Tags.Machine);
				break;
			}
			return returnVal;

	}
}

public enum Tags
{
	Animal,
	Body,
	Food,
	Machine
}
 public enum WordClass
{
	Noun,
	Verb,
	Adjective
}
