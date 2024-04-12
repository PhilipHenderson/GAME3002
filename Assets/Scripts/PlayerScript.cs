using System;
using System.Collections;
using UnityEngine;

public class PlayerScript: MonoBehaviour
{
    [Header("Starter Properties")]
    public Vector3 startPosition;

    [Header("Movement Properties")]
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public float airControlFactor = 0.5f;
    private bool isGrounded;

    [Header("SpeedZone Properties")]
    public int velocityMultiplier;
    public int velocityMultipliyerDuration;
    public bool SpedUp;
    public bool SlowedDown;


    [Header("Key Collection")]
    public int keysCollected = 0;
    public static event Action<int> OnKeysCollectedChanged; 

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionZ;
    }

    private void Update()
    {
        MovePlayer();
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }
    }

    private void MovePlayer()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float controlFactor = isGrounded ? 1f : airControlFactor;
        Vector3 movement = new Vector3(moveHorizontal * moveSpeed * controlFactor, rb.velocity.y, 0.0f);

        rb.velocity = movement;
    }

    private void Jump()
    {
        rb.AddForce(new Vector3(0f, jumpForce, 0f), ForceMode.Impulse);
        isGrounded = false;
    }

    public void CollectKey()
    {
        keysCollected++;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        if (other.gameObject.CompareTag("Trap"))
        {
            transform.position = startPosition;
        }
        if (other.gameObject.CompareTag("Key"))
        {
            CollectKey();
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("SpeedZone"))
        {
            StartCoroutine(ApplySpeedBoost());
        }
        if (other.gameObject.CompareTag("SlowZone"))
        {
            StartCoroutine(ApplySlowBoost());
        }
    }

    private IEnumerator ApplySpeedBoost()
    {
        float originalSpeed = moveSpeed;
        moveSpeed *= velocityMultiplier; 
        SpedUp = true;

        yield return new WaitForSeconds(velocityMultipliyerDuration);

        moveSpeed = originalSpeed;
        SpedUp = false;
    }

    private IEnumerator ApplySlowBoost()
    {
        float originalSpeed = moveSpeed;
        moveSpeed /= velocityMultiplier;
        SpedUp = true;

        yield return new WaitForSeconds(velocityMultipliyerDuration);

        moveSpeed = originalSpeed;
        SpedUp = false;
    }
}
