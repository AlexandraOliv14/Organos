using UnityEngine;
using UnityEngine.UI;

public class ButtonIdioma : MonoBehaviour
{
    [SerializeField] private AudioClip clip;

    [Header("Idioma")]
    [SerializeField] private TipoIdioma idioma;
    [SerializeField] private ManagerMenuButton[] callChange;

    private void Awake()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    private void TaskOnClick()
    {
        ManagerIdioma.instance.ChangeIdioma(idioma);
        SoundManager.instance.PlaySound(clip);

        foreach (ManagerMenuButton call in callChange)
        {
            call.callChange();
        }
    }
}
