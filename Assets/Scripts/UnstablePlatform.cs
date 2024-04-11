using System.Collections;
using UnityEngine;

public class UnstablePlatform : MonoBehaviour
{
    public GameObject[] platformStates; // Assign the models for each state here
    private int stateIndex = 0;
    public float respawnDelay = 5f; // Time before the platform reappears
    private Vector3 originalPosition; // To store the original position
    private Quaternion originalRotation; // To store the original rotation

    private void Start()
    {
        // Store the original position and rotation
        originalPosition = transform.position;
        originalRotation = transform.rotation;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (stateIndex < platformStates.Length)
            {
                ChangePlatformState(stateIndex);
                stateIndex++;
            }

            if (stateIndex == platformStates.Length)
            {
                StartCoroutine(DisableAndRespawnPlatform());
            }
        }
    }

    private void ChangePlatformState(int index)
    {
        // Enable the current state
        platformStates[index].SetActive(true);

        // Disable the previous state if applicable
        if (index > 0)
        {
            platformStates[index - 1].SetActive(false);
        }
    }

    private IEnumerator DisableAndRespawnPlatform()
    {
        // Disable the platform's collider so it can't be interacted with
        GetComponent<Collider>().enabled = false;

        // Optionally disable any other components that should not function while the platform is "destroyed"

        // Wait for the specified respawn delay
        yield return new WaitForSeconds(respawnDelay);

        // Reset the platform state
        stateIndex = 0;
        foreach (var state in platformStates)
        {
            state.SetActive(false);
        }
        platformStates[0].SetActive(true);

        // Reset the platform's position and rotation to the original values
        transform.position = originalPosition;
        transform.rotation = originalRotation;

        // Re-enable the collider
        GetComponent<Collider>().enabled = true;

        // Optionally re-enable any other components you disabled earlier
    }
}
