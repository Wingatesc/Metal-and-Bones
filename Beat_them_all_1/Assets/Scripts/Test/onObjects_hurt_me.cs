using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onObjects_hurt_me : MonoBehaviour {
    public Rigidbody2D rb;
    public GameObject perso;
    public vie_player vie_perso;
    public vie_IA_tuto vie_mechant;
    public float velocity_hurt=0.1f;
    public float velocity_hurt_IA=0.1f;
    public float velocity_object;
    public float vitesse;
    public bool damage_On;
    public bool touching_gound;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        vie_perso = perso.GetComponent<vie_player>();

	}

    /* void OnCollisionEnter2D(Collision2D other)
     {

         if (other.gameObject.tag == "Player" && hurtful)
         {
            // Debug.Log(Mathf.Abs(rb.velocity.y));

             vie_perso.current_life = vie_perso.current_life - velocity_hurt;
         }


         if (other.gameObject.tag == "adversaire" && Mathf.Abs(rb.velocity.y) > velocity_object)
         {
            vie_mechant.current_life = vie_mechant.current_life - velocity_hurt_IA;
         }
     }*/
    void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.tag == "Player" && damage_On)
        {
            // Debug.Log(Mathf.Abs(rb.velocity.y));

            vie_perso.current_life = vie_perso.current_life - velocity_hurt;
        }
         if (other.gameObject.tag == "adversaire" && Mathf.Abs(rb.velocity.y) > velocity_object)
   
        {
            vie_mechant.current_life = vie_mechant.current_life - velocity_hurt_IA;
        }
    
    }
    void hurt_perso()
    {
       vie_perso.current_life =vie_perso.current_life - velocity_hurt;
    }
    void hurt_IA()
    {
        vie_perso.current_life = vie_perso.current_life - velocity_hurt_IA;
    }
   /* void Update()
    {
        vitesse = Mathf.Abs(rb.velocity.y);
        if (Mathf.Abs(rb.velocity.y) >= velocity_object)
        {
            hurtful = true;
        }else
        { hurtful = false;
        }
    }*/
    void pasUpdate()
    {
        vitesse = Mathf.Abs(rb.velocity.y);
        if (vitesse >= velocity_object)
        {
            damage_On = true;
        }
        else
        {
            damage_On = false;
        }
    }

}
