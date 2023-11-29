using System.Collections.Generic; // Add this line to include the necessary namespace
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ObjectSpawnermap : MonoBehaviour
{
    public GameObject objectToSpawn; // Assign the prefab you want to spawn in the Inspector

    private ARRaycastManager raycastManager;
    private List<ARRaycastHit> hits;

    void Start()
    {
        raycastManager = GetComponent<ARRaycastManager>();
        hits = new List<ARRaycastHit>();
    
    }

    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            // Raycast from the screen touch to detect AR plane
            Touch touch = Input.GetTouch(0);
            if (raycastManager.Raycast(touch.position, hits, TrackableType.PlaneWithinPolygon))
            {
                Pose hitPose = hits[0].pose;

                // Spawn the object at the detected position
                Instantiate(objectToSpawn, hitPose.position, hitPose.rotation);
            }
        }
    }
}
