using UnityEngine;
using System.Collections;

public class character_move : MonoBehaviour {
	public float speed=10f;
    public float move2;
    public CapsuleCollider2D coll;
	public float jumpForce = 300f;
	public Rigidbody2D perso;
	public bool facingRight=true;
	//**************JUMP*****************
	public bool grounded=false;
	public Transform groundCheck;
	float groundRadius=0.2f;
	public LayerMask whatIsGround;
	public GameObject barre_de_vie;
	public Animator anim;
	public Poing poing;
	bool anim_marche;
    public AudioSource jumpSound;
    public bool marche_normal = true;

    void Start () {
		anim=GetComponent<Animator>();
        perso = GetComponent<Rigidbody2D>();
        coll = GetComponent<CapsuleCollider2D>();
        groundCheck = this.gameObject.transform.GetChild(0);
        poing = GetComponent<Poing>();
        GameObject music = GameObject.Find("jump");
        jumpSound = music.GetComponent<AudioSource>();
    }
    void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal");
         perso.velocity = new Vector2(move * speed, perso.velocity.y);
        anim.SetFloat("vitesse", Mathf.Abs(move));
         if (move > 0 && !facingRight&&marche_normal)
         {
             Flip();

         }
         if (move < 0 && facingRight&&marche_normal)
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
        }else {
            anim.SetBool("en_l_air", true);
            coll.size = new Vector2(0.71f, 1.54f);
        }
        
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);

       /* move2 = Input.GetAxis("Vertical");
        if (grounded&& Input.GetKey(KeyCode.UpArrow))
        {
            jumpSound.Play();
             perso.velocity = new Vector2(perso.velocity.x, move2 * jumpForce);
            anim.SetTrigger("Jump");
            anim.SetBool("en_l_air", true);
        }*/

    }
        void Update () {

        /* if (Input.GetKeyDown(KeyCode.UpArrow))
         {
             jumpSound.Play();
             //  perso.AddForce(new Vector2(0, jumpForce));
             // perso.velocity = new Vector2(perso.velocity.x, perso.velocity.y+jumpForce);
             perso.velocity = new Vector2(perso.velocity.x, jumpForce);
             anim.SetTrigger("Jump");
             anim.SetBool("en_l_air", true);
         }*/
         if (grounded && Input.GetKeyDown(KeyCode.UpArrow))
         {
             jumpSound.Play();
             //  perso.AddForce(new Vector2(0, jumpForce));
             // perso.velocity = new Vector2(perso.velocity.x, perso.velocity.y+jumpForce);
             perso.velocity = new Vector2(perso.velocity.x, jumpForce);
             anim.SetTrigger("Jump");
             anim.SetBool("en_l_air", true);
         }
  

    }

	void Flip(){
		facingRight=!facingRight;
		Vector3 theScale=transform.localScale;
		theScale.x *=-1;
		transform.localScale=theScale;
	}	
}
