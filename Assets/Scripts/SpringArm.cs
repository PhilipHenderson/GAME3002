using UnityEngine;

public class SpringArm : MonoBehaviour
{
    public Transform target; // The player or the object the camera is following
    public Vector3 offset; // The desired offset from the player
    public float damping = 5.0f; // Control the smoothness of the camera's movement

    void LateUpdate()
    {
        // Calculate the desired position based on player's position and the offset
        Vector3 desiredPosition = target.position + offset;
        // Smoothly interpolate from current position to the desired position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, damping * Time.deltaTime);
        // Apply the smoothed position to the spring arm
        transform.position = smoothedPosition;

        // Optionally look at the player, you can adjust if needed
        transform.LookAt(target.position);
    }
}
