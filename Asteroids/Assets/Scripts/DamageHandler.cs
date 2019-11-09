using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHandler : MonoBehaviour
{
    public GameManager gameManager;
    public HealthBarController healthBar;

    private PlayerParams playerParams;

    SpriteRenderer spriteRenderer;

    public float invulnPeriod = 0;

    private float health = 1;
        
    float invulnTimer = 0;
    int defaultLayer = 0;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        
        defaultLayer = gameObject.layer;

        // This only get the rendere on the parnet object.
        spriteRenderer = GetComponent<SpriteRenderer>();
        
        if(gameObject.CompareTag("Player"))
        {
            healthBar = GameObject.Find("HealthBar").GetComponent<HealthBarController>();
            playerParams = GameObject.Find("PlayerSettings").GetComponent<PlayerParams>();
            health = playerParams.health;
        }

        if (spriteRenderer == null)
        {
            spriteRenderer = transform.GetComponentInChildren<SpriteRenderer>();

            if(spriteRenderer == null)
            {
                Debug.LogError("Object '" + gameObject.name + "' has no sprite renderer.");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        health--;
        if(gameObject.CompareTag("Player"))
        {
            if(healthBar != null)
            {
                healthBar.DecreaseHealth(health);
            }
        }
        
        if (invulnPeriod > 0)
        {
            invulnTimer = invulnPeriod;
            gameObject.layer = 12;
        }
    }

    private void Update()
    {
        if (invulnTimer > 0)
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
        if(gameObject.CompareTag("Enemy"))
        {
            if(!gameManager.gameOver)
            {
                gameManager.UpdateScore(1);
            }
        }
        else if(gameObject.CompareTag("Player"))
        {
            gameManager.GameOver();
        }

        gameObject.SetActive(false);
    }
}
