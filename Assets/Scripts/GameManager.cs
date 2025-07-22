using UnityEngine.UI;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targetPrefabs;
    public bool isGameActive;
    private float spawnRate = 1f;

    private int score;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    public GameObject titleScreen;

    /// <summary>
    /// Takes an int difficultyLevel and sets the spawn rate based on the difficulty level.
    /// Initializes the game state, score, and starts the target spawning coroutine.
    /// Disables the title screen UI.
    /// </summary>

    public void StartGame(int difficultyLevel)
    {
        spawnRate /= difficultyLevel;
        isGameActive = true;
        score = 0;
        StartCoroutine(SpawnTarget());
        UpdateScore(0);
        titleScreen.gameObject.SetActive(false);
    }


    /// <summary>
    /// While loop that spawns targets 
    /// picks a random target prefab from the list
    /// uses a coroutine to wait for a specified spawn rate
    /// </summary>

    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {

            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targetPrefabs.Count);
            Instantiate(targetPrefabs[index]);

        }
    }
    /// <summary>
    /// Adds the scoreToAdd to the current score
    /// Displays the updated score in the scoreText UI element
    /// </summary>

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }
    /// <summary>
    /// Stops the game, sets isGameActive to false
    /// Displays the game over text and restart button
    /// </summary>
    public void GameOver()
    {
        isGameActive = false;
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }
    /// <summary>
    /// Restarts the game by reloading the current scene
    /// The restart button calls this method and was assigned in the inspector
    /// </summary>
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
