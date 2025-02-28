using UnityEngine;

[CreateAssetMenu(fileName = "GameManager", menuName = "GameManager", order = 1)]
public class GameManager : ScriptableObject
{
    public bool gameIsPaused;
    public GameObject MainMenu;
    public GameObject Player;
    public int health = 100; // Default health value

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        gameIsPaused = !gameIsPaused;
        if (gameIsPaused)
        {
            Player.SetActive(false);
            MainMenu.SetActive(true);
            Time.timeScale = 0f;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Player.SetActive(true);
            MainMenu.SetActive(false);
            Time.timeScale = 1;
        }
    }
}

