using UnityEngine;

public class DoorController : MonoBehaviour
{
    public int doorID;
    private Rigidbody doorRigidbody;
    public bool isUnlocked = false;
    PlayerScript playerScript;

    private void Start()
    {
        playerScript =  FindAnyObjectByType<PlayerScript>();
        doorRigidbody = GetComponent<Rigidbody>();
        doorRigidbody.constraints = RigidbodyConstraints.FreezeRotation;
    }

    private void Update()
    {
        if (playerScript.keysCollected >= doorID)
        {
            UnlockDoor();
        }
    }

    private void UnlockDoor()
    {
        doorRigidbody.constraints &= ~RigidbodyConstraints.FreezeRotation; // Unfreeze the rotation
        isUnlocked = true;
        Debug.Log($"Door {doorID} unlocked!");
    }
}
