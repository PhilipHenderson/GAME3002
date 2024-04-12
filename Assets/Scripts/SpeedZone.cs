using System.Collections;
using UnityEngine;

public class SpeedZone : MonoBehaviour
{
    public float speedMultiplier = 2f; // The factor by which the player's speed is multiplied
    public float speedDuration = 5f; // How long the speed boost lasts

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerScript playerScript = other.GetComponent<PlayerScript>();
            if (playerScript != null)
            {
                StartCoroutine(ApplySpeedBoost(playerScript));
            }
        }
    }

    private IEnumerator ApplySpeedBoost(PlayerScript playerScript)
    {
        float originalSpeed = playerScript.moveSpeed;
        playerScript.moveSpeed *= speedMultiplier; // Increase the speed

        yield return new WaitForSeconds(speedDuration); // Wait for the duration of the speed boost

        playerScript.moveSpeed = originalSpeed; // Reset the speed to original
    }
}
