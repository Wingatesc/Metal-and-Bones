using UnityEngine;
using System.Collections;

public class IA_2 : MonoBehaviour {
    public bool patroling;
    public bool chasing;
    public bool attacking;
    public SpriteRenderer flip;
    public character_move perso_move;
    public vie_player vie_perso;
    public Transform depart;
    public Transform arrivee;
    public Transform perso_chase;
    public int speed_patrol=3;
    public int speed_chase = 3;
    public int starting_life = 50;
    public int current_life;
    public float distance;
    public float distanceMax;
    public float distance_attack;
    public float timer_attack;
    public float time_btw_attacks;
    public float damages;
    public Animator anim;
    public Rigidbody2D rb;
    public bool droite=true;
    // Use this for initialization
    void Start () {
        current_life = starting_life;
        rb = GetComponent<Rigidbody2D>();
        flip = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        timer_attack += Time.deltaTime;
        distance = Vector2.Distance(perso_chase.transform.position, rb.transform.position);
        if (timer_attack >= time_btw_attacks && attacking == true)
        {
            Attack_attack();
        }
     
        if (patroling)
        {
            anim.SetBool("chase", false);
            anim.SetBool("attack", false);
            chasing = false;
            attacking = false;
            rb.velocity = new Vector2(speed_patrol, rb.velocity.y);
        }
        if (Mathf.Round(distance) >= distance_attack&& Mathf.Round(distance) <= distanceMax)
        {
            chase_chase();
        }else
        {
            chasing = false;
    
        }
        if (Mathf.Round(distance) >= distanceMax)
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
   
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("mur"))
        {
            // Flip();
            droite = !droite;
            speed_patrol = speed_patrol * -1;
        }
    }
  /*  void Flip()
    {
        droite = !droite; 
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }*/
    void chase_chase()
    {
        anim.SetBool("chase", true);
        anim.SetBool("attack", false);
        chasing = true;
        patroling = false;
        attacking = false;
      
        if (rb.transform.position.x < perso_chase.transform.position.x&&droite)
        {
            rb.velocity = new Vector2(speed_chase, rb.velocity.y);
        }
        if (rb.transform.position.x < perso_chase.transform.position.x && !droite)
        {
           // rb.velocity = new Vector2(speed_chase, rb.velocity.y);
            //  Flip();
            droite = true;
            rb.velocity = new Vector2(speed_chase, rb.velocity.y);
        }
        if (rb.transform.position.x > perso_chase.transform.position.x&&droite)
        {
           // rb.velocity = new Vector2(-speed_chase, rb.velocity.y);
            // Flip();
            droite = false;
            rb.velocity = new Vector2(-speed_chase, rb.velocity.y);
        }
        if (rb.transform.position.x > perso_chase.transform.position.x && !droite)
        {
            // rb.velocity = new Vector2(-speed_chase, rb.velocity.y);
            rb.velocity = new Vector2(-speed_chase, rb.velocity.y);
        }

    }
    void Patrol_patrol()
    {
        chasing = false;
        attacking = false;    
    }
    void Attack_attack()
    {
        chasing = false;
        patroling = false;
        timer_attack = 0f;
       
        anim.SetTrigger("attack");
        vie_perso.current_life = vie_perso.current_life - damages;
        vie_perso.flash=true;
    }
}
