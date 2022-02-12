using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PipeProjectileMovement : MonoBehaviour
{    
    private float horizontalSpeed ;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private bool isRight;
    // Start is called before the first frame update
    void Start()
    {
        horizontalSpeed = Random.Range(5.0f, 12.0f);
        if (!isRight)
        {
            horizontalSpeed *= -1;
        }
        GetComponent<Rigidbody2D>().AddForce(transform.right * horizontalSpeed, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}
