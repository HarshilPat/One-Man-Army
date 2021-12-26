using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject[] spawners;
    private int level = 1;
    private int currentScene = 1;
    private int enemyCount = 0;
    private int enemyLimit = 10;

    public GameObject player;
    public GameObject weapon;
    public GameObject hbCanvas;
    private Scene scene;

    void Start()
    {
        spawners = GameObject.FindGameObjectsWithTag("Spawner");
        int rnd = Random.Range(0, spawners.Length);
        spawners[rnd].GetComponent<SpawnerScript>().SetGateway(true);
        foreach (GameObject spawner in spawners)
        {
            spawner.GetComponent<SpawnerScript>().SetHealth(level + Random.Range(3, 6));
        }

    }

    void Awake()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        SceneManager.sceneLoaded += OnSceneLoaded;
        DontDestroyOnLoad(player.gameObject);
        DontDestroyOnLoad(weapon.gameObject);
        DontDestroyOnLoad(hbCanvas.gameObject);
        DontDestroyOnLoad(gameObject);
        scene = SceneManager.GetActiveScene();

    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (!string.Equals(scene.path, this.scene.path))
        {
            level++;
            PrepareSpawners();
        }
    }

    void PrepareSpawners()
    {
        spawners = GameObject.FindGameObjectsWithTag("Spawner");
        if (spawners.Length > 0)
        {
            int rnd = Random.Range(0, spawners.Length);
            spawners[rnd].GetComponent<SpawnerScript>().SetGateway(true);
            foreach (GameObject spawner in spawners)
            {
                spawner.GetComponent<SpawnerScript>().SetHealth(level + Random.Range(3, 6));
            }
        }
        
    }
    // Update is called once per frame
    public void SetEnemyCount(int amount)
    {
        enemyCount += amount;
    }

    public int GetEnemyCount()
    {
        return enemyCount;
    }
    public int GetEnemyLimit()
    {
        return enemyLimit;
    }

    public void LoadLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex !=2)
        {
            currentScene = 1;
        }
        else
        {
            currentScene = -1;
        }
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + currentScene);
    }
}
