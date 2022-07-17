using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DictionaryManager : MonoBehaviour
{
    public static DictionaryManager instance;
    
    [SerializeField] private GameObject vocaSet_Display;
    [SerializeField] private Transform vocaSet_Display_Parent;
    
    public static Action ClearState;
    public static Action DisplayState;
    public static Action AddState;
    public static Action SelectLanguageState;
    public static Action VocaSelectedState;

    [HideInInspector]
    public DictionaryState currentState;
    [HideInInspector]
    public DictionaryState previousState;

    public static Action CofirmEvent;


    void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(this);
        }
        DontDestroyOnLoad(this);
        
        DictionaryModel.LoadVocabulary();
        DisplayVocaSets();

    }

    void Start()
    {
        ChangeState(DictionaryState.Display); 
        ClearState+=ConditionNotfullfilledTextClear;
    }


    public void DisplayVocaSets()
    {
        if (DictionaryModel.vocabularies==null)
            return;
        foreach (Vocabulary vocabulary in DictionaryModel.vocabularies)
            AddVocaSet(vocabulary);
    }

    public void AddVocaSet(Vocabulary vocabulary)
    {
        GameObject vocaSet_Display=Instantiate(this.vocaSet_Display,vocaSet_Display_Parent);
        vocaSet_Display.GetComponentInChildren<VocaComponent>().SetVocabulary(vocabulary);
    }

    public void DeleteSelectedVocaSet()
    {
        EditVocaComponent selectedVocaComponent =
            MySelectable.selectedMySelectable.GetComponentInChildren<EditVocaComponent>();
        selectedVocaComponent.DeleteVocabulary();
        Destroy(selectedVocaComponent.transform.parent.gameObject);
        DictionaryModel.SaveVocabulary();
    }

    public void ChangeState(DictionaryState dictionaryState, Vocabulary overlap=null)
    {
        previousState = currentState;
        
        ClearState?.Invoke();
        switch (dictionaryState)
        {
            case DictionaryState.Add:
                AddState?.Invoke();
                break;
            case DictionaryState.Display:
                DisplayState?.Invoke();
                break;
            case DictionaryState.SelectLanaguage:
                SelectLanguageState?.Invoke();
                break; 
            case DictionaryState.VocaSelected:
                VocaSelectedState?.Invoke();
                break;
        }
        currentState = dictionaryState;
    }

    public void Confirm()
    {
        CofirmEvent?.Invoke();
    }


    #region ConditionNotFulfilled

    public static Action ConditionNotfulfilledPopupEvent;
    public static Queue<string> ConditionNotfullfilledText=new Queue<string>();

    [SerializeField] private Text txt_conditionNodifier;
    public void ConditionNotfullfilled()
    {
        if (ConditionNotfullfilledText.Count ==0)
            return;
        //skip when "", to know if string is already  added
        if(ConditionNotfullfilledText.Peek()=="")
            ConditionNotfullfilledText.Dequeue();
        txt_conditionNodifier.text = ConditionNotfullfilledText.Dequeue();
        ConditionNotfulfilledPopupEvent?.Invoke();
    }

    public void ConditionNotfullfilledTextClear()
    {
        ConditionNotfullfilledText.Clear();
    }

    #endregion




    
    


}
