using UnityEngine;
using System.Collections;

public class eating : MonoBehaviour {
	public GUIText text;
	public float score;
	public GameObject bug;
	// Use this for initialization
	void Start () {
		score = 0;
	}
	
	// Update is called once per frame
	void Update () {
		text.text = "Bugs Eaten: " + score;
		
		if (score < 0) score = 0;
	}

	void Eat(Bug bug){
		GameObject.Destroy (bug.gameObject);
		particleSystem.Emit(4);
		score++;
	}

	void OnTriggerEnter2D(Collider2D other){
		Debug.Log ("Collision enter");
		if (other.tag == "Bug") {
			Bug bug = other.GetComponent<Bug>();
			Eat(bug);
		}
		if (other.tag == "tree") 
		{
			Debug.Log("Tree!");
			score -= 10;
			for (int i = 0; i< 10; i++) {
				Vector3 pos = new Vector3(Random.insideUnitCircle.x, Random.insideUnitCircle.y);
				pos *= 20;
				//GameObject.Instantiate(bug, pos, Quaternion.identity);
			}
			
		}
	}
}
