using UnityEngine;
using System.Collections;

public class SongEcho : MonoBehaviour {

	public AudioClip song;
	public GameObject soundWave;
	public GameObject light;
	// Use this for initialization
	void Start () {
		StartCoroutine ("SongPulse");
	}
	
	// Update is called once per frame
	void Update () {

	
	}




	IEnumerator SongPulse(){
		while (true) {
			StartCoroutine ("Pulse");
			yield return new WaitForSeconds (3.557f);
		}
	}


	IEnumerator Pulse(){
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

}
