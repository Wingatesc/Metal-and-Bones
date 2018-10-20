using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOverParticles : MonoBehaviour {
    public ParticleSystem parti;
	// Use this for initialization
	void Start () {

       parti= GetComponent<ParticleSystem>();
    }
    void OnMouseExit()
    {
        parti.Stop();
    }
    void OnMouseEnter()
    { 
        parti.Play();
    }

}
