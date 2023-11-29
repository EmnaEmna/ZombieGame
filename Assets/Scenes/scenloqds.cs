using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scenloqds : MonoBehaviour
{
    public string back= "LowPolyFPS_Lite_Demo";

    public GameObject btn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

private void OnTriggerEnter(Collider other) {
    btn.SetActive(true);
}
        public void nav(){
        // Load a scene by its name
        SceneManager.LoadScene(back);

    }
}
