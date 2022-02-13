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
    void FixedUpdate()
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
            velocity.x += horizontal * speed / 16;
            if (velocity.x < -speed)
            {
                velocity.x = -speed;
            }
            else if (velocity.x > speed)
            {
                velocity.x = speed;
            }
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
<<<<<<< Updated upstream
        Debug.DrawRay(transform.position, Vector2.down, Color.green, 1);
=======
        //Debug.DrawRay(transform.position, Vector2.down, Color.green, 1);
    }

    public void Dash()
    {
        
        if(Input.GetKeyDown(KeyCode.LeftShift) && !hasDashed)
        {
            Vector2 velocity = rb2d.velocity;
            rb2d.velocity = new Vector2(rb2d.velocity.x * dashSpeed, rb2d.velocity.y);
            hasDashed = true;
        }
        else if(IsGrounded())
        {
            hasDashed = false;
        }
    }

    public void Flip()
    {
        if(Input.GetAxisRaw("Horizontal") > 0)
        {
            renderer.flipX = false;
        }
        else if (Input.GetAxisRaw("Horizontal") < 0) 
        {
            renderer.flipX = true;
        }
    }

    public void Movement()
    {
        float horizontal = Input.GetAxis("Horizontal");

        Vector2 velocity = rb2d.velocity;
        bool grounded = IsGrounded();
        if (grounded)
        {
            velocity.x = horizontal * speed;
        }
        else
        {
            velocity.x += horizontal * speed / 16;
        }
        rb2d.velocity = velocity;
    }

    public void Jump()
    {


        Vector2 velocity = rb2d.velocity;
        bool grounded = IsGrounded();
        float vertical = Input.GetAxis("Jump");
        if (grounded && vertical > 0.0)
        {
           velocity.y = jumpHeight;

        }
        rb2d.velocity = velocity;
>>>>>>> Stashed changes
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Check to see if the tag on the collider is equal to Enemy
        if (other.gameObject.tag == "ToxicWater")
        {
            Debug.Log("Triggered by Enemy");
        }
    }

}
