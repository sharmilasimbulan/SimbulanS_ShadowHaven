using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float mouseSensitivity = 5f;
    public float distance = 100f;
    public float height = 13f;
    public float lookAtHeight = 31f;

    private float yaw;
    private float pitch;

    void Start()
    {
        // Start the camera facing behind the player
        yaw = -93.899f;
        pitch = 5.284f;
    }


    void LateUpdate()
    {
        if (Input.GetMouseButton(1)) // Right Mouse Button
        {
            yaw += Input.GetAxis("Mouse X") * mouseSensitivity;
            pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity;
            pitch = Mathf.Clamp(pitch, 10f, 60f);
        }

        // Calculate rotation based on mouse
        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0f);

        // Calculate offset from the target with fixed distance and height
        Vector3 offset = rotation * new Vector3(0f, 0f, -distance); // behind player
        Vector3 cameraPosition = target.position + offset + new Vector3(0f, height, 0f);

        transform.position = cameraPosition;
        transform.LookAt(target.position + Vector3.up * lookAtHeight);
    }
}