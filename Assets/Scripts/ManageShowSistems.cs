using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit.Interactors;
using TMPro;


public class ManageShowSistems : MonoBehaviour //RAYINTERACTOR
{
    [SerializeField]
    private InputActionProperty toggleAction;                   //Boton o obotones asignados

    private XRRayInteractor rayInteractor;

    [SerializeField]
    private GameObject menu;

    [SerializeField]
    private GameObject nombreSistems;

    private void Awake()
    {
        toggleAction.action.Enable();
        rayInteractor = GetComponent<XRRayInteractor>();        //Busca el componente de XRRayInteractor
       // nombreSistems.SetActive(false);                         //Por defecto se inicia con el nombre del sistema inactivo
    }

    private void OnPress(InputAction.CallbackContext obj)
    {

        if (!menu.activeSelf)                                   //Verifica que el menu este desactivado
        {
            if (toggleAction.action.IsPressed())                //Cuando se presiona el boton, se activa el rayo y el nombre del sistema
            {
                rayInteractor.enabled = true;
                nombreSistems.SetActive(true);
            }
            else                                                //Si el boton de suelta, se desactiva el rayo, el nombre del sistema y se borra el
            {                                                   //contenido del nombre 
                rayInteractor.enabled = false;
                nombreSistems.SetActive(false);

                TMP_Text sistemText =  nombreSistems.GetComponentInChildren<TMP_Text>();

                if (sistemText!=null)
                {
                    sistemText.text = "";
                }
            }
        }
    }

    private void OnEnable() => toggleAction.action.performed += OnPress;
    private void OnDisable() => toggleAction.action.performed -= OnPress;
    
}