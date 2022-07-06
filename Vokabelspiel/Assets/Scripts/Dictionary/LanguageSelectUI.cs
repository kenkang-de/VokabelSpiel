using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguageSelectUI : MonoBehaviour
{
  [SerializeField] private Language language;

  public void SelectLanguage()
  {
    DictionaryModel.selectedVocabulary.language = language;
  }

}
