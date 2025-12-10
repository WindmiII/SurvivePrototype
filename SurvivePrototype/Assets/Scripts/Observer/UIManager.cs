using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text scoreText;
    public GameObject[] hearts;
    public GameObject restartButton;

    void OnEnable()
    {
        GameEvents.OnEnemyKilled += UpdateScore;
        GameEvents.OnPlayerDamaged += UpdateHealth;
        GameEvents.OnGameOver += ShowRestartButton;
    }

    void OnDisable()
    {
        GameEvents.OnEnemyKilled -= UpdateScore;
        GameEvents.OnPlayerDamaged -= UpdateHealth;
        GameEvents.OnGameOver -= ShowRestartButton;
    }

    void UpdateScore(int scoreToAdd)
    {
        GameManager.score += scoreToAdd;
        scoreText.text = "Score: " + GameManager.score;
    }

    void UpdateHealth(int currentHealth)
    {
        if (currentHealth >= 0 && currentHealth < hearts.Length)
        {
            hearts[currentHealth].SetActive(false);
        }
    }

    void ShowRestartButton()
    {
        if (restartButton != null)
        {
            restartButton.SetActive(true);
        }
    }
}