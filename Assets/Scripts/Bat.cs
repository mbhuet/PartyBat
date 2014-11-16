﻿using UnityEngine;
using System.Collections;

public class Bat : MonoBehaviour {

	// Use this for initialization
	public float rotate = 1;
	public float speed = 1;
	Vector2 direction;

	public AudioClip songClip;

	public GameObject soundWave;

	public GameObject light;

	Vector3 moveDirection;

	GameObject wave;
	//ParticleSystem shockwave;

	void Start () {
		direction = Vector2.up;
		//wave = transform.FindChild ("Sound").gameObject;
		//wave.transform.localScale = Vector3.zero;
		//shockwave = transform.FindChild ("Shockwave").particleSystem;
		StartCoroutine ("Song");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.UpArrow)) {
			if (speed < 3)
				speed += Time.deltaTime*2;
			//StartCoroutine("Echo");		
		}
		if (speed >0)
		speed -= Time.deltaTime / 2;
		//movement
		Vector3 forward = transform.up;
		direction = new Vector2 (forward.x, forward.y);
		transform.Rotate (0, 0, -1*Input.GetAxis ("Horizontal") * rotate);

		rigidbody2D.velocity = direction*speed;
		//end movement




	}

	IEnumerator Echo(){
		//shockwave.Emit (1);

		Light l = (GameObject.Instantiate (light, this.transform.position, Quaternion.identity) as GameObject).GetComponent<Light>();

		float maxSize = 10;
		float waveSpeed = 40;
		GameObject wave = GameObject.Instantiate (soundWave, this.transform.position, Quaternion.identity) as GameObject;
		float t = 0;
		while (t<maxSize) {
			t+= Time.deltaTime * waveSpeed;
			wave.transform.localScale = Vector3.one * t;
			yield return null;
		}

		wave.transform.localScale = Vector3.zero;
		GameObject.Destroy (wave);
	}

	void Eat(Bug bug){
		GameObject.Destroy (bug.gameObject);
}

	void OnTriggerEnter2D(Collider2D other){
		Debug.Log ("Collision enter");
		if (other.tag == "Bug") {
			Bug bug = other.GetComponent<Bug>();
			Eat(bug);
		}
	}

	IEnumerator Song(){
		while (true) {
						audio.PlayOneShot (songClip);
						StartCoroutine ("Echo");
						yield return new WaitForSeconds (songClip.length);
				}
	}

}
		  

