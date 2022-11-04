using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    [SerializeField] private float speed;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        rigidbody2D.velocity = new Vector2(Input.GetAxis("Horizontal")* speed,rigidbody2D.velocity.y);

        if (Input.GetKey(KeyCode.Space))
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, speed);
        
    }
}
