using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class MenuController : MonoBehaviour //MENUS
{
    
    [SerializeField] private InputActionReference openMenuAction;
    [SerializeField] private GameObject[] ItemSistems;

    [SerializeField] private GameObject[] objectsInMenu;

    [SerializeField] private GameObject[] objectsNotInMenu;

    [Header ("RayCast")]
    [SerializeField] private XRRayInteractor reyCastrigth;

    [SerializeField] private XRRayInteractor reyCastleft;

    private void Awake()
    {
        openMenuAction.action.Enable();
        openMenuAction.action.performed += ToogleMenu;
        InputSystem.onDeviceChange -= onDeviceGhange;
    }

    public void CloseMenu()
    {
        gameObject.SetActive(false);
        reyCastrigth.enabled = false;                         //El reyCast se activa o desactiva segun corresponda
        reyCastleft.enabled = false;

        UtilsInteractables.ActiveList(objectsInMenu, false);
        UtilsInteractables.ActiveList(objectsNotInMenu, true);
    }

    public void OpenMenu()
    {
        gameObject.SetActive(true);
        reyCastrigth.enabled = true;                         //El reyCast se activa o desactiva segun corresponda
        reyCastleft.enabled = true;

        UtilsInteractables.ActiveList(objectsInMenu, true);
        UtilsInteractables.ActiveList(objectsNotInMenu, false);
        UtilsInteractables.ActiveList(ItemSistems, false);
    }

    private void ToogleMenu(InputAction.CallbackContext context)
    {
        if(!gameObject.activeSelf) { OpenMenu(); }
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
}
