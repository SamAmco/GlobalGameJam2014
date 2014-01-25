using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    public Camera playerCamera;

    private bool isPOV = false;
    private Transform cameraTransform;

    public void startCameraPOV(Transform otherCameraTransform)
    {
        isPOV = true;
        cameraTransform = otherCameraTransform;
    }

    public void endCameraPOV()
    {
        isPOV = false;
        cameraTransform = null;

        playerCamera.transform.localPosition = Vector3.zero;
        playerCamera.transform.localRotation = Quaternion.identity;
    }

    void Update()
    {
        if (isPOV)
        {
            playerCamera.transform.position = cameraTransform.position;
            playerCamera.transform.rotation = cameraTransform.rotation;
        }
    }
}