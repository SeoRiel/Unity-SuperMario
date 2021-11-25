using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 1.0f;
    public float upForce = 1.0f;

    private int jumpCount = 1;

    private Vector2 move;

    private Transform playerTransform;
    private Rigidbody2D playerRigidbody2D;

    private void Start()
    {
        playerTransform = GetComponent<Transform>();
        playerRigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        move = Vector2.zero;

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
        {
            move = Vector2.right;

            if (Input.GetKey(KeyCode.D) && (transform.eulerAngles.y == 180.0f))
            {
                transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
            }
            else if (Input.GetKey(KeyCode.A) && (transform.eulerAngles.y == 0.0f))
            {
                transform.rotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);
            }
        }

        if (Input.GetKeyDown(KeyCode.W) && jumpCount > 0)
        {
            playerRigidbody2D.AddForce(Vector2.up * upForce);
            jumpCount--;
        }

        transform.Translate(move.normalized * speed * Time.deltaTime, Space.Self);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision != null && jumpCount == 0)
        {
            jumpCount = 1;
        }
    }
}