using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lose : MonoBehaviour
{
    // Start is called before the first frame update
     public GameObject gamover;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
         Debug.Log("Collided with an object tagged as 'YourTag'");
         Debug.Log(other.name+" -----s");

        if (other.CompareTag("enmy"))
        {
            gamover.SetActive(true);
            // Perform actions when collision occurs with an object having "YourTag"
            Debug.Log("Collided with an object tagged as 'YourTag'");
            // Add your logic here
        }
    }
}
