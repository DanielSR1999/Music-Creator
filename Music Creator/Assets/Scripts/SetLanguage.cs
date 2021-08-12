using System.Xml;
using UnityEngine;
using UnityEngine.UI;

public class SetLanguage : MonoBehaviour
{
    [Header("Texts")]
    [SerializeField] Text _welcomeText;
    [SerializeField] Text _introductionText;
    [SerializeField] Text _tutorial01;
    [SerializeField] Text _tutorial02;
    [SerializeField] Text _tutorial03;
    [SerializeField] Text _tutorial04;
    [SerializeField] Text _tutorial05_01;
    [SerializeField] Text _tutorial05_02;
    [SerializeField] Text _tutorial06_01;
    [SerializeField] Text _tutorial06_02;


    XmlDocument _introductionTexts;
    TextAsset _introdutionUrl; 
    private void Start()
    {
        switch (Application.systemLanguage)
        {
            case SystemLanguage.Spanish:
            {
                Configuration.language = Configuration.Language.spanish;
                
                    //Load xml doc
                _introdutionUrl = Resources.Load<TextAsset>("Text/Spanish/introduction");
                _introductionTexts = new XmlDocument();
                _introductionTexts.LoadXml(_introdutionUrl.text);
                    
                break;
            }
            case SystemLanguage.English:
            {
                Configuration.language = Configuration.Language.english;

                    //Load xml doc
                _introdutionUrl = Resources.Load<TextAsset>("Text/English/introduction");
                _introductionTexts = new XmlDocument();
                _introductionTexts.LoadXml(_introdutionUrl.text);
                break;
            }
            default:
            {
                Configuration.language = Configuration.Language.english;

                //Load xml doc
                _introdutionUrl = Resources.Load<TextAsset>("Text/English/introduction");
                _introductionTexts = new XmlDocument();
                _introductionTexts.LoadXml(_introdutionUrl.text);
                break;
            }
        }
        //set text values
        _welcomeText.text = _introductionTexts.SelectSingleNode("data/element[@title='welcome_message']").InnerText;
        _introductionText.text = _introductionTexts.SelectSingleNode("data/element[@title='introduction_message']").InnerText;
        _tutorial01.text = _introductionTexts.SelectSingleNode("data/element[@title='tutorial01']").InnerText;
        _tutorial02.text = _introductionTexts.SelectSingleNode("data/element[@title='tutorial02']").InnerText;
        _tutorial03.text = _introductionTexts.SelectSingleNode("data/element[@title='tutorial03']").InnerText;
        _tutorial04.text = _introductionTexts.SelectSingleNode("data/element[@title='tutorial04']").InnerText;
        _tutorial05_01.text = _introductionTexts.SelectSingleNode("data/element[@title='tutorial05_01']").InnerText;
        _tutorial05_02.text = _introductionTexts.SelectSingleNode("data/element[@title='tutorial05_02']").InnerText;
        _tutorial06_01.text = _introductionTexts.SelectSingleNode("data/element[@title='tutorial06_01']").InnerText;
        _tutorial06_02.text = _introductionTexts.SelectSingleNode("data/element[@title='tutorial06_02']").InnerText;

        Debug.Log("Language: "+ Configuration.language);
    }

    
}
