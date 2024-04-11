using UnityEngine;

public class SpinningTrap : MonoBehaviour
{
    public float torque = 10f; // The amount of torque to apply for spinning
    public Vector3 spinAxis = Vector3.up; // The axis on which the object will spin. Default is up (y-axis)

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Apply a constant torque to spin the trap
        rb.AddTorque(spinAxis * torque, ForceMode.Force);
    }
}
