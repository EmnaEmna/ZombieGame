using UnityEngine;

public class FlashlightController : MonoBehaviour
{
    AndroidJavaObject cameraManager;
    string cameraId;

    void Start()
    {
        cameraManager = new AndroidJavaObject("android.hardware.camera2.CameraManager");
        string[] cameraList = cameraManager.Call<string[]>("getCameraIdList");
        if (cameraList.Length > 0)
        {
            cameraId = cameraList[0]; // Assign the first camera ID from the list
        }
    }

    public void TurnOnFlashlight()
    {
        if (!string.IsNullOrEmpty(cameraId))
        {
            cameraManager.Call("setTorchMode", cameraId, true);
        }
    }

    public void TurnOffFlashlight()
    {
        if (!string.IsNullOrEmpty(cameraId))
        {
            cameraManager.Call("setTorchMode", cameraId, false);
        }
    }
}
