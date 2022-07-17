using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubEditVocaComponent : VocaComponent
{
    Vocabulary _editVocabulary;

    public override void Start()
    {
        Initiate();
        FindLanguageModel();
        Refresh();
    }
    

    public override void Initiate()
    {
    }


    public override void Confirm()
    {
        throw new System.NotImplementedException();
    }

    public override bool ConditionCheck()
    {
        throw new System.NotImplementedException();
    }
}
