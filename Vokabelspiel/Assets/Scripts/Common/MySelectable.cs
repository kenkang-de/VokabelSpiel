using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class MySelectable : MonoBehaviour
{
    public static MySelectable selectedMySelectable;
    
    [SerializeField] private Color normalColor;
    [SerializeField] private Color selectedColor;

    private Graphic _graphic;

    public bool _isSelected;

    void Start()
    {
        _graphic = GetComponent<Graphic>();
    }

    public void SelectToggle(MySelectable mySelectable)
    {
        if (selectedMySelectable != null && selectedMySelectable != this)
        {
            selectedMySelectable.SelectToggle(selectedMySelectable);
        }
        if (!mySelectable._isSelected)
        {
            _isSelected = true;
            selectedMySelectable = this;
            _graphic.color = selectedColor;
            dictionaryStateChanger.SetState(DictionaryState.VocaSelected);
        }
        else
        {
            _isSelected = false;
            selectedMySelectable = null;
            _graphic.color = normalColor;
            dictionaryStateChanger.SetState(DictionaryState.Display);
        }
        dictionaryStateChanger.ChangeState();
    }

    public void Unselect()
    {
        selectedMySelectable.SelectToggle(selectedMySelectable);
        selectedMySelectable = null;
    }

    [SerializeField] private DictionaryStateChanger dictionaryStateChanger;





}




