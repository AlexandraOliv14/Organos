using TMPro;
using UnityEngine;

public class ManagerMenuButton : MonoBehaviour //MENUPRINCIPAL
{

    public GameObject[] childrens;

    public string nombreSistema;

    public void callChange()
    {
        foreach(GameObject children in childrens)   //Busca todos los botones dentro del menu
        {
            string name = children.name;            //Toma el nombre correspondiente

            TMP_Text textB = children.GetComponentInChildren<TMP_Text>();   //Toma el elemento de texto del boton

            if (textB != null)
            {
                textB.text = ManagerIdioma.instance.traduccion(name, nombreSistema); //Inserta el nombre del sistema con la traduccion correspondiente
            }
        }
        
    }

}
