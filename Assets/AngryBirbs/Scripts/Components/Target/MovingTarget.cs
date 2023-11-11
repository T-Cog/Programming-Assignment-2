using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTarget : MonoBehaviour
{
    [Range( 0, 5 )]
    public float HalfPathDistance = 3;
    [Range( 0, 5 )]
    public float MovementSpeed = 2;

    Vector2 startPos;
    Vector2 top;
    Vector2 bottom;

    public void Start()
    {
        startPos = transform.position;
        top = new Vector2 (transform.position.x, transform.position.y + HalfPathDistance);
        bottom = new Vector2(transform.position.x, transform.position.y - HalfPathDistance);
    }

    private void FixedUpdate()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        Vector2 velocity = new Vector2(0, MovementSpeed);
        
        if (rb.position == startPos)
        {
            rb.velocity = velocity;    
        }
        if (rb.position == top)
        {
            rb.velocity = -velocity;
        }
        if (rb.position == bottom)
        {
            rb.velocity = velocity;
        }
    }
}
