using UnityEngine;

public class Boundry : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            collision.gameObject.GetComponent<Ball>().OnNetworkDespawn();
            Spawner.Instance.SpawnBall(); // Spawn a new ball when the old one is destroyed
        }
    }
}
