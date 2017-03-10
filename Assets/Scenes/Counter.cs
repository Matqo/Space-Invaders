using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Counter : MonoBehaviour {
	public float hp;
	public int score;
	public Text scoreText;
	//float player;
	// Use this for initialization
	public PlayerCtrl playerInstance;
	public Image img1,img2,img3;
	void Start () {
		//scoreText = GetComponent<Text> ();
	}

	public void Score(int scorePts){
		score += scorePts;
		scoreText.text = score.ToString ();
		PlayerPrefs.SetInt ("score",score);
	}
	
	void Update () {
		hp = playerInstance.hp;
		if (hp < 100) {
			Debug.Log ("Dead");
			img1.enabled = false;
		} else if (hp < 200) {
			Debug.Log ("Last Health1");
			img2.enabled = false;
		} else if (hp < 300) {
			img3.enabled = false;
			Debug.Log ("2 Health");
		}
	}
}
