using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
	public GameObject bullets;
	public float hp = 200;
	public float projectileSpeed = 10f;
	public int score = 10;
	SpriteRenderer sr;
	private Counter keeper;
	float time;
	public AudioClip deathSound;
	public AudioClip fireSound;

	public Sprite yellowIdle;
	public Sprite yellowActive;

	void Start(){
		keeper = GameObject.Find ("HealthCounter").GetComponent<Counter> ();

	}

	void Fire(){
		GameObject bullet = Instantiate(bullets, transform.position+new Vector3(0,-1,0), Quaternion.identity) as GameObject;
		bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0,-projectileSpeed);
		AudioSource.PlayClipAtPoint(fireSound, transform.position);
	}

	void Update(){
		float prob = 0.5f * Time.deltaTime;
		if(Random.value < prob){
			Fire ();
		}
		time = Time.realtimeSinceStartup;
		int sTime = Mathf.FloorToInt (time);
		Debug.Log ("G" + time);
		sr = GetComponent<SpriteRenderer> ();
		if (sTime % 2 == 0) {
			sr.sprite = yellowIdle;
		} else {
			sr.sprite = yellowActive;
		}

	}

	void OnTriggerEnter2D(Collider2D collider){
		projectile bullet = collider.gameObject.GetComponent<projectile> ();
		if (bullet) {
			hp -= bullet.GetDmg ();
			bullet.Hit ();
			if (hp <= 0) {
				Destroy (gameObject);
				keeper.Score (score);
				AudioSource.PlayClipAtPoint(deathSound, transform.position);

			}
		}
	}

}
