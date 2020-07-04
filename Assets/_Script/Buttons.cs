using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    public WordColumn Verb, Adjective, Noun;
    public WordsData WordsData;
    bool set = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
		if ( !set && WordsData.set )
		{
            Verb.SetWords(WordsData.GetWords(WordClass.Verb));
            Adjective.SetWords(WordsData.GetWords(WordClass.Adjective));
            Noun.SetWords(WordsData.GetWords(WordClass.Noun));
            set = true;
		}
    }
}
