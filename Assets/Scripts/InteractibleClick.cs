using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit.Interactors;
using UnityEngine.XR.Interaction.Toolkit.Interactors.Visuals;

public class InteractibleClick : MonoBehaviour
{
    [SerializeField] private GameObject sistema;
    [SerializeField] private AudioClip clip;

    [SerializeField] private MenuController menuButton;
    [SerializeField] private XRRayInteractor rayInteractor;

    private void Awake()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        
        foreach(Transform t in sistema.transform)
        {
            t.gameObject.SetActive(true);
        }

        sistema.SetActive(true);

        if (sistema.name == "model")
        {
            rayInteractor.GetComponent<XRInteractorLineVisual>().lineWidth = 0.002f;
        }
        else
        {
            rayInteractor.GetComponent<XRInteractorLineVisual>().lineWidth = 0.004f;
        }

        SoundManager.instance.PlaySound(clip);
        menuButton.CloseMenu();
    }
}
