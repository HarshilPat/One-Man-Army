using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public GameObject gameOverUI;

    public GameObject player;

    void Update()
    {
        if (player.GetComponent<PlayerMovement>().isDead) {
            GameOver();
        }
    }

    public void Restart() {
        player.GetComponent<PlayerMovement>().isDead = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene("Game");
    }

    void GameOver() {
        gameOverUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void LoadMenu() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void Quit() {
        Application.Quit();
    }
}
