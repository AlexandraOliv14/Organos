using UnityEngine;
using UnityEngine.UI;

public class SistemClick : MonoBehaviour
{
    [SerializeField] private GameObject sistema;
    [SerializeField] private AudioClip clip;

    [SerializeField] private MenuController menuButton;

    private void Awake()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClick);
    }

    private void OnButtonClick()
    {

        foreach (Transform t in sistema.transform)
        {
            t.gameObject.SetActive(true);
        }

        sistema.SetActive(true);

        SoundManager.instance.PlaySound(clip);
        menuButton.CloseMenu();
    }
}
