using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLevel : MonoBehaviour
{
    public GameObject movingPlatform;
    public GameObject movingPlatformWide;
    public GameObject platform;
    public GameObject widePlatform;
    public GameObject LeftPipe;
    public GameObject RightPipe;
    public Transform power;
    public float minX;
    public float maxX;
    public float maxDifference;
    public float yOffest;
    public float yBoxOffset = 3.0f;

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
        var ranges = new (float start, float end)[] { (-1.0f, 1.0f) };
        for (int i = 0; i < 30; i++)
        {
            var rando = Random.Range(0, 8);
            var isWide = Random.Range(0.0f, 1.0f) > 0.5f;

            var newPlatform = GameObject.Instantiate(getPlatform(rando < 3, isWide), transform);

            var rangeIndex = Random.Range(0, ranges.Length);
            var newX = Random.Range(Mathf.Max(minX, previousX - maxDifference),
                    Mathf.Min(maxX, previousX + maxDifference));
            newPlatform.transform.position = new Vector3(
                newX, i * yOffest, 0);
            previousX = newX;


            if (rando == 0)
            {
                newPlatform.AddComponent<SideMovement>();

            }
            else if (rando == 1)
            {
                newPlatform.AddComponent<UpMovement>();
            }
            else if (rando == 2)
            {
                newPlatform.AddComponent<Crumbling>();
            }
            else if (rando == 3){
                Vector3 pos = newPlatform.transform.position;
                pos.y += 1.0f;
                Transform obj = GameObject.Instantiate(power, pos, transform.rotation);
                obj.parent = newPlatform.transform;
            }


            if (isWide)
            {
                ranges = new[] {
                    (newX - maxDifference - 3, newX - 3),
                    (newX + 2, newX + maxDifference + 2)
                };
            }
            else
            {
                ranges = new[] {
                    (newX - maxDifference - 2, newX - 2),
                    (newX + 1, newX + maxDifference + 1)
                };
            }
        }

        for (int i = 0; i < 10; i++)
        {
            float sidenumber = Random.Range(-1f, 1f);
            if (sidenumber > 0)
            {
                var NewRightPipe = GameObject.Instantiate(RightPipe, new Vector3(-20.0F, (i+2)*10, 0), Quaternion.identity);
            }
            else {
                var newLeftPipe = GameObject.Instantiate(LeftPipe, new Vector3(20.0F, (i+1)*10, 0), Quaternion.identity);

            }
        }  
    }
}
