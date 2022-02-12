using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int speed;
    public int jumpHeight;
    public LayerMask whatIsGround;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Jump");
        transform.Translate(horizontal * speed * Time.deltaTime, 0, 0);

        if (!IsGrounded())
        {
            //Do nothing
            
        } else
        {
            transform.Translate(0, vertical * jumpHeight * Time.deltaTime, 0);
        }
        
    }

    bool IsGrounded()
    {
        return Physics2D.Raycast(transform.position, Vector2.down, 1, whatIsGround);
    }

    private void OnDrawGizmos()
    {
        Debug.DrawRay(transform.position, Vector2.down, Color.green, 1);
    }
}
