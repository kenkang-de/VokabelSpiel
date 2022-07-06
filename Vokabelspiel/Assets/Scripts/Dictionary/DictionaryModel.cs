using System;
using System.Collections;
using System.Collections.Generic;
using MyBox;
using UnityEngine;

public static class DictionaryModel
{
    public static List<Vocabulary> vocabularies = new List<Vocabulary>();
    public static Vocabulary selectedVocabulary;
    
    //Load Vocabulary from Json
    public static void LoadVocabulary()
    {
        vocabularies = FileManager<Vocabulary>.Load();
    }
    
    //Save Vocabulary to Json
    public static void SaveVocabulary()
    {
        FileManager<Vocabulary>.Save(vocabularies);
    }
    
    //Find Vocabulary
    public static Vocabulary FindVocabulary(string word)
    {
        return vocabularies.Find(voca => voca.word == word);
    }

    //Todo Add Vocabulary 
    
    //Todo Create a new Vocaulary
    
    //Todo Delete Vocabulary
    
    //Edit Vocabulary
    public static void EditVocabulary(Vocabulary vocabulary)
    {
        vocabularies[vocabularies.IndexOf(vocabulary)] = vocabulary;
    }
    
}
[Serializable]
public class Vocabulary
{
    public string word;
    public Language language;
    public HashSet<Vocabulary> relatedVocabularies=new HashSet<Vocabulary>();

    public Vocabulary(string word, Language language, HashSet<Vocabulary> relatedVocabularies=null)
    {
        this.word = word;
        this.language = language;
        this.relatedVocabularies = relatedVocabularies;
    }
}

