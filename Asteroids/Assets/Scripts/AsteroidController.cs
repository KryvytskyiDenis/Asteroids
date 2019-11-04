using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    public Rigidbody2D rb;

    public float maxThrust;
    public float maxTorque;
    public int asteroidSize; // 3 - big, 2 - medium, 1 - small, 0 - tiny

    public BoundariesController boundariesController;
    float asteroidBoundariesRadius;

    // Asteroids prefabs
    public GameObject medAsteroidPrefab;
    public GameObject smallAsteroidPrefab;
    public GameObject tinyAsteroidPrefab;

    private void Start()
    {
        asteroidBoundariesRadius = GetComponent<Renderer>().bounds.size.x;

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

            switch(asteroidSize)
            {
                case 3:
                    Instantiate(medAsteroidPrefab, transform.position, transform.rotation);
                    Instantiate(medAsteroidPrefab, transform.position, transform.rotation);
                    break;
                case 2:
                    Instantiate(smallAsteroidPrefab, transform.position, transform.rotation);
                    Instantiate(smallAsteroidPrefab, transform.position, transform.rotation);
                    break;
                case 1:
                    Instantiate(tinyAsteroidPrefab, transform.position, transform.rotation);
                    Instantiate(tinyAsteroidPrefab, transform.position, transform.rotation);
                    break;
            }

            // Move to objects pool
            Destroy(gameObject);
        }
    }
}
