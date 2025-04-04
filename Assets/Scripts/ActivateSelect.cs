using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class ActivateSelect : XRBaseInteractable
{
    [Header("Change Color")]
    [SerializeField] private GameObject sistema;  //Sistema que lo envuelve

    [SerializeField]
    private GameObject nombre;
    private TMP_Text _title;

    [SerializeField] private Material newColor;
    [SerializeField] private Material oldColor1, oldColor2;

    public void Start()
    {
        _title = nombre.GetComponentInChildren<TMP_Text>();
    }

    override protected void OnHoverEntered(HoverEnterEventArgs args)  ///To Hover --> Elemento
    {
        base.OnHoverEntered(args);//para no perder lo anterior

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

            nombre.SetActive(true);

            _title.text = ManagerIdioma.instance.traduccion(gameObject.name, sistema.name); //Inserta el nombre del sistema con su traduccion correspondiente
        }
    }

    protected override void OnHoverExited(HoverExitEventArgs args)
    {
        base.OnHoverExited(args);
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
