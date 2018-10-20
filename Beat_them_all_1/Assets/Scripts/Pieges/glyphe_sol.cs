using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class glyphe_sol : MonoBehaviour {
    public Piege_a_boules script;
    public GameObject objet;
    public AudioSource on;
    public AudioSource off;
    public bool vrai=true;

	void OnTriggerEnter2D(Collider2D other)
    {
        if (vrai)
        {
            on.Play();
            objet = other.gameObject;
            script.attacking = false;
            vrai = false;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == objet.name)
        {
            off.Play();
            script.attacking = true;
            vrai = true;
        }
    }
}
