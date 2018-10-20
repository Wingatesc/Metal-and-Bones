using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class vie_IA2 : MonoBehaviour {
    public float starting_life = 50f;
    public float current_life;
    public Animator anim;
    public Poing poing;
    public IA_3 script_IA3;
    public float temps_disapear = 2f;
    public bool hurt_poing;
    public GameObject health_bar;
    public GameObject health_bar_rouge;
    public Rigidbody2D rb;
    public float velocity_obj;
    public float damages_obj;
    public AudioSource mort;
    public AudioSource hurt;
    public int compteur_son;
    public Super_techniques super_tech;
    private bool unPoint = true;
    public bool flash;
    public float timer;
    public SpriteRenderer spriite;
    public Score score;
    public Panel_score_fin panel_score_fin;
    public int gain_point;
    public bool point = false;
    // Use this for initialization
    void Start()
    {
        script_IA3 = GetComponent<IA_3>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        spriite = GetComponent<SpriteRenderer>(); 
        health_bar_rouge.transform.localScale = new Vector2(starting_life, health_bar.transform.localScale.y);
    }

    // Update is called once per frame
    void Update()
    {
        if (current_life <= 0.05f)
        {
            health_bar.transform.localScale = new Vector2(0.0f, health_bar.transform.localScale.y);
            anim.SetTrigger("isDead");
            script_IA3.enabled = false;
            gameObject.layer = 11;
            Son_mort();
            Destroy(this.gameObject, temps_disapear);
            if (!point)
            {
                score.point = score.point + gain_point;
                panel_score_fin.adv_down += 1;
                point = true;
            }
        }
        else
        {
            health_bar.transform.localScale = new Vector2(current_life, health_bar.transform.localScale.y);
        }
        if (flash)
        {
            spriite.color = new Color(1, 0.1f, 0.1f, 0.7f);
            timer += Time.deltaTime;
        }

        if (timer > 0.2f && flash)
        {
            spriite.color = new Color(1, 1, 1, 1);
            timer = 0;
            flash = false;
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("poing"))
        {
            hurt.Play();
            current_life = current_life - poing.damages;
            flash = true;

        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Obj_physic" && Mathf.Abs(other.rigidbody.velocity.y) >= velocity_obj)
        {
            current_life = current_life - damages_obj;
            hurt.Play();
            flash = true;
        }
        if (other.gameObject.tag == "poing")
        {
            current_life = current_life - poing.damages;
            hurt.Play();
            flash = true;
        }
    }
    void Son_mort()
    {
        if (!mort.isPlaying && compteur_son == 0)
            mort.Play();
        compteur_son = 1;
    }
    /* void techPlusUn()
     {
         if (current_life <= 0.05f&&unPoint)
         {
             super_tech.Ultra_power = super_tech.Ultra_power + 1;
             unPoint = false;
         }
     }*/

}

