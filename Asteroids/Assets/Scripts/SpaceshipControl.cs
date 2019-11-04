using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipControl : MonoBehaviour {

    public Rigidbody2D rb;
    public float thrust;
    public float turnThrust;
    private float thrustInput;
    private float turnInput;

    public BoundariesController boundariesController;
    float shipBoundariesRadius = 0.5f;

    private void Update()
    {
        // Check for input from keyboard
        thrustInput = Input.GetAxis("Vertical"); // [-1;1] by vertical in the project settings: w, s, up, down 
        turnInput = Input.GetAxis("Horizontal"); // [-1;1]  by horizontal in the project settings: a, d, left, right

        // Wrapper
        Vector2 pos = transform.position;

        boundariesController.CheckBoundaries(pos, out Vector2 newPos, pos, shipBoundariesRadius);

        // Update position
        transform.position = newPos;
    }

    void FixedUpdate () 
    {
        // Movement
        Vector3 velocity = new Vector3(0, thrustInput * thrust * Time.deltaTime, 0);
        transform.Translate(velocity);
        //rb.AddRelativeForce(Vector2.up * thrustInput * thrust * Time.deltaTime);

        // Torque for rotation
        rb.AddTorque(-turnInput * turnThrust * Time.deltaTime);
    }
}
