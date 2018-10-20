using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attached_on_piege_boule : MonoBehaviour {
    public Rigidbody2D rb;
    public int hauteur;
    public float damage;
    public vie_player vie_perso;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
      // rb.AddForce(new Vector2(longueur, hauteur));
        rb.AddForce(transform.right * hauteur, ForceMode2D.Impulse);
    }
    void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.tag == "Player")
        {
            vie_perso.flash = true;
         //   son.Play();
            vie_perso.current_life = vie_perso.current_life - damage;
            Destroy(this.gameObject);
        }
        if (other.gameObject.tag == "adversaire")
        {
            Destroy(this.gameObject);
        }
    }
}