using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHandler : MonoBehaviour
{
    public int health = 1;

    public float invulnPeriod = 0;
    float invulnTimer = 0;
    int defaultLayer = 0;

    SpriteRenderer spriteRenderer;
    private void Start()
    {
        defaultLayer = gameObject.layer;

        // This only get the rendere on the parnet object.
        spriteRenderer = GetComponent<SpriteRenderer>();

        if(spriteRenderer == null)
        {
            spriteRenderer = transform.GetComponentInChildren<SpriteRenderer>();

            if(spriteRenderer == null)
            {
                Debug.LogError("Object '" + gameObject.name + "' has no sprite rendXZere.");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger");

        health--;

        if(invulnPeriod > 0)
        {
            invulnTimer = invulnPeriod;
            gameObject.layer = 12;
        }
       
    }

    private void Update()
    {
        
        if(invulnTimer > 0)
        {
            invulnTimer -= Time.deltaTime;

            if (invulnTimer <= 0)
            {
                gameObject.layer = defaultLayer;
                if(spriteRenderer != null)
                {
                    spriteRenderer.enabled = true;
                }
            }
            else
            {
                if (spriteRenderer != null)
                {
                    spriteRenderer.enabled = !spriteRenderer.enabled;
                }
            }
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
