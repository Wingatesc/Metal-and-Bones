using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_doors : MonoBehaviour {

    public Rigidbody2D rb;
    public float velocity_destroy;
    public float vitesse;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D other)
    {
        
        if (vitesse >= velocity_destroy)
        {
            Destroy(this.gameObject);
        }
    }
    void FixedUpdate()
    {
        vitesse = Mathf.Abs(rb.velocity.y);
      
    }

}
