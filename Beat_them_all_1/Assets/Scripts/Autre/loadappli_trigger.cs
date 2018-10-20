using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class loadappli_trigger : MonoBehaviour {
	public string levelname;
	void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(levelname, LoadSceneMode.Single);
        }   
	}

}
