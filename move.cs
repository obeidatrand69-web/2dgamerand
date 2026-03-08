using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;
    public bool isground;
    public float jump = 3f;
    private int jumpCount = 0;
    public int maxJumps = 2;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && (isground || jumpCount < maxJumps))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jump);
            jumpCount++;
        }

        float x = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(x * speed, rb.linearVelocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Graund"))
        {
            isground = true;
            jumpCount = 0;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Graund"))
        {
            isground = false;
        }
    }
}