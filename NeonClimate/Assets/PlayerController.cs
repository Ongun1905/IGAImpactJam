using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector3 velocity;

    public float speed;

    public int jumpHeight;
    public int dashSpeed;
    private bool hasDashed = false;
   
    private Rigidbody2D rb2d;

    public LayerMask whatIsGround;

    private new SpriteRenderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = transform.GetComponent<Rigidbody2D>();
        renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Jump");

        Vector2 velocity = rb2d.velocity;
        bool grounded = IsGrounded();
        if (grounded)
        {
            velocity.x = horizontal * speed;
        } else
        {
            velocity.x += horizontal * speed / 16;
            /*
            if (velocity.x < -speed)
            {
                velocity.x = -speed;
            }
            else if (velocity.x > speed)
            {
                velocity.x = speed;
            }
            */
        }

        if (grounded && vertical > 0.0)
        {
            velocity.y = jumpHeight;
        }

        rb2d.velocity = velocity;

        Dash();
        Flip();
    }

    bool IsGrounded()
    {
        return Physics2D.Raycast(transform.position, Vector2.down, 0.51f, whatIsGround);
    }

    private void OnDrawGizmos()
    {
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
    }
}
