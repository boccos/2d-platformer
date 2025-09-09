using UnityEngine;

public class BirdPoop : MonoBehaviour
{

    public GameObject player;
    public Transform respawnPoint;


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("BirdPoop"))
        {
            player.transform.position = respawnPoint.position;
        }
    }
}
