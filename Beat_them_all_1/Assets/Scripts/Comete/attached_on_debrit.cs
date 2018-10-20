using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attached_on_debrit : MonoBehaviour {
    //public GameObject debrit_clone;
    public float forceX;
    public float forceY;
    public int state;
    public Rigidbody2D rb;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();      
        rb.AddForce(new Vector2(Random.Range(-0.5f, 0.5f) * forceX, forceY));
       
    }   
}
