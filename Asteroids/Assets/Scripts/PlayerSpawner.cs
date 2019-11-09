using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject playerPrefab;

    public void SpawnPlayer()
    {
        Instantiate(playerPrefab, transform.position, Quaternion.identity);
    }
}
