using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHandler : MonoBehaviour
{
    public int health = 1;

    float invulnTimer = 0;
    int defaultLayer = 0;

    private void Start()
    {
        defaultLayer = gameObject.layer; 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger");

        health--;
        invulnTimer = 2f;
        gameObject.layer = 12;
    }

    private void Update()
    {
        invulnTimer -= Time.deltaTime;
        if(invulnTimer <= 0)
        {
            gameObject.layer = defaultLayer;
        }

        if (health <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        Destroy(gameObject);
    }
}
