using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character_move_4 : MonoBehaviour {
    public Rigidbody2D perso;
    public float speed;//9
    public float speed2;//9
    public float Jumpspeed;//8
    public float jump_drag;//0.3
    public float ground_drag;//2
    public float move_drag;//0.3
    public bool facingRight = true;
    public float vitesse;
    public float vitesse_max=6;
    public bool canMove;
    public Transform groundCheck;
    float groundRadius = 0.4f;
    public LayerMask whatIsGround;
    public bool grounded = false;
    // Use this for initialization
    void Start () {
        perso=GetComponent<Rigidbody2D>();
        canMove = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (canMove)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                
                perso.AddForce(new Vector2(speed, 0) );
                facingRight = true;
                Vector3 theScale = transform.localScale;
                theScale.x = 1;
                transform.localScale = theScale;
                perso.drag = move_drag;

            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                
                perso.AddForce(new Vector2(-1*speed, 0));
                facingRight = false;
                Vector3 theScale = transform.localScale;
                theScale.x = -1;
                transform.localScale = theScale;
                Debug.Log("move drag");
                perso.drag = move_drag;
            }
            if (grounded && Input.GetKeyDown(KeyCode.UpArrow))
            {
                // jumpSound.Play();
                // perso.AddForce(new Vector2(0, Jumpspeed));
                perso.velocity = new Vector2(perso.velocity.x, Jumpspeed);
                //  anim.SetTrigger("Jump");
                // anim.SetBool("en_l_air", true);
            }
            if (grounded && Input.GetKeyUp(KeyCode.RightArrow)|| grounded && Input.GetKeyUp(KeyCode.LeftArrow))
            {
              //  Debug.Log("ground drag");
                perso.drag = ground_drag;
            }
            
           
            if (!grounded)
            {
              //  Debug.Log("jump drag");
                perso.drag = jump_drag;
            }
        }
	}
     void FixedUpdate()
    {
        vitesse = perso.velocity.magnitude;
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        if (vitesse > vitesse_max)
        {
            speed = 0;
        }
        else
        {
            speed = speed2;
        }
    }
}
