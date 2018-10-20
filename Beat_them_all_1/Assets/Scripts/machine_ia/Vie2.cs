using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vie2 : MonoBehaviour
{
    public float starting_life = 50f;
    public float current_life;
    public float temps_disapear = 0f;
    public GameObject health_bar;
    public GameObject health_bar_rouge;
    public attached_on_bullet Object_prime_bullet;
    public float damages;
    public float velocity_obj;
    public float damages_obj;
    public bool techBool;
    public GameObject machineGun;
    public AudioSource mort;
    public AudioSource hurt;
    public Super_techniques super_tech;
    public Score score;
    public Panel_score_fin panel_score_fin;
    public int gain_point;
    public bool point = false;
    // Use this for initialization
    void Start()
    {


        current_life = starting_life;
        health_bar_rouge.transform.localScale = new Vector2(starting_life, health_bar.transform.localScale.y);
        // InvokeRepeating("technique", 0, 1);
    }
    void Update()
    {
        if (current_life <= 0)
        {
            //  super_tech.Ultra_power = super_tech.Ultra_power + 1;
            mort.Play();
            Destroy(machineGun, temps_disapear);

            health_bar.transform.localScale = new Vector2((0), health_bar.transform.localScale.y);
            if (!point)
            {
                score.point = score.point + gain_point;
                panel_score_fin.turret_down += 1;
                point = true;
            }
        }
        else
        {
            health_bar.transform.localScale = new Vector2(current_life, health_bar.transform.localScale.y);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            hurt.Play();
            current_life = current_life - damages;
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Obj_physic" && Mathf.Abs(other.rigidbody.velocity.y) >= velocity_obj)
        {
            hurt.Play();
            current_life = current_life - damages_obj;

        }
        if (other.gameObject.tag == "poing")
        {
            hurt.Play();
            current_life = current_life - damages / 2;

        }

    }
    /* void technique()
     {
         if (current_life <= 0 && techBool)
         {
             super_tech.Ultra_power = super_tech.Ultra_power + 1;
             techBool = false;
         }

     }*/
}
