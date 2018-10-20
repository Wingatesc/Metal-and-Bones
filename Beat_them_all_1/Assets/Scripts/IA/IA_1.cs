using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class IA_1 : MonoBehaviour {
	public bool patroling;
	public bool chasing;
	public bool attacking=false;
	public float time_btw_attacks=2;
	public int dammages=10;
	public GameObject player;
	public vie_player vie_perso;
	public LayerMask tout_sauf_mur;
	public LayerMask tout_sauf_perso;
	public float distance_1;
	public float distance_patrol=3f;
	public float distance_chase=5f;
	public float distance_attack=2f;
	public Rigidbody2D rb;
	public float speed_patrol=8f;
	public float speed_chase=11f;
	public bool droite=true;
	RaycastHit2D mur_1;
	RaycastHit2D mur_2;
	RaycastHit2D hit_perso_droite;
	RaycastHit2D hit_perso_gauche;
	public Animator anim;
	float timer_attack;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		vie_perso=player.GetComponent<vie_player>();
		anim=GetComponent<Animator> ();
		rb = GetComponent<Rigidbody2D> ();
	}
	void Patrol(){
		anim.SetBool ("chase", false);
		anim.SetBool ("attack", false);
		if (!droite) {

			rb.AddForce (new Vector2 (-speed_patrol, 0));
			if (mur_2.transform.CompareTag ("mur")) {
				Flip ();
			}
		} 
		if (droite) {
			rb.AddForce (new Vector2 (speed_patrol, 0));
			if (mur_1.transform.CompareTag ("mur")) {
				Flip ();
			}
		} 
	}
	void Chase(){
	
		if(hit_perso_gauche.collider&&Mathf.Round(hit_perso_gauche.point.x - transform.position.x)<=-distance_attack){
			//Debug.Log(Mathf.Round(hit_perso_gauche.point.x - transform.position.x));
			rb.AddForce (new Vector2 (-speed_chase, 0));
			anim.SetBool ("chase", true);
			anim.SetBool ("attack", false);

		}

		/*else{
		
			attacking=true;
			Debug.Log ("else_g");
		}*/
		if (hit_perso_droite.collider && Mathf.Round (hit_perso_droite.point.x - transform.position.x) >= distance_attack) {
			rb.AddForce (new Vector2 (speed_chase, 0));
			anim.SetBool ("chase", true);
			anim.SetBool ("attack", false);

		}
		/*else{
		
			attacking=true;
		
			Debug.Log ("else_d");

		}*/


	}
	void Attack(){

		timer_attack = 0f;
		Debug.Log ("attaack");
		anim.SetTrigger ("attack");
        //anim.SetBool ("patrol", false);
        //anim.SetBool ("chase", false);
        //vie_perso.slider_perso.value = vie_perso.slider_perso.value - dammages;
        vie_perso.current_life = vie_perso.current_life - dammages;

		 

	}



	void FixedUpdate () {
		//**************Raycast detecte perso de face;
		 hit_perso_droite = Physics2D.Raycast(transform.position, Vector2.right,distance_chase,tout_sauf_perso);
		//**************Raycast detecte perso de dos;
		 hit_perso_gauche = Physics2D.Raycast(transform.position, Vector2.left,distance_chase,tout_sauf_perso);
		//***********************Raycasts pour le patrol*****************************
		 mur_1 = Physics2D.Raycast (transform.position, Vector2.right,distance_patrol, tout_sauf_mur);
		 mur_2 = Physics2D.Raycast (transform.position, Vector2.left,distance_patrol, tout_sauf_mur);

		/*if (hit.collider != null) {
		 distance_1 = Mathf.Round(hit.point.x - transform.position.x);
			//Debug.Log ("hit sthg");
		}*/
		if (hit_perso_droite.collider == null && hit_perso_gauche.collider == null) {
			Patrol (); 
			anim.SetBool ("chase", false);
		} else if (hit_perso_droite.collider != null) {
			if(!droite){
				Flip();

			}
			if(droite){
				Chase();
			}
		
		}
		else if (hit_perso_gauche.collider != null) {
			if(!droite){
				Chase();
			}
			if(droite){
				Flip();

			}
		}
		if (timer_attack >= time_btw_attacks && attacking==true) {
			Attack ();
		} 

	}
	//*******************************trigger attaque
	void OnTriggerEnter2D(Collider2D target){
		if (target.tag == "Player") {
			attacking=true;
			Debug.Log ("collider enter");
		}

	}
	void OnTriggerExit2D(Collider2D target){
		if (target.tag == "Player") {
			attacking = false;

		}
	}
	//****************************************************
	void Update(){
		//Debug.Log (Mathf.Round (hit_perso_droite.point.x - transform.position.x));
		//Debug.Log (timer_attack);
		timer_attack += Time.deltaTime;

	}
	void Flip(){
		droite=!droite;
		//speed=speed*-1;
		Vector3 theScale=transform.localScale;
		theScale.x *=-1;
		transform.localScale=theScale;
	}

}
