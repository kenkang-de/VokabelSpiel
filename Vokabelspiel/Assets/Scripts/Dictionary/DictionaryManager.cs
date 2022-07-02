using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DictionaryManager : MonoBehaviour
{
    public static DictionaryManager instance;
    
    [SerializeField] private GameObject UI_VocaSet;
    [SerializeField] private Transform UI_VocaSetParent;
    
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
    }


    public void SetVocaUI()
    {
        foreach (Vocabulary vocabulary in DictionaryModel.vocabularies)
            Instantiate(UI_VocaSet,UI_VocaSetParent);
    }
}
