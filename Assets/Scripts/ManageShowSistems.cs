using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit.Interactors;
using TMPro;
using Unity.VisualScripting;

public class ManageShowSistems : MonoBehaviour //RAYINTERACTOR
{
    [SerializeField] private InputActionProperty toggleAction;                   //Boton o obotones asignados

    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject nombreSistems;
    [SerializeField] private AudioClip soundSelect;

    private XRRayInteractor rayInteractor;

    private GameObject objCurrent;
    private TMP_Text _title;

    private void Awake()
    {
        toggleAction.action.Enable();
        rayInteractor = GetComponent<XRRayInteractor>();
        _title = nombreSistems.GetComponentInChildren<TMP_Text>();
    }

    void Update()
    {
        if (rayInteractor == null || !rayInteractor.isActiveAndEnabled) return;

        // Verifica si el rayo está sobre un interactable
        if (rayInteractor.TryGetCurrent3DRaycastHit(out RaycastHit hit))
        {
            GameObject hoveredObject = hit.collider.gameObject;

            if (objCurrent == hoveredObject) return;

            if (objCurrent != hoveredObject)
            {
                DeselectCurrent();
                OnSelect(hoveredObject);
            }
        }

        if (menu.activeSelf) ClearSelection();
    }

    private void OnSelect(GameObject hoveredObject)
    {
        if (hoveredObject.TryGetComponent<ActivateSelect>(out var actSel)) //Si no lo encuentra devuelve false y si lo encuentra lo guarda en la variable dada
        {
            actSel.Select(_title);
            SoundManager.instance.PlaySound(soundSelect);
        }

        objCurrent = hoveredObject;
    }

    private void DeselectCurrent()
    {
        if (objCurrent != null)
        {
            if (objCurrent.TryGetComponent<ActivateSelect>(out var actSel)) actSel.DesSelect(); //Si no lo encuentra devuelve false y si lo encuentra lo guarda en la variable dada
        }
    }

    private void ClearSelection()
    {
        DeselectCurrent();
        _title.text = "";
        nombreSistems.SetActive(false);
        objCurrent = null;
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
        }
    }

    private void OnRelise(InputAction.CallbackContext obj)
    {
        if (!menu.activeSelf)                                   //Verifica que el menu este desactivado
        {
            ClearSelection();
            rayInteractor.enabled = false;
        }
    }

    private void OnEnable(){toggleAction.action.performed += OnPress; toggleAction.action.canceled += OnRelise;}
    private void OnDisable() { toggleAction.action.performed -= OnPress; toggleAction.action.canceled -= OnRelise; }

}