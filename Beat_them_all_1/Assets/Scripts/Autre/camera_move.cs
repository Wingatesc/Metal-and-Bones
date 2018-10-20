using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_move : MonoBehaviour {
    public float speed;
    public float speedV;
    public Rigidbody2D rb;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        float move = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");

        rb.velocity = new Vector2(move * speed, 0);
        rb.AddForce(new Vector2(0, speedV*vert));
        if (Input.GetKeyUp(KeyCode.R)) {
            speed = speed + 1;
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            speed = speed - 1;
        }
    }
}
