using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DictionaryState{Display , Add, Edit, SelectLanaguage, VocaSelected}

public class DictionaryActivateComponent : MonoBehaviour, ActivateInterface
{
    public DictionaryState[] targetState;
    public bool NonStateRelevant;
    
    void Awake()
    {
        AddListener();
    }

    public void AddListener()
    {
        DictionaryManager.ClearState += Disable;

        if (NonStateRelevant)
        {
            nonStateRelevantInitialize();
            return;
        }
      
        
        foreach (DictionaryState dicState in targetState)
        {
            switch (dicState)
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
                case DictionaryState.VocaSelected:
                    DictionaryManager.VocaSelectedState += Enable;
                    break;
            }
        }

    }

    public void nonStateRelevantInitialize()
    {
        DictionaryManager.ConditionNotfulfilledPopupEvent += AutoDisableCoroutine;
    }

    void OnDisable()
    {
        if(NonStateRelevant && DictionaryManager.ConditionNotfullfilledText.Count>0 )
            DictionaryManager.instance.ConditionNotfullfilled();
    }


    [SerializeField] private float liftime = 3.0f;
    public void AutoDisableCoroutine()
    {
        Enable();
        StartCoroutine(AutoDisable(liftime));
    }
    
    public IEnumerator AutoDisable(float liftime=0)
    {
        yield return new WaitForSeconds(liftime);
        Disable();
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
