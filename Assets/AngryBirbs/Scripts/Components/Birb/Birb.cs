using UnityEngine;

public class Birb : MonoBehaviour
{
    #region Provided Code, Do Not Edit
    private Rigidbody2D m_rigidbody;

    private bool m_canExecuteAirSpecial = true;
    public bool CanExecuteAirSpecial
    {
        get
        {
            return m_rigidbody.simulated && m_canExecuteAirSpecial;
        }
    }

    private void Awake()
    {
        m_rigidbody = GetComponent<Rigidbody2D>();
        StopBirbSimulation();
    }

    public void StopBirbSimulation()
    {
        m_rigidbody.simulated = false;
    }

    public void StartBirbSimulation()
    {
        m_rigidbody.simulated = true;
    }

    public void SetPosition( Vector3 position )
    {
        if ( m_rigidbody.simulated )
        {
            m_rigidbody.MovePosition( position );
        }
        else
        {
            transform.position = position;
        }
    }

    public void ExecuteAirSpecial()
    {
        GetComponent<IAirSpecial>().ExecuteAirSpecial();
        m_canExecuteAirSpecial = false;
    }

    private void OnCollisionEnter2D( Collision2D collision )
    {
        m_canExecuteAirSpecial = false;
    }

    public static GameObject MakeBirbCopy( GameObject original )
    {
        Birb newBirb = Instantiate(original).GetComponent<Birb>();
        Rigidbody2D rb = newBirb.GetComponent<Rigidbody2D>();
        rb.simulated = true;
        newBirb.m_canExecuteAirSpecial = false;
        return newBirb.gameObject;
    }
    #endregion

    [Range( 0, 25 )]
    public float LaunchForce = 12;

    public void Launch(Vector3 offset, float maximumStretch, Rigidbody2D rigidbody)
    {
        //Offset is diveded by maximumStretch to stop the birb from being pulled anywhere on the screen
        offset = offset / maximumStretch;

        //Adds force using the inverse of offset and launch force using the Impulse method to send it in the opposite direction
        //Impulse is used to "push" the object at its position
        rigidbody.AddForce(-offset * LaunchForce, ForceMode2D.Impulse);
    }

}
