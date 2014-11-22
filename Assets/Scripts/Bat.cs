using UnityEngine;
using System.Collections;

public class Bat : MonoBehaviour {

	// Use this for initialization
	public float rotate = 1;
	public float speed = 1;
	public float minSpeed = 1;
	public float maxSpeed = 5;
	public Vector2 forwardDir = new Vector2(1f,1f);
	public float scaleFactor = 2f;
	private Vector2 backwardDir;
	Vector2 direction;

	Vector3 moveDirection;

	//ParticleSystem shockwave;

	void Start () {
		direction = Vector2.up;
		backwardDir = new Vector2(-forwardDir.x, forwardDir.y);
		//wave = transform.FindChild ("Sound").gameObject;
		//wave.transform.localScale = Vector3.zero;
		//shockwave = transform.FindChild ("Shockwave").particleSystem;
	}
	
	// Update is called once per frame
	void Update () {

		Debug.DrawLine (transform.position, transform.position + transform.up * 3, Color.yellow);
		speed = Mathf.Clamp(speed, minSpeed, maxSpeed);

		
		if (speed > minSpeed)
			speed -= Time.deltaTime * 5;

		//movement

		//rotation toward direction of movement - magic trigonometry maths!
		/*
		if (rigidbody2D.velocity.magnitude > .01f) {
			float angle = Mathf.Atan2(rigidbody2D.velocity.y, rigidbody2D.velocity.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis(angle -90, Vector3.forward);
		}*/

		transform.Rotate(0,0, -Input.GetAxis("Horizontal") * rotate);

		transform.Translate(transform.up * speed * Time.deltaTime, Space.World);
		//use spacebar to apply force in direction of key player is holding
		if(Input.GetButtonDown("Jump")){
			speed += scaleFactor;
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



}
		  

