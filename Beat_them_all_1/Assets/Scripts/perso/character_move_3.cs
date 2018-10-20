using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character_move_3 : MonoBehaviour {
    public float move;
    public float speed = 10f;
    public float speed2;
    public float jumpForce = 300f;
    public Rigidbody2D perso;
    public bool facingRight = true;
    //**************JUMP*****************
    public bool grounded = false;
    public Transform groundCheck;
    float groundRadius = 0.2f;
    public LayerMask whatIsGround;
    public GameObject barre_de_vie;
    public Animator anim;
    public Poing poing;
    bool anim_marche;
    public AudioSource jumpSound;
    public float vitesse;
    public float vitesse_max;
    public float torque;
    int jjump = Animator.StringToHash("Jump");
    int enlairr = Animator.StringToHash("en_l_air");
    int marchee= Animator.StringToHash("marche");

    void Start()
    {
        anim = GetComponent<Animator>();
        perso = GetComponent<Rigidbody2D>();
        speed2 = speed;
        poing = GetComponent<Poing>();

    }
    void FixedUpdate()
    {
         move = Input.GetAxis("Horizontal");
        vitesse = perso.velocity.magnitude;
        perso.AddForce((Vector2.right*speed)*move);
        if (move > 0 && !facingRight)
        {
            Flip();
        }
        if (move < 0 && facingRight)
        {
            Flip();
        }

        if (grounded)
        {
           // anim.SetBool("en_l_air", false);
            anim.SetBool(enlairr, false);
        }
        else
        {
           // anim.SetBool("en_l_air", true);
            anim.SetBool(enlairr, true);
        }
        if (Input.GetKey(KeyCode.LeftArrow) && grounded || Input.GetKey(KeyCode.RightArrow) && grounded)
        {
           // anim.SetBool("marche", true);
            anim.SetBool(marchee, true);

        }
        else
        {
          //  anim.SetBool("marche", false);
            anim.SetBool(marchee, false);
        }
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        if (vitesse > vitesse_max)
        {
            speed = 0;

        }else { speed = speed2;
        }
    }
    void Update()
    {

        if (grounded && Input.GetKeyDown(KeyCode.UpArrow))
        {
            jumpSound.Play();
            perso.AddForce(new Vector2(0, jumpForce));
            // anim.SetTrigger("Jump");
             anim.SetTrigger(jjump);
           // anim.SetBool("en_l_air", true);
            anim.SetBool(enlairr, true);
        }
        if(Input.GetKeyUp(KeyCode.RightArrow)|| Input.GetKeyUp(KeyCode.LeftArrow)) {
            // perso.AddForce(Vector2.right * 0);
            speed = 0;
            perso.AddTorque(torque);
        }
     
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }



}

