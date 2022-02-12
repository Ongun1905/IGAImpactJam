using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLevel : MonoBehaviour
{
    public GameObject platform;
    public GameObject widePlatform;
    public float minX;
    public float maxX;
    public float maxDifference;
    public float yOffest;

    void Start()
    {
        float previousX = 0;
        for (int i=0; i<10; i++)
        {
            var newPlatform = GameObject.Instantiate(Random.Range(0.0f, 1.0f)>0.5f?platform:widePlatform, transform);
            var newX = Random.Range(
                    Mathf.Max(minX, previousX - maxDifference),
                    Mathf.Min(maxX, previousX + maxDifference)
                );
            newPlatform.transform.position = new Vector3(
                newX, i * yOffest, 0);
            previousX = newX;

            var rando = Random.Range(0, 4);
            if (rando == 0){
                newPlatform.AddComponent<SideMovement>();
            } else if (rando == 1){
                newPlatform.AddComponent<UpMovement>();
            }
        }
    }
}
