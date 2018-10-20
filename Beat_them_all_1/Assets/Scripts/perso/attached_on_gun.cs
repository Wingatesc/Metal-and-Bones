using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attached_on_gun : MonoBehaviour {
    public Rigidbody2D rb;
    public int longueur;
    public int hauteur;
    public character_move move_perso;
    public TrailRenderer trail;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        move_perso = GameObject.Find("perso 1").GetComponent<character_move>();
        if (move_perso.facingRight)
        {
            rb.AddForce(transform.right * longueur, ForceMode2D.Impulse);
        }else
        {
            rb.AddForce(transform.right * -longueur, ForceMode2D.Impulse);
        }
        trail = GetComponent<TrailRenderer>();
        trail.sortingLayerName = "sol";
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "adversaire"|| other.gameObject.tag == "Wood")
        { 
            Destroy(this.gameObject); 
        }
    }
	
	// Update is called once per frame
}
