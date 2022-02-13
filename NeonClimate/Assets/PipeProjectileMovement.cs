using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PipeProjectileMovement : MonoBehaviour
{    
    private float horizontalSpeed ;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private bool isRight;
    // Start is called before the first frame update
    void Start()
    {
        horizontalSpeed = Random.Range(7.5f, 12.0f);
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

    void OnTriggerEnter2D(Collider2D col)
    {
        Scene scene = SceneManager.GetActiveScene();
        if (col.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(scene.name);
            Destroy(col.gameObject);
        }
    }
    }
