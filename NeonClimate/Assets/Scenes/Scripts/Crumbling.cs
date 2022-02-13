using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crumbling : MonoBehaviour
{
    public float crumbleTime = 1.0f;
    public float regenerateTime = 5.0f;
    public float speed = 40.0f;
    public float delta = 0.1f; // amplitude of "shock" animation

    private bool crumbling = false; // whether the "crumbling" timer has started
    private float startTime = 0.0f;
    private bool playerOnTop = false;
    private Vector2 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        playerOnTop = true;
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        playerOnTop = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerOnTop && !crumbling)
        {
            crumbling = true;
            startTime = Time.time;
        }

        if (crumbling)
        {
            var passed = Time.time - startTime;

            if (passed >= crumbleTime + regenerateTime)
            {
                crumbling = false;
                // make visible again
                gameObject.GetComponent<BoxCollider2D>().enabled = true;
                Crumble(true);
            }
            else if (passed >= crumbleTime)
            {
                // make invisible
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                Crumble(false);
            }
            else if (passed < crumbleTime)
            {
                var pos = startPos;
                pos.x = pos.x + delta * Mathf.Sin(Time.time * speed);
                transform.position = pos;
            }
        }
    }

    void Crumble(bool enable)
    {
        foreach(Transform child in transform)
        {
            var renderer = child.gameObject.GetComponent<SpriteRenderer>();
            renderer.enabled = enable;
        }
    }
}
