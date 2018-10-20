using UnityEngine;
using System.Collections;

public class poing_leger : MonoBehaviour {
	public float time_btw_poing_leger=2;
	 public vie_IA vie_clone;
	public int damages=25;
	public bool can_attack=false;
    public bool attack=false;
	public Animator anim;
	public GameObject adv;
	float timer_attack;
	// Use this for initialization
	void Start () {
		anim=GetComponent<Animator> ();
	}
	

	void Update () {
		timer_attack += Time.deltaTime;
		if(Input.GetKeyDown(KeyCode.E)){
		anim.SetTrigger ("poing_trig");
		}
	if (timer_attack>=time_btw_poing_leger) {

            
            attack = true;
            if (Input.GetKeyDown(KeyCode.E))
            {
                timer_attack = 0;
                attack = false;
            }
        }
        /*else
        {
            attack = false;
        }*/
	}
	/*void OnTriggerEnter2D(Collider2D target){
		vie_clone=target.GetComponent<vie_IA> ();
		if (target.tag == "adversaire") {
			can_attack = true;
		}

	}
	void OnTriggerExit2D(Collider2D target){
		if (target.tag == "adversaire") {
			can_attack = false;
		}
	}*/
	void attack_poing_leger(){
		timer_attack = 0;
        //vie_clone.current_life = vie_clone.current_life - damages;
        attack = true;
	}
}
