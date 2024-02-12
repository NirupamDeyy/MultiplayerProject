using UnityEngine;
using UnityEngine.SceneManagement;

public static class GameManager 
{
    private static bool isPaused = false;

    public static void PauseResumeGame()
    {
        if(isPaused)
        {
            Time.timeScale = 1f;
            isPaused = false;
        }
        else
        {
            Time.timeScale = 0f;
            isPaused = true;
        }
        
    }

    public static void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public static void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public static bool IsPaused()
    {
        return isPaused;
    }

    public static void ToggleFullScreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }

    public static void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }
} 

