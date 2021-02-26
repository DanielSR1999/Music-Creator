using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LanguagesController : MonoBehaviour
{
    public string[] spanishTextTranslations;
    public string[] frenchTextTranslations;
    public string[] italianTextTranslations;
    public string[] germanTextTranslations;
    public Text[] textToTranslate;

    void Start()
    {
        if(Application.systemLanguage==SystemLanguage.Spanish)
        {
            for(int i=0;i< textToTranslate.Length;i++)
            {
                textToTranslate[i].text = spanishTextTranslations[i];
            }
        }
        else if(Application.systemLanguage == SystemLanguage.French)
        {
            for (int i = 0; i < textToTranslate.Length; i++)
            {
                textToTranslate[i].text = frenchTextTranslations[i];
            }
        }
        else if (Application.systemLanguage == SystemLanguage.Italian)
        {
            for (int i = 0; i < textToTranslate.Length; i++)
            {
                textToTranslate[i].text = italianTextTranslations[i];
            }
        }
        else if (Application.systemLanguage == SystemLanguage.Italian)
        {
            for (int i = 0; i < textToTranslate.Length; i++)
            {
                textToTranslate[i].text = germanTextTranslations[i];
            }
        }
    }

   
}
