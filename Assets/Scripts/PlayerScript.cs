using UnityEngine;

public class PlayerScript: MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public float airControlFactor = 0.5f; // Factor to reduce movement speed in the air
    public Vector3 startPosition;

    private Rigidbody rb;
    private bool isGrounded;

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
        float controlFactor = isGrounded ? 1f : airControlFactor; // Full control on ground, reduced in air
        Vector3 movement = new Vector3(moveHorizontal * moveSpeed * controlFactor, rb.velocity.y, 0.0f);

        rb.velocity = movement;
    }

    private void Jump()
    {
        rb.AddForce(new Vector3(0f, jumpForce, 0f), ForceMode.Impulse);
        isGrounded = false;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground")) // Ensure your ground has the tag "Ground"
        {
            isGrounded = true;
        }
        if (other.gameObject.CompareTag("Trap"))
        {
            // Teleport the player to the start position
            transform.position = startPosition;
        }
    }
}
