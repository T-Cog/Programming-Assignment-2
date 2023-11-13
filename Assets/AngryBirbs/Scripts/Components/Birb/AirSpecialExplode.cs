using UnityEngine;

public class AirSpecialExplode : MonoBehaviour, IAirSpecial
{
    [Range( 0, 5 )]
    public float BlastRadius = 2;
    public LayerMask targetMask;

    public void ExecuteAirSpecial()
    {
        //Creats a Collider2D array and uses OverlapCircleAll from the object's position within BlastRadius
        //Checks if anything within BlastRadius has a targetMask
        Collider2D[] targetInRange = Physics2D.OverlapCircleAll(transform.position, BlastRadius, targetMask);

        //Checks if there is any objects in the targetInRange array
        if (targetInRange.Length > 0)
        {
            //Stores each collider in the array as target
            //Access the target class of the target object and calls DestroyTarget
            for (int i = 0; i < targetInRange.Length; i++)
            {
                Collider2D target = targetInRange[i];
                target.GetComponent<Target>().DestroyTarget();
            }
        }
    }
}