using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float rotateSpeed = 60.0f;

    public Joystick joystick; // Reference to your Joystick script

    private Rigidbody tankRigidbody;

    private void Awake()
    {
        tankRigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Get the direction from the joystick
        Vector2 joystickInput = joystick.Direction;

        // Calculate movement based on joystick input
        float verticalInput = joystickInput.y;
        float horizontalInput = joystickInput.x;

        Vector3 movement = transform.forward * verticalInput * moveSpeed * Time.deltaTime;
        Quaternion rotation = Quaternion.Euler(Vector3.up * horizontalInput * rotateSpeed * Time.deltaTime);

        // Apply movement and rotation to the Rigidbody
        tankRigidbody.MovePosition(tankRigidbody.position + movement);
        tankRigidbody.MoveRotation(tankRigidbody.rotation * rotation);
    }
}
