using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector3 velocity;
    public float speed;
    public int jumpHeight;
    public LayerMask whatIsGround;
    private Rigidbody2D rigidbody;
    private float lastGroundedVelocity;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = transform.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Jump");

        var velocity = rigidbody.velocity;
        var grounded = IsGrounded();
        if (grounded)
        {
            velocity.x = horizontal * speed;
            lastGroundedVelocity = velocity.x;
        } else
        {
            velocity.x = lastGroundedVelocity / 2 + horizontal * speed / 2;
        }

        if (grounded && vertical > 0.0)
        {
            velocity.y = jumpHeight;
        }

        rigidbody.velocity = velocity;
    }

    bool IsGrounded()
    {
        return Physics2D.Raycast(transform.position, Vector2.down, 0.51f, whatIsGround);
    }

    private void OnDrawGizmos()
    {
        Debug.DrawRay(transform.position, Vector2.down, Color.green, 1);
    }
}
