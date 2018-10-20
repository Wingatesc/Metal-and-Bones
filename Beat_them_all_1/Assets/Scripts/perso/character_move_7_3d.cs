using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character_move_7_3d : MonoBehaviour {
    public Rigidbody perso;
    public float speed;//1000
    public float speed2;//1000
    public float frein;//1000
    public float speed_en_l_air = 9;
    public float Jumpspeed;
    public float jump_drag;
    public float ground_drag;
    public float move_drag;
    public bool facingRight = true;
    public float vitesse;
    public float vitesse_max = 6;
    public bool canMove;
    public Transform groundCheck;
    public WheelCollider wheel;
    float groundRadius = 0.2f;
    public LayerMask whatIsGround;
    public bool grounded = false;
    // Use this for initialization
    void Start () {
        perso = GetComponent<Rigidbody>();
        canMove = true;
        wheel = GetComponent<WheelCollider>();
        wheel.steerAngle = 90;
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            if (Input.GetKey(KeyCode.RightArrow) && grounded)
            {

                //perso.AddForce(new Vector2(speed, 0));
               // speed = speed2;
                wheel.motorTorque=speed*Time.deltaTime;
                facingRight = true;
                Vector3 theScale = transform.localScale;
                theScale.x = 1;
                transform.localScale = theScale;
                perso.drag = move_drag;

            }
         
            if (Input.GetKey(KeyCode.LeftArrow) && grounded)
            {

                // perso.AddForce(new Vector2(-1 * speed, 0));
              //  speed = speed2;
                wheel.motorTorque = -1*speed * Time.deltaTime;
                facingRight = false;
                Vector3 theScale = transform.localScale;
                theScale.x = -1;
                transform.localScale = theScale;
                Debug.Log("move drag");
                perso.drag = move_drag;
            }
           /* if (Input.GetKey(KeyCode.RightArrow) && !grounded)
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

                perso.velocity = new Vector3(-speed_en_l_air, perso.velocity.y);
                facingRight = false;
                Vector3 theScale = transform.localScale;
                theScale.x = -1;
                transform.localScale = theScale;
                Debug.Log("move drag");
                //perso.drag = move_drag;
            }*/
            if (grounded && Input.GetKeyDown(KeyCode.UpArrow))
            {
                // jumpSound.Play();
                // perso.AddForce(new Vector2(0, Jumpspeed));
                // perso.velocity = new Vector3(perso.velocity.x, Jumpspeed, 0);
                perso.AddForce(new Vector3(0,Jumpspeed,0), ForceMode.Impulse);
                //  anim.SetTrigger("Jump");
                // anim.SetBool("en_l_air", true);
            }
            if (grounded && Input.GetKeyUp(KeyCode.RightArrow) || grounded && Input.GetKeyUp(KeyCode.LeftArrow))
            {
                //  Debug.Log("ground drag");
                // perso.drag = ground_drag;
                wheel.brakeTorque = frein;
                speed = 0;
            }
            else
            {
                wheel.brakeTorque = 0;
            }


            if (!grounded)
            {
                //  Debug.Log("jump drag");

            }
        }
    }
        void FixedUpdate()
        {
            vitesse = perso.velocity.magnitude;
        // grounded = Physics.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        grounded = Physics.CheckSphere(groundCheck.position, groundRadius, whatIsGround);
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