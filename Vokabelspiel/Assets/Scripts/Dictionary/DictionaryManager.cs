using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DictionaryManager : MonoBehaviour
{
    public static DictionaryManager instance;
    
    [SerializeField] private GameObject UI_VocaSet;
    [SerializeField] private Transform UI_VocaSetParent;
    
    public static Action ClearState;
    public static Action DisplayState;
    public static Action AddState;
    public static Action SelectLanguageState;

    [HideInInspector]
    public DictionaryState currentState;
    [HideInInspector]
    public DictionaryState previousState;


    
    void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(this);
        }
        DontDestroyOnLoad(this);
        
        DictionaryModel.LoadVocabulary();
        SetVocaUI();
        ChangeState(DictionaryState.Display);
    }


    public void SetVocaUI()
    {
        foreach (Vocabulary vocabulary in DictionaryModel.vocabularies)
            Instantiate(UI_VocaSet,UI_VocaSetParent);
    }

    public void ChangeState(DictionaryState dictionaryState)
    {
        previousState = currentState;
        
        ClearState?.Invoke();
        switch (dictionaryState)
        {
            case DictionaryState.Add:
                AddState?.Invoke();
                break;
            case DictionaryState.Display:
                DisplayState?.Invoke();
                break;
            case DictionaryState.SelectLanaguage:
                SelectLanguageState?.Invoke();
                break; 
        }
        currentState = dictionaryState;
    }
    
}
