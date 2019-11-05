using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHandler : MonoBehaviour
{
    public GameManager gameManager;

    SpriteRenderer spriteRenderer;

    public int health = 1;

    public float invulnPeriod = 0;
    float invulnTimer = 0;
    int defaultLayer = 0;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        defaultLayer = gameObject.layer;

        // This only get the rendere on the parnet object.
        spriteRenderer = GetComponent<SpriteRenderer>();

        if(spriteRenderer == null)
        {
            spriteRenderer = transform.GetComponentInChildren<SpriteRenderer>();

            if(spriteRenderer == null)
            {
                Debug.LogError("Object '" + gameObject.name + "' has no sprite renderer.");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
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
        if(gameObject.tag.Equals("Enemy"))
        {
            gameManager.UpdateScore(1);
        }
        else if(gameObject.tag.Equals("Player"))
        {
            gameManager.GameOver();
        }

        Destroy(gameObject);
    }
}
