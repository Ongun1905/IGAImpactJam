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
        velocity.x = horizontal * speed;

        if (IsGrounded() && vertical > 0.0)
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
