using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private Text scoreText;

    void Awake()
    {
        scoreText = GetComponent<Text>();

        GameController.OnScoreChanged += UpdateScore;
    }

    private void UpdateScore(float score)
    {
        scoreText.text = scoreText.text = "Score: " + score;
    }
}