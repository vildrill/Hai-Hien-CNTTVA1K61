using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int level;
    public static float lives;
    public static int score;
    public void PlayGame()
    {
        NewGame();
    }
    public void QuitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        /* Debug.Log("Quit");
         Application.Quit();*/
    }
    private void Start()
    {
        DontDestroyOnLoad(gameObject);       
    }
    private void NewGame()
    {
        lives = 3f;
        score = 0;
        LoadLevel(1);
    }
    private void LoadLevel(int index)
    {
        level = index;       
        Invoke(nameof(LoadScene), 1f);
    }
    private void LoadScene()
    {
        SceneManager.LoadScene(level);
    }
    public void LevelComplete()
    {
        score += 100;

        int nextLevel = level + 1;

        if (nextLevel < SceneManager.sceneCountInBuildSettings)
        {
            LoadLevel(nextLevel);
        }
        else
        {
            LoadLevel(1);
        }
    }
    public void LevelFailed()
    {
        lives--;
        if (lives <= 0)
        {
            LoadLevel(3);
        }
        else
        {
            LoadLevel(level);
        }
    }
}
