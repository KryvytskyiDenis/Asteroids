using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameManager gameManager;

    ObjectPooler objectPooler;
    public List<string> enemyTag;

    public float spawnDistance = 12f;

    public float timer = 1;

    private float delay = 5;

    private void Start()
    {
        objectPooler = ObjectPooler.Instance;
    }

    void Update()
    {
        if(!gameManager.gameOver)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                timer = delay;
                delay *= 0.9f;
                if (delay < 2)
                    delay = 2;

                Vector3 offset = Random.onUnitSphere;
                offset.z = 0;
                offset = offset.normalized * spawnDistance;

                int index = Random.Range(0, enemyTag.Count);

                objectPooler.SpawnFromPool(enemyTag[index], transform.position + offset, Quaternion.identity);
            }
        }
    }
}