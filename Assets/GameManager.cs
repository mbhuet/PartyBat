using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public int numBugs;
	public GameObject bug;
	GUIText timeText;
	GUIText message;
	public GameObject player;

	bool ended = false;

	public float time;
	// Use this for initialization
	void Start () {
		PlaceBugs ();
		timeText = transform.FindChild ("Time").guiText;
		message = transform.FindChild ("Message").guiText;
		message.enabled = false;

	}
	
	// Update is called once per frame
	void Update () {
		if (!ended) {
						time -= Time.deltaTime;
						timeText.text = time.ToString ("F2");

						if (time <= 0) {
								End ();		
						}
				} else {
				
			}

				
		if (Input.GetKeyDown (KeyCode.Return)) {
			Time.timeScale = 1;
						Application.LoadLevel (Application.loadedLevel);
				}

	}

	void PlaceBugs(){
		for (int i = 0; i< numBugs; i++) {
			Vector3 pos = new Vector3(Random.insideUnitCircle.x, Random.insideUnitCircle.y);
			pos *= 20;
			GameObject.Instantiate(bug, pos, Quaternion.identity);
		}
	}

	void End(){
		ended = true;
		timeText.text = "0";
		Time.timeScale = 0;
		message.enabled = true;
		if (player.GetComponent<eating>().score >= 30) 
		{
			message.text = "You Partied Hard!";
		} 
		else 
		{
			message.text = "Party Harder";
		}

	}


}
