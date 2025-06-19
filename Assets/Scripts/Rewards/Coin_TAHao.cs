using UnityEngine;

public class Coin_TAHao : MonoBehaviour
{
    public int score = 1;
    public int mssv = 3;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            int coinValue = score + mssv;
            GameManager.Instance.AddScore(coinValue);
            Destroy(gameObject);
        }
    }
}
