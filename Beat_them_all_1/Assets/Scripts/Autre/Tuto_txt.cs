using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Tuto_txt : MonoBehaviour {
    public GameObject txt;
	// Use this for initialization
	void Start () {
        txt.SetActive(false);
    }
	
	// Update is called once per frame
	void OnTriggerEnter2D (Collider2D other) {
        if (other.gameObject.CompareTag("Player"))
        {
            txt.SetActive(true);
           
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            txt.SetActive(false);

        }
    }
}
