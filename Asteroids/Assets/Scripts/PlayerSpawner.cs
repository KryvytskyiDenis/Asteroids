using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject playerPrefab;
    private GameObject playerInstance;

    public int countLives = 4;

    float respawnTimer;
    public void SpawnPlayer()
    {
        countLives--;
        respawnTimer = 2f;
        playerInstance = Instantiate(playerPrefab, transform.position, Quaternion.identity);
        Debug.Log("Player spawned");
    }

    private void Start()
    {
        SpawnPlayer();
    }

    private void Update()
    {
        
    }

    // Is not used now
    void RespawnPlayer()
    {
        if (playerInstance == null && countLives > 0)
        {
            respawnTimer -= Time.deltaTime;

            if (respawnTimer <= 0)
            {
                SpawnPlayer();
            }
        }
    }
}
