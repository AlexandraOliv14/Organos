using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class MenuController : MonoBehaviour //MENUS
{
    
    [SerializeField] private InputActionReference openMenuAction;
    [SerializeField] private List<GameObject> ItemSistems;

    [SerializeField] private GameObject nombreSistems;
    [SerializeField] private GameObject cartelMenu;
    [SerializeField] private GameObject cartelPress;

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

        nombreSistems.SetActive(true);
        cartelMenu.SetActive(true);
        cartelPress.SetActive(true);
    }

    public void OpenMenu()
    {
        gameObject.SetActive(true);
        reyCastrigth.enabled = true;                         //El reyCast se activa o desactiva segun corresponda
        reyCastleft.enabled = true;

        nombreSistems.SetActive(false);
        cartelMenu.SetActive(false);
        cartelPress.SetActive(false);

        foreach (GameObject item in ItemSistems)
        {
            item.SetActive(false);
            InteractableCirculatory circ = item.GetComponent<InteractableCirculatory>();
            if (circ != null) circ.initialState();
            InteractableDigestive dig = item.GetComponent<InteractableDigestive>();
            if (dig != null) dig.initialState();
            InteractableEncefalo cerb = item.GetComponent<InteractableEncefalo>();
            if (cerb != null) cerb.initialState();
            InteractableEye ojo = item.GetComponent<InteractableEye>();
            if (ojo != null) ojo.close = true;

        }
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
