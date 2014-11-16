using UnityEngine;
using System.Collections;

public class Bug : MonoBehaviour {
	Vector3 moveDir;
	float speed = .5f;
	bool spotted = false;

	TrailRenderer trail;

	// Use this for initialization
	void Start () {
		moveDir = Random.insideUnitSphere;
		moveDir.z = 0;
		moveDir.Normalize ();

		//moveDir = Vector3.left;
		/*
		trail = GetComponent<TrailRenderer> ();
		trail.time = 0;
		trail.startWidth = transform.localScale.x;
		trail.endWidth = transform.localScale.x;
		*/

		SetColor (Color.black);
		//StartCoroutine ("Show");
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Translate (moveDir * Time.deltaTime * speed);
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


	IEnumerator Show(){
		spotted = true;
		float effectSpeed = 1;

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
		Debug.Log ("here");
		//trail.enabled = false;
		spotted = false;
	
	}


}
