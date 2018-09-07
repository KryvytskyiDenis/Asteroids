using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipControl : MonoBehaviour {

    public Rigidbody2D rb;
    //public float thrust;
    //public float turnThrust;
    private float thrustInput;
    private float turnInput;
    public float screenTop;
    public float screenBottom;
    public float screenLeft;
    public float screenRight;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //check for input from keyboard
        thrustInput = Input.GetAxis("Vertical"); // [-1;1] в настрояках проекта по вертикали: w, s, up, down 
        turnInput = Input.GetAxis("Horizontal"); // [-1;1] в настрояках проекта по вертикали: a, d, left, right

        //Обертка над сценой

        Vector2 newPosition = transform.position;
        if (transform.position.y > screenTop)
        {
            newPosition.y = screenBottom;
        }
        if (transform.position.y < screenBottom)
        {
            newPosition.y = screenTop;
        }
        if (transform.position.x < screenLeft)
        {
            newPosition.x = screenRight;
        }
        if (transform.position.x > screenRight)
        {
            newPosition.x = screenLeft;
        }

        transform.position = newPosition;
    }

    private void FixedUpdate()
    {
        rb.AddRelativeForce(Vector2.up * thrustInput);
        rb.AddTorque(-turnInput); // крутящий момент для вращения
    }
}
