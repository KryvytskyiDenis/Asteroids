using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject playerPrefab;
    private GameObject playerInstance;

    private int health;
    float respawnTimer;

    public void SpawnPlayer()
    {
        respawnTimer = 2f;
        playerInstance = Instantiate(playerPrefab, transform.position, Quaternion.identity);
        health = playerInstance.GetComponent<DamageHandler>().health;
    }

    private void Update()
    {
        //RespawnPlayer();
    }

    void RespawnPlayer()
    {
        if (playerInstance == null && health > 0)
        {
            respawnTimer -= Time.deltaTime;

            if (respawnTimer <= 0)
            {
                SpawnPlayer();
            }
        }
    }
}
