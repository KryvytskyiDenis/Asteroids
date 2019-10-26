using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipShooting : MonoBehaviour
{
    public Vector3 bulletOffset = new Vector3(0, 0.5f, 0);
    public GameObject bulletPrefab;
    int bulletLayer = 0;

    public float fireDelay = 0.25f;
    float cooldownTimer = 0;

    bool isPlayer = false;
    bool isFire = false;

    Transform player;

    private void Start()
    {
        bulletLayer = gameObject.layer;
        isPlayer = gameObject.tag == "Player";
    }

    private void Update()
    {
        cooldownTimer -= Time.deltaTime;

        if(isPlayer)
        {
            isFire = Input.GetButton("Fire1");
            Debug.Log(isFire);
        }

        if(!isPlayer)
        {
            if (player == null)
            {
                GameObject go = GameObject.FindGameObjectWithTag("Player");

                if (go != null)
                {
                    player = go.transform;
                }
            }
        }
        
        if (cooldownTimer <= 0 && ((isPlayer && isFire) || (!isPlayer && player != null && Vector3.Distance(transform.position, player.position) < 7)))
        {
           
            cooldownTimer = fireDelay;

            Vector3 offset = transform.rotation * bulletOffset;

            GameObject bulletGO = Instantiate(bulletPrefab, transform.position + offset, transform.rotation);
            bulletGO.layer = bulletLayer;
        }
    }
}
