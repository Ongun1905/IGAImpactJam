using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperJump : MonoBehaviour
{
    private PlayerController script;

    void OnTriggerEnter2D(Collider2D collider)
    {
        // Give Temporary Jumppower
        StartCoroutine(Power(collider.gameObject));

        // Disable Powerball
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }

    IEnumerator Power(GameObject obj)
    {
        script = obj.GetComponent(typeof(PlayerController)) as PlayerController;

        if (script != null){
            script.jumpHeight *= 5;
            yield return new WaitForSeconds(3);
            script.jumpHeight /= 5;
        }
    }
}
