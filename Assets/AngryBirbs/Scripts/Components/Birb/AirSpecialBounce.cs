using UnityEngine;

public class AirSpecialBounce : MonoBehaviour, IAirSpecial
{
    [Range( 0, 1 )]
    public float SlowDownFactor = 1;

    public void ExecuteAirSpecial()
    {
        //Gets the rigidbody 2D from the game object and stores it's velocity
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        Vector2 currentVelocity= rb.velocity;

        //Checks if the object is moving downward
        if (currentVelocity.y <= 0)
        {
            //Sets the velocity upward and modifies it by SlowDownFactor while keeping forward velocity
            Vector2 newVelocity = new Vector2(currentVelocity.x, -currentVelocity.y * SlowDownFactor);

            //Sets the new impulse based on current and new velocity
            Vector2 impulse = newVelocity - currentVelocity;
            
            //Adds force to the object at its current position
            rb.AddForce(impulse, ForceMode2D.Impulse);
        }
    }
}
