using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidsSpawner : MonoBehaviour
{
    public AsteroidPrefabList asteroidPrefabs;

    public float delay = 0.5f;

    private float timer;
    private Vector2 pos;
    private float spawnDistance = 12f;

    private void Update()
    {
        timer -= Time.deltaTime;

        if(timer <= 0)
        {
            timer = delay;

            // Generate an asteroid with the random size
            int size =  Random.Range((int)AsteroidPrefabList.AsteroidSize.Tiny, (int)AsteroidPrefabList.AsteroidSize.Big);

            Vector3 offset = Random.onUnitSphere;

            offset.z = 0;
            offset = offset.normalized * spawnDistance;

            Instantiate(asteroidPrefabs.list[size], transform.position + offset, Quaternion.identity);
        }
    }
}
