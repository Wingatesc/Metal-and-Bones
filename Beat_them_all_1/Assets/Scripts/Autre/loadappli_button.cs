using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEditor;

public class loadappli_button : MonoBehaviour {
    public SceneAsset Scene;
	// Use this for initialization

	public void OnClick(){
         SceneManager.LoadScene(Scene.name);

    }

}
