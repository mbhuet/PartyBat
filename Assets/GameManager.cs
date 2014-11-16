using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public int numBugs;
	public GameObject bug;
	// Use this for initialization
	void Start () {
		PlaceBugs ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void PlaceBugs(){
		for (int i = 0; i< numBugs; i++) {
			Vector3 pos = new Vector3(Random.insideUnitCircle.x, Random.insideUnitCircle.y);
			pos *= 20;
			GameObject.Instantiate(bug, pos, Quaternion.identity);
		}
	}
}
