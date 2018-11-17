using UnityEngine;
using System.Collections;

public class IA_4 : MonoBehaviour
{
    public bool patroling;
    public bool chasing;
    public bool attacking;
    //********New attack model********
    public bool attacking2;
    public bool stuned1;
    public bool stuned2;
    public bool GonnaAttack1 = false;
    public bool GonnaAttack2;
    public float timerFlashAtck;
    public float timeGonnaAtck = 1f; //time where the character indicates he is gonn attack
    public float timerStun;
    public float timerStopStun;
    //************************************
    public SpriteRenderer flip;
    public character_move perso_move;
    public vie_player vie_perso;
    public Transform milieu;
    public Transform perso_chase;
    public int speed_patrol = 3;
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
    public bool droite = true;
    public AudioSource sword;
    // Use this for initialization
    void Start()
    {
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
    void stuned()
    {
        rb.bodyType = RigidbodyType2D.Kinematic;
        chasing = false;
        patroling = false;
        attacking = false;
        attacking2 = false;
        GonnaAttack1 = false;
        GonnaAttack2 = false;
        anim.SetBool("Stun1", true);
        timerStun += Time.deltaTime;
        if (timerStun >= timerStopStun)
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
            timerStun = 0;
            stuned1 = false;
            stuned2 = false;
            anim.SetBool("Stun1", false);
            flip.color = new Color(1, 1f, 1f, 1f);
        }
    }
    void Update()
    {

        if (!patroling&&!stuned1&&!stuned2)
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
        if (!attacking && !stuned1&& !stuned2&& Mathf.Round(distance) <= distance_chase && Mathf.Abs(perso_chase.position.y - rb.position.y) < 1)
         {
             chase_chase();

         }
      /*  if (!attacking && Mathf.Round(distance) <= distance_chase && Mathf.Abs(perso_chase.position.y - rb.position.y) < 1)
        {
            chase_chase();

        }*/
        if (Mathf.Round(distance) >= distance_chase)
        {
            patroling = true;
        }
        if (Mathf.Round(distance) <= distance_attack)
        {
            attacking = true;
        }
        else
        {
            attacking = false;
        }
        if (stuned1)
        {
            stuned();
        }
        if (droite)
        {

            flip.flipX = false;
        }
        else
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
        if (timerFlashAtck <= timeGonnaAtck)
        {
            timerFlashAtck += Time.deltaTime;
            flip.color = new Color(0.1f, 0.5f, 1f, 1f);
            GonnaAttack1 = true;
        }

        if (timerFlashAtck > timeGonnaAtck)
        {
            flip.color = new Color(1, 1f, 1f, 1f);
            chasing = false;
            patroling = false;
            timer_attack = 0f;
            sword.Play();
            anim.SetTrigger("attack");
            vie_perso.current_life = vie_perso.current_life - damages;
            vie_perso.flash = true;
            timerFlashAtck = 0;
            GonnaAttack1 = false;
        }
    }
    void OuEstLePerso()
    {

        distance = Vector2.Distance(perso_chase.transform.position, rb.transform.position);
    }

    void Perso_chase()
    {
        position_perso = perso_chase.transform.position.x;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("void on trigger");
        if (collision.gameObject.tag == ("Pouss") && GonnaAttack1)
        {
            Debug.Log("collide with pouss");
            stuned1 = true;
           
        }
        if (collision.gameObject.tag == ("Aspire") && GonnaAttack2)
        {
            stuned2 = true;
        }
    }
}