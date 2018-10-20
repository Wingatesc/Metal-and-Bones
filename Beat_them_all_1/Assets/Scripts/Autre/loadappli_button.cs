using UnityEngine;
using System.Collections;

public class loadappli_button : MonoBehaviour {
	public string levelname;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame


	public void OnClick(){
		Application.LoadLevel(levelname);

	}

}
