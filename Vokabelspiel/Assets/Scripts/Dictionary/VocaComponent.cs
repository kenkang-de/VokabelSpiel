using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class VocaComponent : MonoBehaviour
{
    [SerializeField] InputField text;
    [SerializeField] private Button flag;

    [SerializeField] private int index;

    Vocabulary _vocabulary;
    private LanguageModel _languageModel;
    void Start()
    {
        Initiate();
        DisplayWord(_vocabulary.word);
        DisplayLanguage(_vocabulary.language);
    }
    void Initiate()
    {
        _vocabulary = DictionaryModel.vocabularies[index];
        _languageModel = FindObjectOfType<LanguageModel>();
    }

    public void SelectVocabulary()
    {
        DictionaryModel.selectedVocabulary = _vocabulary;
    }

    public void SetVoca(string word)
    {
        _vocabulary.word = word;
        DictionaryModel.SaveVocabulary();
    }

    public void SetLangauge(Language language)
    {
        _vocabulary.language = language;
        DictionaryModel.SaveVocabulary();
    }

    public void DisplayWord(string voca)
    {
        text.text = voca;
    }

    public void DisplayLanguage(Language language)
    {
        flag.image.sprite=_languageModel.flags[language];
    }
    
    
    
}
