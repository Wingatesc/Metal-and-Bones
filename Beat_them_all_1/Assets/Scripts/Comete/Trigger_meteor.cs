using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_meteor : MonoBehaviour {
    public GameObject meteor;
    public meteor script;


	void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player"))
        {
            script.En_mouvement = true;
        }

	}
    void OnTriggerExit2D(Collider2D other)
    {
       
        if (other.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }

    }
}
