using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class restart_lvl : MonoBehaviour {
    public Scene scene;
	// Use this for initialization
    public void Start()
    {
        scene = SceneManager.GetActiveScene();
    }
	void Update() {
		if (Input.GetKey (KeyCode.Return)) {		
            SceneManager.LoadScene(scene.name,LoadSceneMode.Single);            
		}
	}
}
