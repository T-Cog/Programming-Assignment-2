using UnityEngine;

public class AirSpecialSplit : MonoBehaviour, IAirSpecial
{
    public float SplitAngleInDegrees = 10;

    public void ExecuteAirSpecial()
    {
        //Creates new birb GameObjects using MakeBirbCopy method
        GameObject topBirb = Birb.MakeBirbCopy(gameObject);
        GameObject bottomBirb = Birb.MakeBirbCopy(gameObject);

        //Gets and stores the rigidbodies of each birb
        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
        Rigidbody2D rigidbodyBirdUp = topBirb.GetComponent<Rigidbody2D>();
        Rigidbody2D rigidbodyBirdDown = bottomBirb.GetComponent<Rigidbody2D>();

        //Sets the simulated variable of rigidbodies to true
        //This allows the forces and rotations to have effect
        rigidbodyBirdUp.simulated = true;
        rigidbodyBirdDown.simulated = true;

        //Rotates the birds based on SplitAngleInDegress, using the original velocity to maintain the same speed
        Vector2 originalVelocity = rigidbody.velocity;
        Vector2 velocityUp = RotateVector2D(SplitAngleInDegrees, originalVelocity);
        Vector2 velocityDown = RotateVector2D(-SplitAngleInDegrees, originalVelocity);

        //Adds appropriate velocity as impulse to send birb copies in the appropriate direction
        rigidbodyBirdUp.AddForce(velocityUp, ForceMode2D.Impulse);
        rigidbodyBirdDown.AddForce(velocityDown, ForceMode2D.Impulse);

    }

    Vector3 RotateVector2D(float angle, Vector3 v)
    {
        Quaternion rotation = Quaternion.Euler(0, 0, angle);
        Matrix4x4 m = Matrix4x4.Rotate(rotation);
        return m.MultiplyPoint3x4(v);
    }
}
