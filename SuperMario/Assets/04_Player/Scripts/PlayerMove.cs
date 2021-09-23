using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 1.0f;
    public float upForce = 1.0f;

    private Transform playerTransform;
    private Rigidbody2D playerRigidbody2D;
    private RaycastHit2D ray2D;

    private float vertical;
    private float horizontal;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        // Gizmos.DrawLine(playerTransform.position, new Vector2(0.0f, 1.0f));
    }

    private void Start()
    {
        playerTransform = GetComponent<Transform>();
        playerRigidbody2D = GetComponent<Rigidbody2D>();
        ray2D = GetComponent<RaycastHit2D>();
    }

    private void Update()
    {
        Vector2 move = Vector2.zero;

        if (Input.GetKey(KeyCode.D))
        {
            move = Vector2.right;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            move = Vector2.left;
        }

        // Ray가 floor에 닿아있는 상태에서 키 입력 시
        if(Input.GetKeyDown(KeyCode.W))
        {
            playerRigidbody2D.AddForce(Vector2.up * upForce);
            // move += Vector2.up * upForce;
        }

        playerTransform.Translate(move.normalized * speed * Time.deltaTime, Space.Self);
    }
}
