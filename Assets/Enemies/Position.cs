using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Position : MonoBehaviour {

	void onDrawGizmos(){
		Gizmos.DrawWireSphere (transform.position, 1);
	}

}