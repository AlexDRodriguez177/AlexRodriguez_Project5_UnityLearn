using UnityEngine;
using UnityEngine.UI;
public class ButtonDifficulty : MonoBehaviour
{
    private Button difficultyButton;
    private GameManager gameManager;
    public int difficultyLevel;

    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        difficultyButton = GetComponent<Button>();

        difficultyButton.onClick.AddListener(SetDifficulty);
    }

   

    void SetDifficulty()
    {
        gameManager.StartGame(difficultyLevel);
    }
}
