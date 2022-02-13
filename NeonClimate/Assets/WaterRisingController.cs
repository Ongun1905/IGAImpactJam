using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
