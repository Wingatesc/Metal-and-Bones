using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class select_lvl_click : MonoBehaviour {
    public string levelname;
    public SpriteRenderer spriite;
    public ParticleSystem parti;
    public AudioSource son;
    public float R;
    public float V;
    public float B;
    void Start()
    {
        spriite = GetComponent<SpriteRenderer>();
        parti = GetComponent<ParticleSystem>();
        R= GetComponent<SpriteRenderer>().color.r;
        V = GetComponent<SpriteRenderer>().color.g;
        B = GetComponent<SpriteRenderer>().color.b;

    }
    void OnMouseEnter()
    {
        spriite.color = new Color(0.9f, 0.8f, 1);
    }
    void OnMouseDown()
    {
        son.Play();
        parti.Play();
        Invoke("ChangeLvl", 2);
       
    }
    void ChangeLvl() {
        SceneManager.LoadScene(levelname);
    }
    void OnMouseExit()
    {
        spriite.color = new Color(R, V, B);
    }
  

}
