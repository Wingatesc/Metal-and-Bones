using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tuto_destroy_wall : MonoBehaviour {
    public GameObject txt;
    public GameObject mur_a_delete;
    public GameObject mur_a_delete2;
    public float timer;
    public float time_max=2f;
    public bool start_timer;

    // Use this for initialization
    void Start () {
        txt.SetActive(false);
        start_timer = false;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            txt.SetActive(true);
            start_timer = true;

        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            txt.SetActive(false);

        }
    }
    // Update is called once per frame
    void Update () {
        if (start_timer)
        {
            timer += Time.deltaTime;
        }
        if (timer > time_max)
        {
            txt.SetActive(false);
            Destroy(mur_a_delete);
            Destroy(mur_a_delete2);
            Destroy(this.gameObject,1);
        }
	}
}
