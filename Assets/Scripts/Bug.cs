using UnityEngine;
using System.Collections;

public class Bug : MonoBehaviour {
	Vector3 moveDir;
	public float speed = .5f;
	bool spotted = false;

	float maxSpread = 5;
	public float spread = 0;
	public int steadiness = 0;

	public float fadeSpeed;
	
	private int angleHold;
	private float heldAngle;

	public float effectSpeed = 1;

	TrailRenderer trail;

	// Use this for initialization
	void Start () {
		//moveDir = Random.insideUnitSphere;
		//moveDir.z = 0;
		//moveDir.Normalize ();

		this.transform.eulerAngles = new Vector3 (0, 0, Random.Range (0, 360));
		SetColor (Color.black);
		//StartCoroutine ("Show");
	}
	
	// Update is called once per frame
	void Update () {
		Move ();
	}

	void SetColor(Color c){
		this.renderer.material.color = c;
		if (trail != null) {
						trail.material.color = c;
				}
	}

	public void Spot(){
		//if (!spotted) {
		StopCoroutine ("Show");
		if (trail != null) {
			GameObject.Destroy(trail.gameObject);
			trail = null;
		}
		StartCoroutine("Show");		
		//}
	}

	void Move(){

		angleHold--;
		if (angleHold <= 0) {
			

			heldAngle = Random.Range (-spread, spread);
			

			if (heldAngle == 0) heldAngle = .01f; //to prevent divide by 0 errors.

			int maxHold = Random.Range(0,steadiness);
			angleHold = maxHold;

		}
		this.transform.Rotate (0, 0, heldAngle);
		this.transform.Translate (0, speed * Time.deltaTime, 0, Space.Self);
	}



	IEnumerator Show(){
		spotted = true;
		//float effectSpeed = 1;

		//trail.enabled = true;
		//trail.time = 5;
		GameObject trailObj = new GameObject ();
		trailObj.transform.parent = this.transform;
		trailObj.transform.localPosition = Vector3.zero;
		trail = trailObj.AddComponent<TrailRenderer> ();
		trail.material = this.renderer.material;
		trail.time = 5;
		trail.startWidth = transform.localScale.x;
		trail.endWidth = transform.localScale.x;

		SetColor (Color.white);
		float t = 0;
		while (t<1) {
			t+=Time.deltaTime * effectSpeed;
			SetColor(Color.Lerp(Color.white, Color.black, t));		
			yield return null;
		}

		SetColor (Color.black);
		GameObject.Destroy(trail.gameObject);
		trail = null;
//		Debug.Log ("here");
		//trail.enabled = false;
		spotted = false;
	
	}


}
