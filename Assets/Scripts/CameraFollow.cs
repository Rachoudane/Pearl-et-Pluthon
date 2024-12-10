using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // The object (e.g., character) that the camera should follow
    public Transform target;

    // How smoothly the camera should follow the target
    public float smoothSpeed = 0.125f;

    // Offset to adjust the camera's position relative to the target
    public Vector3 offset;

    // Used to store the velocity of the camera for the SmoothDamp function
    private Vector3 velocity = Vector3.zero;

    // Called after all Update calls, ideal for camera adjustments
    void LateUpdate()
    {
        // Only follow if a target is assigned
        if (target != null)
        {
            // Calculate the desired position of the camera based on the target's position and offset
            Vector3 desiredPosition = target.position + offset;

            // Ensure the camera's z-position remains fixed at -10
            desiredPosition.z = -10f;

            // Smoothly transition the camera to the desired position
            Vector3 smoothedPosition = Vector3.SmoothDamp(
                transform.position,    // Current position of the camera
                desiredPosition,       // Target position
                ref velocity,          // Reference to the velocity for smoothing
                smoothSpeed            // Time it takes to reach the target
            );

            // Update the camera's position to the smoothed position
            transform.position = smoothedPosition;
        }
    }
}
