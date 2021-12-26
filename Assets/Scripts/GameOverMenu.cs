using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public GameObject gameOverUI;
    public GameManager gameManager;

    public void Restart() {
        gameOverUI.SetActive(false);
        Destroy(gameManager.GetComponent<GameManager>().player);
        Destroy(gameManager.GetComponent<GameManager>().weapon);
        Time.timeScale = 1f;
        SceneManager.LoadScene("Game");
    }

    public void GameOver() {
        gameOverUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void LoadMenu() {
        gameOverUI.SetActive(false);
        SceneManager.LoadScene("MainMenu");
    }

    public void Quit() {
        Application.Quit();
    }
}
