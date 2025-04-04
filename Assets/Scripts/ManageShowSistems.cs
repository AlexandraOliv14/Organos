using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit.Interactors;
using TMPro;
using UnityEngine.XR.Interaction.Toolkit;
using Unity.VisualScripting;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using System;
using NUnit.Framework.Internal;

public class ManageShowSistems : MonoBehaviour //RAYINTERACTOR
{
    [SerializeField]
    private InputActionProperty toggleAction;                   //Boton o obotones asignados

    private XRRayInteractor rayInteractor;

    [SerializeField]
    private GameObject menu;

    [SerializeField]
    private GameObject nombreSistems;

    private GameObject objCurrent;

    private void Awake()
    {
        toggleAction.action.Enable();
        rayInteractor = GetComponent<XRRayInteractor>(); 
    }

    void Update()
    {
        if (rayInteractor == null)
            return;

        // Verifica si el rayo está sobre un interactable
        if (rayInteractor.TryGetCurrent3DRaycastHit(out RaycastHit hit))
        {
            GameObject hoveredObject = hit.collider.gameObject;
            if (objCurrent == hoveredObject) return;

            if(objCurrent != hoveredObject)
            {
                if(objCurrent != null)
                {
                    ActivateSelect actSelCurrent = objCurrent.GetComponent<ActivateSelect>();
                    if (!actSelCurrent.IsUnityNull()) actSelCurrent.desSelect();
                }

                ActivateSelect actSel = hoveredObject.GetComponent<ActivateSelect>();
                if (!actSel.IsUnityNull()) actSel.select();

                objCurrent = hoveredObject;
            }
        }
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

                //nombreSistems.SetActive(false);

                //TMP_Text sistemText =  nombreSistems.GetComponentInChildren<TMP_Text>();

                /*if (sistemText!=null)
                {
                    sistemText.text = "";
                }*/
            }
        }
    }
    private void OnEnable() => toggleAction.action.performed += OnPress;
    private void OnDisable() => toggleAction.action.performed -= OnPress;

}