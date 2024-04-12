using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{
    // Assign these in the inspector with the corresponding teleport locations
    public Transform[] teleportLocations;

    private void Update()
    {
        CheckTeleportKeys();
    }

    private void CheckTeleportKeys()
    {
        // Loop through number keys 1 to 9
        for (int i = 0; i < Mathf.Min(teleportLocations.Length, 9); i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + i))
            {
                // Teleport the player to the location corresponding to the number key pressed
                TeleportToLocation(i);
            }
        }
    }

    private void TeleportToLocation(int locationIndex)
    {
        if (locationIndex < teleportLocations.Length)
        {
            // Update the player's position to the teleport location
            transform.position = teleportLocations[locationIndex].position;
            // Optionally reset player velocity if desired
            var rb = GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = Vector3.zero;
            }
        }
    }
}
