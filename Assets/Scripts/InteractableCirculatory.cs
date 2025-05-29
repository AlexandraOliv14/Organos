using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit.Interactors;
using UnityEngine.XR.Interaction.Toolkit.Interactors.Visuals;

public class InteractableCirculatory : MonoBehaviour
{

    [SerializeField] private InputActionProperty action;
    public int state = 4;
    private GameObject[] childrenART;
    private GameObject[] childrenVEN;

    [SerializeField] private XRRayInteractor rayInteractor;

    private void Awake()
    {
        action.action.Enable();
        childrenART = GameObject.FindGameObjectsWithTag("arterias");
        childrenVEN = GameObject.FindGameObjectsWithTag("venas");

        state = 4;
    }

    private void OnEnable()
    {
        rayInteractor.GetComponent<XRInteractorLineVisual>().lineWidth = 0.002f;
        action.action.performed += OnAction;
    }
    private void OnDisable()
    {
        state = 4;
        rayInteractor.GetComponent<XRInteractorLineVisual>().lineWidth = 0.004f;
        action.action.performed -= OnAction;
    }

    private void Update()
    {
        if (!gameObject.activeSelf) return;
        if (gameObject.activeSelf)
        {
            if(state == 1)
            {
                UtilsInteractables.ActiveList(childrenART, false);
            }
            if (state == 2)
            {
                UtilsInteractables.ActiveList(childrenART, true);
                UtilsInteractables.ActiveList(childrenVEN, false);
            }
            if(state == 3)
            {
                UtilsInteractables.ActiveList(childrenART, false);
                UtilsInteractables.ActiveList(childrenVEN, false);
            }
            if (state == 4)
            {
                UtilsInteractables.ActiveList(childrenART, true);
                UtilsInteractables.ActiveList(childrenVEN, true);
            }
        }
    }

    private void OnAction(InputAction.CallbackContext obj)
    {
        if (gameObject.activeSelf)
        {
            switch (state) { 
                case 0:
                    state = 1;
                    break;
                case 1:
                    state = 2;
                    break;
                case 2:
                    state = 3;
                    break;
                case 3:
                    state = 4;
                    break;
                case 4:
                    state = 1;
                    break;
            }
        }
    }

}

