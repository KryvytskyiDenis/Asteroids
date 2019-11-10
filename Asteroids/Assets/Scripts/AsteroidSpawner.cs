using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    ObjectPooler objectPooler;

    public List<string> asteroidSize;

    public float delay = 0.5f;

    private float timer;
    private float spawnDistance = 12f;

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
            int sizeIndex = Random.Range(0, asteroidSize.Count);

            Vector3 offset = Random.onUnitSphere;
            offset.z = 0;
            offset = offset.normalized * spawnDistance;

            objectPooler.SpawnFromPool(asteroidSize[sizeIndex], transform.position + offset, Quaternion.identity);
        }
    }
}
