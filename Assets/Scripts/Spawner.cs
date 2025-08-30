using Fusion;
using UnityEngine;

public class Spawner : NetworkBehaviour
{
    [SerializeField] private GameObject Ball;

    // make instance of this
    public static Spawner Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public void SpawnBall()
    {
        if (Object.HasStateAuthority)
        {
            Runner.Spawn(Ball, Vector3.zero, Quaternion.identity);
        }
    }
}
