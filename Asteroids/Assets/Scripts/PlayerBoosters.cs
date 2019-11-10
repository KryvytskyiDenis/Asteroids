using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoosters : MonoBehaviour
{
    [SerializeField]
    GameObject shield;

    public void GenerateShield()
    {
        shield.SetActive(true);
        float time = shield.GetComponent<Booster>().actionTime;
        DamageHandler damageHandler = gameObject.GetComponent<DamageHandler>();
        damageHandler.isShield = true;
        damageHandler.StartInvulnerable(time); 
        
    }
}
