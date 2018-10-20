using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character_move_5 : MonoBehaviour {
    public Rigidbody2D perso;
    public float speed ;//70
    public float speed2;//70
    public float speed_en_l_air;//4
    public float Jumpspeed;//8
    public float jump_drag;//0
    public float ground_drag;//0
    public float move_drag;//0
    public bool facingRight = true;
    public float vitesse;
    public float vitesse_max;//5
    public bool canMove;
    public Transform groundCheck;
    float groundRadius = 0.2f;
    public LayerMask whatIsGround;
    public bool grounded = false;
    // Use this for initialization
    void Start()
    {
        perso = GetComponent<Rigidbody2D>();
        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            if (Input.GetKey(KeyCode.RightArrow)&&grounded)
            {

                perso.AddForce(new Vector2(speed, 0));
                facingRight = true;
                Vector3 theScale = transform.localScale;
                theScale.x = 1;
                transform.localScale = theScale;
                perso.drag = move_drag;

            }
            if (Input.GetKey(KeyCode.LeftArrow)&&grounded)
            {

                perso.AddForce(new Vector2(-1 * speed, 0));
                facingRight = false;
                Vector3 theScale = transform.localScale;
                theScale.x = -1;
                transform.localScale = theScale;
                Debug.Log("move drag");
                perso.drag = move_drag;
            }
            if (Input.GetKey(KeyCode.RightArrow) && !grounded)
            {

                perso.velocity = new Vector2(speed_en_l_air, perso.velocity.y);
                facingRight = true;
                Vector3 theScale = transform.localScale;
                theScale.x = 1;
                transform.localScale = theScale;
                //perso.drag = move_drag;

            }
            if (Input.GetKey(KeyCode.LeftArrow) && !grounded)
            {

                perso.velocity = new Vector2(-speed_en_l_air, perso.velocity.y);
                facingRight = false;
                Vector3 theScale = transform.localScale;
                theScale.x = -1;
                transform.localScale = theScale;
                Debug.Log("move drag");
                //perso.drag = move_drag;
            }
            if (grounded && Input.GetKeyDown(KeyCode.UpArrow))
            {
                // jumpSound.Play();
                // perso.AddForce(new Vector2(0, Jumpspeed));
                perso.velocity = new Vector2(perso.velocity.x, Jumpspeed);
                //  anim.SetTrigger("Jump");
                // anim.SetBool("en_l_air", true);
            }
            if (grounded && Input.GetKeyUp(KeyCode.RightArrow) || grounded && Input.GetKeyUp(KeyCode.LeftArrow))
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