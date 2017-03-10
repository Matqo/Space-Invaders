using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMgr : MonoBehaviour {

	public void LoadLevel(string name){
		Debug.Log ("Gets Here");
		if (name == "Level"||name=="Main Menu") {
			PlayerPrefs.SetInt ("score",0);
		}
		Application.LoadLevel(name);
	}

	public void Quit(string name){
		Debug.Log ("Quits Here");
		Application.Quit ();
	}



}
