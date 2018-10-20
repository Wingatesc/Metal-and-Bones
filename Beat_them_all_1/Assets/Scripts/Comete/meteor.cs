using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meteor : MonoBehaviour
{
    public bool En_mouvement;
    public bool detruit;
    public float speedX;
    public float speedY;
    public GameObject clone_debrit;
    public Rigidbody2D rb;
    public vie_player player;
    public GameObject debrit;
    public Transform[] appari_spots;
    public TrailRenderer trail;
    public AudioSource fiou;
    public AudioSource boom;
    public int compteur_fiou=0;
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        trail = GetComponent<TrailRenderer>();
        trail.sortingLayerName = "sol";
        InvokeRepeating("OnTheMove", 0, 0.1f);
    }
    void OnCollisionEnter2D()
    {
        explode();
        Destroy(this.gameObject);
       
    }
    void explode()
    {
        boom.Play();
        int SpawnPointIndex = Random.Range(0, appari_spots.Length);
        clone_debrit =Instantiate(debrit, appari_spots[0].position, appari_spots[0].rotation);
        clone_debrit = Instantiate(debrit, appari_spots[1].position, appari_spots[1].rotation);
        clone_debrit = Instantiate(debrit, appari_spots[2].position, appari_spots[2].rotation);
        clone_debrit = Instantiate(debrit, appari_spots[3].position, appari_spots[3].rotation);
        clone_debrit = Instantiate(debrit, appari_spots[4].position, appari_spots[4].rotation);  
    }
    void OnTheMove()
    {
        if (En_mouvement)
        {
            Son_woosh();
            rb.gravityScale = 1;
            rb.AddForce(new Vector2(speedX, speedY));
        }
    }
    void Son_woosh()
    {
       /* if (!fiou.isPlaying && compteur_fiou == 0)
         
            fiou.Play();
        compteur_fiou = 1;*/
        if (compteur_fiou == 0)

            fiou.Play();
        compteur_fiou = 1;
    }
}