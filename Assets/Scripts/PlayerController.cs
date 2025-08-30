using Fusion;
using Fusion.Addons.Physics;
using UnityEngine;
using UnityEngine.Windows;


public class PlayerController : NetworkBehaviour
{
    public float Speed;
    
    private NetworkRigidbody2D rb;
    private Vector2 lastTargetY;

    public override void Spawned()
    {
        rb = GetComponent<NetworkRigidbody2D>();
        if (Object.HasInputAuthority) // or some condition
        {
            Runner.SetIsSimulated(Object, true);
        }
    }

    public override void FixedUpdateNetwork()
    {
        if (GetInput(out NetworkInputData data) && data.HasInput)
        {
            lastTargetY = new Vector2(rb.Rigidbody.position.x, data.position.y);

            float diffY = lastTargetY.y - rb.Rigidbody.position.y;

            if (Mathf.Abs(diffY) > 0.01f)
            {
                float dir = Mathf.Sign(diffY);
                rb.Rigidbody.linearVelocity = new Vector2(0, dir * Speed);
            }
            else
            {
                rb.Rigidbody.linearVelocity = Vector2.zero;
                rb.Rigidbody.position = lastTargetY; // snap to target Y
            }
        }
        else
        {
            rb.Rigidbody.linearVelocity = Vector2.zero;
        }
    }
}



