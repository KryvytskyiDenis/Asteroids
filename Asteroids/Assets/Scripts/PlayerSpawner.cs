using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject playerPrefab;
    GameObject playerInstance;

    public int countLives = 4;

    float respawnTimer;
    void SpawnPlayer()
    {
        countLives--;
        respawnTimer = 2f;
        playerInstance = Instantiate(playerPrefab, transform.position, Quaternion.identity);
    }

    private void Start()
    {
        SpawnPlayer();
    }

    private void Update()
    {
        if(playerInstance == null && countLives > 0)
        {
            respawnTimer -= Time.deltaTime;
            
            if(respawnTimer <= 0)
            {
                SpawnPlayer();
            }
        }
    }
    private void OnGUI()
    {
        if(countLives > 0 || playerInstance != null)
        {
            GUI.Label(new Rect(0, 0, 100, 50), "Lives left: " + countLives);
            GUI.Label(new Rect(0, 50, 100, 50), "Health: " + playerInstance.GetComponent<DamageHandler>().health);
        }
        else
        {
            GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 50, 100, 50), "Game Over");
        }
        
    }
}
