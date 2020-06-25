
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    public Transform cameraToLookAt;
    private void Update()
    {
        if (cameraToLookAt == null) cameraToLookAt = Camera.main.transform;
        transform.LookAt(
            transform.position + cameraToLookAt.rotation * Vector3.forward,
            cameraToLookAt.rotation * Vector3.up);
    }
}