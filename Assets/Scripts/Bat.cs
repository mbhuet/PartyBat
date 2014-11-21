using UnityEngine;
using System.Collections;

public class Bat : MonoBehaviour {

	// Use this for initialization
	public float rotate = 1;
	public float speed = 1;
	private float minSpeed = 6;
	public Vector2 forwardDir = new Vector2(1f,1f);
	public float scaleFactor = 50f;
	private Vector2 backwardDir;
	Vector2 direction;

	public AudioClip songClip;

	public GameObject soundWave;

	public GameObject light;

	Vector3 moveDirection;

	GameObject wave;
	//ParticleSystem shockwave;

	void Start () {
		direction = Vector2.up;
		backwardDir = new Vector2(-forwardDir.x, forwardDir.y);
		//wave = transform.FindChild ("Sound").gameObject;
		//wave.transform.localScale = Vector3.zero;
		//shockwave = transform.FindChild ("Shockwave").particleSystem;
		StartCoroutine ("Song");
	}
	
	// Update is called once per frame
	void Update () {
		speed = rigidbody2D.velocity.magnitude;
		if (speed < minSpeed){
			//normalize velocity and multiply by speed
			rigidbody2D.velocity = rigidbody2D.velocity.normalized * minSpeed;
			//StartCoroutine("Echo");		
		}
		
		if (speed >0)
		speed -= Time.deltaTime / 2;



		//movement
		//rotation toward direction of movement - magic trigonometry maths!
		if (rigidbody2D.velocity.magnitude > .01f) {
			float angle = Mathf.Atan2(rigidbody2D.velocity.y, rigidbody2D.velocity.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis(angle -90, Vector3.forward);
		}

		//use spacebar to apply force in direction of key player is holding
		if(Input.GetButton("Jump")){
			rigidbody2D.AddForce(Vector2.right * Input.GetAxis("Horizontal") * scaleFactor);
			rigidbody2D.AddForce(Vector2.up * Input.GetAxis("Vertical") * scaleFactor);
		}

		/*
		Vector3 forward = transform.up;
		direction = new Vector2 (forward.x, forward.y);
		transform.Rotate (0, 0, -1*Input.GetAxis ("Horizontal") * rotate);

		rigidbody2D.velocity = direction*speed;*/

		//Rigidbody2D rb = GetComponent<Rigidbody2D>();

		/*if(Input.GetKeyDown(KeyCode.RightArrow)){
			//rb.AddForce(forwardDir * scaleFactor);
			rigidbody2D.AddForce(Input.GetAxis("Horizontal") * scaleFactor);			
			Debug.Log("right");
		}

		if(Input.GetKeyDown(KeyCode.UpArrow)){
			//rb.AddForce(transform.up * scaleFactor);
			rigidbody2D.AddForce(Vector2.up * scaleFactor);		
			Debug.Log("up");
		}

		if(Input.GetKeyDown(KeyCode.LeftArrow)){
			//rb.AddForce(backwardDir * scaleFactor);
			rigidbody2D.AddForce(forwardDir * scaleFactor);	
			Debug.Log("left");
		}*/
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
		  

