using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    public AsteroidPrefabList asteroidPrefabs;

    public Rigidbody2D rb;

    public float maxThrust;
    public float maxTorque;
    public int asteroidSize; // 3 - big, 2 - medium, 1 - small, 0 - tiny

    public BoundariesController boundariesController;
    float asteroidBoundariesRadius;

    private void Start()
    {
        asteroidBoundariesRadius = GetComponent<Renderer>().bounds.size.x;
        asteroidPrefabs = GameObject.Find("PrefabsManager").GetComponent<AsteroidPrefabList>();

        Vector2 thrust = new Vector2(Random.Range(-maxThrust, maxThrust), Random.Range(-maxThrust, maxThrust));
        float torque = Random.Range(-maxTorque, maxTorque);

        rb.AddForce(thrust);
        rb.AddTorque(torque);
    }

    private void Update()
    {
        // Wrapper
        Vector2 pos = transform.position;

        boundariesController.CheckBoundaries(pos, out Vector2 newPos, pos, asteroidBoundariesRadius);

        // Update position
        transform.position = newPos;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Bullet"))
        {
            int asteroidsCountToGenerate = 2;

            switch(asteroidSize)
            {
                case 3:
                    InstantiateAsteroidWithPrefab((int)AsteroidPrefabList.AsteroidSize.Medium, asteroidsCountToGenerate);
                    break;
                case 2:
                    InstantiateAsteroidWithPrefab((int)AsteroidPrefabList.AsteroidSize.Small, asteroidsCountToGenerate);
                    break;
                case 1:
                    InstantiateAsteroidWithPrefab((int)AsteroidPrefabList.AsteroidSize.Tiny, asteroidsCountToGenerate);
                    break;
            }

            // Move to objects pool
            Destroy(gameObject);
        }
    }

    void InstantiateAsteroidWithPrefab(int index, int count)
    {
        for(int i = 0; i < count; i++)
        {
            Instantiate(asteroidPrefabs.list[index], transform.position, transform.rotation);
        }
    }
}
