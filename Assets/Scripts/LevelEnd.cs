using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnd: MonoBehaviour
{
    public GameObject endLevelMenu; // Assign your end level menu panel to this in the inspector

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Make sure your player has the "Player" tag
        {
            ShowEndLevelMenu();
        }
    }

    public void ShowEndLevelMenu()
    {
        // Show the end level menu
        endLevelMenu.SetActive(true);
        // Optionally pause the game if needed
        Time.timeScale = 0;
    }

    public void RestartLevel()
    {
        // Reload the current level
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1; // Make sure to resume the time if you've paused it
    }

    public void GoToMainMenu()
    {
        // Load the main menu scene by name
        SceneManager.LoadScene("MainMenu"); // Replace "MainMenu" with your main menu scene's name
        Time.timeScale = 1; // Make sure to resume the time if you've paused it
    }
}
