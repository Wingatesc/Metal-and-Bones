using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vie : MonoBehaviour {
    public float starting_life = 50f;
    public float current_life;
    public float temps_disapear = 0f;
    public GameObject health_bar;
    public GameObject health_bar_rouge;
    public attached_on_bullet Object_prime_bullet;
    public float damages;
    public float velocity_obj=5;
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
        GameObject music = GameObject.Find("turret_meurt");
        GameObject music2 = GameObject.Find("get_hit");
        mort = music.GetComponent<AudioSource>();
        hurt = music2.GetComponent<AudioSource>();
        machineGun = transform.parent.gameObject;
    }
    void Update()
    {
        if (current_life <= 0)
        {
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

        if (other.gameObject.tag == "poing")
        {
            hurt.Play();
            current_life = current_life - damages / 2;

        }
        /*     if (other.gameObject.tag == "Obj_physic" && other.gameObject.GetComponent<On_object_hurt_2>().damage_On == true|| other.gameObject.tag == "Untagged" && other.gameObject.GetComponent<On_object_hurt_2>().damage_On == true)
             {
                 hurt.Play();
                 current_life = current_life - other.gameObject.GetComponent<On_object_hurt_2>().velocity_hurt*4;

             }*/
        if (other.gameObject.tag == "Obj_physic" && other.gameObject.GetComponent<On_object_hurt_2>() || other.gameObject.tag == "Untagged" && other.gameObject.GetComponent<On_object_hurt_2>())
        {
            if (other.gameObject.GetComponent<On_object_hurt_2>().damage_On == true)
            {
                hurt.Play();
                current_life = current_life - other.gameObject.GetComponent<On_object_hurt_2>().velocity_hurt * 4;
            }

        }

    }
}
