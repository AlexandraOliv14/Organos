using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;
using Unity.VisualScripting;

public class InteractableDigestive : MonoBehaviour
{
    [SerializeField] private InputActionProperty action;

    [SerializeField] private GameObject[] carteles;

    [Header("Flechas a mover")]
    public GameObject i_arrow1;
    public GameObject i_arrow2;
    public GameObject i_arrow3;
    public GameObject i_arrow4;
    public GameObject i_arrow5;
    public GameObject i_arrow6;
    public GameObject i_arrow7;
    public GameObject i_arrow8;
    public GameObject i_arrow9;

    public GameObject i_arrow10;
    public GameObject i_arrow11;
    public GameObject i_arrow12;
    public GameObject i_arrow13;
    public GameObject i_arrow14;
    public GameObject i_arrow15;
    public GameObject i_arrow16;

    public GameObject e_arrow1;
    public GameObject e_arrow2;
    public GameObject e_arrow3;
    public GameObject e_arrow4;
    public GameObject e_arrow5;
    public GameObject e_arrow6;

    public GameObject g_arrow1;
    public GameObject g_arrow2;
    public GameObject g_arrow3;
    public GameObject g_arrow4;
    public GameObject g_arrow5;
    public GameObject g_arrow6;
    public GameObject g_arrow7;
    public GameObject g_arrow8;
    public GameObject g_arrow9;
    public GameObject g_arrow10;

    private bool moving = false;

    private bool sequencia = true;
    private bool actiu = false;

    private void Awake()
    {
        action.action.Enable();
    }

    private void OnDisable()
    {
        moving = false;
        sequencia = true;
        actiu = false;

        UtilsInteractables.ActiveList(carteles, false);
    }

    private void OnEnable()
    {
        moving = false;
        sequencia = true;
        actiu = false;
        UtilsInteractables.ActiveList(carteles, false);
        action.action.performed += OnAction;
    }

    private void Update()
    {
        if (!gameObject.activeSelf) return;
        if (actiu)
        {
            moving = true; //activo moviment
            UtilsInteractables.ActiveList(carteles, true);
        }
        else
        {
            moving = false; //deixa de fer sequencia de fletxes
            Parar(); //desactiva les fletxes
            UtilsInteractables.ActiveList(carteles, false);
        }


        if (moving)
        {
            if (sequencia)
            { //Boolea per activar coroutines sols un cop

                StartCoroutine("I_Sequencia"); //moviment i activaci� fletxes i cartells
            }

        }
    }

    private void OnAction(InputAction.CallbackContext obj) 
    {
        actiu = !actiu;
    }

    void Parar()
    {
        //funcior per desactivar totes les fletxes.
        i_arrow1.SetActive(false);
        i_arrow2.SetActive(false);
        i_arrow3.SetActive(false);
        i_arrow4.SetActive(false);
        i_arrow5.SetActive(false);
        i_arrow6.SetActive(false);
        i_arrow7.SetActive(false);
        i_arrow8.SetActive(false);
        i_arrow9.SetActive(false);
        i_arrow10.SetActive(false);
        i_arrow11.SetActive(false);
        i_arrow12.SetActive(false);
        i_arrow13.SetActive(false);
        i_arrow14.SetActive(false);
        i_arrow15.SetActive(false);
        i_arrow16.SetActive(false);

        e_arrow1.SetActive(false);
        e_arrow2.SetActive(false);
        e_arrow3.SetActive(false);
        e_arrow4.SetActive(false);
        e_arrow5.SetActive(false);
        e_arrow6.SetActive(false);

        g_arrow1.SetActive(false);
        g_arrow2.SetActive(false);
        g_arrow3.SetActive(false);
        g_arrow4.SetActive(false);
        g_arrow5.SetActive(false);
        g_arrow6.SetActive(false);
        g_arrow7.SetActive(false);
        g_arrow8.SetActive(false);
        g_arrow9.SetActive(false);
        g_arrow10.SetActive(false);

    }


