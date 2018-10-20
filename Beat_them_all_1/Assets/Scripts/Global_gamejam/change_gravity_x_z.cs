using UnityEngine;
using System.Collections;

public class change_gravity_x_z : MonoBehaviour {
	public Rigidbody2D rb;
	public float enX;
	public float enY;
    public bool fly=false;
	// Use this for initialization
	void Update () {
        if (fly)
        {

            // rb.gravityScale = -1;
            rb.velocity = new Vector2(enX, enY);
        }else
        {
            // rb.gravityScale = 1;
            rb.velocity = new Vector2(0, 0);
        }
    }
	
	// Update is called once per frame
	
    }

