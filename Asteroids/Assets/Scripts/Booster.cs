using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Booster : MonoBehaviour
{
    public float actionTime;
    private float timer;

    private void Start()
    {
        timer = actionTime;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if(timer <= 0)
        {
            timer = actionTime;
            gameObject.SetActive(false);
        }
    }
}
