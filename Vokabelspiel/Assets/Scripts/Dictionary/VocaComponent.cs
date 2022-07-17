using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public abstract class VocaComponent :MonoBehaviour
{
    protected InputField text;
    protected Button flag;
    
    protected Vocabulary _vocabulary;
    protected LanguageModel _languageModel;

    public abstract void Start();
    public abstract void Initiate();
    
    void Awake()
    {
        flag = GetComponentInChildren<Button>();
        text = GetComponentInChildren<InputField>();
    }

    public Vocabulary GetVocabulary()
    {
        return _vocabulary;
    }

    public void SetVocabulary(Vocabulary vocabulary)
    {
        _vocabulary = vocabulary;
    }

    public void ClearVocaComponent()
    {
        if(GetType()==typeof(SubAddVocaComponent))
            Destroy(gameObject);
        Initiate();
        Refresh();
    }
    
    public void FindLanguageModel()=> _languageModel = FindObjectOfType<LanguageModel>();
    
    public void SelectVocabulary()
    {
        DictionaryModel.selectedVocaComponent = this;
    }

    public void SetVoca(string word)
    {
        _vocabulary.word = word;
        DictionaryModel.SaveVocabulary();
        Refresh();
    }

    public void SetLangauge(Language language)
    {
        _vocabulary.language = language;
        DictionaryModel.SaveVocabulary();
        Refresh();
    }

    public void DisplayWord(string voca)
    {
        text.text = voca;
    }

    public void DisplayLanguage(Language language)
    {
        flag.image.sprite=_languageModel.flags[language];
    }
    
    public void Refresh()
    {
        if (_vocabulary == null)
            return;
        DisplayWord(_vocabulary.word);
        DisplayLanguage(_vocabulary.language); 
    }
    
    public abstract void Confirm();

    public void OnEnable()
    {
        DictionaryManager.CofirmEvent += Confirm;
    }

    public void OnDisable()
    {
        DictionaryManager.CofirmEvent -= Confirm;
    }


    public abstract bool ConditionCheck();
    
    public enum Condition {Empty}

    protected string ConditionMessage(Condition condition)
    {
        switch (condition)
        {
            case Condition.Empty:
                return "Can't have blanks.";
        }

        return "Error 00";
    }
}
