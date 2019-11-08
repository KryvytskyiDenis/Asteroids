using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour, IPooledObject
{
    private float timerDefault = 3f; // This variable need because of object pooling 
    public float timer;

    public void OnObjectSpawn()
    {
        // Need this code, because after movement the object to object pool timer doesn't reset
        timer = timerDefault;
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if(timer <= 0)
        {
            // Move to object pool
            gameObject.SetActive(false);
        }
    }
}
