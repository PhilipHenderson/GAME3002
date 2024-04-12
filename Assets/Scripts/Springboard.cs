using UnityEngine;

public class Springboard : MonoBehaviour
{
    public float launchForce = 20f; // The force that will be applied to launch the player

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody playerRigidbody = other.GetComponent<Rigidbody>();
            if (playerRigidbody != null)
            {
                // Apply an upward force to the player's Rigidbody
                playerRigidbody.AddForce(Vector3.up * launchForce, ForceMode.VelocityChange);
            }
        }
    }
}
