using UnityEngine;

public class MysteryBlock_TAHao : MonoBehaviour
{
    public GameObject coinPrefab;
    public Transform spawnPoint;
    private bool used = false;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!used && collision.collider.CompareTag("Player"))
        {
            Vector2 contactPoint = collision.GetContact(0).point;
            bool hitFromBelow = contactPoint.y < transform.position.y;

            if (hitFromBelow)
            {
                Instantiate(coinPrefab, spawnPoint.position, Quaternion.identity);
                used = true;
                
            }
        }
    }
}
