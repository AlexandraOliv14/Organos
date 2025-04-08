using UnityEngine;
using UnityEngine.InputSystem;

public class InteractableEye : MonoBehaviour
{
    [SerializeField] private InputActionProperty action;

    public bool close = true;

    private MoveEye[] moves;

    private void Awake()
    {
        action.action.Enable();
        moves = gameObject.GetComponentsInChildren<MoveEye>();

    }

    private void OnAction(InputAction.CallbackContext obj)
    {
        foreach (MoveEye part in moves)
        {
            if (close) part.MoveOpen();
            else part.MoveClose();
        }
        close = !close;
    }


    private void OnEnable() => action.action.performed += OnAction;
    private void OnDisable() => action.action.performed -= OnAction;
}
