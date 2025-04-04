using System.Collections.Generic;
using System.IO;
using System.Xml;
using UnityEngine;

struct Valors 
{
    public string english_value;
    public string spanish_value;
    public string catalan_value;
}

public enum TipoIdioma : int { spanish, catalan, english }; //Elecciones de idioma
public class ManagerIdioma : MonoBehaviour //ManagerIdioma
{
    public static ManagerIdioma instance { get; private set; }
   
    [SerializeField]
    private TipoIdioma idiomas;

    private Dictionary<string, Dictionary<string, Valors>> dict_total; //Diccionario de traducciones


    private void Awake()
    {
        instance = this;
        idiomas = TipoIdioma.spanish;                                           //Inicia con español

        dict_total = new Dictionary<string, Dictionary<string, Valors>>();      //Iniciacion del diccionario

        TextAsset[] idiomasText = Resources.LoadAll<TextAsset>("lenguajes");    //Carga todos los archivos de lenguaje

        foreach (var sistema in idiomasText)                                    //Recorre los archivos 
        {
            Dictionary<string, Valors> dict_scene = parseXmlFile(sistema.text); //Traduce un archivo y lo guarda en un diccionario
            dict_total.Add(sistema.name, dict_scene);                           //Añade la traduccion en un diccionario total de traducciones
        }
    }
    private Dictionary<string, Valors> parseXmlFile(string xmlData)             //Toma la data de los xml y las para al diccionario correpondiente
    {
        Dictionary<string, Valors> dict_scene = new Dictionary<string, Valors>();

        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(new StringReader(xmlData));

        string xmlPathPattern = "//escena/element";
        XmlNodeList myNodeList = xmlDoc.SelectNodes(xmlPathPattern);

        Valors val;

        foreach (XmlNode node in myNodeList)
        {

            XmlNode t_english = node.FirstChild;
            XmlNode t_spanish = t_english.NextSibling;
            XmlNode t_catalan = t_spanish.NextSibling;

            val = new Valors();

            val.english_value = t_english.InnerText;
            val.spanish_value = t_spanish.InnerText;
            val.catalan_value = t_catalan.InnerText;

            dict_scene.Add(t_english.InnerText, val);
        }

        return dict_scene;
    }

    private string retornaNom(string nom, string sistem) //Busca la traducción en el diccionario
    {
        string name = "";

        if (dict_total.ContainsKey(sistem))             //El diccionario contiene el sistema buscado
        {
            if (dict_total[sistem].ContainsKey(nom))    //El diccionario dentro conriene la palabra buscada
            {
                Valors val = dict_total[sistem][nom];   //El valor buscado

                switch (idiomas)                        //Busca el idioma correspondiente a la traducción
                {
                    case TipoIdioma.catalan:
                        name = val.catalan_value;
                        break;
                    case TipoIdioma.spanish:
                        name = val.spanish_value;
                        break;
                    case TipoIdioma.english:
                        name = val.english_value;
                        break;

                }
            }
        }

        return name;                                   //retorna la treduccion correspondiente
    }
    public void ChangeIdioma(TipoIdioma idioma)                                 //Cambia el Idioma de traducciones
    {
        idiomas = idioma;
    }

    public string traduccion(string key, string sistema)
    {
        return retornaNom(key, sistema);
    }

}
