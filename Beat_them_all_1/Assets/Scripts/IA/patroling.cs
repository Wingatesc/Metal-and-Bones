using UnityEngine;
using System.Collections;

public class patroling : MonoBehaviour {
    public Transform depart;
    public Transform arrivee;
    public IA_2 adv;
    public bool droite = true;
    public float speed = 8f;
    public Rigidbody2D rb;
    // Use this for initialization
    void Start () {
       
    }

   
    void Update()
    {
        if (adv.patroling)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("mur"))
        {
            Flip();
            speed = speed * -1;
        }
    }
    void Flip()
    {
        droite = !droite;
        //speed=speed*-1;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
