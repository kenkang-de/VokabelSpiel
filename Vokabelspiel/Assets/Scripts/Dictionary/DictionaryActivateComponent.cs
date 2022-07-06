using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DictionaryState{Display , Add, Edit, SelectLanaguage}

public class DictionaryActivateComponent : MonoBehaviour, ActivateInterface
{
    public DictionaryState targetState;
    
    void Awake()
    {
        AddListener();
    }

    public void AddListener()
    {
        DictionaryManager.ClearState += Disable;
        switch (targetState)
        {
            case DictionaryState.Display:
                DictionaryManager.DisplayState += Enable;
                break;
            case DictionaryState.Add:
                DictionaryManager.AddState += Enable;
                break;
            case DictionaryState.SelectLanaguage:
                DictionaryManager.SelectLanguageState += Enable;
                break;
        }
    }

    public void Enable()
    {
        gameObject.SetActive(true);
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }
}
