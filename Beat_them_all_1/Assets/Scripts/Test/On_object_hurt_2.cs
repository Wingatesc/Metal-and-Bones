using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class On_object_hurt_2 : MonoBehaviour
{
    public Rigidbody2D rb;
    public float add_damage;
    public float velocity_hurt;
    public float velocity_size;
    public float velocity_mass;
    public float velocity_hurt_IA;
    public float velocity_hurt_turret;
    public float velocity_object = 5; // if speed is superior to that, it will hurt
    public float vitesse;
    public bool damage_On;
    public bool touching_gound;
    public bool trig=true;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // vie_perso = perso.GetComponent<vie_player>();
        //  Debug.Log("Width of the object = "+transform.localScale.x);
        //  Debug.Log("Height of the object = "+transform.localScale.y);
        velocity_mass = rb.mass / 400;
        velocity_size = ((Mathf.Round(transform.localScale.x * 100) + Mathf.Round(transform.localScale.y * 100)) / 3000);
        velocity_hurt = velocity_size + add_damage + velocity_mass;

        if (velocity_size > 1) {
            velocity_size = 1;
        }
        if (velocity_hurt < 0.1f)
        {
            velocity_hurt = 0.1f;
        }
        // Debug.Log("Damage if it falls on someone = " + velocity_hurt);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Aspire")
        {
           // Debug.Log("trigggggggggggggger");
            trig = false;
        }

    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Aspire")
        {
            //  Debug.Log("ground enter");
            trig = true;
        }

    }
    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.layer == 0 || other.gameObject.tag == "Obj_physic")
        {
            // Debug.Log("ground exit");
            touching_gound = false;

        }
    }
    void OnCollisionStay2D(Collision2D other)
    {
        /* if (other.gameObject.tag == "Player" && damage_On)
         {
             other.gameObject.GetComponent<vie_player>().current_life = other.gameObject.GetComponent<vie_player>().current_life - velocity_hurt;
             other.gameObject.GetComponent<vie_player>().flash = true;
         }
         if (other.gameObject.tag == "adversaire" && damage_On)
         {
            // Debug.Log("touch adv");
             other.gameObject.GetComponentInChildren<vie_IA2>().current_life = other.gameObject.GetComponentInChildren<vie_IA2>().current_life - velocity_hurt;   
         }
         if (other.gameObject.tag == "Wood" && damage_On)
         {
           //  Debug.Log(other.gameObject.name);
             other.gameObject.GetComponentInChildren<Vie2>().current_life = other.gameObject.GetComponentInChildren<Vie>().current_life - velocity_hurt;
         }*/
        if (other.gameObject.layer == 0 || other.gameObject.tag == "Obj_physic")
        {
            //  Debug.Log("ground enter");
            touching_gound = true;
        }

    }
    



    /*  void hurt_perso()
  {
      vie_perso.current_life = vie_perso.current_life - velocity_hurt;
  }
  void hurt_IA()
  {
      vie_perso.current_life = vie_perso.current_life - velocity_hurt;
  }*/

    void FixedUpdate()
    {
        vitesse = Mathf.Abs(rb.velocity.magnitude);
        if (vitesse >= velocity_object && !touching_gound&&trig)
        {
            damage_On = true;
        }
        else
        {
            damage_On = false;
        }
    }
}

