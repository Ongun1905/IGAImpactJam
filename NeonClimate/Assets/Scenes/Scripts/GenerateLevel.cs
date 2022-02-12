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
    public float yBoxOffset = 2.0f;

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

            var rando = Random.Range(0, 4);

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
