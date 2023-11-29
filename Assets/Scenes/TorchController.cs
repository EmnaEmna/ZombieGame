using UnityEngine;

public class TorchController : MonoBehaviour
{
    public void ToggleTorch()
    {
        AndroidJavaClass cameraClass = new AndroidJavaClass("android.hardware.camera2.CameraManager");
        AndroidJavaObject cameraManager = cameraClass.CallStatic<AndroidJavaObject>("getSystemService", "camera");
        string[] cameraIds = cameraManager.Call<string[]>("getCameraIdList");

        foreach (string cameraId in cameraIds)
        {
            AndroidJavaObject cameraCharacteristics = cameraManager.Call<AndroidJavaObject>("getCameraCharacteristics", cameraId);
            bool hasTorch = cameraCharacteristics.Call<bool>("get", "FLASH_INFO_AVAILABLE");

            if (hasTorch)
            {
                cameraManager.Call("setTorchMode", cameraId, !cameraManager.Call<bool>("getTorchMode", cameraId));
                break;
            }
        }
    }
}