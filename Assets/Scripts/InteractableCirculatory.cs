using UnityEngine;
using UnityEngine.InputSystem;


public class InteractableCirculatory : MonoBehaviour
{

    [SerializeField] private InputActionProperty action;

    public int state = 4;
    private GameObject[] childrenART;
    private GameObject[] childrenVEN;

    UtilsInteractables utils;

    private void Awake()
    {
        action.action.Enable();
        childrenART = GameObject.FindGameObjectsWithTag("arterias");
        childrenVEN = GameObject.FindGameObjectsWithTag("venas");

        utils = new UtilsInteractables();
    }

    private void Start()
    {
        state = 4;
    }

    public void initialState()
    {
        state = 4;
    }

    private void Update()
    {
        if (gameObject.activeSelf)
        {
            if(state == 1)
            {
                utils.activeList(childrenART, false);
            }
            if (state == 2)
            {
                utils.activeList(childrenART, true);
                utils.activeList(childrenVEN, false);
            }
            if(state == 3)
            {
                utils.activeList(childrenART, false);
                utils.activeList(childrenVEN, false);
            }
            if (state == 4)
            {
                utils.activeList(childrenART, true);
                utils.activeList(childrenVEN, true);
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

    private void OnEnable() => action.action.performed += OnAction;
}

