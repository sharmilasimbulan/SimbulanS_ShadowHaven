using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 10f;
    public Transform cameraTransform;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal"); // A/D
        float vertical = Input.GetAxisRaw("Vertical");     // W/S

        Vector3 input = new Vector3(horizontal, 0, vertical).normalized;

        if (input.magnitude >= 0.1f)
        {
            // Get camera-relative direction
            Vector3 camForward = cameraTransform.forward;
            Vector3 camRight = cameraTransform.right;
            camForward.y = 0;
            camRight.y = 0;
            camForward.Normalize();
            camRight.Normalize();

            Vector3 moveDir = camForward * input.z + camRight * input.x;

            // Move
            rb.MovePosition(rb.position + moveDir * moveSpeed * Time.fixedDeltaTime);

            // Rotate
            Quaternion toRotation = Quaternion.LookRotation(moveDir, Vector3.up);
            rb.rotation = Quaternion.Slerp(rb.rotation, toRotation, rotationSpeed * Time.fixedDeltaTime);
        }
    }
}