using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class MySelectable : MonoBehaviour
{
    [SerializeField]private Color normalColor;
    [SerializeField]private Color selectedColor;

    private Graphic _graphic;
    
    public bool _isSelected;

    void Start()
    {
        _graphic = GetComponent<Graphic>();
    }
    
    public void SelectToggle(MySelectable mySelectable)
    {
        if (!mySelectable._isSelected)
        {
            _isSelected = true;
            _graphic.color = selectedColor;
        }
        else
        {
            _isSelected = false;
            _graphic.color = normalColor;
        }
    }


}
