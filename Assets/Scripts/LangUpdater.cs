using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LangUpdater : MonoBehaviour
{
    private int langCode;

    // Start is called before the first frame update
    void Start()
    {
        Lean.Localization.LeanLocalization.SetCurrentLanguageAll("日本語");
    }

    // Update is called once per frame
    void Update()
    {
        langCode = PlayerPrefs.GetInt("Lang", 0);
        switch (langCode)
        {
            
            case 0:
            Lean.Localization.LeanLocalization.SetCurrentLanguageAll("日本語");
            break;
            case 1:
            Lean.Localization.LeanLocalization.SetCurrentLanguageAll("英語");
            break;
            
        }
    }
}
