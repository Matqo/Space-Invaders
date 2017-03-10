using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerCtrl : MonoBehaviour {
	public GameObject projectile;
	public float projectileSpeed = 10;
	public float projectileRepeatRate = 0.2f;
	public float hp = 300;

	public float speed = 15.0f;
	public float padding = 1;
	public float health = 200;

	public AudioClip fireSound;
	public AudioClip deathSound;
	bool dead = false;

	private float left = -5;
	private float right = 5;

	float timeLeft = 2;

	public Sprite destroyedPlayer;

	SpriteRenderer sr;

//	void OnTriggerEnter2D(Collider2D collider){
//		Projectile missile = collider.gameObject.GetComponent<Projectile>();
//		if(missile){
//			health -= missile.GetDamage();
//			missile.Hit();
//			if (health <= 0) {
//				Die();
//			}
//		}
//	}

	void Die(){
		//LevelMgr man = GameObject.Find("LevelManager").GetComponent<LevelMgr>();
		//man.LoadLevel("Lose");


	}

	void Start(){
		Camera camera = Camera.main;
		float distance = transform.position.z - camera.transform.position.z;
		left = camera.ViewportToWorldPoint(new Vector3(0,0,distance)).x + padding;
		right = camera.ViewportToWorldPoint(new Vector3(1,1,distance)).x - padding;
	}

	void Shoot(){
		GameObject bullet = Instantiate(projectile, transform.position+new Vector3(0,1,0), Quaternion.identity) as GameObject;
		bullet.GetComponent<Rigidbody2D>().velocity = new Vector3(0, projectileSpeed, 0);
		AudioSource.PlayClipAtPoint(fireSound, transform.position);
	}
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space)){
			InvokeRepeating("Shoot", 0.0001f, projectileRepeatRate);
		}
		if(Input.GetKeyUp(KeyCode.Space)){
			CancelInvoke("Shoot");
		}
		if(Input.GetKey(KeyCode.A)){
			transform.position = new Vector3(
				Mathf.Clamp(transform.position.x - speed * Time.deltaTime, left, right),
				transform.position.y, 
				transform.position.z 
			);
		}else if (Input.GetKey(KeyCode.D)){
			transform.position = new Vector3(
				Mathf.Clamp(transform.position.x + speed * Time.deltaTime, left, right),
				transform.position.y, 
				transform.position.z 
			);
		}

		if (dead) {

			Debug.Log ("Gets heer");
			timeLeft -= Time.deltaTime;
			if (timeLeft < 0) {
				Application.LoadLevel ("Lose");
				Destroy (gameObject);
			}
		}
	}



	void OnTriggerEnter2D(Collider2D collider){
		projectile bullet = collider.gameObject.GetComponent<projectile> ();
		if (bullet) {
			hp -= bullet.GetDmg ();
			bullet.Hit ();
			if (hp <= 0) {
				AudioSource.PlayClipAtPoint(deathSound, transform.position);
				sr = GetComponent<SpriteRenderer> ();
				sr.sprite = destroyedPlayer;
				dead = true;
				//Destroy (gameObject);

			}
		}
	}
}
