using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    public GameObject pauseMenu; // Assign the pause menu panel in the inspector

    // Call this function when the 'Start' button is pressed
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Call this function to restart the current level
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1; // Make sure to resume the time if you've paused it
    }

    // Call this function to return to the main menu
    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1; // Make sure to resume the time if you've paused it
    }

    // Call this function when the 'Quit' button is pressed
    public void QuitGame()
    {
        Application.Quit();
    }

    // Call this function when the 'Resume' button is pressed
    public void ResumeGame()
    {
        // Hide the pause menu
        pauseMenu.SetActive(false);

        // Resume the game time
        Time.timeScale = 1;
    }
}
