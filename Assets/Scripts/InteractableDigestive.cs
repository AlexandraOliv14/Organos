using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;
using Unity.VisualScripting;

public class InteractableDigestive : MonoBehaviour
{
    [SerializeField] private InputActionProperty action;

    [SerializeField] private GameObject[] carteles;

    [Header("Flechas a mover")]
    [SerializeField] private GameObject[] flechas;

    private bool actiu = false;


    private void Awake()
    {
        action.action.Enable();
    }

    private void OnDisable()
    {
        actiu = false;

        UtilsInteractables.ActiveList(carteles, false);
        UtilsInteractables.ActiveList(flechas, false);
    }

    private void OnEnable()
    {
        actiu = false;
        UtilsInteractables.ActiveList(carteles, false);
        UtilsInteractables.ActiveList(flechas, false);
        action.action.performed += OnAction;
    }


    private void OnAction(InputAction.CallbackContext obj)
    {
        actiu = !actiu;
        if (actiu)
        {
            UtilsInteractables.ActiveList(carteles, true);
            UtilsInteractables.ActiveList(flechas, true);
        }
        else
        {
            UtilsInteractables.ActiveList(carteles, false);
            UtilsInteractables.ActiveList(flechas, false);
        }
    }
}