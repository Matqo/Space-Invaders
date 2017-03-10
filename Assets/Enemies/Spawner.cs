using UnityEngine;
using System.Collections;


public class Spawner : MonoBehaviour {
	public GameObject enemyPrefab;
	public float width = 15f;
	public float height = 8f;
	bool movingRight = true;
	public float speed = 5f;
	private float max;
	private float min;
	// Use this for initialization
	void Start () {
		float cameraDistance = transform.position.z - Camera.main.transform.position.z;
		Vector3 left = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, cameraDistance));
		Vector3 right = Camera.main.ViewportToWorldPoint (new Vector3 (1, 0, cameraDistance));
		max = right.x;
		min = left.x;
		foreach(Transform child in transform){
			GameObject enemy = Instantiate (enemyPrefab, child.transform.position, Quaternion.identity) as GameObject;
		enemy.transform.parent = child;
		}
	}

	public void onDrawGizmos(){
		Gizmos.DrawWireCube (transform.position, new Vector3 (width, height));
	}
	// Update is called once per frame
	void Update () {
		if (movingRight) {
			transform.position += Vector3.right * speed * Time.deltaTime;
		} else {
			transform.position += Vector3.left * speed * Time.deltaTime;

		}
		float rightEdge = transform.position.x + (0.5f * width);
		float leftEdge = transform.position.x - (0.5f * width);
		if (leftEdge < min || rightEdge > max) {
			movingRight = !movingRight;
		}
		if(noEnemies()){
			Application.LoadLevel("Win");
			Destroy(gameObject);
		}
	}



	bool noEnemies(){
		foreach (Transform enemyPosition in transform) {
			if (enemyPosition.childCount > 0) {
				return false;
			}
			//return true;
		}return true;
	}
}