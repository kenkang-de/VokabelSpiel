using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class EditVocaComponent : VocaComponent
{
    [SerializeField] private GameObject relationPrefab;

    public override void Start()
    {
        Initiate();
        FindLanguageModel();
        Refresh();
        DisplayRelation();
    }

    public override void Initiate()
    {
        
    }

    private void DisplayRelation()
    {
        if (_vocabulary.relatedVocabularies == null)
            return; 
        foreach (string relatedWord in _vocabulary.relatedVocabularies) 
        {
                GameObject relationPrefab=Instantiate(this.relationPrefab, transform.parent);
                relationPrefab.GetComponent<SubEditVocaComponent>().SetVocabulary(DictionaryModel.FindVocabulary(relatedWord)); 
        }
    }

    public void UpdateRelation()
    {
        if (_vocabulary.relatedVocabularies == null)
            return;
        List<SubEditVocaComponent> subEditVocaComponents;
        do
        {
            subEditVocaComponents = transform.parent.GetComponentsInChildren<SubEditVocaComponent>().ToList();

            if (subEditVocaComponents.Count < _vocabulary.relatedVocabularies.Count)
            {
                GameObject relationPrefab = Instantiate(this.relationPrefab, transform.parent);
                relationPrefab.GetComponent<SubEditVocaComponent>().SetVocabulary(DictionaryModel.FindVocabulary(_vocabulary.relatedVocabularies[subEditVocaComponents.Count]));
            }
            if (subEditVocaComponents.Count > _vocabulary.relatedVocabularies.Count)
            {
                Destroy(subEditVocaComponents[subEditVocaComponents.Count-1].gameObject);
                subEditVocaComponents.RemoveAt(subEditVocaComponents.Count - 1);
            }
        } while (subEditVocaComponents.Count != _vocabulary.relatedVocabularies.Count);
    }

    public void OnEnable()
    {
        base.OnEnable();
        StartCoroutine(waitUntilInstatiate());
    }

    public override bool ConditionCheck()
    {
        throw new System.NotImplementedException();
    }

    IEnumerator waitUntilInstatiate()
    {
        yield return new WaitUntil(()=>_vocabulary != null);
        UpdateRelation();
    }
    

    public override void Confirm()
    {
        //TODO here Edit vocabualry
        /*DictionaryModel.AddVocabulary(_vocabulary);*/
        DictionaryModel.SaveVocabulary();
    }
    
    public void DeleteVocabulary()
    {
        DictionaryModel.DeleteVocabulary(_vocabulary);
    }
    
}
