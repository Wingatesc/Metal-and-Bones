using UnityEngine;
using System.Collections;

public class IA_3 : MonoBehaviour {
    public bool patroling;
    public bool chasing;
    public bool attacking;
    public SpriteRenderer flip;
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
        flip = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        InvokeRepeating("OuEstLePerso", 0, 0.7f);
        GameObject player = GameObject.Find("perso 1");
        perso_chase = player.transform;
        vie_perso = perso_chase.GetComponent<vie_player>();
        perso_move = perso_chase.GetComponent<character_move>();
        GameObject music = GameObject.Find("adv_1_attck");
        sword = music.GetComponent<AudioSource>();
    }

    void Update()
    {
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
        /*if (!attacking&&Mathf.Round(distance) <= distance_chase)
        {
            chase_chase();

        }*/
        if (!attacking && Mathf.Round(distance) <= distance_chase&& Mathf.Abs(perso_chase.position.y - rb.position.y)<1)
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
        anim.SetBool("chase", true);
        anim.SetBool("attack", false);
        chasing = true;
        patroling = false;
        attacking = false;    
        if (rb.transform.position.x < perso_chase.transform.position.x)
        {
            rb.velocity = new Vector2(speed_chase, rb.velocity.y);
            droite = true;
        }
       
        if (rb.transform.position.x > perso_chase.transform.position.x)
        {
            droite = false;
            rb.velocity = new Vector2(-speed_chase, rb.velocity.y);
        }
    }
    void Patrol_patrol()
    {
        chasing = false;
        attacking = false;
        anim.SetBool("chase", false);
        anim.SetBool("attack", false);
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
        chasing = false;
        patroling = false;
        timer_attack = 0f;
        sword.Play();
        anim.SetTrigger("attack");
        vie_perso.current_life = vie_perso.current_life - damages;
        vie_perso.flash = true;
    }
    void OuEstLePerso()
    {
        //distance = Vector2.Distance(perso_chase.transform.position, rb.transform.position);
        /* if (Vector2.Distance(perso_chase.transform.position, rb.transform.position)<1)
         {
             distance = Mathf.Abs(perso_chase.position.x - rb.position.x);
             Vector2.Distance(perso_chase.transform.position, rb.transform.position);
         }*/

        distance = Vector2.Distance(perso_chase.transform.position, rb.transform.position);

        // distance = Vector2.Distance(perso_chase.transform.position, rb.transform.position);


    }
    void Perso_chase()
    {
        position_perso = perso_chase.transform.position.x;
    }
}
