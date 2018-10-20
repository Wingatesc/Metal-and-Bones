using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueStart : MonoBehaviour {
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
    public int currentlineq;
    public int currentliner;
    public TextAsset textFile;
    public string[] textlines;
    public int endofconv;
    private bool est_dans_trigger;
    // Use this for initialization
    void Start () {
            img_1.SetActive(true);
            img_2.SetActive(true);
            bande.SetActive(true);
            panel.SetActive(true);
        a_cacher1.SetActive(false);
        a_cacher2.SetActive(false);
        a_cacher3.SetActive(false);
        text();
             state = 1;
        endatline = textlines.Length - 1;
        can_talk = true;
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
   /* void OnTriggerEnter2D()
    {
        text();
        state = 0;
        can_talk = true;
        Debug.Log("can_talk");
    }*/

   /* void OnTriggerExit2D()
    {
        can_talk = false;
        img_1.SetActive(false);
        img_2.SetActive(false);
        bande.SetActive(false);
        panel.SetActive(false);
        est_dans_trigger = false;
        endatline = 0;
        state = 0;
    }*/
    void Update () {
        // if (Input.GetKeyDown(KeyCode.Space) && est_dans_trigger == true&&state==1)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentlineq += 2;
            currentliner+= 2;
           
        }
        if ((currentliner) >= endatline)
        {
            img_1.SetActive(false);
            img_2.SetActive(false);
            bande.SetActive(false);
            panel.SetActive(false);
            a_cacher1.SetActive(true);
            a_cacher2.SetActive(true);
            a_cacher3.SetActive(true);
            can_talk = false;

        }
        le_texte_question.text = textlines[currentlineq];
        le_texte_reponse.text = textlines[currentliner];
        //******************************************************
        if (can_talk)
        {
            est_dans_trigger = true;
            if (Input.GetKeyDown(KeyCode.Space) && state == 0)
            {

                img_1.SetActive(true);
                img_2.SetActive(true);
                bande.SetActive(true);
                panel.SetActive(true);
                a_cacher1.SetActive(false);
                a_cacher2.SetActive(false);
                a_cacher3.SetActive(false);
                state = 1;
            }
          /*  if (endatline == 0)
            {
                endatline = textlines.Length - 1;
            }*/


        }
    }
 
}
