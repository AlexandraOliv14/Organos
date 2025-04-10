using Unity.VisualScripting;
using UnityEngine;

public static class UtilsInteractables
{
    public static void ActiveList(GameObject[] partSistem, bool active)
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
