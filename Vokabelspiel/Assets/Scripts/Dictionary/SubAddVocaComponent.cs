using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubAddVocaComponent : VocaComponent
{
    public override void Start()
    {
        Initiate();
        FindLanguageModel();
    }

    public override void Initiate()
    {
        _vocabulary= new Vocabulary("", Language.NONE);
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
            _vocabulary=DictionaryModel.FindVocabulary(_vocabulary);
        else
        {
            DictionaryModel.AddVocabulary(_vocabulary);
            DictionaryManager.instance.AddVocaSet(_vocabulary);
        }
        AddVocaComponent.NewVocabulary.CrossRelate(_vocabulary);

        DictionaryModel.SaveVocabulary();
    }

    public override bool ConditionCheck()
    {
        if (_vocabulary.word=="")
            return false;
        return true;
    }
}
