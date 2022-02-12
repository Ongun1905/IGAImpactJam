using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLevel : MonoBehaviour
{
    public GameObject platform;
    public float minX;
    public float maxX;
    public float maxDifference;
    public float yOffest;
    // Start is called before the first frame update
    void Start()
    {
        float previousX = 0;
        for (int i=0; i<10; i++)
        {
            var newPlatform = GameObject.Instantiate(platform, transform);
            var newX = Random.Range(
                    Mathf.Max(minX, previousX - maxDifference),
                    Mathf.Min(maxX, previousX + maxDifference)
                );
            newPlatform.transform.position = new Vector3(
                newX, i * yOffest, 0);
            previousX = newX;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
