using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_bullets_pickUp : MonoBehaviour {
    public Super_techniques super_Tech;
    public AudioSource son;
    public bool can = true;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")&&super_Tech.Ultra_power<4&&can)
        {
            son.Play();
            super_Tech.Ultra_power = super_Tech.Ultra_power + 1;
            can = false;
            Destroy(gameObject);
        }
    }
}
