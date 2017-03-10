using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreEnd : MonoBehaviour {

	public Text text;

	void Start () {
		text.text = PlayerPrefs.GetInt("score").ToString();
	}
}
