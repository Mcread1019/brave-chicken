using System.IO;
using UnityEngine;

public class PlayerDataManager : MonoBehaviour
{
    public Transform playerTransform;
    public GameManager gameManager; // Reference to GameManager
    public UI uiManager; // Reference to UI script
    private string savePath;

    private void Start()
    {
        savePath = Application.persistentDataPath + "/playerData.json";
    }

    public void SaveGame()
    {
        PlayerData playerData = new PlayerData
        {
            position = new float[] { playerTransform.position.x, playerTransform.position.y, playerTransform.position.z },
            
        //health = gameManager.health, // Use GameManager's health
        //score = uiManager.GetScore() // Get score from UI
    };

        string json = JsonUtility.ToJson(playerData);
        File.WriteAllText(savePath, json);
        Debug.Log("Game Saved!");
        Debug.Log($"Loaded Position: {playerTransform.position.x})");
        Debug.Log($"Player Position After Loading: {playerTransform.position}");
    }

    public void LoadGame()
    {
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            PlayerData loadedData = JsonUtility.FromJson<PlayerData>(json);

            // Get the player's CharacterController
            CharacterController characterController = playerTransform.GetComponent<CharacterController>();
            if (characterController != null)
            {
                characterController.enabled = false; // Disable before setting position
            }

            // Restore player position
            playerTransform.position = new Vector3(loadedData.position[0], loadedData.position[1], loadedData.position[2]);

            if (characterController != null)
            {
                characterController.enabled = true; // Re-enable after setting position
            }

            Debug.Log("Game Loaded!");
            Debug.Log($"Player Position After Loading: {playerTransform.position}");
        }
        else
        {
            Debug.LogWarning("Save file not found!");
        }
    }
}
