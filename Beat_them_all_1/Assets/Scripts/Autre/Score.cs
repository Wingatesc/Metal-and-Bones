using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour {
    public Text text;
    public int point;
	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
        text.text = "Score : 000" + point.ToString();
        InvokeRepeating("score", 0, 0.1f);
	}

    public void score()
    {
        text.text = "Score :" + point.ToString();
    }
}
