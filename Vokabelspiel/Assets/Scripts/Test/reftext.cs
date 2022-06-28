using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class reftext : MonoBehaviour
{
    public InputField text;

    public void SetVoca()
    {
       ref var x =ref DictionaryModel.vocabularies[0].word;
       x = text.text;
    }
}
