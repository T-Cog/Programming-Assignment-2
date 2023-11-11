using UnityEngine;

public class AirSpecialExplode : MonoBehaviour, IAirSpecial
{
    [Range( 0, 5 )]
    public float BlastRadius = 2;
    public LayerMask targetMask;

    public void ExecuteAirSpecial()
    {
        Collider2D[] targetInRange = Physics2D.OverlapCircleAll(transform.position, BlastRadius, targetMask);

        if (targetInRange.Length > 0)
        {
            for (int i = 0; i < targetInRange.Length; i++)
            {
                Collider2D target = targetInRange[i];
                target.GetComponent<Target>().DestroyTarget();
            }
        }
    }
}