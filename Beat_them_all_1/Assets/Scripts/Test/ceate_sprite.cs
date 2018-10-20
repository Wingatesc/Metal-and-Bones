using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ceate_sprite : MonoBehaviour {
    public Texture2D tex;
    public Sprite mySprite;
    public Sprite le_sprite;
    public float largeur;
    public Transform pivoot;
    private SpriteRenderer sr;

    void Awake()
    {
        sr = gameObject.AddComponent<SpriteRenderer>() as SpriteRenderer;
        sr.color = new Color(0.9f, 0.9f, 0.9f, 1.0f);
       // mySprite = gameObject.AddComponent<Sprite>() as Sprite;
        transform.position = new Vector2(0, 0);
    }

    void Start()
    {
        mySprite = Sprite.Create(tex, new Rect(5.0f, 5.0f, 50, 50), new Vector2(pivoot.transform.position.x, pivoot.transform.position.y), 100.0f);
        sr.sprite = le_sprite; 
        
    }
    void Update()
    {

        sr.transform.localScale = new Vector2(largeur, 1);


    }
   



}
