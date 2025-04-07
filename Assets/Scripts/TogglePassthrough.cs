using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.ARFoundation;

public class TogglePassthrough : MonoBehaviour //PLAYER
{
    [SerializeField] private InputActionProperty toggleAction;

    private GameObject[] plane; 

    private ARCameraManager arCameraManager;

    [SerializeField] private TMP_Text button;

    private void Awake()
    {
        toggleAction.action.Enable();
        arCameraManager = FindAnyObjectByType<ARCameraManager>(); //Encuantra la camara de realidad aumentada
        plane = GameObject.FindGameObjectsWithTag("plane");       //Encuentra todos los objetos con el tag de plane--> Actualmente solo 1
    }

    private void OnTogglePerformed(InputAction.CallbackContext obj)
    {
        if (arCameraManager)                                                //Verifica que se encontro la camara
        {
            if (arCameraManager.enabled)                                    //Si esta encendidad prepara la escena para el cuando se apague la camara
            {
                Camera.main.clearFlags = CameraClearFlags.Skybox;           //Instala el Skybox para la realidad virtual
                if (plane != null)
                {
                    plane[0].transform.localScale = new Vector3(5f, 0.5f, 5f);
                }
                button.text = "passthrough";
            }
            else                                                            //Si esta apagada prepara la escena para cuando la capara se prenda
            {
                Camera.main.clearFlags = CameraClearFlags.SolidColor;       //Para la realidad mixta se establece el color solido
                Camera.main.backgroundColor = new Color32(0, 0, 0, 0);      //El color debe establecerce como  0,0,0,0
                if (plane != null)
                {
                    plane[0].transform.localScale = new Vector3(3f, 0.1f, 4f);
                }
                button.text = "VR";
            }
            arCameraManager.enabled = !arCameraManager.enabled;             //Realiza el cambio de camara correspondiente
        }

    }

    private void OnEnable() => toggleAction.action.performed += OnTogglePerformed;

    private void OnDisable() => toggleAction.action.performed -= OnTogglePerformed;

}