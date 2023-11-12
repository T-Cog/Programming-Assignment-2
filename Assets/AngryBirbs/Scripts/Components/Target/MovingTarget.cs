using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTarget : MonoBehaviour
{
    [Range( 0, 5 )]
    public float HalfPathDistance = 3;
    [Range( 0, 5 )]
    public float MovementSpeed = 2;

    Vector3 startPos;
    Vector3 top;
    Vector3 bottom;

    public void Awake()
    {
        startPos = transform.position;
        top = new Vector3 (startPos.x, startPos.y + HalfPathDistance);
        bottom = new Vector3(startPos.x, startPos.y - HalfPathDistance);
    }

    private void FixedUpdate()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        Vector2 velocity = new Vector2(0, MovementSpeed);
        
       if (transform.position == startPos)
        {
            rb.velocity = velocity;    
        }
        else if (transform.position.y >= top.y)
        {
            rb.velocity = -velocity;
        }
        else if (transform.position.y <= bottom.y)
        {
            rb.velocity = velocity;
        }
    }
}
