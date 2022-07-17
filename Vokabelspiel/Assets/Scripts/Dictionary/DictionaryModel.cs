using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MyBox;
using UnityEngine;

public static class DictionaryModel
{
    public static List<Vocabulary> vocabularies = new List<Vocabulary>();
    public static VocaComponent selectedVocaComponent;
    
    //Load Vocabulary from Json
    public static void LoadVocabulary()
    {
        vocabularies = FileManager<Vocabulary>.Load();
        if(vocabularies==null) 
            vocabularies = new List<Vocabulary>();
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

    public static Vocabulary FindVocabulary(Vocabulary vocabulary)
    {
        Vocabulary result = FindVocabulary(vocabulary.word);
        if (result.language==vocabulary.language)
        {
            return result;
        }
        else
            return null;
    }
    //Check if word already exists
    public static bool ContainsVocabulary(string word)
    {
        return vocabularies.Any(voca => voca.word == word);
    }

    public static bool ContainsVocabulary(Vocabulary vocabulary)
    {
        if (ContainsVocabulary(vocabulary.word))
        {
            return FindVocabulary(vocabulary.word).language == vocabulary.language;
        }
        else
            return false;
    }

    //Add Vocabulary 
    public static void AddVocabulary(Vocabulary vocabulary)
    {
        if(!ContainsVocabulary(vocabulary.word))
        vocabularies.Add(vocabulary);
    }

    //Delete Vocabulary
    public static void DeleteVocabulary(Vocabulary vocabulary)
    {
        if (ContainsVocabulary(vocabulary))
        {
            foreach (string meaning in vocabulary.relatedVocabularies)
                FindVocabulary(meaning).relatedVocabularies.Remove(vocabulary.word);
            vocabularies.Remove(vocabulary);
        }
    }
    
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
    public List<string> relatedVocabularies=new List<string>();

    public Vocabulary(string word, Language language)
    {
        this.word = word;
        this.language = language;
    }

    public void Relate(Vocabulary vocabulary)
    {
        relatedVocabularies.Add(vocabulary.word);
    }

    public void CrossRelate(Vocabulary vocabulary)
    {
        Relate(vocabulary);
        vocabulary.Relate(this);
    }
}

