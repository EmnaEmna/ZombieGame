using UnityEngine;
using TMPro;
public class ShakeDetector : MonoBehaviour
{
    public float shakeThreshold = 3.0f; // Adjust this value to set the sensitivity of the shake

    private bool isShaking = false;
    private float lastShakeTime;
     public TextMeshProUGUI coinCountText;
     public int nbul=10;
    
    void Update()
    {
        if (Input.acceleration.magnitude >= shakeThreshold && !isShaking)
        {
            isShaking = true;
            lastShakeTime = Time.time;
            Debug.Log("Shake detected!");
            // You can replace the line above with any action you want to perform on shake
            Debug.Log("Hey"); // Print "Hey" to the console
           coinCountText.text=""+10;
           nbul=10;
        }

        if (isShaking && Time.time - lastShakeTime > 0.5f) // Set a cooldown time to prevent continuous detection
        {
            isShaking = false;
        }
    }



    public void fire(){
        if(nbul>0){
            
        nbul--;
         coinCountText.text=""+nbul;
        }
    }
}
