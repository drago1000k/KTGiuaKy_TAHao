using UnityEngine;

public class Goomba_TAHao : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 4f;
    [SerializeField] private float changeDirectionTime = 2f;

    private Rigidbody2D rb;
    private bool movingRight = true;
    private float timer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        timer = changeDirectionTime;
    }

    void Update()
    {
        rb.velocity = new Vector2((movingRight ? 1 : -1) * moveSpeed * Time.deltaTime * 50, rb.velocity.y);

        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            movingRight = !movingRight;
            transform.localScale = new Vector3(movingRight ? 1 : -1, 1, 1);
            timer = changeDirectionTime;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground_TAHao"))
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
        }
    }
}