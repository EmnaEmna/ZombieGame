using UnityEngine;

public class LightSensorController : MonoBehaviour
{
    public Light lightSensor; // Assign your Light GameObject to this variable in the Inspector
    public float lightThreshold = 0.5f; // Set your threshold value

    void Update()
    {
        if (lightSensor != null)
        {
            float lightIntensity = lightSensor.intensity;

            // Check if light intensity is below the threshold
            if (lightIntensity < lightThreshold)
            {
                Debug.Log("No light detected (or hand covering sensor).");
            }
        }
        else
        {
            Debug.LogError("Light sensor object not assigned!");
        }
    }
}
