using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PipeProjectileMovement : MonoBehaviour
{    
    private float horizontalSpeed = -10f ;
    [SerializeField] private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(transform.right * horizontalSpeed, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
