using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnDisableUnityEvent : MonoBehaviour
{
    [SerializeField] 
    private UnityEvent onDisbleUnityEvent;

    void OnDisable()
    {
        onDisbleUnityEvent.Invoke();
    }
}
