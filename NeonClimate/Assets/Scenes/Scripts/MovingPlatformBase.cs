using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformBase : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col)
    {
        col.gameObject.transform.SetParent(gameObject.transform, true);
    }

    void OnCollisionExit2D(Collision2D col)
    {
        col.gameObject.transform.parent = null;
    }
}
