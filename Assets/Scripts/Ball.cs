using Fusion;
using UnityEngine;

public class Ball : NetworkBehaviour
{
    [SerializeField] private float speed = 10f;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public override void Spawned()
    {
        if (Object.HasStateAuthority) // Only server moves the ball
        {
            Vector2 dir = new Vector2(
            Random.value < 0.5f ? -1 : 1,
            Random.Range(-0.5f, 0.5f)
        ).normalized;

            rb.linearVelocity = dir * speed;
        }
    }

    public void OnNetworkDespawn()
    {
        Runner.Despawn(Object);
    }
}
