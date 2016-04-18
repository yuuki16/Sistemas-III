using UnityEngine;
using System.Collections;
using System.IO;
using System.Xml;
using System.Text;
using System.Collections.Generic;

public class LanguageController : MonoBehaviour 
{
    public TextAsset dictionary;

    public string languageName;
    public int currentLanguage;

    List<Dictionary<string, string>> languages = new List<Dictionary<string, string>>();
    Dictionary<string, string> obj;

	void Awake () 
	{
        Reader();
	}

    public Dictionary<string, string> languageChange(int language)
    {
        return languages[language];
    }

    void Reader()
    {
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(dictionary.text);
        XmlNodeList languagesList = xmlDoc.GetElementsByTagName("language");

        foreach (XmlNode language in languagesList)
        {
            XmlNodeList languageContent = language.ChildNodes;
            obj = new Dictionary<string, string>();

            foreach (XmlNode value in languageContent)
            {
                if (value.Name == "name")
                    obj.Add(value.Name, value.InnerText);
                if (value.Name == "btPlay")
                    obj.Add(value.Name, value.InnerText);
                if (value.Name == "txtSalir")
                    obj.Add(value.Name, value.InnerText);
                if (value.Name == "txtNo")
                    obj.Add(value.Name, value.InnerText);
                if (value.Name == "txtYes")
                    obj.Add(value.Name, value.InnerText);
                if (value.Name == "txtDeveloped")
                    obj.Add(value.Name, value.InnerText);
                if (value.Name == "txtVersion")
                    obj.Add(value.Name, value.InnerText);
                if (value.Name == "txtScoreTitle")
                    obj.Add(value.Name, value.InnerText);
                if (value.Name == "txtBestScoreTitle")
                    obj.Add(value.Name, value.InnerText);
                if (value.Name == "txtGameOver")
                    obj.Add(value.Name, value.InnerText);
                if (value.Name == "txtRestart")
                    obj.Add(value.Name, value.InnerText);
            }
            languages.Add(obj);
        }

    }
}
