﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEditor;

public class loadappli_but_fix : MonoBehaviour {

    //public SceneAsset Scene;
    public string levelname;

    public void OnClick(){
        // SceneManager.LoadScene(levelname, LoadSceneMode.Single);
        Application.LoadLevel(levelname);

    }

}
