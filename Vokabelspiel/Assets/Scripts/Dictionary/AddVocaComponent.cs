using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddVocaComponent : VocaComponent
{
    public static Vocabulary NewVocabulary;

    [SerializeField] private GameObject SubAddPrefab;

    public override void Start()
    {
        Initiate();
        FindLanguageModel();
    }

    public override void Initiate()
    {
        _vocabulary= new Vocabulary("", Language.NONE);
        NewVocabulary = _vocabulary;
    }

    public override void Confirm()
    {
        if (!ConditionCheck())
        {
            DictionaryStateChanger.changeBlock = true;
            DictionaryManager.ConditionNotfullfilledText.Enqueue(ConditionMessage(Condition.Empty));
            DictionaryManager.ConditionNotfullfilledText.Enqueue("");
            DictionaryManager.instance.ConditionNotfullfilled();
            return;
        }
        else
            DictionaryStateChanger.changeBlock = false;

 
        if (DictionaryModel.ContainsVocabulary(_vocabulary))
            NewVocabulary = DictionaryModel.FindVocabulary(_vocabulary);
        else
        {
            DictionaryModel.AddVocabulary(_vocabulary);
            DictionaryManager.instance.AddVocaSet(_vocabulary);
            DictionaryModel.SaveVocabulary();  
        }

    }

    public override bool ConditionCheck()
    {
        if (_vocabulary.word=="")
            return false;
        return true;
    }

    public void AddSubVocaComponent()
    {
        GameObject subVoca = Instantiate(SubAddPrefab, transform.parent);
        subVoca.transform.SetSiblingIndex(transform.parent.childCount-2);
    }
}
