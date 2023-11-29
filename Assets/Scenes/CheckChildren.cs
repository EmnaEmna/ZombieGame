using UnityEngine;

public class CheckChildren : MonoBehaviour
{
    // Reference to the GameObject you want to check
    public GameObject gamover;
    public GameObject cheakifwin;

    void Update()
    {
        // Check if the GameObject has children
        if (!(cheakifwin.transform.childCount > 0))
        {
           gamover.SetActive(true);
           
            
        }
        
    }
}
