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
    public float speedDown;
    public float speeds;

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
            rb.velocity = new Vector3(0, speedDown, 0);
            speedMultiplier = 0f;
        }

        rb.AddForce(Input.GetAxis("Horizontal") * MovedForce * speedMultiplier, 0.0f, 0.0f, ForceMode.VelocityChange);

        if (IsGrounded)
        {
            rb.AddForce(-rb.velocity.x * FrigtionForce, 0.0f, 0.0f, ForceMode.VelocityChange);
        }

    }
    private void OnCollisionStay(Collision other)
    {
        
        //if(other.gameObject.name.Equals("l")) 
        //{
        //    Debug.Log("collision");
        //    //rb.AddForce(speeds, 0, 0);
        //}
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