    IEnumerator I_Sequencia()
    {
        //moviment i activaci� de fletxes i cartells
        sequencia = false;
        if (moving)
        {
            i_arrow1.SetActive(true);
            g_arrow1.SetActive(true);
            g_arrow2.SetActive(true);
            g_arrow3.SetActive(true);
            g_arrow4.SetActive(true);
            g_arrow5.SetActive(true);
            g_arrow10.SetActive(false);
            yield return new WaitForSeconds(0.2f);
            i_arrow2.SetActive(true);
            i_arrow15.SetActive(true);


            yield return new WaitForSeconds(0.2f);
            i_arrow1.SetActive(false);
            i_arrow3.SetActive(true);
            i_arrow16.SetActive(true);

            yield return new WaitForSeconds(0.2f);
            i_arrow2.SetActive(false);
            i_arrow15.SetActive(false);
            i_arrow4.SetActive(true);

            g_arrow1.SetActive(false);
            g_arrow2.SetActive(false);
            g_arrow3.SetActive(false);
            g_arrow4.SetActive(false);
            g_arrow5.SetActive(false);
            g_arrow6.SetActive(true);
            yield return new WaitForSeconds(0.2f);
            i_arrow3.SetActive(false);
            i_arrow16.SetActive(false);
            i_arrow5.SetActive(true);
            g_arrow7.SetActive(true);
            g_arrow6.SetActive(false);

            yield return new WaitForSeconds(0.2f);
            i_arrow4.SetActive(false);
            i_arrow6.SetActive(true);
            g_arrow8.SetActive(true);
            g_arrow7.SetActive(false);
            yield return new WaitForSeconds(0.2f);
            i_arrow5.SetActive(false);
            i_arrow7.SetActive(true);
            e_arrow1.SetActive(true);
            g_arrow9.SetActive(true);
            g_arrow8.SetActive(false);
            yield return new WaitForSeconds(0.2f);
            i_arrow6.SetActive(false);
            i_arrow8.SetActive(true);
            e_arrow2.SetActive(true);
            g_arrow10.SetActive(true);
            g_arrow9.SetActive(false);
            yield return new WaitForSeconds(0.2f);
            i_arrow7.SetActive(false);
            e_arrow1.SetActive(false);
            i_arrow9.SetActive(true);
            e_arrow3.SetActive(true);

            g_arrow10.SetActive(false);
            g_arrow1.SetActive(true);
            g_arrow2.SetActive(true);
            g_arrow3.SetActive(true);
            g_arrow4.SetActive(true);
            g_arrow5.SetActive(true);
            yield return new WaitForSeconds(0.2f);
            i_arrow8.SetActive(false);
            e_arrow2.SetActive(false);
            i_arrow10.SetActive(true);
            e_arrow4.SetActive(true);

            yield return new WaitForSeconds(0.2f);
            i_arrow9.SetActive(false);
            e_arrow3.SetActive(false);
            i_arrow11.SetActive(true);
            e_arrow5.SetActive(true);

            yield return new WaitForSeconds(0.2f);
            i_arrow10.SetActive(false);
            e_arrow4.SetActive(false);
            i_arrow12.SetActive(true);
            e_arrow6.SetActive(true);
            g_arrow1.SetActive(false);
            g_arrow2.SetActive(false);
            g_arrow3.SetActive(false);
            g_arrow4.SetActive(false);
            g_arrow5.SetActive(false);
            g_arrow6.SetActive(true);
            yield return new WaitForSeconds(0.2f);
            i_arrow11.SetActive(false);
            e_arrow5.SetActive(false);
            i_arrow13.SetActive(true);
            g_arrow7.SetActive(true);
            g_arrow6.SetActive(false);
            yield return new WaitForSeconds(0.2f);
            i_arrow12.SetActive(false);
            e_arrow6.SetActive(false);
            i_arrow14.SetActive(true);
            g_arrow8.SetActive(true);
            g_arrow7.SetActive(false);
            yield return new WaitForSeconds(0.2f);

            i_arrow13.SetActive(false);
            g_arrow9.SetActive(true);
            g_arrow8.SetActive(false);
            yield return new WaitForSeconds(0.2f);
            i_arrow14.SetActive(false);
            g_arrow10.SetActive(true);
            g_arrow9.SetActive(false);
        }

        sequencia = true;


    }
}