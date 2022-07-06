using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DictionaryStateChanger : MonoBehaviour
{
    [SerializeField] DictionaryState dictionaryState;
    
    public void ChangeState() => DictionaryManager.instance.ChangeState(dictionaryState);

    public void ChangeToPreviousState() =>
        DictionaryManager.instance.ChangeState(DictionaryManager.instance.previousState);
}
