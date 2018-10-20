using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Panel_score_fin : MonoBehaviour {
    public float chrono;
  
    public Text Score_enemies;
    public Score score;
    public Text Score_total;
    public Text Score_end_level;
    public Text score_txt;
    public Text turrets_down_txt;
    public Text adv_downn_txt;
    // public bool tic_tac;
    // public int soixante_sec=60;
    public GameObject panel;
    public GameObject perso;
    public GameObject a_cacher_Score;
    public GameObject a_cacher_ViePerso;
    public GameObject a_cacher_img_power;
    public AudioSource son;
    public int nb_adv;
    public int nb_turret;
    public int adv_down;
    public int turret_down;
    public int end_lvl_points;
    // Use this for initialization
    void Start () {
      //  tic_tac = true;
        panel.SetActive(false);
        InvokeRepeating("PasUpdate", 0, 0.1f);
        
	}
	
	
    void PasUpdate()
    {
        turrets_down_txt.text = "Turrets down:" + turret_down + "/" + nb_turret;
        adv_downn_txt.text = "Soldiers down:" + adv_down + "/" + nb_adv;
        Score_enemies.text = "Score from enemies dead :" + score.point.ToString();
        Score_end_level.text = "Bonus for ending the level: " + end_lvl_points;

       // Score_total.text = "Total score: " + (score.point.ToString() + end_lvl_points);
        Score_total.text = "Total score: " + (int.Parse(score.point.ToString()) + end_lvl_points);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")){
            son.Play();
            a_cacher_Score.SetActive(false);
            a_cacher_ViePerso.SetActive(false);
            a_cacher_img_power.SetActive(false);
            panel.SetActive(true);
            // perso.SetActive(false);
            perso.GetComponent<vie_player>().enabled = false;
             perso.GetComponent<character_move>().speed = 0;
            perso.GetComponent<character_move>().jumpForce = 0;
            perso.GetComponent<Poing>().enabled = false;
            
        }
    }
}
