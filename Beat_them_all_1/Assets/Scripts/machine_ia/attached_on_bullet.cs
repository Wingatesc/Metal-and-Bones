using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attached_on_bullet : MonoBehaviour {
    public Rigidbody2D rb;
    public int longueur;
    public int hauteur;
    public float damage=0.15f;
    public vie_player vie_perso;
    public AudioSource son;
    public TrailRenderer trail;
    public SpriteRenderer spriite;
    public float R;
    public float V;
    public float B;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * longueur,ForceMode2D.Impulse);
        trail = GetComponent<TrailRenderer>();
        trail.sortingLayerName = "sol";
        spriite = GetComponent<SpriteRenderer>();
    }


    // Update is called once per frame
   void OnCollisionEnter2D(Collision2D other)
    {
        
        if (other.gameObject.tag=="Player"){
            vie_perso.flash = true;
            son.Play();
            vie_perso.current_life = vie_perso.current_life - damage;
            Destroy(this.gameObject);       
        }
      
    }
    void OnTriggerEnter2D(Collider2D otherr)
    {
        if (otherr.gameObject.tag == "Pouss")
        {
            spriite.color = new Color(R, V, B, 1);
            gameObject.layer = 15;
            tag = "Bullet";
            float alpha = 1.0f;
            Gradient gradient = new Gradient();
            gradient.SetKeys(
                 // new GradientColorKey[] { new GradientColorKey(Color.HSVToRGB(R,V,B), 0.0f), new GradientColorKey(Color.HSVToRGB(R/2, V/2, B/2), 1.0f)
                  new GradientColorKey[] { new GradientColorKey(new Color(R,V,B), 0.0f), new GradientColorKey(new Color(R, V, B), 1.0f)},
                 new GradientAlphaKey[] { new GradientAlphaKey(alpha, 0.0f), new GradientAlphaKey(alpha, 1.0f) }
                 );
            trail.colorGradient = gradient;

        }
    }
}
