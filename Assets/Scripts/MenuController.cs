using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class MenuController : MonoBehaviour //MENUS
{
    
    [SerializeField]
    private InputActionReference openMenuAction;

    [SerializeField]
    private List<GameObject> ItemSistems;

    [Header ("RayCast")]
    [SerializeField]
    private XRRayInteractor reyCastrigth;

    [SerializeField]
    private XRRayInteractor reyCastleft;

    private void Awake()
    {
        openMenuAction.action.Enable();
        openMenuAction.action.performed += ToogleMenu;
        InputSystem.onDeviceChange -= onDeviceGhange;

    }

    private void ToogleMenu(InputAction.CallbackContext context)
    {
        gameObject.SetActive(!gameObject.activeSelf);                     //El menu se activa o desactiva segun corresponda

        reyCastrigth.enabled = gameObject.activeSelf;                         //El reyCast se activa o desactiva segun corresponda
        reyCastleft.enabled = gameObject.activeSelf;

        if (gameObject.activeSelf)                                       //Cierra los sistemas si el menu esta activo
        {
            foreach (GameObject item in ItemSistems)
            {
                item.SetActive(false);
            }
        }
    }

    private void onDeviceGhange(InputDevice device, InputDeviceChange change) //Precausion para cuando se sueltan los mandos
    {
        switch (change)
        {
            case InputDeviceChange.Disconnected:
                gameObject.SetActive(false);
                openMenuAction.action.performed -= ToogleMenu;
                break;
            case InputDeviceChange.Reconnected:
                gameObject.SetActive(true);
                openMenuAction.action.performed += ToogleMenu;
                break;
        }
    
    }

    public void OnClick() //Parte de las funciones al seleccionar un sistema en el menu
    {
        gameObject.SetActive (false);
        reyCastrigth.enabled = false;
        reyCastleft.enabled = false;

    }
}
