using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
[Serializable]
public class TextManager 
{
    [SerializeField] public string Word1;
    [SerializeField] public string Word2;
    [SerializeField] public string Word3;
    [SerializeField] public string GeneratedText;
    [SerializeField] public List<string> TextsCollection;

    public TextManager()
    {
        Word1 = "n";
        Word2 = "n";
        Word3 = "n";
        GeneratedText = Word1 + Word2 + Word3;
        TextsCollection = new List<string>();
        TextsCollection.Add("sample text");
    }

    public void GenerateText ()
    {
        if (Word1 != "n" && Word2 != "n" && Word3 != "n")
        {
            if (Word1 == "a" && Word2 == "b" && Word3 == "c")
            {
                GeneratedText = TextsCollection[0];
            }
        }
    }
    
    
}
