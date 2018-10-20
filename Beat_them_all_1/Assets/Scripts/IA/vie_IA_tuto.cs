using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class vie_IA_tuto : MonoBehaviour {
	public float starting_life=50f;
	public float current_life;
    public Poing poing;
	public float temps_disapear=2f;
    public bool hurt_poing;
    public GameObject health_bar;
    public GameObject health_bar_rouge;
    public Rigidbody2D rb;
    public bool flash;
    public float timer;
    public SpriteRenderer spriite;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
		current_life = starting_life;   
        health_bar_rouge.transform.localScale = new Vector2(starting_life, health_bar.transform.localScale.y);
        spriite = GetComponent<SpriteRenderer>();

    }
	
	// Update is called once per frame
	void Update () {
        if (current_life <= 0.05)
        {
             health_bar.transform.localScale = new Vector2(0, health_bar.transform.localScale.y);
            Destroy(this.gameObject, temps_disapear);
        }
        else
        {
            health_bar.transform.localScale = new Vector2(current_life, health_bar.transform.localScale.y);
        }
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

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("poing"))
        {
            flash = true;
            current_life = current_life - poing.damages;
        }
      

    }

}
