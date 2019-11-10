using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosterSpawner : MonoBehaviour
{
    ObjectPooler objectPooler;

    public List<string> boosters;

    public float delay = 1f;

    private float timer;

    private void Start()
    {
        objectPooler = ObjectPooler.Instance;
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            timer = delay;

            // Generate an asteroid with the random size
            int sizeIndex = Random.Range(0, boosters.Count);

            float spawnY = Random.Range
                  (Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y);
            float spawnX = Random.Range
                (Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x);

            Vector2 spawnPosition = new Vector2(spawnX, spawnY);


            objectPooler.SpawnFromPool(boosters[sizeIndex], spawnPosition, Quaternion.identity);
        }
    }

}
