using UnityEngine;

public class Move : MonoBehaviour
{
    public Rigidbody rb;
    public Transform BodyPlayer;
    public float MovedForce;
    public float FrigtionForce;
    public float MaxSpeed = 5.0f;
    public float _rotationSpeed;
    public float _xEuler = 90;
    public bool IsGrounded;

    private void FixedUpdate()
    {

        //Moved
        float forwardForce = Input.GetAxis("Horizontal");
        if (forwardForce > 0)
            _xEuler = 90f;
        else if (forwardForce < 0)
            _xEuler = 270f;

        transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(0, _xEuler, 0), _rotationSpeed);

        float speedMultiplier = 1.0f;

        if (!IsGrounded)
        {
            speedMultiplier = 0.7f;
            if (Mathf.Abs(rb.velocity.x) > MaxSpeed && Mathf.Abs(Input.GetAxis("Horizontal")) > 0)
            {
                speedMultiplier = 0;
            }
        }

        rb.AddForce(Input.GetAxis("Horizontal") * MovedForce * speedMultiplier, 0.0f, 0.0f, ForceMode.VelocityChange);

        if (IsGrounded)
        {
            rb.AddForce(-rb.velocity.x * FrigtionForce, 0.0f, 0.0f, ForceMode.VelocityChange);
        }

    }
    private void OnCollisionStay(Collision other)
    {

        if (Vector3.Angle(other.contacts[0].normal, Vector3.up) <= 45.0f)
        {
            IsGrounded = true;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        IsGrounded = false;
    }
}