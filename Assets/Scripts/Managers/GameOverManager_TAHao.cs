using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverManager_TAHao : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private Button restartButton;
    [SerializeField] private Button quitButton;

    private void Start()
    {
        gameOverPanel.SetActive(false);
        restartButton.onClick.AddListener(ReloadScene_TAHao);
        quitButton.onClick.AddListener(QuitGame_TAHao);
    }

    private void ShowGameOver_TAHao()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0; 
    }

    private void ReloadScene_TAHao()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0); 
    }

    private void QuitGame_TAHao()
    {
        Application.Quit();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            ShowGameOver_TAHao();
            
        }
    }
}