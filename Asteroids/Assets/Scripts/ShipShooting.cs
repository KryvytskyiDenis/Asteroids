using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipShooting : MonoBehaviour
{
    public ObjectPooler objectPooler;

    public Vector3 bulletOffset = new Vector3(0, 0.5f, 0);
    public string bulletTag;

    int bulletLayer = 0;

    public float fireDelay = 0.25f;
    float cooldownTimer = 0;
    
    bool isPlayer = false;
    bool isFire = false;

    Transform player;

    public BoundariesController boundariesCotroller;

    private void Start()
    {
        objectPooler = ObjectPooler.Instance;

        bulletLayer = gameObject.layer;
        isPlayer = gameObject.tag == "Player";
    }

    private void Update()
    {
        cooldownTimer -= Time.deltaTime;

        if(isPlayer)
        {
            isFire = Input.GetButton("Fire1");
        }
        else
        {
            if (player == null)
            {
                GameObject go = GameObject.FindGameObjectWithTag("Player");

                if (go != null)
                {
                    player = go.transform;
                    isFire = true;
                }
            }
        }
        
        if(isFire && cooldownTimer <= 0)
        {
            if(isPlayer || (!isPlayer && player != null))
            {
                // Check the boundaries
                // shoot only if position is on the screen
                if (boundariesCotroller.IsOnScreen(transform.position))
                {
                    cooldownTimer = fireDelay;

                    Vector3 offset = transform.rotation * bulletOffset;

                    GameObject bulletGO = objectPooler.SpawnFromPool(bulletTag, transform.position + offset, transform.rotation);
                    bulletGO.layer = bulletLayer;
                }
            }
        }
    }
}