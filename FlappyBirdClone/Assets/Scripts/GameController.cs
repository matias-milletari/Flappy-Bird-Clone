using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public GameObject gameOverText;
    public bool gameOver;
    public float scrollSpeed = -1.5f;
    public Text scoreText;

    public delegate void ScoreChange(float score);
    public static event ScoreChange OnScoreChanged;

    private int score;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        gameOverText.SetActive(false);

        Bird.OnBirdCollided += GameOver;
        Column.OnColumnPassed += ColumnsPassed;
    }

    private void Update()
    {
        if (gameOver && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void GameOver()
    {
        gameOverText.SetActive(true);
        gameOver = true;
    }

    public void ColumnsPassed()
    {
        if (gameOver)
        {
            return;
        }

        score++;

        if (OnScoreChanged != null) OnScoreChanged(score);
    }
}
