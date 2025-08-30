using Fusion;
using Fusion.Addons.Physics;
using UnityEngine;

public class Ball : NetworkBehaviour
{
    [Networked] private Vector2 Direction { get; set; }
    [SerializeField] private float speed = 10f;

    public override void Spawned()
    {
        if (Object.HasStateAuthority) // Only server moves the ball
        {
            // Start with random direction
            Direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-0.5f, 0.5f)).normalized;
        }
    }

    public override void FixedUpdateNetwork()
    {
        if (Object.HasStateAuthority) // Only server moves the ball
        {
            transform.position += (Vector3)(Direction * speed * Runner.DeltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!Object.HasStateAuthority) return;

        Vector2 normal = collision.contacts[0].normal;
        Direction = Vector2.Reflect(Direction, normal).normalized;
        Debug.LogError("Ball collided with " + collision.gameObject.name);
    }

    public void OnNetworkDespawn()
    {
       Runner.Despawn(Object);
    }
}
