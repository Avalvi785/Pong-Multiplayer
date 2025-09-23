using Fusion;
using System.Linq;
using UnityEngine;

public class Spawner : NetworkBehaviour, IPlayerJoined
{
    public GameObject PlayerPrefab;
    public GameObject Ball;
    public Vector3[] spawnPositions;

    public override void Spawned()
    {
        int index = Runner.LocalPlayer.RawEncoded % spawnPositions.Length;
        Runner.Spawn(PlayerPrefab, spawnPositions[index], Quaternion.identity, Runner.LocalPlayer);
    }

    public void SpawnBall()
    {
        if (HasStateAuthority == false)
            return;

        Runner.Spawn(Ball, Vector3.zero, Quaternion.identity);
    }

    public void PlayerJoined(PlayerRef player)
    {
        if (Runner.ActivePlayers.Count() >= 2)
            SpawnBall();
    }
}

