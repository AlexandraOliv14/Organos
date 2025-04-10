using UnityEngine;
using UnityEngine.InputSystem;

public class InteractableEncefalo : MonoBehaviour
{
    [SerializeField]
    private InputActionProperty action;

    public int state = 6;

    private GameObject[] childrenSterm;
    private GameObject[] childrenUll;
    private GameObject[] childrenLimb;
    private GameObject[] childrenBasal;

    private GameObject childCerebel;
    private GameObject childThalamus;
    private GameObject childEmilL;
    private GameObject childEmilR;
    private GameObject chilVent;

    [Header("Letreros")]
    [SerializeField] private GameObject LetreroVent;
    [SerializeField] private GameObject LetreroLimb;
    [SerializeField] private GameObject LetreroNerv;

    private void Awake()
    {
        action.action.Enable();

        childrenLimb = GameObject.FindGameObjectsWithTag("limbic");
        childrenSterm = GameObject.FindGameObjectsWithTag("sterm");
        childrenBasal = GameObject.FindGameObjectsWithTag("basal");
        childrenUll = GameObject.FindGameObjectsWithTag("ull");

        childCerebel = gameObject.transform.Find("r_cerebellum").gameObject;
        childThalamus = gameObject.transform.Find("r_thalamus").gameObject;
        childEmilL = gameObject.transform.Find("r_Left Cerebral Hemisphere").gameObject;
        childEmilR = gameObject.transform.Find("r_Right Cerebral Hemisphere").gameObject;
        chilVent = gameObject.transform.Find("r_ventricle").gameObject;

        state = 6;
    }
    private void OnDisable()
    {
        state = 6;
        action.action.performed -= OnAction;
    }
    
    private void Update()
    {
        if (!gameObject.activeSelf) return;
        if (gameObject.activeSelf)
        {

            if (state == 1)
            {
                childEmilL.SetActive(false);
                
            }
            if (state == 2)
            {
                childEmilR.SetActive(false);
                childCerebel.SetActive(false);
            }
            if (state == 3)
            {
                //cartel sistema ventricular
                LetreroVent.SetActive(true);

                UtilsInteractables.ActiveList(childrenSterm, false);
                UtilsInteractables.ActiveList(childrenLimb, false);
                UtilsInteractables.ActiveList(childrenUll, false);
                UtilsInteractables.ActiveList(childrenBasal, false);

                childThalamus.SetActive(false);
                chilVent.SetActive(true);
            }
            if (state == 4)
            {
                //sistema limbico+
                LetreroLimb.SetActive(true);

                UtilsInteractables.ActiveList(childrenLimb, true);
                UtilsInteractables.ActiveList(childrenBasal, true);
                childThalamus.SetActive(true);

                UtilsInteractables.ActiveList(childrenSterm, false);
                chilVent.SetActive(false);
                LetreroVent.SetActive(false);
            }
            if (state == 5)
            {
                //sistema nervioso
                LetreroNerv.SetActive(true);

                UtilsInteractables.ActiveList(childrenSterm, true);
                UtilsInteractables.ActiveList(childrenUll, true);

                UtilsInteractables.ActiveList(childrenLimb, false);
                UtilsInteractables.ActiveList(childrenBasal, false);

                chilVent.SetActive(false);
                childThalamus.SetActive(false);
                LetreroLimb.SetActive(false);
            }
            if (state == 6)
            {
                //todo
                UtilsInteractables.ActiveList(childrenSterm, true);
                UtilsInteractables.ActiveList(childrenLimb, true);
                UtilsInteractables.ActiveList(childrenUll, true);
                UtilsInteractables.ActiveList(childrenBasal, true);

                childCerebel.SetActive(true);
                childThalamus.SetActive(true);
                childEmilL.SetActive(true);
                childEmilR.SetActive(true);
                chilVent.SetActive(true);

                LetreroVent.SetActive(false);
                LetreroNerv.SetActive(false);
                LetreroLimb.SetActive(false);

            }
        }
    }

    private void OnAction(InputAction.CallbackContext obj)
    {
        if (gameObject.activeSelf)
        {
            switch (state)
            {
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
                    state = 5;
                    break;
                case 5:
                    state = 6;
                    break;
                case 6:
                    state = 1;
                    break;
            }
        }
    }

    private void OnEnable() => action.action.performed += OnAction;
}
