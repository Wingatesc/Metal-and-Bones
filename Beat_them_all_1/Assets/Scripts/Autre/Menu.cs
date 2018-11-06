using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class Menu : MonoBehaviour {
    public bool open;
    public GameObject leMenu;
    public GameObject menu;
    void Start () {
        GameObject menuu = GameObject.Find("Menu");
        leMenu = menuu.GetComponent<GameObject>();
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
