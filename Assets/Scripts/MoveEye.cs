using UnityEngine;

public class MoveEye : MonoBehaviour
{
    [SerializeField] private GameObject inicio;
    [SerializeField] private GameObject final;

    public float velocidad = 2f;

    private bool moveOpen;

    public void MoveOpen(){ moveOpen = true; }

    public void MoveClose(){ moveOpen = false;}

    private void Update()
    {
        if (moveOpen)
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, final.transform.position, velocidad * Time.deltaTime);
        }
        else
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, inicio.transform.position, velocidad * Time.deltaTime);
        }
    }


}
