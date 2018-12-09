using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEditor;

public class loadappli_button : MonoBehaviour {

    //public SceneAsset Scene;
    public string levelname;

    public void OnClick(){
        SceneManager.LoadScene(levelname, LoadSceneMode.Single);

    }

}
