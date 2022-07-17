using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DictionaryConditionalStateChanger : DictionaryStateChanger
{
    public UnityEvent<VocaComponent> Condition;
    private bool isSatisfied;
    [SerializeField] DictionaryState dictionaryStateonTrue;
    [SerializeField] DictionaryState dictionaryStateonFalse;

    public void ChangeState(VocaComponent vocaComponent)
    {
        Condition.Invoke(vocaComponent);
        
        if (isSatisfied)
            SetState(dictionaryStateonTrue);
        else
            SetState(dictionaryStateonFalse);
        
        ChangeState(); 
    }

    public void IfVocaOverlap(VocaComponent vocaComponent)
    {
        isSatisfied=DictionaryModel.ContainsVocabulary(vocaComponent.GetVocabulary());
    }
}
