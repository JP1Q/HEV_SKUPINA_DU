using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    private static ScoreManager instance;

    private void Start()
    {
        if (instance != null)
        {
            Destroy(gameObject); // Ensures only one instance of ScoreManager exists
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        // Check if the current scene index is not 0
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            // Initialize the score
            Score.currentScore = 0;

            // Display the score UI
            DisplayScoreUI();
        }
        else
        {
            // Hide the score UI in the first scene
            scoreText.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        // Update the score UI continuously
        DisplayScoreUI();
    }

    // Display the score UI
    private void DisplayScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + Score.currentScore;
        }
    }
}
