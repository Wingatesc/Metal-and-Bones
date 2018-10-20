using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character_move_2 : MonoBehaviour {
    public float speed = 10f;
    public CapsuleCollider2D coll;
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
    public GameObject poing;
    bool anim_marche;
    public AudioSource jumpSound;
    public bool marche_normal = true;
    public float acceleration;

    void Start()
    {
        groundCheck= transform.Find("groundCheck");
        anim = GetComponent<Animator>();
        perso = GetComponent<Rigidbody2D>();
        coll = GetComponent<CapsuleCollider2D>();
    }
    void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal");
        anim.SetFloat("vitesse", Mathf.Abs(move));
        perso.velocity = new Vector2(move * speed, perso.velocity.y);
        if (move > 0 && !facingRight && marche_normal)
        {
            Flip();

        }
        if (move < 0 && facingRight && marche_normal)
        {
            Flip();

        }
        if (Input.GetKey(KeyCode.LeftArrow) && grounded || Input.GetKey(KeyCode.RightArrow) && grounded)
        {
            anim.SetBool("marche", true);
        }
        else
        {
            anim.SetBool("marche", false);
        }
        if (Input.GetKey(KeyCode.E))
        {

            marche_normal = false;
        }
        else
        {
            marche_normal = true;
        }

        if (grounded)
        {
            anim.SetBool("en_l_air", false);
            coll.size = new Vector2(0.71f, 2.24f);
        }
        else
        {
            anim.SetBool("en_l_air", true);
            coll.size = new Vector2(0.71f, 1.54f);
        }
       
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
    
    }
    void Update()
    {
        if (grounded && Input.GetKeyDown(KeyCode.UpArrow))
        {
            jumpSound.Play();
            // perso.velocity = new Vector2(perso.velocity.x, jumpForce);
            perso.AddForce(new Vector2(0, jumpForce),ForceMode2D.Impulse);
            anim.SetTrigger("Jump");
            anim.SetBool("en_l_air", true);
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
