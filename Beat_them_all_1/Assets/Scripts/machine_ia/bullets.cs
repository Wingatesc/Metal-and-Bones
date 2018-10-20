using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullets : MonoBehaviour {
    public bool attacking;
    public bool stand_by;
    public float distance;
    public float distance_attack;
    public float timer_attack;
    public float time_btw_attacks;
    public Rigidbody2D rb;
    public Transform perso;
    public Transform[] gun;
    public GameObject bullet;
    public GameObject bullet_clone;
    public bool peut_tirer;
    public AudioSource son;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("OuEstLePersoTurret", 0, 0.8f);
        gun[0] = transform.GetChild(0);
        bullet = GameObject.Find("bullet_turret");
        GameObject music = GameObject.Find("turret_shoot");
        son = music.GetComponent<AudioSource>(); 
    }
	void Update () {
        timer_attack += Time.deltaTime;

        /*  if (distance < distance_attack&&timer_attack>time_btw_attacks)
          {
              Fire();
              timer_attack = 0;
          }*/
          if(perso.position.y >= transform.position.y)
        {
            peut_tirer = true;
        }else { peut_tirer = false; }
        if (distance < distance_attack && timer_attack > time_btw_attacks&&peut_tirer)
        {
            Fire();
            timer_attack = 0;
        }
    }
    void Fire()
    {
        son.Play();
       // int SpawnPointIndex = Random.Range(0, gun.Length);

        bullet_clone = Instantiate(bullet, gun[0].position, gun[0].rotation);
        Destroy(bullet_clone, 2);
       
    }
    void OuEstLePersoTurret()
    {
        distance = Vector2.Distance(perso.transform.position, transform.position);
    }
}
