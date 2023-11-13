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
    
    bool moving = false;

    public void Awake()
    {
        //Sets the vector based on the starting position of the object when the project runs
        startPos = transform.position;
        
        //Sets the vectors based on the starting position and uses HalfPathDistance
        //These are used to set boundaries for the moving target
        top = new Vector2 (startPos.x, startPos.y + HalfPathDistance);
        bottom = new Vector2 (startPos.x, startPos.y - HalfPathDistance);
    }

    private void FixedUpdate()
    {
        //Stores the rigidbody of the object the script is attached to
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        //Stores a velocity vector using MovementSpeed for vertical movement
        Vector2 velocity = new Vector2(0, MovementSpeed);
    
        //Checks if the target is at the starting position and sets velocity to move upward
        //Sets moving to true so this statement is skipped in future checks
       if (rb.position == startPos && moving == false)
        {
            rb.velocity = velocity;
            moving = true;
        }
        //Checks if the vertical position is at or above the top boundary and inverses velocity to move downward
        else if (rb.position.y >= top.y)
        {
            rb.velocity = -velocity;
        }
        //Checks if the vertical position is at or below the bottom boundary and sets the velocity to move upward
        else if (rb.position.y <= bottom.y)
        {
            rb.velocity = velocity;
        }
    }
}
