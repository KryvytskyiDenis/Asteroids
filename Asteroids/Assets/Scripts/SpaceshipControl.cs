using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipControl : MonoBehaviour {

    public Rigidbody2D rb;
    public float thrust;
    public float turnThrust;
    private float thrustInput;
    private float turnInput;

    float shipBoundariesRadius = 0.5f;

	void Update () {
        // Check for input from keyboard
        thrustInput = Input.GetAxis("Vertical"); // [-1;1] by vertical in the project settings: w, s, up, down 
        turnInput = Input.GetAxis("Horizontal"); // [-1;1]  by horizontal in the project settings: a, d, left, right

        // Wrapper
        Vector2 pos = transform.position;
        Vector2 newPos = transform.position;

        // Do vertical bounds
        if (pos.y - shipBoundariesRadius > Camera.main.orthographicSize)
        {
            newPos.y = -Camera.main.orthographicSize;
        }
        if (pos.y + shipBoundariesRadius < -Camera.main.orthographicSize)
        {
            newPos.y = Camera.main.orthographicSize;
        }

        // Calculate the orthographic width based on the screen ration
        float screenRation = (float) Screen.width / (float) Screen.height;
        float widthOrtho = Camera.main.orthographicSize * screenRation;

        // Do horizontal bounds
        if (pos.x - shipBoundariesRadius > widthOrtho)
        {
            newPos.x = -widthOrtho;
        }
        if (pos.x + shipBoundariesRadius < -widthOrtho)
        {
            newPos.x = widthOrtho;
        }

        // Update position
        transform.position = newPos;

        // Move
        //Vector3 velocity = new Vector3(0, thrustInput * thrust * Time.deltaTime, 0);
        //transform.Translate(velocity);
        rb.AddRelativeForce(Vector2.up * thrustInput * thrust * Time.deltaTime);

        // Torque for rotation
        rb.AddTorque(-turnInput * turnThrust * Time.deltaTime);
    }
}
