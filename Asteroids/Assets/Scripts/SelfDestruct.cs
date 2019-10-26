using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    public float timer = 1f;
    
    private void Update()
    {
        timer -= Time.deltaTime;
        Debug.Log("timer:" + timer);
        if(timer <= 0)
        {
            Destroy(gameObject);
        }
    }
}
