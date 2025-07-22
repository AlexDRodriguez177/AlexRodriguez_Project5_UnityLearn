using UnityEngine;
using UnityEngine.UI;
public class ButtonDifficulty : MonoBehaviour
{
    private Button difficultyButton;
    private GameManager gameManager;
    public int difficultyLevel;

    /// <summary>
    /// Finds and stores the GameManager component
    /// Gets the Button component
    /// Depending on the difficulty level, sets the button's onClick listener to call SetDifficulty.
    /// </summary>
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        difficultyButton = GetComponent<Button>();

        difficultyButton.onClick.AddListener(SetDifficulty);
    }


    /// <summary>
    /// Assigsn the difficulty level to the GameManager and starts the game.
    /// </summary>
    void SetDifficulty()
    {
        gameManager.StartGame(difficultyLevel);
    }
}
