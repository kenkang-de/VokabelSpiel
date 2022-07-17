using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DictionaryStateChanger : MonoBehaviour
{
    [SerializeField] DictionaryState dictionaryState;

    public static bool changeBlock;

    public void ChangeState()
    {
        if(!changeBlock)
        DictionaryManager.instance.ChangeState(dictionaryState);
    }

    public void SetState(DictionaryState dictionaryState) => this.dictionaryState = dictionaryState;

    public void ChangeToPreviousState() =>
        DictionaryManager.instance.ChangeState(DictionaryManager.instance.previousState);
}
