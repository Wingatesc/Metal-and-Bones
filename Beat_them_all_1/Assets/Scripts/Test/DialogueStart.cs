using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueStart : MonoBehaviour {
    public GameObject img_1;
    public GameObject img_2;
    public GameObject bande;
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

    void Update () {
        if (Input.GetKeyDown(KeyCode.Space)&&can_talk)
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
            can_talk = false;

        }
        le_texte_question.text = textlines[currentlineq];
        le_texte_reponse.text = textlines[currentliner];
      
    }
 
}
