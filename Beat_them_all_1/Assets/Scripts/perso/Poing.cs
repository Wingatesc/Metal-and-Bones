using UnityEngine;
using System.Collections;
public class Poing : MonoBehaviour
{
    public float spot1;
    public float spot2;
    public GameObject ball;
    public GameObject bullet_super;
    private GameObject clone_bullet;
    public GameObject pousse;
    public GameObject attract;
    private GameObject attract_clone;
    private GameObject pousse_clone;
    public character_move move_perso;
    private GameObject clone;
    public Transform[] appari_spots;
    public float damages;
    public int vitesse_power;
    public Animator anim;
    public float timer_pousse;
    public float timer_punch;
    private float timer_gun;
    public float timer_att;
    public float time_btw_att;
    public float time_btw_pousse;
    public float time_btw_poing;
    public int gun;
    public int state;
    public AudioSource son_poing_whoosh;
    public AudioSource son_pouss;
    public AudioSource guns;
    public AudioSource attire;
    public Super_techniques tech_script;
    private bool superGun = false;
    public float timer_combo;
    public float timer_power;
    public bool peut_attirer = true;
    public bool peut_attirer2 = true;
    private bool peut_pouss=true;
    // Use this for initialization
    void Start()
    {
       
        anim = GetComponent<Animator>();
        state = 0;
        InvokeRepeating("combo", 0, 0.1f);
      /*  peut_attirer = false;*/
        GameObject music = GameObject.Find("Attire");
        GameObject music2 = GameObject.Find("guns_perso");
        GameObject music3 = GameObject.Find("power_pouss");
        GameObject music4 = GameObject.Find("poing_woosh");
        attire = music.GetComponent<AudioSource>();
        guns = music2.GetComponent<AudioSource>();
       son_pouss = music3.GetComponent<AudioSource>();
        son_poing_whoosh = music4.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Punch()
    {
        int SpawnPointIndex = Random.Range(0, appari_spots.Length);
        clone = Instantiate(ball, appari_spots[0].position, appari_spots[0].rotation);
        Destroy(clone, 0.2f);
        if (state == 0 && move_perso.grounded)
        {
            timer_combo = 0;
            anim.SetTrigger("poing_trig");

        }
        if (state == 1 && move_perso.grounded)
        {
            anim.SetTrigger("poing_trig");
            timer_combo = 0;

        }
        if (state == 2 && move_perso.grounded)
        {
            timer_combo = 0;

            anim.SetTrigger("poing_trig2");

        }
        if (state == 3 && move_perso.grounded)
        {
            anim.SetTrigger("poing_trig3");
            timer_combo = 0;

        }
        if (state == 4 && move_perso.grounded)
        {
            anim.SetTrigger("poing_trig4");
            timer_combo = 0;
            state = -1;

        }

        if (move_perso.grounded == false)
        {
            anim.SetTrigger("poing_air");
        }

    }

    void Projection()
    {

        pousse_clone = Instantiate(pousse, appari_spots[1].position, appari_spots[1].rotation);
        pousse_clone.GetComponent<Rigidbody2D>().AddForce(new Vector2(vitesse_power * move_perso.transform.localScale.x, 0));

        Destroy(pousse_clone, 0.5f);

    }
    void attirer()
    {
        attract_clone = Instantiate(attract, appari_spots[2].position, appari_spots[2].rotation);     
    }
    void Super_tech_flingues()
    {
        guns.Play();
        clone_bullet = Instantiate(bullet_super, appari_spots[3].position, appari_spots[3].rotation);
        Destroy(clone_bullet, 3);
        clone_bullet = Instantiate(bullet_super, appari_spots[4].position, appari_spots[4].rotation);
        Destroy(clone_bullet, 3);
        clone_bullet = Instantiate(bullet_super, appari_spots[5].position, appari_spots[5].rotation);
        Destroy(clone_bullet, 3);
        clone_bullet = Instantiate(bullet_super, appari_spots[6].position, appari_spots[6].rotation);
        Destroy(clone_bullet, 3);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Z)|| Input.GetKey(KeyCode.W))
        {
            anim.SetBool("marche", false);
        }
        timer_pousse += Time.deltaTime;
        timer_punch += Time.deltaTime;
        timer_combo += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Z) && timer_punch > time_btw_poing|| Input.GetKeyDown(KeyCode.W) && timer_punch > time_btw_poing)
        {
            Punch();
            timer_punch = 0;
            state = state + 1;
            son_poing_whoosh.Play();    
        }
        //*****************************************************************
        if (Input.GetKeyDown(KeyCode.E)&& peut_attirer)
        {
            peut_pouss = false;
            anim.SetTrigger("attract");
            attirer();
            attire.Play();           
        }

        if (Input.GetKeyUp(KeyCode.E))

        {
            peut_pouss = true;
            attire.Stop();
            Destroy(attract_clone);
        }
        if (Input.GetKeyDown(KeyCode.R) && timer_power <= 1&&peut_pouss)
        {
            if (timer_pousse > time_btw_pousse)
            {
                son_pouss.Play();
                Projection();
                anim.SetTrigger("Move_Obj_power");
                timer_pousse = 0;
            }

           /* peut_attirer = false;
            peut_attirer2 = false;*/
        }
        if (Input.GetKey(KeyCode.R))
        {
            peut_attirer = false;       
        }
        if (Input.GetKeyUp(KeyCode.R))
        {
            peut_attirer = true;
        }
        //**********************************************************
        if ((Input.GetKeyDown(KeyCode.T) && tech_script.Ultra_power >= 1))
        {
            anim.SetTrigger("Super_tech_gun");
            Super_tech_flingues();
            superGun = true;
            tech_script.Ultra_power = tech_script.Ultra_power - 1;
        }
        if (superGun)
        {
            timer_gun += Time.deltaTime;
        }
        if (timer_gun >= 1 && superGun)
        {
            Super_tech_flingues();
            timer_gun = 0;
            superGun = false;
        }
        if (attract_clone != null)
        {
            attract_clone.transform.position = new Vector2(appari_spots[2].position.x, appari_spots[2].position.y);
        }
    }
    void combo()
    {
        if (timer_combo >= 2)
        {
            state = 0;
        }
    }

}