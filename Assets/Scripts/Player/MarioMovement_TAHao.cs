using UnityEngine.SceneManagement;
using UnityEngine;


public class MarioMovement_TAHao : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private GameObject gameOverPanel;

    private Rigidbody2D rb;
    private Animator animator;
    private bool isGrounded;
    private float moveInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(moveInput * moveSpeed * Time.deltaTime * 50, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false;
        }

        animator.SetBool("Idle", moveInput == 0 && isGrounded);
        animator.SetBool("Run", moveInput != 0 && isGrounded);
        animator.SetBool("Jump", !isGrounded);

        if (moveInput != 0)
        {
            transform.localScale = new Vector3(moveInput > 0 ? 1 : -1, 1, 1);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground_TAHao"))
        {
            isGrounded = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemies_TAHao"))
        {
            ShowGameOver_TAHao();
        }
        else if (collision.CompareTag("Pipe_TAHao"))
        {
            SceneManager.LoadScene(1);
        }
    }

    private void ShowGameOver_TAHao()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }
}