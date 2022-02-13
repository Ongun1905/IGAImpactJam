using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector3 velocity;

    public float speed;

    public float jumpHeight;
    public int dashSpeed;
    private bool hasDashed = false;
	private float lastImageXpos;
	[SerializeField] private float distanceBetweenImages = 1f;
   
    private Rigidbody2D rb2d;

    public LayerMask whatIsGround;

    private new SpriteRenderer renderer;

    public bool hasPressedJump = false;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        renderer = GetComponent<SpriteRenderer>();
    }
	
	void Update()
	{
		Dash();
		CheckDash();
	}

    // Update is called once per frame
    void FixedUpdate()
    {
		
    }

    public bool IsGrounded()
    {
        return Physics2D.Raycast(transform.position, Vector2.down, 1.5f, whatIsGround);
    }

    private void OnDrawGizmos()
    {
        Debug.DrawRay(transform.position, Vector2.down, Color.green, 2);
    }

    public void Movement()
    {
        Debug.Log("move");
        float horizontal = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(horizontal, 0);
        rb2d.velocity = new Vector2(movement.x * speed, rb2d.velocity.y);
        rb2d.MovePosition(rb2d.position + rb2d.velocity * Time.fixedDeltaTime);

    }

    public void Dash()
    {
        
        if(Input.GetKeyDown(KeyCode.LeftShift) && !hasDashed)
        {
            Vector2 velocity = rb2d.velocity;
            rb2d.velocity = new Vector2(rb2d.velocity.x * dashSpeed, rb2d.velocity.y);
            hasDashed = true;
			
			PlayerAfterImagePool.Instance.GetFromPool();
			lastImageXpos = transform.position.x;
        }
        else if(IsGrounded())
        {
            hasDashed = false;
        }
    }
	
	private void CheckDash()
	{
		if (hasDashed)
		{
			if (Mathf.Abs(transform.position.x - lastImageXpos) > distanceBetweenImages)
			{
				PlayerAfterImagePool.Instance.GetFromPool();
				lastImageXpos = transform.position.x;
			}
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

  

    public void Jump()
    {
        Vector2 playerPos = Vector2.up;
        rb2d.AddForce(playerPos*jumpHeight, ForceMode2D.Impulse);
    }

    
}
