using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [Range( 0, 20 )]
    public float MinimumBreakSpeed = 10;

    private void OnCollisionEnter2D( Collision2D collision )
    {   
        //Checks if the velocity of the collided object is moving at or above MinimumBreakSpeed
        //Calls DestroyTarget
        if (collision.relativeVelocity.magnitude >= MinimumBreakSpeed)
        {
            DestroyTarget();
        }
    }

    public void DestroyTarget()
    {
        Destroy( gameObject );
    }
}
