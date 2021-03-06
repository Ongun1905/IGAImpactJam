 using UnityEngine;
 using System.Collections;
 
 public class UpMovement : MovingPlatformBase {
 
    public float delta = 0.5f;  // Amount to move left and right from the start point
    public float speed;
    private Vector3 startPos;
 
     void Start () {
        startPos = transform.position;
        speed = Random.Range(1, 5);
    }
     
     void Update () {
        Vector3 v = startPos;
        transform.position = new Vector3(startPos.x, startPos.y + delta * Mathf.Sin (Time.time * speed), startPos.z);
     }
 }
