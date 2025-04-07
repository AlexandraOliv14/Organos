using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ActivateSelect : MonoBehaviour
{
    [SerializeField] private GameObject sistema;  //Sistema que lo envuelve

    [Header("Change Color")]
    [SerializeField] private Material newColor;
    [SerializeField] private Material oldColor1, oldColor2;

    public void Select(TMP_Text _title)
    {
        Renderer render = GetComponent<Renderer>();
        if (render != null)
        {
            if (oldColor2.IsUnityNull())    //Solo cambiar un color
            {
                render.material = newColor;    //Color de seleccion
            }
            else                            //Cambiar 2 color
            {
                Material[] materials = new Material[2];
                materials[0] = newColor;
                materials[1] = newColor;

                render.materials = materials;  //Color de seleccion
            }
        }

       _title.text = ManagerIdioma.instance.traduccion(gameObject.name, sistema.name);
    }
    public void DesSelect()
    {
        Renderer render = GetComponent<Renderer>();
        if (render != null)
        {
            if (oldColor2.IsUnityNull()) //Solo cambiar un color
            {
                render.material = oldColor1;  //Color de correspondiente
            }
            else                            //Cambiar 2 color
            {
                Material[] materials = new Material[2];
                materials[0] = oldColor1;
                materials[1] = oldColor2;

                render.materials = materials;  //Color de correspondiente
            }
        }
    }

}
