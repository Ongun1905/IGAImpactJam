using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaterRisingController : MonoBehaviour
{
	[SerializeField] private float speed = 3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0,speed*Time.deltaTime,0) * Time.deltaTime);
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
