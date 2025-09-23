using UnityEngine;

public class Boundry : MonoBehaviour
{
    public Spawner spawner;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
           // collision.gameObject.GetComponent<Ball>().OnNetworkDespawn();
           // spawner.SpawnBall(); // Spawn a new ball when the old one is destroyed
        }
    }
}
