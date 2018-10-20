using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piege_a_boules : MonoBehaviour {
    public bool attacking;
    public bool stand_by;
    public float timer_attack;
    public float time_btw_attacks;
    public float timer_attack2;
    public float timer_attack3;
    public Transform[] gun;
    public GameObject bullet;
    public GameObject bullet_clone;
    public GameObject bullet_clone2;
    public GameObject bullet_clone3;
    public GameObject bullet_clone4;
    public GameObject bullet_clone5;
    public GameObject bullet_clone6;
    public bool second_coup;
    public GameObject glyphe_sol;
    public bool troisieme_coup;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer_attack += Time.deltaTime;
        if (timer_attack >= time_btw_attacks&&attacking)
        {
            timer_attack = 0;
            tir();
            second_coup = true;
        }
        if (second_coup)
        {
            timer_attack2 += Time.deltaTime;
        }
        if (timer_attack2 >= 1)
        {
            tir();
            timer_attack2 = 0;
            second_coup = false;
            troisieme_coup = true;
        }
        if (troisieme_coup)
        {
            timer_attack3 += Time.deltaTime;
        }
        if (timer_attack3 >= 1)
        {
            tir();
            timer_attack3 = 0;
            troisieme_coup = false;
        }
    }
    void tir()
    {
        int SpawnPointIndex = Random.Range(0, gun.Length);

        bullet_clone = Instantiate(bullet, gun[0].position, gun[0].rotation);
        bullet_clone2 = Instantiate(bullet, gun[1].position, gun[1].rotation);
        bullet_clone3 = Instantiate(bullet, gun[2].position, gun[2].rotation);
        bullet_clone4 = Instantiate(bullet, gun[3].position, gun[3].rotation);
        bullet_clone5 = Instantiate(bullet, gun[4].position, gun[4].rotation);
        bullet_clone6 = Instantiate(bullet, gun[5].position, gun[5].rotation);
        Destroy(bullet_clone, 3);
        Destroy(bullet_clone2, 3);
        Destroy(bullet_clone3, 3);
        Destroy(bullet_clone4, 3);
        Destroy(bullet_clone5, 3);
        Destroy(bullet_clone6, 3);
    }
}
