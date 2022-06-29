using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DictionaryManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
     DictionaryModel.LoadVocabulary();
    }
}
