using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour {
    public GameObject img_1;
    public GameObject img_2;
    public GameObject bande;
    public GameObject a_cacher1;
    public GameObject a_cacher2;
    public GameObject a_cacher3;
    public GameObject panel;
    public bool can_talk;
    public Text le_texte_question;
    public Text le_texte_reponse;
    public int endatline;
    public int state;
    public bool state_bool;
    public int currentlineq;
    public int currentliner;
    public TextAsset textFile;
    public string[] textlines;
    public int endofconv;
    private bool est_dans_trigger;

    void Start () {
            img_1.SetActive(false);
            img_2.SetActive(false);
            bande.SetActive(false);
            panel.SetActive(false);
       
        text();
        endatline = textlines.Length - 1;
        state_bool = false; 
    }
    void text()
    {
        if (textFile != null)
        {
            currentlineq = 0;
            currentliner = 1;
            textlines = textFile.text.Split('\n');
            textlines = textFile.text.Split('\n');
        }
    }
    void enter()
    {
        currentlineq = 0;
        currentliner = 1;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            text();
            img_1.SetActive(true);
            img_2.SetActive(true);
            bande.SetActive(true);
            panel.SetActive(true);
            state_bool = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            text();
            state_bool = false;
            can_talk = true;
            Debug.Log("can_talk");
            a_cacher1.SetActive(false);
            a_cacher2.SetActive(false);
            a_cacher3.SetActive(false);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            can_talk = false;
            img_1.SetActive(false);
            img_2.SetActive(false);
            bande.SetActive(false);
            panel.SetActive(false);
            est_dans_trigger = false;
            a_cacher1.SetActive(true);
            a_cacher2.SetActive(true);
            a_cacher3.SetActive(true);
            state_bool = true;
        }
    }
    void Update () {
    
        if (Input.GetKeyDown(KeyCode.Space) && est_dans_trigger == true && state_bool)
        {
            currentlineq += 2;
            currentliner+= 2;
           
        }
        if (can_talk)
        {
            est_dans_trigger = true;


            if (Input.GetKeyDown(KeyCode.Space) && !state_bool)
            {
                text();
                img_1.SetActive(true);
                img_2.SetActive(true);
                bande.SetActive(true);
                panel.SetActive(true);

                state_bool = true;
            }
        }
        if ((currentliner) > endatline)
        {
            img_1.SetActive(false);
            img_2.SetActive(false);
            bande.SetActive(false);
            panel.SetActive(false);
            state_bool = false;


        }
        if (state_bool)
        {
            le_texte_question.text = textlines[currentlineq];
            le_texte_reponse.text = textlines[currentliner];
        }
       
        //******************************************************

    }
}
