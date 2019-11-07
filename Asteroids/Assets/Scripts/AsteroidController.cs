using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour, IPooledObject
{
    AsteroidSpawner asteroidSpawner;
    ObjectPooler objectPooler;

    public Rigidbody2D rb;

    public float maxThrust;
    public float maxTorque;
    public int sizeIndex; // 3 - big, 2 - medium, 1 - small, 0 - tiny

    public BoundariesController boundariesController;
    float boundariesRadius;

    private void Start()
    {
        boundariesRadius = GetComponent<Renderer>().bounds.size.x;
        asteroidSpawner =  GameObject.Find("AsteroidSpawner").GetComponent<AsteroidSpawner>();
        objectPooler = ObjectPooler.Instance;
    }

    public void OnObjectSpawn()
    {
        Vector2 thrust = new Vector2(Random.Range(-maxThrust, maxThrust), Random.Range(-maxThrust, maxThrust));
        float torque = Random.Range(-maxTorque, maxTorque);

        rb.AddForce(thrust);
        rb.AddTorque(torque);
    }

    private void Update()
    {
        // Wrapper
        Vector2 pos = transform.position;

        boundariesController.CheckBoundaries(pos, out Vector2 newPos, pos, boundariesRadius);

        // Update position
        transform.position = newPos;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Bullet"))
        {
            int count = 2;

            // Move to objects pool
            gameObject.SetActive(false);

            if (sizeIndex > 0)
            {
                InstantiateAsteroid(sizeIndex - 1, count); // generate two smaller than current one
            }
        }
    }

    void InstantiateAsteroid(int sizeIndex, int count)
    {
        for(int i = 0; i < count; i++)
        {
            objectPooler.SpawnFromPool(asteroidSpawner.asteroidSize[sizeIndex], transform.position, transform.rotation);
        }
    }
}
