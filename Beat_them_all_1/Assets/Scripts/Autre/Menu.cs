using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class Menu : MonoBehaviour {
    public bool open;
    public GameObject menu;
    void Start () {
        menu = GameObject.Find("Menu");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            open = !open;
        }
        if (open)
        {
            menu.SetActive(true);
        }
        else
        {
            menu.SetActive(false);
        }
    }
}
