using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnEnableUnityEvent : MonoBehaviour
{
    [SerializeField] 
    private UnityEvent onEnableUnityEvent;

    void OnEnable()
    {
        onEnableUnityEvent.Invoke();
    }
}
