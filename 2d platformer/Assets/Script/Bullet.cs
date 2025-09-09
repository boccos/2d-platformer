using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collided with: " + collision.gameObject.name);
        Debug.Log("Layer: " + collision.gameObject.layer);

        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("OneWayPlatform") || collision.gameObject.CompareTag("Teleporter"))
        {
            Debug.Log("Destroying object");
            Destroy(gameObject);
        }
    }
}

