using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gain_vie : MonoBehaviour {
    public vie_player vie_perso;
    public float timer;
    public float health;
    public AudioSource son;
    void Start(){
        GameObject music = GameObject.Find("health_up");
        GameObject player = GameObject.Find("perso 1");
        vie_perso = player.GetComponent<vie_player>();
        son = music.GetComponent<AudioSource>();

    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            son.Play();
            vie_perso.current_life = vie_perso.current_life + health;
            Destroy(this.gameObject, timer);
        }
    }
}
