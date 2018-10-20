using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class vie_player2 : MonoBehaviour {
    public float current_life;
    public float starting_life;
    public character_move script_move;
    public Image barre;
    public float timer;
    public SpriteRenderer spriite;
    public Animator anim;
    public float velocity_obj;
    public float damages_obj;
    public bool flash;
    public AudioSource ko;
    public AudioSource hurt;
    public int compteur_son;
    public Scene scene;

    void Start()
    {
        current_life = starting_life;
        compteur_son = 0;
        anim = GetComponent<Animator>();
        script_move = GetComponent<character_move>();
        spriite = GetComponent<SpriteRenderer>();
        scene = SceneManager.GetActiveScene();
        InvokeRepeating("loadscenemort", 0, 2);
        InvokeRepeating("vie_max", 0, 1);
    }
    void Update()
    {

        if (barre.fillAmount <= 0.0000f)
        {

            Son_mort();
            anim.SetTrigger("isDead");
            script_move.enabled = false;
        }
        barre.fillAmount = current_life / 2;

        if (flash)
        {
            spriite.color = new Color(1, 0.1f, 0.1f, 0.7f);
            timer += Time.deltaTime;
        }

        if (timer > 0.2f && flash)
        {
            spriite.color = new Color(1, 1, 1, 1);
            timer = 0;
            flash = false;
        }

    }
    void OnCollisionEnter2D(Collision2D other)
    {
        /* if (other.gameObject.tag == "Obj_physic" && Mathf.Abs(other.rigidbody.velocity.y) >= velocity_obj)
         {
             current_life = current_life - damages_obj;
             flash = true;
             hurt.Play();
         }*/
        if (other.gameObject.tag == "Obj_physic" && Mathf.Abs(other.rigidbody.velocity.magnitude) >= velocity_obj)
        {
            current_life = current_life - damages_obj;
            flash = true;
            hurt.Play();
        }
    }
    void Son_mort()
    {
        if (!ko.isPlaying && compteur_son == 0)
            //  ko.PlayOneShot(koClip);
            ko.Play();
        compteur_son = 1;
    }
    public void loadscenemort()
    {
        if (script_move.enabled == false)
        {
            StartCoroutine("Wait");
        }
    }
    public void vie_max()
    {
        if (current_life > starting_life)
        {
            current_life = starting_life;
        }
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3);

        SceneManager.LoadScene(scene.name, LoadSceneMode.Single);
    }
}
