using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefTest : MonoBehaviour
{
    void Awake()
    {
        DictionaryModel.vocabularies.Add(new Vocabulary("Test",Language.EN));
        DictionaryModel.SaveVocabulary();
    }

}



