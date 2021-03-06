﻿using UnityEngine;
using System.Collections;

public class eating : MonoBehaviour {
	public GUIText text;
	public float score;
	public GameObject bug;
	public AudioClip eatSound;

	// Use this for initialization
	void Start () {
		score = 0;
	}
	
	// Update is called once per frame
	void Update () {
		text.text = "Bugs Eaten: " + score;


	}

	void Eat(Bug bug){
						GameObject.Destroy (bug.gameObject);
						particleSystem.Emit (10);
						score++;
						AudioSource.PlayClipAtPoint (eatSound, transform.position);

	}

	void OnTriggerEnter2D(Collider2D other){
//		Debug.Log ("Collision enter");
		if (other.tag == "Bug") {
			Bug bug = other.GetComponent<Bug>();
			if (bug.spotted) {

				Eat(bug);
			}
		}
		if (other.tag == "tree") 
		{
			score -= 10;
			if (score < 0) score = 0;
			for (int i = 0; i< 3; i++) {
				Vector3 pos = new Vector3(transform.position.x+Random.insideUnitCircle.x, transform.position.y+Random.insideUnitCircle.y);
				pos *= 1;
				Bug b = (GameObject.Instantiate(bug, pos, Quaternion.identity) as GameObject).GetComponent<Bug>();
				b.StartCoroutine("Show");
				Debug.Log("Spawn");

			}
			StartCoroutine("LightTree", other.gameObject);
			
		}
	}

	IEnumerator LightTree(GameObject obj){
		obj.transform.FindChild ("White").renderer.enabled = false;
		yield return new WaitForSeconds(.1f);
		obj.transform.FindChild ("White").renderer.enabled = true;

		
	}
}
