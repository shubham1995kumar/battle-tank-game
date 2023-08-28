using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;           // Reference to the tank's transform.
    public float smoothSpeed = 0.125f; // Controls the smoothness of camera movement.
    public Vector3 offset;             // Offset between the camera and the tank.

    private void LateUpdate()
    {
        if (target == null)
            return;

        // Calculate the desired position for the camera.
        Vector3 desiredPosition = target.position + offset;

        // Smoothly interpolate between the current camera position and the desired position.
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Update the camera's position.
        transform.position = smoothedPosition;

        // Make the camera look at the tank's position.
        transform.LookAt(target);
    }
}
