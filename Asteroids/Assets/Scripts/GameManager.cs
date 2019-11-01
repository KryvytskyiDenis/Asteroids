using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreTxt;
    public TextMeshProUGUI gameOverTxt;
    public TextMeshProUGUI restartGameTxt;
    public TextMeshProUGUI healthTxt;

    private DamageHandler damageHandler;
    private PlayerSpawner playerSpawner;

    public bool gameOver;

    private int score;
        
    private void Start()
    {
        ResetHud();
    }

    private void Update()
    {
        if(damageHandler == null)
        {
            damageHandler = GameObject.FindWithTag("Player").GetComponent<DamageHandler>();
        }

        if (playerSpawner == null)
        {
            playerSpawner = GameObject.FindWithTag("Player").GetComponent<PlayerSpawner>();
        }

        if(gameOver && Input.GetKey(KeyCode.R))
        {
            RestartGame();
            ResetHud();
        }
        else if (damageHandler)
        {
            healthTxt.text = "Health: " + damageHandler.health.ToString();
        }
    }

    public void UpdateScore(int addScore)
    {
        score += addScore;
        scoreTxt.text = "Score: " + score;
    }

    public void GameOver()
    {
        Debug.Log("Game over");
        restartGameTxt.enabled = true;
        gameOverTxt.enabled = true;
        gameOver = true;
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        playerSpawner.SpawnPlayer();
    }

    void ResetHud()
    {
        score = 0;
        restartGameTxt.enabled = false;
        gameOverTxt.enabled = false;
        gameOver = false;
    }
}
