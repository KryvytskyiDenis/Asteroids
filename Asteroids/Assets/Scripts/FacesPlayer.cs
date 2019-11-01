using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacesPlayer : MonoBehaviour
{
    public float rotationSpeed = 90f;

    Transform player;

    private void Update()
    {
        if(player == null)
        {
            GameObject go = GameObject.FindGameObjectWithTag("Player");

            if(go != null)
            {
                player = go.transform;
            }
        }

        // At this point, we've either found the player,
        // or he/she doesn't exist right now.
        if (player == null)
            return; // Try again next frame

        // Here we know for sure we have a player. Turn to face it
        Vector3 dir = player.position - transform.position;
        dir.Normalize();

        float zAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;

        Quaternion desiredRotation = Quaternion.Euler(0, 0, zAngle);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRotation, rotationSpeed * Time.deltaTime);
    }
}
