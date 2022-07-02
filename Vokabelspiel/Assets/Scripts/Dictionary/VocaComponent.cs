using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class VocaComponent : MonoBehaviour
{
    [SerializeField] InputField text;

    [SerializeField] private int index;
    
    Vocabulary _vocabulary;
    void Start()
    {
        GetVoca();
        DisplayWord(_vocabulary.word);
    }
    public void GetVoca()
    {
        _vocabulary = DictionaryModel.vocabularies[index];
    }
    public void SetVoca(string word)
    {
        _vocabulary.word = word;
        DictionaryModel.SaveVocabulary();
    }

    public void DisplayWord(string voca)
    {
        text.text = voca;
    }

    public void Select(BaseEventData eventData)
    {
        if (eventData.selectedObject == this.gameObject)
            {
                eventData.selectedObject = null;
            }
    }

    public void Click()
    {
        
    }
}
