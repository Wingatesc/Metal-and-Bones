using UnityEngine;
using System.Collections;

public class IA_3_adv2 : MonoBehaviour {
    public bool patroling;
    public bool chasing;
    public bool attacking;
    public bool stillness;
    public SpriteRenderer flip;
    public CapsuleCollider2D coll;
    public character_move perso_move;
    public vie_player vie_perso;
    public Transform milieu;
    public Transform perso_chase;
    public int speed_patrol=3;
    public int speed_chase = 3;
    public int starting_life = 50;
    public int current_life;
    public float position_perso;
    public float distance;
    public float distance_chase;
    public float distance_patrol;
    public float distance_patrol_plus;
    public float distance_patrol_moins;
    public float distance_attack;
    public float timer_attack;
    public float time_btw_attacks;
    public float damages;
    public Animator anim;
    public Rigidbody2D rb;
    public bool droite=true;
    public AudioSource sword;
    // Use this for initialization
    void Start () {
        current_life = starting_life;
        distance_patrol_plus = milieu.position.x + distance_patrol;
        distance_patrol_moins = milieu.position.x - distance_patrol;
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<CapsuleCollider2D>();
        flip = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        InvokeRepeating("OuEstLePerso", 0, 0.7f); 

    }

    void Update()
    {
        if (stillness)
        {
            speed_patrol = 0;
        }
        if (!patroling)
        {
            timer_attack += Time.deltaTime;
        }
        if (timer_attack >= time_btw_attacks && attacking == true)
        {
            Attack_attack();
        }
     
        if (patroling)
        {
            rb.velocity = new Vector2(speed_patrol, rb.velocity.y);
            Patrol_patrol();  
        }
        /* if (!attacking&&Mathf.Round(distance) <= distance_chase)
         {
             chase_chase();

         }*/
        if (!attacking && Mathf.Round(distance) <= distance_chase && Mathf.Abs(perso_chase.position.y - rb.position.y) < 1)
        {
            chase_chase();

        }
        if (Mathf.Round(distance) >= distance_chase)
        {
            patroling = true;
        }
        if (Mathf.Round(distance) <= distance_attack)
        {
            attacking = true;
        }else
        {
            attacking = false;
        }
        if (droite)
        {
           
            flip.flipX = false;
        }else
        {           
            flip.flipX = true;
        }
    }
    void chase_chase()
    { 
       // coll.size = new Vector2(0.4f, 2.29f);
        coll.offset = new Vector2(0, -0.06f);
        coll.size = new Vector2(0.68f, 2.42f);
        anim.SetBool("chase", true);
        anim.SetBool("attack", false);
        stillness = false;
        chasing = true;
        patroling = false;
        attacking = false;    
        if (rb.transform.position.x < perso_chase.transform.position.x)
        {
            coll.offset = new Vector2(0.55f, 0.06f);
            rb.velocity = new Vector2(speed_chase, rb.velocity.y);
            droite = true;
        }
       
        if (rb.transform.position.x > perso_chase.transform.position.x)
        {
            coll.offset = new Vector2(-0.69f, 0.06f);
            droite = false;
            rb.velocity = new Vector2(-speed_chase, rb.velocity.y);
        }
    }
    void Patrol_patrol()
    {
        coll.offset= new Vector2(-0.1f, -0.45f);
        coll.size = new Vector2(0.4f,1.56f);
        anim.SetBool("chase", false);
        anim.SetBool("attack", false);
        stillness = false;
        chasing = false;
        attacking = false;
        if (rb.transform.position.x >= distance_patrol_plus)
        {
            droite = false;
            speed_patrol = -2;
        }
        if (rb.transform.position.x <= distance_patrol_moins)
        {
            droite = true;
            speed_patrol = 2;
        }
    }
  
    void Attack_attack()
    {
        coll.offset = new Vector2(0, -0.06f);
        coll.size = new Vector2(0.68f, 2.42f);
        chasing = false;
        patroling = false;
        stillness = false;
        timer_attack = 0f;
        sword.Play();
        anim.SetTrigger("attack");
        vie_perso.current_life = vie_perso.current_life - damages;
        vie_perso.flash = true;
    }
    void OuEstLePerso()
    {
        distance = Vector2.Distance(perso_chase.transform.position, rb.transform.position);
    }
    void Perso_chase()
    {
        position_perso = perso_chase.transform.position.x;
    }
   void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("mur"))
        {
            patroling = false;
            stillness = true;
        }
    }
}
