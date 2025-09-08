using Fusion;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : NetworkBehaviour
{
    public float Speed;

    private Vector2 lastTargetY;

    public override void Spawned()
    {
        if (Object.HasInputAuthority) // or some condition
        {
            Runner.SetIsSimulated(Object, true);
        }
    }

    public override void FixedUpdateNetwork()
    {
        if (GetInput(out NetworkInputData data) && data.HasInput)
        {
            lastTargetY = new Vector2(transform.position.x, data.position.y);

            float diffY = lastTargetY.y - transform.position.y;

            if (Mathf.Abs(diffY) > 0.01f)
            {
                float dir = Mathf.Sign(diffY);
                transform.Translate(0, dir * Speed *Runner.DeltaTime, 0);
            }
            else
            {
                transform.position = lastTargetY; // snap to target Y
            }
        }
    }
}



