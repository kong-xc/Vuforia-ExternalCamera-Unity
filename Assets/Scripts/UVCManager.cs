using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
public class UVCManager : MonoBehaviour
{
    private void Awake()
    {
#if UNITY_ANDROID
        bool driverLibrarySet = false;
        driverLibrarySet = VuforiaUnity.SetDriverLibrary("libUVCDriver.so");

        if (driverLibrarySet)
        {
            // Load your applications scene here 
            // InitAndLoadScene(VUFORIA_DRIVER_CAMERA_SCENE_INDEX);

            // The application needs to ask for USB permissions to run the USB camera
            // this is done after the driver is loaded. We call a method in the UVC driver
            // Java code to request permissions, passing in the Unity app's activity.
            AndroidJavaClass unityJC = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject unityActivity = unityJC.GetStatic<AndroidJavaObject>("currentActivity");

            AndroidJavaClass usbControllerJC = new AndroidJavaClass("com.vuforia.samples.uvcDriver.USBController");
            usbControllerJC.CallStatic("requestUSBPermission", unityActivity);
        }
        else
        {
            Debug.Log("Failed to initialize the UVC driver - defaulting to the standard scene");

            // Fall back to the in-built camera
        }
#endif
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
