using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour {

    public float leftConstraint, rightConstraint, topConstraint, bottomConstraint;
    private Camera cam;
    
    void Start () {
        cam = Camera.main;
        leftConstraint = cam.ScreenToWorldPoint(Vector3.zero).x;
        rightConstraint = cam.ScreenToWorldPoint(new Vector3(Screen.width, 0f, 0f)).x;
        topConstraint = cam.ScreenToWorldPoint(new Vector3(0f, Screen.height, 0f)).y;
        bottomConstraint = cam.ScreenToWorldPoint(Vector3.zero).y;
    }

	void Update () {
		if(transform.position.x < leftConstraint)
        {
            transform.position = new Vector2(rightConstraint - 0.1f, transform.position.y);
        }

        if (transform.position.x > rightConstraint)
        {
            transform.position = new Vector2(leftConstraint + 0.1f, transform.position.y);
        }

        if (transform.position.y < bottomConstraint)
        {
            transform.position = new Vector2(transform.position.x, topConstraint - 0.1f);
        }

        if (transform.position.y > topConstraint)
        {
            transform.position = new Vector2(transform.position.x, bottomConstraint + 0.1f);
        }
    }
}
