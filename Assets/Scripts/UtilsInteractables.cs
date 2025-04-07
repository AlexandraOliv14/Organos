using Unity.VisualScripting;
using UnityEngine;

public class UtilsInteractables
{
    public void activeList(GameObject[] partSistem, bool active)
    {

        if(!partSistem.IsUnityNull() && partSistem.Length > 0)
        {
            foreach (GameObject child in partSistem)
            {
                child.SetActive(active);
            }
        }    
    }
}
