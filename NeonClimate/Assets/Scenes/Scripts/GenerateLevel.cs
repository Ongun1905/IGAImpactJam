using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLevel : MonoBehaviour
{
    public GameObject movingPlatform;
    public GameObject movingPlatformWide;
    public GameObject platform;
    public GameObject widePlatform;
    public float minX;
    public float maxX;
    public float maxDifference;
    public float yOffest;
    public float yBoxOffset = 2.0f;

    GameObject getPlatform(bool moving, bool wide)
    {
        if (moving && wide)
        {
            return movingPlatformWide;
        } else if (moving && !wide) {
            return movingPlatform;
        } else if (!moving && wide)
        {
            return widePlatform;
        } else if (!moving && !wide)
        {
            return platform;
        }
        return platform;
    }

    void Start()
    {
        float previousX = 0;
        for (int i=0; i<10; i++)
        {
            var rando = Random.Range(0, 8);

            var newPlatform = GameObject.Instantiate(getPlatform(rando<3, Random.Range(0.0f, 1.0f)>0.5f), transform);
            var newX = Random.Range(
                    Mathf.Max(minX, previousX - maxDifference),
                    Mathf.Min(maxX, previousX + maxDifference)
                );
            newPlatform.transform.position = new Vector3(
                newX, i * yOffest, 0);
            previousX = newX;


            if (rando == 0) {
                newPlatform.AddComponent<SideMovement>();
            } else if (rando == 1) {
                newPlatform.AddComponent<UpMovement>();
            } else if (rando == 2) {
                newPlatform.AddComponent<Crumbling>();
            }
        }
    }
}
